namespace LANMonitor
{
    partial class SettingsForm
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
            this.InterfaceSelectCB = new System.Windows.Forms.ComboBox();
            this.InterfaceSelectLbl = new System.Windows.Forms.Label();
            this.RefreshLbl = new System.Windows.Forms.Label();
            this.RefreshTB = new System.Windows.Forms.TextBox();
            this.Separator = new System.Windows.Forms.Label();
            this.ScanLimitLbl = new System.Windows.Forms.Label();
            this.ScanLimitTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InterfaceSelectCB
            // 
            this.InterfaceSelectCB.FormattingEnabled = true;
            this.InterfaceSelectCB.Location = new System.Drawing.Point(8, 38);
            this.InterfaceSelectCB.Name = "InterfaceSelectCB";
            this.InterfaceSelectCB.Size = new System.Drawing.Size(333, 21);
            this.InterfaceSelectCB.TabIndex = 0;
            // 
            // InterfaceSelectLbl
            // 
            this.InterfaceSelectLbl.AutoSize = true;
            this.InterfaceSelectLbl.Location = new System.Drawing.Point(8, 9);
            this.InterfaceSelectLbl.Name = "InterfaceSelectLbl";
            this.InterfaceSelectLbl.Size = new System.Drawing.Size(52, 13);
            this.InterfaceSelectLbl.TabIndex = 1;
            this.InterfaceSelectLbl.Text = "Interface:";
            // 
            // RefreshLbl
            // 
            this.RefreshLbl.AutoSize = true;
            this.RefreshLbl.Location = new System.Drawing.Point(5, 91);
            this.RefreshLbl.Name = "RefreshLbl";
            this.RefreshLbl.Size = new System.Drawing.Size(136, 13);
            this.RefreshLbl.TabIndex = 2;
            this.RefreshLbl.Text = "Refresh Interval (Seconds):";
            // 
            // RefreshTB
            // 
            this.RefreshTB.Location = new System.Drawing.Point(8, 118);
            this.RefreshTB.Name = "RefreshTB";
            this.RefreshTB.Size = new System.Drawing.Size(330, 20);
            this.RefreshTB.TabIndex = 3;
            // 
            // Separator
            // 
            this.Separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Separator.Location = new System.Drawing.Point(8, 72);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(336, 2);
            this.Separator.TabIndex = 4;
            // 
            // ScanLimitLbl
            // 
            this.ScanLimitLbl.AutoSize = true;
            this.ScanLimitLbl.Location = new System.Drawing.Point(8, 174);
            this.ScanLimitLbl.Name = "ScanLimitLbl";
            this.ScanLimitLbl.Size = new System.Drawing.Size(171, 13);
            this.ScanLimitLbl.TabIndex = 5;
            this.ScanLimitLbl.Text = "Limit Number of Devices Scanned:";
            // 
            // ScanLimitTB
            // 
            this.ScanLimitTB.Location = new System.Drawing.Point(8, 201);
            this.ScanLimitTB.Name = "ScanLimitTB";
            this.ScanLimitTB.Size = new System.Drawing.Size(330, 20);
            this.ScanLimitTB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(8, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(336, 2);
            this.label4.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(357, 487);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ScanLimitTB);
            this.Controls.Add(this.ScanLimitLbl);
            this.Controls.Add(this.Separator);
            this.Controls.Add(this.RefreshTB);
            this.Controls.Add(this.RefreshLbl);
            this.Controls.Add(this.InterfaceSelectLbl);
            this.Controls.Add(this.InterfaceSelectCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox InterfaceSelectCB;
        private System.Windows.Forms.Label InterfaceSelectLbl;
        private System.Windows.Forms.Label RefreshLbl;
        private System.Windows.Forms.TextBox RefreshTB;
        private System.Windows.Forms.Label Separator;
        private System.Windows.Forms.Label ScanLimitLbl;
        private System.Windows.Forms.TextBox ScanLimitTB;
        private System.Windows.Forms.Label label4;
    }
}