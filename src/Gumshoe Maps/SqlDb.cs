using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
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
                                        `level` INTEGER, `name` TEXT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `zana_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `rarity` TEXT, 
                                        `level` INTEGER, `name` TEXT)";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText =
                            @"CREATE TABLE IF NOT EXISTS `carto_drops` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `map_id` INTEGER, `rarity` TEXT, 
                                        `level` INTEGER, `name` TEXT)";
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
                                dtMaps.Rows.Add(int.Parse(reader["id"].ToString()),
                                    int.Parse(reader["level"].ToString()),
                                    reader["name"].ToString(), int.Parse(reader["quality"].ToString()),
                                    int.Parse(reader["quantity"].ToString()));
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
            var dtDrops = new DataTable("maps");
            dtDrops.Columns.Add("id");
            dtDrops.Columns.Add("map_id");
            dtDrops.Columns.Add("rarity");
            dtDrops.Columns.Add("level");
            dtDrops.Columns.Add("name");

            try
            {
                using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
                {
                    const string selectQuery = @"SELECT * FROM `map_drops` WHERE `map_id`=@mapid";
                    using (var cmd = new SQLiteCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("mapid", mapId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dtDrops.Rows.Add(int.Parse(reader["id"].ToString()),
                                    int.Parse(reader["map_id"].ToString()),
                                    reader["rarity"].ToString(), int.Parse(reader["level"].ToString()),
                                    int.Parse(reader["name"].ToString()));
                            }
                        }
                    }
                    return dtDrops;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal void AddDrop(Map newMap, int mapId)
        {
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
            {
                const string addQuery = @"INSERT INTO `map_drops` (`map_id`, `rarity`, `level`, `name`) VALUES 
                                                                  (@mapid, @rarity, @level, @name)";
                using (var cmd = new SQLiteCommand(addQuery, connection))
                {
                    cmd.Parameters.AddWithValue("mapid", mapId);
                    cmd.Parameters.AddWithValue("rarity", newMap.Rarity);
                    cmd.Parameters.AddWithValue("level", newMap.Level);
                    cmd.Parameters.AddWithValue("name", newMap.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void AddZana(Map newMap, int mapId)
        {
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
            {
                const string addQuery = @"INSERT INTO `zana_drops` (`map_id`, `rarity`, `level`, `name`) VALUES 
                                                                   (@mapid, @rarity, @level, @name)";
                using (var cmd = new SQLiteCommand(addQuery, connection))
                {
                    cmd.Parameters.AddWithValue("mapid", mapId);
                    cmd.Parameters.AddWithValue("rarity", newMap.Rarity);
                    cmd.Parameters.AddWithValue("level", newMap.Level);
                    cmd.Parameters.AddWithValue("name", newMap.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void AddCarto(Map newMap, int mapId)
        {
            using (var connection = new SQLiteConnection(Constring).OpenAndReturn())
            {
                const string addQuery = @"INSERT INTO `carto_drops` (`map_id`, `rarity`, `level`, `name`) VALUES 
                                                                   (@mapid, @rarity, @level, @name)";
                using (var cmd = new SQLiteCommand(addQuery, connection))
                {
                    cmd.Parameters.AddWithValue("mapid", mapId);
                    cmd.Parameters.AddWithValue("rarity", newMap.Rarity);
                    cmd.Parameters.AddWithValue("level", newMap.Level);
                    cmd.Parameters.AddWithValue("name", newMap.Name);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
