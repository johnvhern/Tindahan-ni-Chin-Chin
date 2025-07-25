using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Controls
{
    public partial class SideNavigation : UserControl
    {
        private Forms.MainForm mainForm; // Reference to the main view
        private Button activeButton;

        // User controls for different modules
        Controls.POS POS = new Controls.POS();
        Controls.Inventory Inventory = new Controls.Inventory();

        private void ColorActiveButton(Button button)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(26, 26, 26);
                activeButton.ForeColor = Color.FromArgb(242, 242, 242); // Reset previous active button color
            }

            activeButton = button;
            activeButton.BackColor = Color.FromArgb(160, 160, 160);
            activeButton.ForeColor = Color.FromArgb(242, 242, 242); // Set active button color
        }

        public SideNavigation(Forms.MainForm form)
        {
            InitializeComponent();
            this.mainForm = form; // Store the reference to the main view
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ColorActiveButton((Button)sender); // Highlight the active button
        }


        private void btnPOS_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(POS); // Open the POS user control in the main view
            ColorActiveButton((Button)sender);

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(Inventory); // Open the Inventory user control in the main view
            ColorActiveButton((Button)sender);
        }

        private void SideNavigation_Load(object sender, EventArgs e)
        {
            txtUser.Text = UserSession.Username; // Set the username from the session
            ColorActiveButton(btnDashboard);
            flowLayoutPanel1.HorizontalScroll.Enabled = false; // Disable vertical scrolling
        }

        private void panel3_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.AutoScrollPosition.X, e.NewValue);
        }
    }
}
