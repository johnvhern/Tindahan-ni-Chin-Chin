using Syncfusion.Windows.Forms;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class ProductCategorySelection : UserControl
    {
        public Action OnSelectedCategory; // callback to notify parent form
        public string selectedCategoryId;
        public string selectedCategoryName;

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
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Action";
                    buttonColumn.Text = "Remove";
                    buttonColumn.Name = "Remove";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvSelectedCategory.Columns.Add(buttonColumn);

                }
                else
                {
                    MessageBoxAdv.Show(this, "can only select 1 category per product");
                }

            }

            selectedCategoryId = dgvProductCategory.Rows[e.RowIndex].Cells["#"].Value.ToString();
            selectedCategoryName = dgvProductCategory.Rows[e.RowIndex].Cells["Name"].Value.ToString();

        }

        private void dgvSelectedCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable removeSelectedRow = new DataTable();

            if (e.ColumnIndex == dgvSelectedCategory.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSelectedCategory.Rows[e.RowIndex];

                // Remove the selected row from the DataGridView
                if (dgvSelectedCategory.Rows.Count > 0)
                {
                    dgvSelectedCategory.Columns.Remove("Remove");
                    dgvSelectedCategory.Rows.Remove(selectedRow);
                    dgvSelectedCategory.DataSource = null;

                }
                else
                {
                    MessageBoxAdv.Show(this, "No category selected to remove.");
                }

            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult result = MessageBoxAdv.Show(this, $"Are you sure you want to add this category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dgvSelectedCategory.Rows.Count > 0)
                    {
                        AddProduct addProductControl = new AddProduct();

                        Forms.AddForm addProductForm = new Forms.AddForm();
                        addProductForm.LoadUserControl(addProductControl);

                        OnSelectedCategory?.Invoke(); // Notify parent form that a category has been selected
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
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvSelectedCategory.Rows.Count > 1)
                {
                    DialogResult result = MessageBoxAdv.Show(this, "Are you sure you want to cancel the category selection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dgvSelectedCategory.Rows.Clear(); // Clear the selected category DataGridView
                        dgvSelectedCategory.Columns.Clear(); // Clear the columns to reset the view
                        selectedCategoryId = string.Empty; // Reset selected category ID
                        selectedCategoryName = string.Empty; // Reset selected category name
                    }
                }
                else
                {
                    this.ParentForm.Close(); // Close the parent form (AddForm) without any action
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(this, "An error occurred while cancelling category selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategorySearch_TextChanged(object sender, EventArgs e)
        {
            DataTable categoryTable = Database.DBCategory.getCategoryList().Result; // Fetch the category list asynchronously

            string filterText = txtSearchCategory.Text.Trim().Replace("'", "''"); // Prevent SQL injection-like issues

            if (categoryTable != null)
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    dgvProductCategory.DataSource = categoryTable;
                }
                else
                {
                    DataView dv = categoryTable.DefaultView;
                    dv.RowFilter = $"[Name] LIKE '%{filterText}%'";
                    dgvProductCategory.DataSource = dv;
                }
            }
        }
    }
}
