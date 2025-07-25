using Syncfusion.Windows.Forms;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class ProductCategorySelection : UserControl
    {
        public ProductCategorySelection()
        {
            InitializeComponent();
        }

        private async void ProductCategorySelection_Load(object sender, System.EventArgs e)
        {
            await LoadProductCategory();
        }

        private async Task LoadProductCategory()
        {
            DataTable dataTable = await Database.DBCategory.getCategoryList();
            dgvProductCategory.DataSource = dataTable;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Add";
            buttonColumn.Name = "Add";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvProductCategory.Columns.Add(buttonColumn);
        }

        private void dgvProductCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable selectedCategory = new DataTable();
            selectedCategory.Columns.Add("#", typeof(string));
            selectedCategory.Columns.Add("Name", typeof(string));

            if (e.ColumnIndex == dgvProductCategory.Columns["Add"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvProductCategory.Rows[e.RowIndex];


                string categoryId = selectedRow.Cells["#"].Value.ToString();
                string categoryName = selectedRow.Cells["Name"].Value.ToString();

                if (dgvSelectedCategory.Rows.Count <= 0)
                {
                    selectedCategory.Rows.Add(categoryId, categoryName);

                    dgvSelectedCategory.DataSource = null;
                    dgvSelectedCategory.DataSource = selectedCategory;
                }
                else
                {
                    MessageBoxAdv.Show(this, "can only select 1 category per product");
                }

            }

        }
    }
}
