using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class CategoriesUC : UserControl
    {
        private DataTable categoryTable; // DataTable to hold the category data
        private PaginationHelper paginationHelper = new PaginationHelper(); // Instance of PaginationHelper to manage pagination
        public CategoriesUC()
        {
            InitializeComponent();
        }

        private async void CategoriesUC_Load(object sender, EventArgs e)
        {
            cbCategoryEntries.SelectedIndex = 0; // Set the default selected index of the combo box to 0
            await LoadCategory();
        }

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

    }
}
