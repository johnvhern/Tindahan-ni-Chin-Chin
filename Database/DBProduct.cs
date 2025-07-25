using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tindahan_ni_Chin_Chin.Database
{
    internal class DBProduct
    {
        public static Task<DataTable> getProductList()
        {
            return Task.Run(() =>
            {
                using (var conn = DatabaseCreation.GetConnection())
                {
                    string query = "SELECT * FROM product";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt); // Still synchronous
                        return dt;
                    }
                }
            });
        }
    }
}
