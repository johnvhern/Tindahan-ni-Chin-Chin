using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class VendorsUC : UserControl
    {
        private DataTable vendorTable;
        private PaginationHelper paginationHelper = new PaginationHelper(); // Instance of PaginationHelper to manage pagination
        public VendorsUC()
        {
            InitializeComponent();
        }

        private async void VendorsUC_Load(object sender, EventArgs e)
        {
            cbVendorEntries.SelectedIndex = 0; // Set the default selected index of the combo box to 0
            await LoadVendorList(); // Load the vendor list when the user control is loaded
        }

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
