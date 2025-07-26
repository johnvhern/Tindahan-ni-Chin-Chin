using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class ProductsUC : UserControl
    {
        private DataTable productTable;
        private PaginationHelper paginationHelper = new PaginationHelper();
        public ProductsUC()
        {
            InitializeComponent();
        }

        private async void ProductsUC_Load(object sender, System.EventArgs e)
        {
            cbProductEntries.SelectedIndex = 0; // Set the default selected index of the combo box to 0
            await LoadProductList();
        }

        private async Task LoadProductList()
        {
            productTable = await Database.DBProduct.getProductList(); // Returns a DataTable
            dgvProduct.DataSource = productTable;

            string selected = cbProductEntries.SelectedItem?.ToString() ?? "10"; // Get the selected value from the combo box or default to "10"

            if (int.TryParse(selected, out int rowLimit))
            {
                paginationHelper.SetPageSize(rowLimit, productTable.Rows.Count); // Set the page size based on the selected value
            }

            var page = paginationHelper.GetPage(productTable, 1); // Get the initial page of data
            dgvProduct.DataSource = page; // Set the DataGridView's data source to the paginated data

            var (start, end) = paginationHelper.GetDisplayRange(productTable.Rows.Count); // Get the display range for the current page
            lblProductCurrentPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
            lblProductPageInfo.Text = $"Showing {start} to {end} of {productTable.Rows.Count} entries";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var addProductControl = new Controls.AddProduct();

            addProductControl.OnProductAdded += async () => // Subscribe to the OnCategoryAdded event
            {
                await LoadProductList(); // Call the ReloadVendors method to refresh the vendor list
            };

            Forms.AddForm addProductForm = new Forms.AddForm();
            addProductForm.OpenControl(addProductControl); // Open the AddCategory user control in the AddProduct form
            addProductForm.Text = "Add Product"; // Set the title of the AddForm
            addProductForm.SetBounds(0, 0, 409, 500); // Set the size of the AddForm
            addProductForm.ShowDialog(); // Show the AddCategory form as a dialog
        }

        private void btnRefreshProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnProductPrev_Click(object sender, EventArgs e)
        {

        }

        private void btnProductNext_Click(object sender, EventArgs e)
        {

        }

        private void cbProductEntries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
