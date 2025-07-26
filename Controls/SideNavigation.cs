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
        POS POS = new Controls.POS();
        ProductsUC ProductsUC = new Controls.ProductsUC();
        CategoriesUC CategoriesUC = new Controls.CategoriesUC();
        VendorsUC VendorsUC = new VendorsUC();

        public SideNavigation(Forms.MainForm form)
        {
            InitializeComponent();
            this.mainForm = form; // Store the reference to the main view
        }

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

        private void SideNavigation_Load(object sender, EventArgs e)
        {
            txtUser.Text = UserSession.Username; // Set the username from the session
            ColorActiveButton(btnDashboard);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(POS);
            ColorActiveButton((Button)sender);
        }

        private void btnPautang_Click(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(ProductsUC);
            ColorActiveButton((Button)sender);

        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(CategoriesUC);
            ColorActiveButton((Button)sender);
        }

        private void btnVendors_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(VendorsUC);
            ColorActiveButton((Button)sender);
        }

        private void btnManageStock_Click(object sender, EventArgs e)
        {

        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {

        }
    }
}
