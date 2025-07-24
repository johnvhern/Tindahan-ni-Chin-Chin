using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tindahan_ni_Chin_Chin.Database
{
    internal class DBVendors
    {
        public static DataTable GetVendorList()
        {
            using (var conn = DatabaseCreation.GetConnection())
            {
                string query = "SELECT vendor_id AS '#', vendor_name AS 'Name', vendor_contact_number AS 'Contact Number' FROM vendor";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
