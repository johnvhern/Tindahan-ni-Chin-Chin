using System.Data;
using System.Data.SQLite;
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
                    string query = "SELECT product_id AS '#', product_name AS 'Name', category.category_name AS 'Category', vendor.vendor_name AS 'Vendor', product_price AS 'Price', product_stock AS 'Stock'" +
                    " FROM product INNER JOIN category ON product.product_category = category.category_id INNER JOIN vendor ON product.product_vendor = vendor.vendor_id";
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
