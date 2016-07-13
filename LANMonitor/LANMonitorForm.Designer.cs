namespace LANMonitor
{
    partial class LANMonitorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LANMonitorForm));
            this.LANDevicesList = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LANMonitorNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.LANMonitorStausMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.RefreshDevicesTimer = new System.Windows.Forms.Timer(this.components);
            this.LMStatusbar = new System.Windows.Forms.StatusStrip();
            this.LMStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.LMMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsClearDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsClearIF = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.LANDevicesList)).BeginInit();
            this.LANMonitorStausMenu.SuspendLayout();
            this.LMStatusbar.SuspendLayout();
            this.LMMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LANDevicesList
            // 
            this.LANDevicesList.AllowUserToAddRows = false;
            this.LANDevicesList.AllowUserToDeleteRows = false;
            this.LANDevicesList.AllowUserToOrderColumns = true;
            this.LANDevicesList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LANDevicesList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LANDevicesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LANDevicesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LANDevicesList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LANDevicesList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LANDevicesList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.LANDevicesList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LANDevicesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LANDevicesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LANDevicesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Host,
            this.MAC,
            this.FirstSeen,
            this.LastSeen,
            this.Description,
            this.Vendor,
            this.Status,
            this.Notify});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LANDevicesList.DefaultCellStyle = dataGridViewCellStyle11;
            this.LANDevicesList.Location = new System.Drawing.Point(12, 27);
            this.LANDevicesList.MultiSelect = false;
            this.LANDevicesList.Name = "LANDevicesList";
            this.LANDevicesList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LANDevicesList.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.LANDevicesList.RowHeadersVisible = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LANDevicesList.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.LANDevicesList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LANDevicesList.RowTemplate.DividerHeight = 1;
            this.LANDevicesList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LANDevicesList.Size = new System.Drawing.Size(1079, 257);
            this.LANDevicesList.TabIndex = 3;
            this.LANDevicesList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LANDevicesList_CellContentClick);
            this.LANDevicesList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.LANDevicesList_CellEndEdit);
            this.LANDevicesList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.LANDevicesList_CellFormatting);
            this.LANDevicesList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LANDevicesList_CellMouseClick);
            this.LANDevicesList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.LANDevicesList_SortCompare);
            this.LANDevicesList.Sorted += new System.EventHandler(this.LANDevicesList_Sorted);
            this.LANDevicesList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LANDevicesList_MouseUp);
            // 
            // IP
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IP.DefaultCellStyle = dataGridViewCellStyle3;
            this.IP.DividerWidth = 1;
            this.IP.HeaderText = "   IP";
            this.IP.MinimumWidth = 100;
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // Host
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Host.DefaultCellStyle = dataGridViewCellStyle4;
            this.Host.DividerWidth = 1;
            this.Host.FillWeight = 153F;
            this.Host.HeaderText = "   Host";
            this.Host.MinimumWidth = 153;
            this.Host.Name = "Host";
            this.Host.ReadOnly = true;
            // 
            // MAC
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MAC.DefaultCellStyle = dataGridViewCellStyle5;
            this.MAC.DividerWidth = 1;
            this.MAC.FillWeight = 123F;
            this.MAC.HeaderText = "   MAC";
            this.MAC.MinimumWidth = 123;
            this.MAC.Name = "MAC";
            this.MAC.ReadOnly = true;
            // 
            // FirstSeen
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FirstSeen.DefaultCellStyle = dataGridViewCellStyle6;
            this.FirstSeen.DividerWidth = 1;
            this.FirstSeen.FillWeight = 122F;
            this.FirstSeen.HeaderText = "   First Seen";
            this.FirstSeen.MinimumWidth = 122;
            this.FirstSeen.Name = "FirstSeen";
            this.FirstSeen.ReadOnly = true;
            // 
            // LastSeen
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LastSeen.DefaultCellStyle = dataGridViewCellStyle7;
            this.LastSeen.DividerWidth = 1;
            this.LastSeen.FillWeight = 123F;
            this.LastSeen.HeaderText = "   Last Seen";
            this.LastSeen.MinimumWidth = 123;
            this.LastSeen.Name = "LastSeen";
            this.LastSeen.ReadOnly = true;
            // 
            // Description
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Description.DefaultCellStyle = dataGridViewCellStyle8;
            this.Description.DividerWidth = 1;
            this.Description.FillWeight = 102F;
            this.Description.HeaderText = "    Description";
            this.Description.MinimumWidth = 102;
            this.Description.Name = "Description";
            // 
            // Vendor
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Vendor.DefaultCellStyle = dataGridViewCellStyle9;
            this.Vendor.DividerWidth = 1;
            this.Vendor.FillWeight = 180F;
            this.Vendor.HeaderText = "   Interface Vendor";
            this.Vendor.MinimumWidth = 180;
            this.Vendor.Name = "Vendor";
            this.Vendor.ReadOnly = true;
            // 
            // Status
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle10;
            this.Status.DividerWidth = 1;
            this.Status.FillWeight = 102F;
            this.Status.HeaderText = "    Status";
            this.Status.MinimumWidth = 102;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Notify
            // 
            this.Notify.FillWeight = 30F;
            this.Notify.HeaderText = "*";
            this.Notify.MinimumWidth = 30;
            this.Notify.Name = "Notify";
            this.Notify.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Notify.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LANMonitorNotify
            // 
            this.LANMonitorNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.LANMonitorNotify.ContextMenuStrip = this.LANMonitorStausMenu;
            this.LANMonitorNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("LANMonitorNotify.Icon")));
            this.LANMonitorNotify.Visible = true;
            this.LANMonitorNotify.BalloonTipClicked += new System.EventHandler(this.LANMonitorNotify_BalloonTipClicked);
            this.LANMonitorNotify.BalloonTipClosed += new System.EventHandler(this.LANMonitorNotify_BalloonTipClosed);
            this.LANMonitorNotify.BalloonTipShown += new System.EventHandler(this.LANMonitorNotify_BalloonTipShown);
            this.LANMonitorNotify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LANMonitorNotify_MouseClick);
            this.LANMonitorNotify.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LANMonitorNotify_MouseMove);
            // 
            // LANMonitorStausMenu
            // 
            this.LANMonitorStausMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.TrayMenuExit});
            this.LANMonitorStausMenu.Name = "LANMonitorStausMenu";
            this.LANMonitorStausMenu.Size = new System.Drawing.Size(104, 48);
            this.LANMonitorStausMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.LANMonitorStausMenu_Closing);
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(103, 22);
            this.MenuOpen.Text = "Open";
            this.MenuOpen.Click += new System.EventHandler(this.TrayMenuOpen_Click);
            // 
            // TrayMenuExit
            // 
            this.TrayMenuExit.Name = "TrayMenuExit";
            this.TrayMenuExit.Size = new System.Drawing.Size(103, 22);
            this.TrayMenuExit.Text = "Exit";
            this.TrayMenuExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TrayMenuExit.Click += new System.EventHandler(this.TrayMenuExit_Click);
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.WorkerReportsProgress = true;
            this.BackgroundWorker.WorkerSupportsCancellation = true;
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // RefreshDevicesTimer
            // 
            this.RefreshDevicesTimer.Interval = 1000;
            this.RefreshDevicesTimer.Tick += new System.EventHandler(this.RefreshDevicesTimer_Tick);
            // 
            // LMStatusbar
            // 
            this.LMStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LMStatusText});
            this.LMStatusbar.Location = new System.Drawing.Point(0, 297);
            this.LMStatusbar.Name = "LMStatusbar";
            this.LMStatusbar.Size = new System.Drawing.Size(1103, 22);
            this.LMStatusbar.TabIndex = 4;
            // 
            // LMStatusText
            // 
            this.LMStatusText.Name = "LMStatusText";
            this.LMStatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // LMMenu
            // 
            this.LMMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuTools,
            this.MenuHelp});
            this.LMMenu.Location = new System.Drawing.Point(0, 0);
            this.LMMenu.Name = "LMMenu";
            this.LMMenu.Size = new System.Drawing.Size(1103, 24);
            this.LMMenu.TabIndex = 5;
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileSave,
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(37, 20);
            this.MenuFile.Text = "File";
            // 
            // MenuFileSave
            // 
            this.MenuFileSave.Name = "MenuFileSave";
            this.MenuFileSave.Size = new System.Drawing.Size(119, 22);
            this.MenuFileSave.Text = "Save List";
            this.MenuFileSave.Click += new System.EventHandler(this.MenuFileSave_Click);
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(119, 22);
            this.MenuFileExit.Text = "Exit";
            this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // MenuTools
            // 
            this.MenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolsClearDevices,
            this.MenuToolsClearIF,
            this.MenuToolsSettings});
            this.MenuTools.Name = "MenuTools";
            this.MenuTools.Size = new System.Drawing.Size(48, 20);
            this.MenuTools.Text = "Tools";
            // 
            // MenuToolsClearDevices
            // 
            this.MenuToolsClearDevices.Name = "MenuToolsClearDevices";
            this.MenuToolsClearDevices.Size = new System.Drawing.Size(150, 22);
            this.MenuToolsClearDevices.Text = "Clear Devices";
            this.MenuToolsClearDevices.Click += new System.EventHandler(this.MenuToolsClearDevices_Click);
            // 
            // MenuToolsClearIF
            // 
            this.MenuToolsClearIF.Name = "MenuToolsClearIF";
            this.MenuToolsClearIF.Size = new System.Drawing.Size(150, 22);
            this.MenuToolsClearIF.Text = "Clear Interface";
            this.MenuToolsClearIF.Click += new System.EventHandler(this.MenuToolsClearIF_Click);
            // 
            // MenuToolsSettings
            // 
            this.MenuToolsSettings.Name = "MenuToolsSettings";
            this.MenuToolsSettings.Size = new System.Drawing.Size(150, 22);
            this.MenuToolsSettings.Text = "Settings";
            this.MenuToolsSettings.Click += new System.EventHandler(this.MenuToolsSettings_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(44, 20);
            this.MenuHelp.Text = "Help";
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.MenuHelpAbout.Text = "About";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // LANMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 319);
            this.Controls.Add(this.LMStatusbar);
            this.Controls.Add(this.LMMenu);
            this.Controls.Add(this.LANDevicesList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.LMMenu;
            this.MinimumSize = new System.Drawing.Size(1119, 357);
            this.Name = "LANMonitorForm";
            this.Text = "LANMonitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LANMonitorForm_FormClosing);
            this.Load += new System.EventHandler(this.LANMonitorForm_Load);
            this.Resize += new System.EventHandler(this.LANMonitorForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.LANDevicesList)).EndInit();
            this.LANMonitorStausMenu.ResumeLayout(false);
            this.LMStatusbar.ResumeLayout(false);
            this.LMStatusbar.PerformLayout();
            this.LMMenu.ResumeLayout(false);
            this.LMMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView LANDevicesList;
        private System.Windows.Forms.NotifyIcon LANMonitorNotify;
        private System.Windows.Forms.ContextMenuStrip LANMonitorStausMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuExit;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Timer RefreshDevicesTimer;
        private System.Windows.Forms.StatusStrip LMStatusbar;
        private System.Windows.Forms.ToolStripStatusLabel LMStatusText;
        private System.Windows.Forms.MenuStrip LMMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuTools;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem MenuToolsClearDevices;
        private System.Windows.Forms.ToolStripMenuItem MenuToolsClearIF;
        private System.Windows.Forms.ToolStripMenuItem MenuToolsSettings;
        private System.Windows.Forms.ToolStripMenuItem MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Notify;
    }
}

