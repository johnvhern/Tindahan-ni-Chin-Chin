using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class AddProduct : UserControl
    {
        public Action OnProductAdded; // callback to notify parent form
        public AddProduct()
        {
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
            //string vendorName = txtVendorName.Text.Trim();
            //string vendorContact = txtVendorContactNumber.Text.Trim();

            //if (!string.IsNullOrEmpty(vendorName) || !string.IsNullOrEmpty(vendorContact))
            //{
            //    DialogResult result = MessageBoxAdv.Show(this, "Are you sure you want to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //    if (result == DialogResult.Yes)
            //    {
            //        this.ParentForm.Close(); // Close the parent form (AddForm)
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    this.ParentForm.Close(); // Close the parent form (AddForm) without confirmation if no data is entered
            //}
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
