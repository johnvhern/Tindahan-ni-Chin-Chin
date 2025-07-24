using Syncfusion.Windows.Forms.Tools;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tindahan_ni_Chin_Chin.Database
{
    internal class DBCategory
    {
        public static DataTable getCategoryList()
        {
            using (var conn = DatabaseCreation.GetConnection())
            {
                string queryGetCategory = "SELECT category_id AS '#', category_name AS 'Name' FROM category";

                using (var cmd = new SQLiteCommand(queryGetCategory, conn))
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
