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
        public Action OnProductAdded; // callback to notify parent form
        private string selectedCategoryId;
        private string selectedCategoryName;

        public AddProduct()
        {
            messageBoxStyle(); // Apply custom message box style
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //string vendorName = txtVendorName.Text.Trim();
                //string vendorContact = txtVendorContactNumber.Text.Trim();

                //if (string.IsNullOrEmpty(vendorName) || string.IsNullOrEmpty(vendorContact))
                //{
                //    messageBoxStyle(); // Apply custom message box style
                //    MessageBoxAdv.Show(this, "Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                //    using (var conn = Database.DatabaseCreation.GetConnection())
                //    {
                //        string insertVendorQuery = @"INSERT INTO vendor (vendor_name, vendor_contact_number) VALUES (@vendor_name, @vendor_contact_number);";

                //        using (var cmd = new SQLiteCommand(insertVendorQuery, conn))
                //        {
                //            cmd.Parameters.AddWithValue("@vendor_name", vendorName);
                //            cmd.Parameters.AddWithValue("@vendor_contact_number", vendorContact);
                //            cmd.ExecuteNonQuery();
                //            messageBoxStyle(); // Apply custom message box style
                //            MessageBoxAdv.Show(this, "Vendor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);

                //            OnVendorAdded?.Invoke(); // Notify parent form that a vendor has been added
                //            this.ParentForm.Close(); // Close the parent form (AddForm) after successful addition
                //        }
                //    }
                //}
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

        private void txtProductCategory_Click(object sender, EventArgs e)
        {
            var productCategory = new ProductCategorySelection();

            productCategory.OnSelectedCategory += () => // Subscribe to the OnCategoryAdded event
            {
                txtProductCategory.Text = productCategory.selectedCategoryName; // Update the text box with the selected category name
                selectedCategoryName = productCategory.selectedCategoryName; // Store the selected category name
                selectedCategoryId = productCategory.selectedCategoryId; // Store the selected category ID
            };

            Forms.LookupForm productCategoryForm = new Forms.LookupForm();
            productCategoryForm.OpenControl(productCategory); // Open the AddCategory user control in the AddProduct form
            productCategoryForm.Text = "Select Category"; // Set the title of the AddForm
            productCategoryForm.ShowDialog(); // Show the AddCategory form as a dialog
        }
    }
}
