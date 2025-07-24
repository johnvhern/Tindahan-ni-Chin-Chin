using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tindahan_ni_Chin_Chin.Database;

namespace Tindahan_ni_Chin_Chin.Forms
{
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            messageBoxStyle();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userLogin();
        }

        private void userLogin()
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();
            String hashedPassword = DatabaseCreation.HashPassword(password);

            using (var conn = DatabaseCreation.GetConnection())
            {
                string selectQuery = "SELECT id, username, password FROM user WHERE username = @username AND password = @password";

                using (var cmd = new SQLiteCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserSession.UserId = reader.GetInt32(0); // Get user ID
                            UserSession.Username = reader.GetString(1); // Get username
                            // Login successful, open MainView
                            MessageBoxAdv.Show(this, "Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            MainForm mainView = new MainForm();
                            mainView.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            // Login failed, show error message
                            MessageBoxAdv.Show(this, "Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                conn.Close();
            }
        }

        private void messageBoxStyle()
        {
            MessageBoxAdv.MetroColorTable.BorderColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MetroColorTable.BackColor = Color.White;
            MessageBoxAdv.MetroColorTable.ForeColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MetroColorTable.OKButtonBackColor = Color.FromArgb(26, 26, 26);
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
        }
    }
}
