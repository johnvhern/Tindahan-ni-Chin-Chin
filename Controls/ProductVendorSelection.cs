using Syncfusion.Windows.Forms;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class ProductVendorSelection : UserControl
    {
        public Action OnSelectedVendor; // callback to notify parent form
        public string selectedVendorId, selectedProductVendor;
        public ProductVendorSelection()
        {
            InitializeComponent();
        }

        private async void ProductVendorSelection_Load(object sender, EventArgs e)
        {
            await LoadVendorList();
        }

        private async Task LoadVendorList()
        {
            DataTable dataTable = await Database.DBVendors.GetVendorListAsync();
            dgvProductVendor.DataSource = dataTable;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Add";
            buttonColumn.Name = "Add";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgvProductVendor.Columns.Add(buttonColumn);
        }

        private void dgvProductCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataTable selectedVendor = new DataTable();

            selectedVendor.Columns.Add("#", typeof(string));
            selectedVendor.Columns.Add("Name", typeof(string));

            if (e.ColumnIndex == dgvProductVendor.Columns["Add"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvProductVendor.Rows[e.RowIndex];


                string categoryId = selectedRow.Cells["#"].Value.ToString();
                string categoryName = selectedRow.Cells["Name"].Value.ToString();

                if (dgvSelectedVendor.Rows.Count <= 0)
                {
                    selectedVendor.Rows.Add(categoryId, categoryName);

                    dgvSelectedVendor.DataSource = null;
                    dgvSelectedVendor.DataSource = selectedVendor;
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Action";
                    buttonColumn.Text = "Remove";
                    buttonColumn.Name = "Remove";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvSelectedVendor.Columns.Add(buttonColumn);

                }
                else
                {
                    MessageBoxAdv.Show(this, "can only select 1 vendor per product");
                }

            }

            selectedVendorId = dgvProductVendor.Rows[e.RowIndex].Cells["#"].Value.ToString();
            selectedProductVendor = dgvProductVendor.Rows[e.RowIndex].Cells["Name"].Value.ToString();

        }

        private void dgvSelectedCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataTable removeSelectedRow = new DataTable();

            if (e.ColumnIndex == dgvSelectedVendor.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSelectedVendor.Rows[e.RowIndex];

                // Remove the selected row from the DataGridView
                if (dgvSelectedVendor.Rows.Count > 0)
                {
                    dgvSelectedVendor.Columns.Remove("Remove");
                    dgvSelectedVendor.Rows.Remove(selectedRow);
                    dgvSelectedVendor.DataSource = null;

                }
                else
                {
                    MessageBoxAdv.Show(this, "No vendor selected to remove.");
                }

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult result = MessageBoxAdv.Show(this, $"Are you sure you want to add this vendor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dgvSelectedVendor.Rows.Count > 0)
                    {
                        AddProduct addProductControl = new AddProduct();

                        Forms.AddForm addProductForm = new Forms.AddForm();
                        addProductForm.LoadUserControl(addProductControl);

                        OnSelectedVendor?.Invoke(); // Notify parent form that a category has been selected
                        this.ParentForm.Close(); // Close the parent form (AddForm) after successful addition
                    }
                    else
                    {
                        MessageBoxAdv.Show(this, "Please select a category to add.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(this, "An error occurred while adding the product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error in ProductVendorSelection: " + ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            try
            {

                if (dgvSelectedVendor.Rows.Count > 1)
                {
                    DialogResult result = MessageBoxAdv.Show(this, "Are you sure you want to cancel the category selection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dgvSelectedVendor.Rows.Clear(); // Clear the selected category DataGridView
                        dgvSelectedVendor.Columns.Clear(); // Clear the columns to reset the view
                        selectedVendorId = string.Empty; // Reset selected category ID
                        selectedProductVendor = string.Empty; // Reset selected category name
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(this, "An error occurred while cancelling category selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error in ProductVendorSelection: " + ex.Message);
            }

        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            DataTable vendorTable = Database.DBVendors.GetVendorListAsync().Result; // Fetch the category list asynchronously

            string filterText = txtSearchVendor.Text.Trim().Replace("'", "''"); // Prevent SQL injection-like issues

            if (vendorTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dgvProductVendor.DataSource = vendorTable;
                }
                else
                {
                    DataView dv = vendorTable.DefaultView;
                    dv.RowFilter = $"[Name] LIKE '%{filterText}%'";
                    dgvProductVendor.DataSource = dv;
                }
            }
        }
    }
}
