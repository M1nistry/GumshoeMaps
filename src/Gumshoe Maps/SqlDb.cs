using System;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace Gumshoe_Maps
{
    public class SqlDb
    {
        private readonly string _dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps\MapsDB.s3db";
        private SQLiteConnection Connection { get; set; }
        private string Constring { get; set; }
        public SqlDb()
        {
            
            Constring = String.Format(@"Data Source={0};Version=3;", _dbPath);
            Connection = new SQLiteConnection(Constring) {ParseViaFramework = true};
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
                                        `name` TEXT, `quality` INTEGER, `quantity` INTEGER, `started_at` DATETIME, `finished_at` DATETIME);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `affixes` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `affix` TEXT);";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `map_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `rarity` TEXT, 
                                        `level` INTEGER, `name` TEXT, `zana` TINYINT, `carto` TINYINT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `currency_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `name` TEXT, `count` INTEGER)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `unique_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `name` TEXT)";
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
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
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

                    return (int)connection.LastInsertRowId;
                }
            }
        }

        internal DataTable MapDataTable()
        {
            var dtMaps = new DataTable("maps");
            dtMaps.Columns.Add("id");
            dtMaps.Columns.Add("level");
            dtMaps.Columns.Add("name");
            dtMaps.Columns.Add("quality");
            dtMaps.Columns.Add("quantity");
            dtMaps.Columns.Add("-");
            dtMaps.Columns.Add(" ");
            dtMaps.Columns.Add("+");
            
            try
            {
                using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
                {
                    const string selectQuery = @"SELECT * FROM `maps`";
                    using (var cmd = new SQLiteCommand(selectQuery, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var mapId = int.Parse(reader["id"].ToString());
                                dtMaps.Rows.Add(mapId,
                                    int.Parse(reader["level"].ToString()),
                                    reader["name"].ToString(), int.Parse(reader["quality"].ToString()),
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
                using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
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
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
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
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
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

        internal void AddCurrency(int mapId, string name)
        {
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
            {
                const string insertCurrency = @"INSERT OR REPLACE INTO `currency_drops` (`map_id`, `name`, `count`) VALUES (@id, @name, COALESCE((SELECT count FROM currency_drops WHERE name=@name AND map_id=@id), 0) + 1)";
                using (var cmd = new SQLiteCommand(insertCurrency, connection))
                {
                    cmd.Parameters.AddWithValue("id", mapId);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void AddUnique(int mapId, string name)
        {
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
            {
                const string insertCurrency = @"INSERT INTO `unique_drops` (`name`) VALUES (@name) WHERE map_id=@id";
                using (var cmd = new SQLiteCommand(insertCurrency, connection))
                {
                    cmd.Parameters.AddWithValue("id", mapId);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
