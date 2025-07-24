using Syncfusion.Compression.Zip;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Windows.Forms;
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
            cbVendorEntries.SelectedIndex = 0; // Set the default selected index of the vendor combo box to the first entry
            cbCategoryEntries.SelectedIndex = 0; // Set the default selected index of the category combo box to the first entry
            LoadVendorList(); // Load the vendor list into the DataTable
            LoadCategory(); // Load the category list into the DataGridView 
        }

        // REUSABLE METHODS

        private ComboBox rowLimit(ComboBox comboBox)
        {
            DataTable dataTable = vendorTable ?? categoryTable;
            try
            {
                if (dataTable != null)
                {
                    string selected = comboBox.SelectedItem?.ToString() ?? "1"; // Get the selected value or default to "10"
                    DataTable paged = paginator.ApplyRowLimit(dataTable, selected);

                    var (start, end) = paginator.GetDisplayRange(vendorTable.Rows.Count);
                    lblPageInfo.Text = $"Showing {start} to {end} of {vendorTable.Rows.Count} entries";

                    dgvVendor.DataSource = paged;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(this, "An error occurred while setting the row limit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return comboBox;
        }

        public class Paginator
        {
            private int _pageSize = 10;
            private int _currentPage = 1;
            private int _totalPages = 1;

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
                    _pageSize = newSize;
                    _currentPage = 1;
                    CalculateTotalPages(sourceTable.Rows.Count);
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

        public DataGridView gridviewStyle(DataGridView view)
        {
            // Set overall mode to None so per-column settings apply
            view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Auto-size some columns to fit their content
            view.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            view.Columns["Contact Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set one column to fill the remaining space
            view.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            view.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold); // Set header font style
            view.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular); // Set header font style

            return view;
        }

        // CATEGORY MANAGEMENT METHODS

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var addCategoryControl = new Controls.AddCategory();

            addCategoryControl.OnCategoryAdded += () => // Subscribe to the OnCategoryAdded event
            {
                LoadCategory(); // Call the ReloadVendors method to refresh the vendor list
            };

            Forms.AddForm addCategoryForm = new Forms.AddForm();
            addCategoryForm.OpenControl(addCategoryControl); // Open the AddCategory user control in the AddProduct form
            addCategoryForm.Text = "Add Category"; // Set the title of the AddForm
            addCategoryForm.SetBounds(0, 0, 409, 200); // Set the size of the AddForm
            addCategoryForm.ShowDialog(); // Show the AddCategory form as a dialog
        }

        private void LoadCategory()
        {
            categoryTable = Database.DBCategory.getCategoryList(); // Returns a DataTable
            dgvCategory.DataSource = Database.DBCategory.getCategoryList(); // Reload the category list into the DataGridView
            rowLimit(cbCategoryEntries); // Reset the row limit based on the selected value in the combo box
        }

        // VENDOR MANAGEMENT METHODS

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            var addVendorControl = new Controls.AddVendor();

            addVendorControl.OnVendorAdded += () => // Subscribe to the OnVendorAdded event
            {
                LoadVendorList(); // Call the ReloadVendors method to refresh the vendor list
            };


            Forms.AddForm addVendorForm = new Forms.AddForm();
            addVendorForm.OpenControl(addVendorControl); // Open the AddVendor user control in the AddProduct form
            addVendorForm.Text = "Add Vendor"; // Set the title of the AddForm
            addVendorForm.SetBounds(0, 0, 409, 250); // Set the size of the AddForm
            addVendorForm.ShowDialog();
        }

        private void btnVendorRefresh_Click(object sender, EventArgs e)
        {
            vendorTable = Database.DBVendors.GetVendorList(); // Returns a DataTable
            dgvVendor.DataSource = Database.DBVendors.GetVendorList(); // Refresh the vendor list in the DataGridView
            rowLimit(cbVendorEntries); // Reset the row limit based on the selected value in the combo box
        }

        private void btnVendorPrev_Click(object sender, EventArgs e)
        {
            int next = paginator.CurrentPage - 1;
            DataTable nextPage = paginator.GetPage(vendorTable, next);
            dgvVendor.DataSource = nextPage;
            lblVendorCurrentPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
        }

        private void btnVendorNext_Click(object sender, EventArgs e)
        {
            int next = paginator.CurrentPage + 1;
            DataTable nextPage = paginator.GetPage(vendorTable, next);
            dgvVendor.DataSource = nextPage;
            lblVendorCurrentPage.Text = paginator.CurrentPage.ToString(); // Update the current page label
        }

        public void LoadVendorList()
        {
            vendorTable = Database.DBVendors.GetVendorList(); // Returns a DataTable
            dgvVendor.DataSource = vendorTable; // Set the DataGridView's data source to the vendor table
            rowLimit(cbVendorEntries); // Apply the row limit based on the selected value in the combo box
        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchVendor.Text.Trim().Replace("'", "''"); // Prevent SQL injection-like issues

            if (vendorTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dgvVendor.DataSource = vendorTable;
                    rowLimit(cbVendorEntries); // Reset to the full vendor list when the search box is empty
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
            rowLimit(cbVendorEntries); // Apply the row limit based on the selected value in the combo box
        }

        private void dgvVendor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            gridviewStyle(dgvVendor); // Apply the grid view style to the DataGridView
        }
    }
}
