namespace Tindahan_ni_Chin_Chin.Controls
{
    partial class Inventory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabProduct = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabVendor = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVendorPrev = new System.Windows.Forms.Button();
            this.btnVendorNext = new System.Windows.Forms.Button();
            this.lblVendorCurrentPage = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label26 = new System.Windows.Forms.Label();
            this.cbVendorEntries = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSearchVendor = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.panel15 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label29 = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVendorRefresh = new System.Windows.Forms.Button();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.tabCategory = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabStock = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dgvVendor = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabVendor.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.panel14.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchVendor)).BeginInit();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabControlAdv1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1102, 693);
            this.panel1.TabIndex = 0;
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(1082, 673);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControlAdv1.Controls.Add(this.tabProduct);
            this.tabControlAdv1.Controls.Add(this.tabVendor);
            this.tabControlAdv1.Controls.Add(this.tabCategory);
            this.tabControlAdv1.Controls.Add(this.tabStock);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAdv1.InactiveTabColor = System.Drawing.Color.White;
            this.tabControlAdv1.Location = new System.Drawing.Point(10, 10);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.ShowScroll = false;
            this.tabControlAdv1.Size = new System.Drawing.Size(1082, 673);
            this.tabControlAdv1.SizeMode = Syncfusion.Windows.Forms.Tools.TabSizeMode.FillToRight;
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabPanelBackColor = System.Drawing.Color.White;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            this.tabControlAdv1.ThemeName = "TabRendererMetro";
            // 
            // tabProduct
            // 
            this.tabProduct.Image = null;
            this.tabProduct.ImageSize = new System.Drawing.Size(16, 16);
            this.tabProduct.Location = new System.Drawing.Point(0, 28);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.ShowCloseButton = false;
            this.tabProduct.Size = new System.Drawing.Size(1082, 645);
            this.tabProduct.TabIndex = 1;
            this.tabProduct.Text = "Product";
            this.tabProduct.ThemesEnabled = false;
            // 
            // tabVendor
            // 
            this.tabVendor.Controls.Add(this.panel11);
            this.tabVendor.Image = null;
            this.tabVendor.ImageSize = new System.Drawing.Size(16, 16);
            this.tabVendor.Location = new System.Drawing.Point(0, 28);
            this.tabVendor.Name = "tabVendor";
            this.tabVendor.ShowCloseButton = false;
            this.tabVendor.Size = new System.Drawing.Size(1082, 645);
            this.tabVendor.TabIndex = 3;
            this.tabVendor.Text = "Vendor";
            this.tabVendor.ThemesEnabled = false;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Controls.Add(this.panel15);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1082, 645);
            this.panel11.TabIndex = 5;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.dgvVendor);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 83);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1082, 524);
            this.panel12.TabIndex = 3;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tableLayoutPanel9);
            this.panel13.Controls.Add(this.flowLayoutPanel5);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 607);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1082, 38);
            this.panel13.TabIndex = 2;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.Controls.Add(this.btnVendorPrev, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnVendorNext, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblVendorCurrentPage, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(938, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(144, 38);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // btnVendorPrev
            // 
            this.btnVendorPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnVendorPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVendorPrev.FlatAppearance.BorderSize = 0;
            this.btnVendorPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendorPrev.ForeColor = System.Drawing.Color.White;
            this.btnVendorPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnVendorPrev.Image")));
            this.btnVendorPrev.Location = new System.Drawing.Point(3, 3);
            this.btnVendorPrev.Name = "btnVendorPrev";
            this.btnVendorPrev.Size = new System.Drawing.Size(41, 32);
            this.btnVendorPrev.TabIndex = 0;
            this.btnVendorPrev.UseVisualStyleBackColor = false;
            this.btnVendorPrev.Click += new System.EventHandler(this.btnVendorPrev_Click);
            // 
            // btnVendorNext
            // 
            this.btnVendorNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnVendorNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVendorNext.FlatAppearance.BorderSize = 0;
            this.btnVendorNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendorNext.ForeColor = System.Drawing.Color.White;
            this.btnVendorNext.Image = ((System.Drawing.Image)(resources.GetObject("btnVendorNext.Image")));
            this.btnVendorNext.Location = new System.Drawing.Point(97, 3);
            this.btnVendorNext.Name = "btnVendorNext";
            this.btnVendorNext.Size = new System.Drawing.Size(44, 32);
            this.btnVendorNext.TabIndex = 1;
            this.btnVendorNext.UseVisualStyleBackColor = false;
            this.btnVendorNext.Click += new System.EventHandler(this.btnVendorNext_Click);
            // 
            // lblVendorCurrentPage
            // 
            this.lblVendorCurrentPage.AutoSize = true;
            this.lblVendorCurrentPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVendorCurrentPage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCurrentPage.Location = new System.Drawing.Point(50, 0);
            this.lblVendorCurrentPage.Name = "lblVendorCurrentPage";
            this.lblVendorCurrentPage.Size = new System.Drawing.Size(41, 38);
            this.lblVendorCurrentPage.TabIndex = 2;
            this.lblVendorCurrentPage.Text = "1";
            this.lblVendorCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lblPageInfo);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(311, 38);
            this.flowLayoutPanel5.TabIndex = 1;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(0, 10);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(57, 17);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "Showing";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.flowLayoutPanel6);
            this.panel14.Controls.Add(this.tableLayoutPanel10);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 48);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1082, 35);
            this.panel14.TabIndex = 1;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label26);
            this.flowLayoutPanel6.Controls.Add(this.cbVendorEntries);
            this.flowLayoutPanel6.Controls.Add(this.label27);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(208, 35);
            this.flowLayoutPanel6.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(0, 10);
            this.label26.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 17);
            this.label26.TabIndex = 0;
            this.label26.Text = "Show";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbVendorEntries
            // 
            this.cbVendorEntries.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbVendorEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendorEntries.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbVendorEntries.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVendorEntries.FormattingEnabled = true;
            this.cbVendorEntries.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.cbVendorEntries.Location = new System.Drawing.Point(44, 7);
            this.cbVendorEntries.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cbVendorEntries.Name = "cbVendorEntries";
            this.cbVendorEntries.Size = new System.Drawing.Size(49, 23);
            this.cbVendorEntries.TabIndex = 3;
            this.cbVendorEntries.SelectedIndexChanged += new System.EventHandler(this.cbVendorEntries_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(96, 10);
            this.label27.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(49, 17);
            this.label27.TabIndex = 2;
            this.label27.Text = "entries";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.label28, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.txtSearchVendor, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(709, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(373, 35);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(3, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(180, 35);
            this.label28.TabIndex = 2;
            this.label28.Text = "Search:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchVendor
            // 
            this.txtSearchVendor.BeforeTouchSize = new System.Drawing.Size(181, 27);
            this.txtSearchVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchVendor.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtSearchVendor.Location = new System.Drawing.Point(189, 3);
            this.txtSearchVendor.Name = "txtSearchVendor";
            this.txtSearchVendor.Size = new System.Drawing.Size(181, 27);
            this.txtSearchVendor.TabIndex = 3;
            this.txtSearchVendor.TextChanged += new System.EventHandler(this.txtSearchVendor_TextChanged);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.tableLayoutPanel11);
            this.panel15.Controls.Add(this.tableLayoutPanel12);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1082, 48);
            this.panel15.TabIndex = 0;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.label29, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(964, 48);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(3, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(958, 48);
            this.label29.TabIndex = 0;
            this.label29.Text = "Vendor List";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Controls.Add(this.btnVendorRefresh, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.btnAddVendor, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(964, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(118, 48);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // btnVendorRefresh
            // 
            this.btnVendorRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnVendorRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVendorRefresh.FlatAppearance.BorderSize = 0;
            this.btnVendorRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendorRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnVendorRefresh.Image")));
            this.btnVendorRefresh.Location = new System.Drawing.Point(62, 3);
            this.btnVendorRefresh.Name = "btnVendorRefresh";
            this.btnVendorRefresh.Size = new System.Drawing.Size(53, 42);
            this.btnVendorRefresh.TabIndex = 1;
            this.btnVendorRefresh.UseVisualStyleBackColor = false;
            this.btnVendorRefresh.Click += new System.EventHandler(this.btnVendorRefresh_Click);
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnAddVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddVendor.FlatAppearance.BorderSize = 0;
            this.btnAddVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVendor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVendor.Image")));
            this.btnAddVendor.Location = new System.Drawing.Point(3, 3);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(53, 42);
            this.btnAddVendor.TabIndex = 0;
            this.btnAddVendor.UseVisualStyleBackColor = false;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // tabCategory
            // 
            this.tabCategory.Image = null;
            this.tabCategory.ImageSize = new System.Drawing.Size(16, 16);
            this.tabCategory.Location = new System.Drawing.Point(0, 28);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.ShowCloseButton = false;
            this.tabCategory.Size = new System.Drawing.Size(1082, 645);
            this.tabCategory.TabIndex = 2;
            this.tabCategory.Text = "Category";
            this.tabCategory.ThemesEnabled = false;
            // 
            // tabStock
            // 
            this.tabStock.Image = null;
            this.tabStock.ImageSize = new System.Drawing.Size(16, 16);
            this.tabStock.Location = new System.Drawing.Point(0, 28);
            this.tabStock.Name = "tabStock";
            this.tabStock.ShowCloseButton = false;
            this.tabStock.Size = new System.Drawing.Size(1082, 645);
            this.tabStock.TabIndex = 4;
            this.tabStock.Text = "Stock Adjustment";
            this.tabStock.ThemesEnabled = false;
            // 
            // dgvVendor
            // 
            this.dgvVendor.AllowUserToAddRows = false;
            this.dgvVendor.AllowUserToDeleteRows = false;
            this.dgvVendor.AllowUserToResizeRows = false;
            this.dgvVendor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvVendor.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvVendor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVendor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendor.EnableHeadersVisualStyles = false;
            this.dgvVendor.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvVendor.Location = new System.Drawing.Point(0, 0);
            this.dgvVendor.MultiSelect = false;
            this.dgvVendor.Name = "dgvVendor";
            this.dgvVendor.ReadOnly = true;
            this.dgvVendor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVendor.RowHeadersVisible = false;
            this.dgvVendor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvVendor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendor.Size = new System.Drawing.Size(1082, 524);
            this.dgvVendor.TabIndex = 0;
            this.dgvVendor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvVendor_CellFormatting);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "Inventory";
            this.Size = new System.Drawing.Size(1102, 693);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabVendor.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchVendor)).EndInit();
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabProduct;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabCategory;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabVendor;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabStock;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btnVendorPrev;
        private System.Windows.Forms.Button btnVendorNext;
        private System.Windows.Forms.Label lblVendorCurrentPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Button btnVendorRefresh;
        private System.Windows.Forms.Button btnAddVendor;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearchVendor;
        private System.Windows.Forms.ComboBox cbVendorEntries;
        private System.Windows.Forms.DataGridView dgvVendor;
    }
}
