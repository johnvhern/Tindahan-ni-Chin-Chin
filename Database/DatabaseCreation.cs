using System;
using System.Data.SQLite;
using System.IO;

namespace Tindahan_ni_Chin_Chin.Database
{
    internal class DatabaseCreation
    {
        public static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pos.db");
        public static string connectionString = $"Data Source={dbPath}; Version=3; PRAGMA journal_mode = WAL; PRAGMA foreign_keys = ON; New = True; Compress = True; Connection Timeout=0";
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
                    product_price INTEGER NOT NULL,
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

        public static void addProduct()
        {
            string productName = "Hotdog";
            int productCategory = 1; // Assuming category_id 1 exists
            int productVendor = 1; // Assuming vendor_id 1 exists
            string productPrice = "100.00";
            int productStock = 10;

            using (var conn = GetConnection())
            {
                string insertQuery = "INSERT INTO product (product_name, product_category, product_vendor, product_price, product_stock) " +
                                     "VALUES (@productName, @productCategory, @productVendor, @productPrice, @productStock)";

                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@productCategory", productCategory);
                    cmd.Parameters.AddWithValue("@productVendor", productVendor);
                    cmd.Parameters.AddWithValue("@productPrice", productPrice);
                    cmd.Parameters.AddWithValue("@productStock", productStock);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Product added successfully");
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine("Error inserting product, error: " + ex.Message);
                    }
                }
            }
        }

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
