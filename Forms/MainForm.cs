using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tindahan_ni_Chin_Chin.Controls;

namespace Tindahan_ni_Chin_Chin.Forms
{
    public partial class MainForm : MetroForm
    {
        private UserControl currentControl = null;
        //private bool isDragging = false; // Flag to track dragging state
        public MainForm()
        {
            InitializeComponent();
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Text = "Project POS : Version " + Application.ProductVersion;
            this.WindowState = FormWindowState.Maximized;
            SideNavigation sideNavigation = new SideNavigation(this);
            sideNavigation.Dock = DockStyle.Left;
            this.Controls.Add(sideNavigation);
            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
            null, panel3, new object[] { true });
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED - enables smoother UI rendering
                return cp;
            }
        }

        // Override WndProc to handle window messages for dragging
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_SYSCOMMAND = 0x0112;
        //    const int WM_NCLBUTTONDBLCLK = 0x00A3;
        //    const int SC_MOVE = 0xF010; // Move command
        //    const int WM_EXITSIZEMOVE = 0x0232; // Event when dragging stops

        //    if (m.Msg == WM_NCLBUTTONDBLCLK)
        //    {
        //        return; // Ignore the double-click event on the title bar
        //    }

        //    // Detect when dragging starts
        //    if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_MOVE)
        //    {
        //        isDragging = true;
        //    }

        //    // Detect when dragging stops
        //    if (m.Msg == WM_EXITSIZEMOVE && isDragging)
        //    {
        //        isDragging = false;
        //        this.WindowState = FormWindowState.Maximized; // Re-maximize
        //    }

        //    base.WndProc(ref m);
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenControl(new Controls.POS()); // Open the POS view by default when the main view loads
        }

        public void OpenControl(UserControl control)
        {
            // Prevent re-adding the same control instance
            if (currentControl == control)
                return;

            // Remove the old control from the panel (do NOT dispose it if reusing)
            if (currentControl != null)
            {
                panel3.Controls.Remove(currentControl);
            }

            currentControl = control;
            control.Dock = DockStyle.Fill;
            panel3.Controls.Add(control);
        }
    }
}
