using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tindahan_ni_Chin_Chin.Database
{
    internal class DatabaseCreation
    {
        public static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pos.db");
        public static string connectionString = $"Data Source={dbPath}; Version=3; PRAGMA journal_mode = WAL; New = True; Compress = True; Connection Timeout=0";
        public static void InitializeDatabase()
        {
            // Create the database file if it does not exist
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                Console.WriteLine("Database file created.");
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string[] commands =
                {
                @"CREATE TABLE IF NOT EXISTS user (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL UNIQUE,  
                    password TEXT NOT NULL);",

                @"CREATE TABLE IF NOT EXISTS category (
                    category_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    category_name TEXT NOT NULL);",

                @"CREATE TABLE IF NOT EXISTS vendor (
                    vendor_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    vendor_name TEXT NOT NULL,
                    vendor_contact_number TEXT);",

                @"CREATE TABLE IF NOT EXISTS product (
                    product_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    product_name TEXT NOT NULL,
                    product_category INTEGER NOT NULL,
                    product_vendor INTEGER NOT NULL,
                    product_price TEXT NOT NULL,
                    product_stock INTEGER NOT NULL DEFAULT 0,
                    FOREIGN KEY(product_category) REFERENCES category(category_id),
                    FOREIGN KEY(product_vendor) REFERENCES vendor(vendor_id));"
            };

                foreach (var sql in commands)
                {
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }

            Console.WriteLine("Database initialized.");
        }

        // Use for password hashing when creating a new user or verifying login credentials
        public static string HashPassword(string input)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        // create a new user with a hashed password
        //public static void createUser()
        //{
        //    string username = "admin";
        //    string password = "admin";
        //    string hashedPassword = HashPassword(password);

        //    using (var conn = GetConnection())
        //    {

        //        string insertQuery = "INSERT INTO user (id, username, password) VALUES (1, @username, @password)";

        //        using (var cmd = new SQLiteCommand(insertQuery, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@username", username);
        //            cmd.Parameters.AddWithValue("@password", hashedPassword);

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //                Console.WriteLine("User created successfully");
        //            }
        //            catch (SQLiteException ex)
        //            {
        //                Console.WriteLine("Error inserting user, error: " + ex.Message);
        //            }
        //        }
        //    }
        //}

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection($"Data Source={dbPath}; Version=3;");
            conn.Open();

            // Set PRAGMA busy timeout to wait 5 seconds before failing
            using (var cmd = new SQLiteCommand("PRAGMA busy_timeout = 5000;", conn))
                cmd.ExecuteNonQuery();

            // Set WAL journal mode for concurrency
            using (var cmd = new SQLiteCommand("PRAGMA journal_mode=WAL;", conn))
                cmd.ExecuteNonQuery();

            return conn;
        }
    }
}
