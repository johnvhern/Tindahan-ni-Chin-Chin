using Syncfusion.Compression.Zip;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Tindahan_ni_Chin_Chin.Database;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class Inventory : UserControl
    {
        Paginator paginator = new Paginator();
        private DataTable vendorTable, categoryTable; // DataTable to hold data
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

        private void ApplyRowLimit(ComboBox comboBox, DataTable sourceTable, DataGridView targetGrid, Label infoLabel)
        {
            try
            {
                if (sourceTable != null)
                {
                    string selected = comboBox.SelectedItem.ToString();
                    DataTable paged = paginator.ApplyRowLimit(sourceTable, selected);

                    var (start, end) = paginator.GetDisplayRange(sourceTable.Rows.Count);

                    infoLabel.Text = $"Showing {start} to {end} of {sourceTable.Rows.Count} entries";
                    targetGrid.DataSource = paged;
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(this, "An error occurred while setting the row limit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class Paginator
        {
            private int _pageSize = 10;
            private int _currentPage = 1;
            private int _totalPages = 1;

            public void SetPageSize(int newSize, int totalRows)
            {
                _pageSize = newSize;
                _currentPage = 1;
                CalculateTotalPages(totalRows);
            }


            public (int Start, int End) GetDisplayRange(int totalRows)
            {
                int start = (_currentPage - 1) * _pageSize + 1;
                int end = Math.Min(_currentPage * _pageSize, totalRows);

                if (totalRows == 0) // handle empty state
                {
                    start = 0;
                    end = 0;
                }

                return (start, end);
            }

            public DataTable ApplyRowLimit(DataTable sourceTable, string selectedValue)
            {
                if (sourceTable == null || string.IsNullOrEmpty(selectedValue))
                    return null;

                if (int.TryParse(selectedValue, out int newSize))
                {
                    SetPageSize(newSize, sourceTable.Rows.Count);
                    return GetPage(sourceTable, _currentPage);
                    
                }

                return sourceTable;
            }


            private void CalculateTotalPages(int rowCount)
            {
                _totalPages = (_pageSize == 0) ? 1 : (int)Math.Ceiling((double)rowCount / _pageSize);
            }

            public DataTable GetPage(DataTable sourceTable, int pageNumber)
            {
                if (sourceTable == null || _pageSize <= 0)
                    return sourceTable;

                _currentPage = Math.Max(1, Math.Min(pageNumber, _totalPages));

                var resultTable = sourceTable.Clone();
                int startIndex = (_currentPage - 1) * _pageSize;
                int endIndex = Math.Min(startIndex + _pageSize, sourceTable.Rows.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    resultTable.ImportRow(sourceTable.Rows[i]);
                }

                return resultTable;
            }

            public int CurrentPage => _currentPage;
            public int TotalPages => _totalPages;
            public int PageSize => _pageSize;

            
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
            ApplyRowLimit(cbCategoryEntries, categoryTable, dgvCategory, lblCategoryPageInfo); // Reset the row limit based on the selected value in the combo box
        }

        private async Task LoadCategory()
        {
            categoryTable = await Database.DBCategory.getCategoryList(); // Returns a DataTable
            dgvCategory.DataSource = categoryTable;

            string selected = cbCategoryEntries.SelectedItem?.ToString() ?? "10"; // Get the selected value from the combo box or default to "10"

            if (int.TryParse(selected, out int rowLimit))
            {
                paginator.SetPageSize(rowLimit, categoryTable.Rows.Count); // Set the page size based on the selected value
            }

            var page = paginator.GetPage(categoryTable, 1); // Get the initial page of data
            dgvCategory.DataSource = page; // Set the DataGridView's data source to the paginated data

            var (start, end) = paginator.GetDisplayRange(categoryTable.Rows.Count); // Get the display range for the current page
            lblCurrentCategoryPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
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
                    ApplyRowLimit(cbCategoryEntries, categoryTable, dgvCategory, lblCategoryPageInfo); // Reset to the full category list when the search box is empty
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
            ApplyRowLimit(cbCategoryEntries, categoryTable, dgvCategory, lblCategoryPageInfo); // Apply the row limit based on the selected value in the combo box
        }

        private void btnCategoryPrev_Click(object sender, EventArgs e)
        {
            int next = paginator.CurrentPage - 1;
            DataTable nextPage = paginator.GetPage(categoryTable, next);
            dgvCategory.DataSource = nextPage;

            var (start, end) = paginator.GetDisplayRange(categoryTable.Rows.Count);
            lblCurrentCategoryPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
            lblCategoryPageInfo.Text = $"Showing {start} to {end} of {categoryTable.Rows.Count} entries";


        }

        private void btnCategoryNext_Click(object sender, EventArgs e)
        {
            int next = paginator.CurrentPage + 1;
            DataTable nextPage = paginator.GetPage(categoryTable, next);
            dgvCategory.DataSource = nextPage;

            var (start, end) = paginator.GetDisplayRange(categoryTable.Rows.Count);
            lblCurrentCategoryPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
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
            ApplyRowLimit(cbVendorEntries, vendorTable, dgvVendor, lblPageInfo); // Reset the row limit based on the selected value in the combo box
        }

        private void btnVendorPrev_Click(object sender, EventArgs e)
        {
            var prevPage = paginator.GetPage(vendorTable, paginator.CurrentPage - 1);
            dgvVendor.DataSource = prevPage;

            var (start, end) = paginator.GetDisplayRange(vendorTable.Rows.Count);
            lblVendorCurrentPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
            lblPageInfo.Text = $"Showing {start} to {end} of {vendorTable.Rows.Count} entries";


        }

        private void btnVendorNext_Click(object sender, EventArgs e)
        {
            if (paginator.CurrentPage < paginator.TotalPages)
            {
                var nextPage = paginator.GetPage(vendorTable, paginator.CurrentPage + 1);
                var (start, end) = paginator.GetDisplayRange(vendorTable.Rows.Count);
                dgvVendor.DataSource = nextPage; // Set the DataGridView's data source to the next page of data

                lblVendorCurrentPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
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
                paginator.SetPageSize(rowLimit, vendorTable.Rows.Count); // Set the page size based on the selected value
            }

            var page = paginator.GetPage(vendorTable, 1); // Get the initial page of data
            dgvVendor.DataSource = page; // Set the DataGridView's data source to the paginated data

            var (start, end) = paginator.GetDisplayRange(vendorTable.Rows.Count); // Get the display range for the current page
            lblVendorCurrentPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
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
                    ApplyRowLimit(cbVendorEntries, vendorTable, dgvVendor, lblPageInfo); // Reset to the full vendor list when the search box is empty
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
            ApplyRowLimit(cbVendorEntries, vendorTable, dgvVendor, lblPageInfo); // Apply the row limit based on the selected value in the combo box
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
