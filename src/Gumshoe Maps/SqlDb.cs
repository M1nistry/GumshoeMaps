using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public class SqlDb
    {
        private readonly string _dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps\MapsDB.s3db";
        private SQLiteConnection Connection { get; set; }
        public SqlDb()
        {
            
            var constring = String.Format(@"Data Source={0};Version=3;", _dbPath);
            Connection = new SQLiteConnection(constring) {ParseViaFramework = true};
            if (SetupDb())
            {
                
            }
        }

        private bool SetupDb()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps");
                if (!File.Exists(_dbPath)) SQLiteConnection.CreateFile(_dbPath);
            }
            try
            {
                using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
                {
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `maps` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `rarity` TEXT, `level` INTEGER, 
                                        `name` TEXT, `quality` INTEGER, `quantity` INTEGER, `started_at` DATETIME, `finished_at` DATETIME, `notes` TEXT);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `affixes` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `affix` TEXT);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `map_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `rarity` TEXT, 
                                        `level` INTEGER, `name` TEXT, `zana` TINYINT, `carto` TINYINT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `currency_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `name` TEXT, `count` INTEGER)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `unique_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `name` TEXT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE UNIQUE INDEX  IF NOT EXISTS currency_idx ON currency_drops(map_id, name);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `experience` (`level` INTEGER, `total_exp` INTEGER, `exp_goal` INTEGER);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS `map_experience` (`map_id` INTEGER, `exp_before` INTEGER, `level_before` INTEGER, `percent_before` INTEGER, 
                                           `exp_after` INTEGER, `level_after`, `percent_after`);";
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(@"Error: " + ex.Message);
                return false;
            }
        }

        internal int AddMap(Map newMap)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string addQuery = @"INSERT INTO `maps` (`rarity`, `level`, `name`, `quality`, `quantity`, `started_at`) VALUES 
                                                             (@rarity, @level, @name, @quality, @quantity, @startedat)";
                using (var cmd = new SQLiteCommand(addQuery, connection))
                {
                    cmd.Parameters.AddWithValue("rarity", newMap.Rarity);
                    cmd.Parameters.AddWithValue("level", newMap.Level);
                    cmd.Parameters.AddWithValue("name", newMap.Name);
                    cmd.Parameters.AddWithValue("quality", newMap.Quality);
                    cmd.Parameters.AddWithValue("quantity", newMap.Quantity + Properties.Settings.Default.zanaQuantity);
                    cmd.Parameters.AddWithValue("startedat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    cmd.ExecuteNonQuery();
                }

                var mapId = (int)connection.LastInsertRowId;
                const string addAffixes = @"INSERT INTO `affixes` (`map_id`, `affix`) VALUES (@id, @affix)";
                using (var cmd = new SQLiteCommand(addAffixes, connection))
                {
                    cmd.Parameters.AddWithValue("id", connection.LastInsertRowId);
                    foreach (var affix in newMap.Affixes)
                    {
                        cmd.Parameters.AddWithValue("affix", affix);
                        cmd.ExecuteNonQuery();
                    }
                }
                const string addExperience =
                    @"INSERT INTO `map_experience` (`map_id`, `exp_before`, `level_before`, `percent_before`) VALUES (@id, @expb, @levelb, @percentb);";
                using (var cmd = new SQLiteCommand(addExperience, connection))
                {
                    cmd.Parameters.AddWithValue("@id", mapId);
                    cmd.Parameters.AddWithValue("@expb", newMap.ExpBefore.CurrentExperience);
                    cmd.Parameters.AddWithValue("@levelb", newMap.ExpBefore.Level);
                    cmd.Parameters.AddWithValue("@percentb", newMap.ExpBefore.Percentage);
                    cmd.ExecuteNonQuery();
                }

                return mapId;
            }
        }

        internal Map GetMap(int mapId)
        {
            var affixes = MapAffixes(mapId);
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string queryMap = @"SELECT * from `maps` m1 JOIN `map_experience` e1 ON m1.id=e1.map_id WHERE m1.id=@id";
                using (var cmd = new SQLiteCommand(queryMap, connection))
                {
                    cmd.Parameters.AddWithValue("@id", mapId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id, level, quality, quantity, levelBefore, percentBefore, levelAfter, percentAfter;
                            Int64 experienceBefore, experienceAfter;
                            var expBefore = new Experience
                            {
                                CurrentExperience = Int64.TryParse(reader["exp_before"].ToString(), out experienceBefore) ? experienceBefore : 0,
                                Level = int.TryParse(reader["level_before"].ToString(), out levelBefore) ? levelBefore : 0,
                                Percentage = int.TryParse(reader["percent_before"].ToString(), out percentBefore) ? percentBefore : 0,
                            };
                            var expAfter = new Experience
                            {
                                CurrentExperience = Int64.TryParse(reader["exp_after"].ToString(), out experienceAfter) ? experienceAfter : 0,
                                Level = int.TryParse(reader["level_after"].ToString(), out levelAfter) ? levelAfter : 0,
                                Percentage = int.TryParse(reader["percent_after"].ToString(), out percentAfter) ? percentAfter : 0,
                            };
                            
                            DateTime startAt, finishAt;
                            return new Map
                            {
                                Id = int.TryParse(reader["id"].ToString(), out id) ? id : -1,
                                Rarity = reader["rarity"].ToString(),
                                Level = int.TryParse(reader["level"].ToString(), out level) ? level : -1,
                                Name = reader["name"].ToString(),
                                Quality = int.TryParse(reader["quality"].ToString(), out quality) ? quality : -1,
                                Quantity = int.TryParse(reader["quantity"].ToString(), out quantity) ? quantity : -1,
                                StartAt = DateTime.TryParse(reader["started_at"].ToString(), out startAt) ? startAt : new DateTime(0001, 01, 01),
                                FinishAt = DateTime.TryParse(reader["finished_at"].ToString(), out finishAt) ? finishAt : new DateTime(0001, 01, 01),
                                Notes = reader["notes"].ToString(),
                                ExpAfter = expAfter,
                                ExpBefore = expBefore,
                                Affixes = affixes
                            };
                        }
                    }
                }
            }
            return null;
        }

        internal DataTable MapDataTable()
        {
            var dtMaps = new DataTable("maps");
            dtMaps.Columns.Add("id", typeof(int));
            dtMaps.Columns.Add("level");
            dtMaps.Columns.Add("name");
            dtMaps.Columns.Add("gained");
            dtMaps.Columns.Add("rarity");
            dtMaps.Columns.Add("quality");
            dtMaps.Columns.Add("quantity");
            dtMaps.Columns.Add("-");
            dtMaps.Columns.Add(" ");
            dtMaps.Columns.Add("+");
            
            try
            {
                using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
                {
                    const string selectQuery = @"SELECT * FROM `maps`";
                    using (var cmd = new SQLiteCommand(selectQuery, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var mapId = int.Parse(reader["id"].ToString());
                                dtMaps.Rows.Add(mapId, int.Parse(reader["level"].ToString()),
                                    reader["name"].ToString(), String.Format("{0:N0}",ExpGained(mapId)),
                                    reader["rarity"].ToString(), int.Parse(reader["quality"].ToString()),
                                    int.Parse(reader["quantity"].ToString()), MapDrops(mapId, "<"),
                                    MapDrops(mapId, "="), MapDrops(mapId, ">"));
                            }
                        }
                    }
                    return dtMaps;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal DataTable DropDataTable(int mapId)
        {
            var dtDrops = new DataTable("drops");
            dtDrops.Columns.Add("title");
            dtDrops.Columns.Add("drops");
            var drops = "";

            try
            {
                using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
                {
                    const string mapQuery = @"SELECT `level` FROM `map_drops` WHERE `map_id`=@mapid";
                    const string uniqueQuery = @"SELECT `name` FROM `unique_drops` WHERE `map_id`=@mapid";
                    const string currencyQuery = @"SELECT name, count FROM `currency_drops` WHERE `map_id`=@mapid";
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = mapQuery;
                        cmd.Parameters.AddWithValue("mapid", mapId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                drops += reader["level"] + ", ";
                            }
                            if (drops.Length > 2) drops = drops.Remove(drops.Length - 2, 2);
                            dtDrops.Rows.Add("Maps", drops);
                        }

                        cmd.CommandText = uniqueQuery;
                        drops = "";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                drops += reader["name"] + ", ";
                            }
                            if (drops.Length > 2)drops = drops.Remove(drops.Length - 2, 2);
                            dtDrops.Rows.Add("Uniques", drops);
                        }

                        cmd.CommandText = currencyQuery;
                        drops = "";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                drops += reader["name"] + " x" + reader["count"] + ", ";
                            }
                            if (drops.Length > 2) drops = drops.Remove(drops.Length - 2, 2);
                            dtDrops.Rows.Add("Currency", drops);
                        }
                    }
                    return dtDrops;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        internal void AddDrop(Map newMap, int mapId, int zana = 0, int carto = 0)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string addQuery = @"INSERT INTO `map_drops` (`map_id`, `rarity`, `level`, `name`, `zana`, `carto`) VALUES 
                                                                  (@mapid, @rarity, @level, @name, @zana, @carto)";
                using (var cmd = new SQLiteCommand(addQuery, connection))
                {
                    cmd.Parameters.AddWithValue("mapid", mapId);
                    cmd.Parameters.AddWithValue("rarity", newMap.Rarity);
                    cmd.Parameters.AddWithValue("level", newMap.Level);
                    cmd.Parameters.AddWithValue("name", newMap.Name);
                    cmd.Parameters.AddWithValue("zana", zana);
                    cmd.Parameters.AddWithValue("carto", carto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal int MapDrops(int mapId, string symbol)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                var queryMaps = @"SELECT count(d.level) FROM map_drops d JOIN maps m ON d.map_id=m.id WHERE d.map_id=@mapId AND d.level " + symbol + @" m.level ";
                using (var cmd = new SQLiteCommand(queryMaps, connection))
                {
                    cmd.Parameters.AddWithValue("mapId", mapId);
                    var value = cmd.ExecuteScalar().ToString();
                    return int.Parse(value);
                }
            }
        }

        internal long ExpGained(int id)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string queryGained = @"SELECT exp_after, exp_before FROM map_experience WHERE map_id=@id";
                using (var cmd = new SQLiteCommand(queryGained, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long expBefore, expAfter;
                            if (!Int64.TryParse(reader["exp_before"].ToString(), out expBefore) || !Int64.TryParse(reader["exp_after"].ToString(), out expAfter)) continue;
                            var value = (expAfter - expBefore);
                            return value;
                        }
                    }
                }
            }
            return 0;
        }

        internal void AddCurrency(int mapId, KeyValuePair<int, string> currency)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string insertCurrency = @"INSERT OR REPLACE INTO `currency_drops` (`map_id`, `name`, `count`) VALUES (@id, @name, COALESCE((SELECT count FROM currency_drops WHERE name=@name AND map_id=@id), 0) + @count)";
                using (var cmd = new SQLiteCommand(insertCurrency, connection))
                {
                    cmd.Parameters.AddWithValue("id", mapId);
                    cmd.Parameters.AddWithValue("name", currency.Value);
                    cmd.Parameters.AddWithValue("count", currency.Key);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void AddUnique(int mapId, string name)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string insertCurrency = @"INSERT INTO `unique_drops` (`map_id`, `name`) VALUES (@id, @name)";
                using (var cmd = new SQLiteCommand(insertCurrency, connection))
                {
                    cmd.Parameters.AddWithValue("id", mapId);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal List<KeyValuePair<int, string>> MapList(int id)
        {
            var mapList = new List<KeyValuePair<int, string>>();
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string mapListQuery = @"SELECT level, name FROM `map_drops` WHERE map_id=@id;";
                using (var cmd = new SQLiteCommand(mapListQuery, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mapList.Add(new KeyValuePair<int, string>(int.Parse(reader["level"].ToString()), reader["name"].ToString()));
                        }
                    }
                }
            }
            return mapList;
        }

        internal List<string> MapAffixes(int id)
        {
            var affixList = new List<string>();
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string selectAffix = @"SELECT `affix` FROM `affixes` WHERE map_id=@id";
                using (var cmd = new SQLiteCommand(selectAffix, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            affixList.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return affixList;
        }

        internal void FinishMap(int id, Experience exp)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string updateFinish = @"UPDATE maps SET finished_at=@finish WHERE id=@id";
                using (var cmd = new SQLiteCommand(updateFinish, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("finish", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }
                const string updateExperience = @"UPDATE map_experience SET exp_after=@expa, level_after=@levela, percent_after=@percenta WHERE map_id=@id;";
                using (var cmd = new SQLiteCommand(updateExperience, connection))
                {
                    cmd.Parameters.AddWithValue("@expa", exp.CurrentExperience);
                    cmd.Parameters.AddWithValue("@levela", exp.Level);
                    cmd.Parameters.AddWithValue("@percenta", exp.Percentage);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal bool DeleteMap(int id)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.CommandText = @"DELETE FROM `maps` WHERE id=@id";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"DELETE FROM `map_drops` WHERE map_id=@id";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"DELETE FROM `currency_drops` WHERE map_id=@id";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"DELETE FROM `unique_drops` WHERE map_id=@id";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"DELETE FROM `affixes` WHERE map_id=@id";
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }

        internal void UpdateNotes(int id, string notes)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string updateNotes = @"UPDATE maps SET notes=@notes WHERE id=@id";
                using (var cmd = new SQLiteCommand(updateNotes, connection))
                {
                    cmd.Parameters.AddWithValue("@notes", notes);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void AddCurrency(int id, string currency, int count)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string insertCurrency = @"INSERT INTO `currency_drops` (`map_id`, `name`, `count`) VALUES (@id, @currency, @count);";
                using (var cmd = new SQLiteCommand(insertCurrency, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@currency", currency);
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void AddExperience(List<Experience> expList)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string insertExp = @"INSERT INTO `experience` (level, total_exp, exp_goal) VALUES (@level, @totalExp, @expGoal);";
                var transaction = connection.BeginTransaction();
                using (var cmd = new SQLiteCommand(insertExp, connection))
                {
                    cmd.Parameters.AddWithValue("@level", "");
                    cmd.Parameters.AddWithValue("@totalExp", "");
                    cmd.Parameters.AddWithValue("@expGoal", "");
                    foreach (var item in expList)
                    {
                        InsertExperience(item, cmd);
                    }
                }
                transaction.Commit();
            }
        }

        private static void InsertExperience(Experience exp, SQLiteCommand cmd)
        {
            cmd.Parameters["@level"].Value = exp.Level;
            cmd.Parameters["@totalExp"].Value = exp.CurrentExperience;
            cmd.Parameters["@expGoal"].Value = exp.NextLevelExperience;
            cmd.ExecuteNonQuery();
        }

        internal int ExperienceCount()
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string countExp = @"SELECT count(*) FROM `experience`;";
                using (var cmd = new SQLiteCommand(countExp, connection))
                {
                    int count;
                    var value = cmd.ExecuteScalar();
                    if (value != null && int.TryParse(value.ToString(), out count)) return count;
                }
            }
            return 0;
        }

        internal int ExperienceGoal(int level)
        {
            using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
            {
                const string countExp = @"SELECT exp_goal FROM `experience` WHERE level=@level;";
                using (var cmd = new SQLiteCommand(countExp, connection))
                {
                    cmd.Parameters.AddWithValue("@level", level);
                    int exp;
                    var value = cmd.ExecuteScalar();
                    if (value != null && int.TryParse(value.ToString(), out exp)) return exp;
                }
            }
            return 0;
        }
    }
}
