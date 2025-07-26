using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class Inventory : UserControl
    {
        private DataTable vendorTable, categoryTable, productTable; // DataTable to hold data
        private PaginationHelper paginationHelper = new PaginationHelper(); // Instance of PaginationHelper to manage pagination
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
        }

        // REUSABLE METHODS
        private async void tabControlAdv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControlAdv1.SelectedTab.Name)
            {
                case "tabProduct":
                    cbProductEntries.SelectedIndex = 0;
                    await LoadProductList();
                    break;
                case "tabVendor":
                    cbVendorEntries.SelectedIndex = 0; // Reset to the first entry limit when switching to Vendor tab
                    await LoadVendorList(); // Load the vendor list when the Vendor tab is selected
                    break;
                case "tabCategory":
                    cbCategoryEntries.SelectedIndex = 0; // Reset to the first entry limit when switching to Category tab
                    await LoadCategory(); // Load the category list when the Category tab is selected
                    break;
            }
        }



        // ----------------------------------------------------------------------------------------------------------------- //

        // PRODUCT MANAGEMENT METHODS

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

        // CATEGORY MANAGEMENT METHODS

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var addCategoryControl = new Controls.AddCategory();

            addCategoryControl.OnCategoryAdded += async () => // Subscribe to the OnCategoryAdded event
            {
                await LoadCategory(); // Call the ReloadVendors method to refresh the vendor list
            };

            Forms.AddForm addCategoryForm = new Forms.AddForm();
            addCategoryForm.OpenControl(addCategoryControl); // Open the AddCategory user control in the AddProduct form
            addCategoryForm.Text = "Add Category"; // Set the title of the AddForm
            addCategoryForm.SetBounds(0, 0, 409, 200); // Set the size of the AddForm
            addCategoryForm.ShowDialog(); // Show the AddCategory form as a dialog
        }

        private async void btnRefreshCategory_Click(object sender, EventArgs e)
        {
            categoryTable = await Database.DBCategory.getCategoryList(); // Returns a DataTable
            dgvCategory.DataSource = categoryTable; // Refresh the category list in the DataGridView
            paginationHelper.ApplyRowLimit(cbCategoryEntries, categoryTable, dgvCategory, lblCategoryPageInfo); // Reset the row limit based on the selected value in the combo box
        }

        private async Task LoadCategory()
        {
            categoryTable = await Database.DBCategory.getCategoryList(); // Returns a DataTable
            dgvCategory.DataSource = categoryTable;

            string selected = cbCategoryEntries.SelectedItem?.ToString() ?? "10"; // Get the selected value from the combo box or default to "10"

            if (int.TryParse(selected, out int rowLimit))
            {
                paginationHelper.SetPageSize(rowLimit, categoryTable.Rows.Count); // Set the page size based on the selected value
            }

            var page = paginationHelper.GetPage(categoryTable, 1); // Get the initial page of data
            dgvCategory.DataSource = page; // Set the DataGridView's data source to the paginated data

            var (start, end) = paginationHelper.GetDisplayRange(categoryTable.Rows.Count); // Get the display range for the current page
            lblCurrentCategoryPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
            lblCategoryPageInfo.Text = $"Showing {start} to {end} of {categoryTable.Rows.Count} entries"; // Update the label with the display range information

        }

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchCategory.Text.Trim().Replace("'", "''"); // Prevent SQL injection-like issues

            if (categoryTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dgvCategory.DataSource = categoryTable;
                    paginationHelper.ApplyRowLimit(cbCategoryEntries, categoryTable, dgvCategory, lblCategoryPageInfo); // Reset to the full category list when the search box is empty
                }
                else
                {
                    DataView dv = categoryTable.DefaultView;
                    dv.RowFilter = $"[Name] LIKE '%{filterText}%'";
                    dgvCategory.DataSource = dv;
                }
            }
        }

        private void cbCategoryEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            paginationHelper.ApplyRowLimit(cbCategoryEntries, categoryTable, dgvCategory, lblCategoryPageInfo); // Apply the row limit based on the selected value in the combo box
        }

        private void btnCategoryPrev_Click(object sender, EventArgs e)
        {
            int next = paginationHelper.CurrentPage - 1;
            DataTable nextPage = paginationHelper.GetPage(categoryTable, next);
            dgvCategory.DataSource = nextPage;

            var (start, end) = paginationHelper.GetDisplayRange(categoryTable.Rows.Count);
            lblCurrentCategoryPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
            lblCategoryPageInfo.Text = $"Showing {start} to {end} of {categoryTable.Rows.Count} entries";


        }

        private void btnCategoryNext_Click(object sender, EventArgs e)
        {
            int next = paginationHelper.CurrentPage + 1;
            DataTable nextPage = paginationHelper.GetPage(categoryTable, next);
            dgvCategory.DataSource = nextPage;

            var (start, end) = paginationHelper.GetDisplayRange(categoryTable.Rows.Count);
            lblCurrentCategoryPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
            lblCategoryPageInfo.Text = $"Showing {start} to {end} of {categoryTable.Rows.Count} entries";
        }

        private void dgvCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Auto-size some columns to fit their content
            dgvCategory.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set one column to fill the remaining space
            dgvCategory.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCategory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold); // Set header font style
            dgvCategory.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular); // Set header font style
        }








        // VENDOR MANAGEMENT METHODS

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            var addVendorControl = new Controls.AddVendor();

            addVendorControl.OnVendorAdded += async () => // Subscribe to the OnVendorAdded event
            {
                await LoadVendorList(); // Call the LoadVendorList method to refresh the vendor list
            };


            Forms.AddForm addVendorForm = new Forms.AddForm();
            addVendorForm.OpenControl(addVendorControl); // Open the AddVendor user control in the AddProduct form
            addVendorForm.Text = "Add Vendor"; // Set the title of the AddForm
            addVendorForm.SetBounds(0, 0, 409, 250); // Set the size of the AddForm
            addVendorForm.ShowDialog();
        }

        private async void btnVendorRefresh_Click(object sender, EventArgs e)
        {
            vendorTable = await Database.DBVendors.GetVendorListAsync(); // Returns a DataTable
            dgvVendor.DataSource = vendorTable; // Refresh the vendor list in the DataGridView
            paginationHelper.ApplyRowLimit(cbVendorEntries, vendorTable, dgvVendor, lblPageInfo); // Reset the row limit based on the selected value in the combo box
        }

        private void btnVendorPrev_Click(object sender, EventArgs e)
        {
            var prevPage = paginationHelper.GetPage(vendorTable, paginationHelper.CurrentPage - 1);
            dgvVendor.DataSource = prevPage;

            var (start, end) = paginationHelper.GetDisplayRange(vendorTable.Rows.Count);
            lblVendorCurrentPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
            lblPageInfo.Text = $"Showing {start} to {end} of {vendorTable.Rows.Count} entries";


        }

        private void btnVendorNext_Click(object sender, EventArgs e)
        {
            if (paginationHelper.CurrentPage < paginationHelper.TotalPages)
            {
                var nextPage = paginationHelper.GetPage(vendorTable, paginationHelper.CurrentPage + 1);
                var (start, end) = paginationHelper.GetDisplayRange(vendorTable.Rows.Count);
                dgvVendor.DataSource = nextPage; // Set the DataGridView's data source to the next page of data

                lblVendorCurrentPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
                lblPageInfo.Text = $"Showing {start} to {end} of {vendorTable.Rows.Count} entries";
            }
        }

        public async Task LoadVendorList()
        {
            vendorTable = await Database.DBVendors.GetVendorListAsync(); // Returns a DataTable
            dgvVendor.DataSource = vendorTable; // Set the DataGridView's data source to the vendor table

            string selected = cbVendorEntries.SelectedItem?.ToString() ?? "10"; // Get the selected value from the combo box or default to "10"

            if (int.TryParse(selected, out int rowLimit))
            {
                paginationHelper.SetPageSize(rowLimit, vendorTable.Rows.Count); // Set the page size based on the selected value
            }

            var page = paginationHelper.GetPage(vendorTable, 1); // Get the initial page of data
            dgvVendor.DataSource = page; // Set the DataGridView's data source to the paginated data

            var (start, end) = paginationHelper.GetDisplayRange(vendorTable.Rows.Count); // Get the display range for the current page
            lblVendorCurrentPage.Text = paginationHelper.CurrentPage.ToString(); // Update the current page label
            lblPageInfo.Text = $"Showing {start} to {end} of {vendorTable.Rows.Count} entries"; // Update the label with the display range information
        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchVendor.Text.Trim().Replace("'", "''"); // Prevent SQL injection-like issues

            if (vendorTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dgvVendor.DataSource = vendorTable;
                    paginationHelper.ApplyRowLimit(cbVendorEntries, vendorTable, dgvVendor, lblPageInfo); // Reset to the full vendor list when the search box is empty
                }
                else
                {
                    DataView dv = vendorTable.DefaultView;
                    dv.RowFilter = $"[Name] LIKE '%{filterText}%'";
                    dgvVendor.DataSource = dv;
                }
            }
        }

        private void cbVendorEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            paginationHelper.ApplyRowLimit(cbVendorEntries, vendorTable, dgvVendor, lblPageInfo); // Apply the row limit based on the selected value in the combo box
        }

        private void dgvVendor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Set overall mode to None so per - column settings apply
            dgvVendor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Auto-size some columns to fit their content
            dgvVendor.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendor.Columns["Contact Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set one column to fill the remaining space
            dgvVendor.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvVendor.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold); // Set header font style
            dgvVendor.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular); // Set header font style
        }
    }
}
