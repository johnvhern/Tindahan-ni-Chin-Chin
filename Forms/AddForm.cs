using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin.Forms
{
    public partial class AddForm : MetroForm
    {
        private UserControl currentControl = null;
        public AddForm()
        {
            InitializeComponent();
        }

        public void OpenControl(UserControl control)
        {
            // Prevent re-adding the same control instance
            if (currentControl == control)
                return;

            // Remove the old control from the panel (do NOT dispose it if reusing)
            if (currentControl != null)
            {
                panelControl.Controls.Remove(currentControl);
            }

            currentControl = control;
            control.Dock = DockStyle.Fill;
            panelControl.Controls.Add(control);
        }
    }
}
