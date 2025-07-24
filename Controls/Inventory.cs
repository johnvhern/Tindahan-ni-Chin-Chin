using Syncfusion.Pdf.Interactive;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class Inventory : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 1;
        private DataTable vendorTable; // DataTable to hold vendor data
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            cbVendorEntries.SelectedIndex = 0; // Set the default selected index of the vendor combo box to the first entry
            LoadVendorList(); // Load the vendor list into the DataTable
        }

        // CATEGORY MANAGEMENT METHODS



        // VENDOR MANAGEMENT METHODS

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            var addVendorControl = new Controls.AddVendor();

            addVendorControl.OnVendorAdded += () => // Subscribe to the OnVendorAdded event
            {
                ReloadVendors(); // Call the ReloadVendors method to refresh the vendor list
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
            ApplyRowLimit(); // Reapply the row limit after refreshing the vendor list
        }

        private void btnVendorPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }

        private void btnVendorNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

        public void LoadVendorList()
        {
            vendorTable = Database.DBVendors.GetVendorList(); // Returns a DataTable
            dgvVendor.DataSource = vendorTable; // Set the DataGridView's data source to the vendor table
            ApplyRowLimit();
        }

        public void ReloadVendors()
        {
            vendorTable = Database.DBVendors.GetVendorList(); // Returns a DataTable
            dgvVendor.DataSource = Database.DBVendors.GetVendorList(); // Reload the vendor list into the DataGridView
            ApplyRowLimit(); // Reapply the row limit after reloading the vendor list
        }

        private void ApplyRowLimit()
        {
            if (vendorTable == null) return;

            string selectedValue = cbVendorEntries.SelectedItem?.ToString();

            // Try parse page size
            if (int.TryParse(selectedValue, out int newSize))
            {
                pageSize = newSize;
                currentPage = 1;
                CalculateTotalPages();
                DisplayPage(currentPage);
            }
        }

        private void CalculateTotalPages()
        {
            if (vendorTable == null || vendorTable.Rows.Count == 0)
            {
                totalPages = 1;
                return;
            }

            totalPages = (int)Math.Ceiling(vendorTable.Rows.Count / (double)pageSize);
        }


        private void DisplayPage(int page)
        {
            if (vendorTable == null) return;

            int startIndex = (page - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, vendorTable.Rows.Count);

            DataTable pageTable = vendorTable.Clone();

            for (int i = startIndex; i < endIndex; i++)
            {
                pageTable.ImportRow(vendorTable.Rows[i]);
            }

            dgvVendor.DataSource = pageTable;

            lblPageInfo.Text = $"Showing {startIndex + 1} to {endIndex} of {vendorTable.Rows.Count} entries";
            lblVendorCurrentPage.Text = page.ToString();

            btnVendorPrev.Enabled = currentPage > 1;
            btnVendorNext.Enabled = currentPage < totalPages;
        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchVendor.Text.Trim().Replace("'", "''"); // Prevent SQL injection-like issues

            if (vendorTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dgvVendor.DataSource = vendorTable;
                    ApplyRowLimit(); // Reapply the row limit when the filter is cleared
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
            ApplyRowLimit(); // Apply the row limit when the selected index changes
        }

        private void dgvVendor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set overall mode to None so per-column settings apply
            dgvVendor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Auto-size some columns to fit their content
            dgvVendor.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvVendor.Columns["Contact Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set one column to fill the remaining space
            dgvVendor.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

           

        }
    }
}
