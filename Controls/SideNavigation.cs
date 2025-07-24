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
    public partial class SideNavigation : UserControl
    {
        private Forms.MainForm mainForm; // Reference to the main view

        // User controls for different modules
        Controls.POS POS = new Controls.POS();
        Controls.Inventory Inventory = new Controls.Inventory();
        public SideNavigation(Forms.MainForm form)
        {
            InitializeComponent();
            this.mainForm = form; // Store the reference to the main view
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(POS); // Open the POS user control in the main view
           
        }

        private void btnPautang_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            mainForm.OpenControl(Inventory); // Open the Inventory user control in the main view
        }

        private void SideNavigation_Load(object sender, EventArgs e)
        {
            btnPOS.Focus(); // Set focus on the POS button by default
        }

    }
}
