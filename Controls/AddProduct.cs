using Syncfusion.Windows.Forms;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class AddProduct : UserControl
    {
        public Action OnProductAdded, OnVendorAdded; // callback to notify parent form
        private string selectedCategoryId, selectedCategoryName, selectedVendorId, selectedVendorName;

        public AddProduct()
        {
            messageBoxStyle(); // Apply custom message box style
            InitializeComponent();
        }

        private void txtProductCategory_Click(object sender, EventArgs e)
        {
            var productCategory = new ProductCategorySelection();

            productCategory.OnSelectedCategory += () => // Subscribe to the OnCategoryAdded event
            {
                txtProductCategory.Text = productCategory.selectedCategoryName; // Update the text box with the selected category name
                selectedCategoryId = productCategory.selectedCategoryId; // Store the selected category ID
            };

            Forms.LookupForm productCategoryForm = new Forms.LookupForm();
            productCategoryForm.OpenControl(productCategory); // Open the AddCategory user control in the AddProduct form
            productCategoryForm.Text = "Select Category"; // Set the title of the AddForm
            productCategoryForm.ShowDialog(); // Show the AddCategory form as a dialog
        }

        private void txtProductVendor_Click(object sender, EventArgs e)
        {
            var productVendor = new ProductVendorSelection();

            productVendor.OnSelectedVendor += () => // Subscribe to the OnCategoryAdded event
            {
                txtProductVendor.Text = productVendor.selectedProductVendor; // Update the text box with the selected category name
                selectedVendorId = productVendor.selectedVendorId; // Store the selected category ID
            };

            Forms.LookupForm productVendorForm = new Forms.LookupForm();
            productVendorForm.OpenControl(productVendor); // Open the AddCategory user control in the AddProduct form
            productVendorForm.Text = "Select Vendor"; // Set the title of the AddForm
            productVendorForm.ShowDialog(); // Show the AddCategory form as a dialog

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = txtProductName.Text.Trim();
                string productPrice = txtProductPrice.Text.Trim();
                string productStock = txtProductStock.Text.Trim();
                string productCategory = txtProductCategory.Text.Trim();
                string productVendor = txtProductVendor.Text.Trim();

                if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productPrice) || string.IsNullOrEmpty(productCategory) || string.IsNullOrEmpty(productVendor) || string.IsNullOrEmpty(productStock))
                {
                    messageBoxStyle(); // Apply custom message box style
                    MessageBoxAdv.Show(this, "Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    using (var conn = Database.DatabaseCreation.GetConnection())
                    {
                        double price = double.Parse(productPrice);
                        int finalPrice = (int)(price * 100); // Convert price to cents for storage
                        int stock = Int32.Parse(productStock);
                        int category = Int32.Parse(selectedCategoryId);
                        int vendor = Int32.Parse(selectedVendorId);

                        string insertVendorQuery = @"INSERT INTO product (product_name, product_category, product_vendor, product_price, product_stock) VALUES (@product_name, @product_category, @product_vendor, @product_price, @product_stock);";

                        using (var cmd = new SQLiteCommand(insertVendorQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@product_name", productName);
                            cmd.Parameters.AddWithValue("@product_category", category);
                            cmd.Parameters.AddWithValue("@product_vendor", vendor); // Use the selected vendor ID
                            cmd.Parameters.AddWithValue("@product_price", finalPrice);
                            cmd.Parameters.AddWithValue("@product_stock", stock);

                            cmd.ExecuteNonQuery();
                            messageBoxStyle(); // Apply custom message box style
                            MessageBoxAdv.Show(this, "Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);

                            OnProductAdded?.Invoke(); // Notify parent form that a vendor has been added
                            this.ParentForm.Close(); // Close the parent form (AddForm) after successful addition
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                File.AppendAllText("error.log", DateTime.Now + " - " + ex.ToString() + Environment.NewLine);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            string productPrice = txtProductPrice.Text.Trim();
            string productStock = txtProductStock.Text.Trim();
            string productCategory = txtProductCategory.Text.Trim();
            string productVendor = txtProductVendor.Text.Trim();

            if (!string.IsNullOrEmpty(productName) || !string.IsNullOrEmpty(productPrice) || !string.IsNullOrEmpty(productStock) || !string.IsNullOrEmpty(productCategory) || !string.IsNullOrEmpty(productVendor))
            {
                DialogResult result = MessageBoxAdv.Show(this, "Are you sure you want to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.ParentForm.Close(); // Close the parent form (AddForm)
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.ParentForm.Close(); // Close the parent form (AddForm) without confirmation if no data is entered
            }
        }
        private void messageBoxStyle()
        {
            MessageBoxAdv.MetroColorTable.BorderColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MetroColorTable.BackColor = Color.White;
            MessageBoxAdv.MetroColorTable.ForeColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MetroColorTable.OKButtonBackColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MetroColorTable.YesButtonBackColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MetroColorTable.NoButtonBackColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
        }

    }
}
