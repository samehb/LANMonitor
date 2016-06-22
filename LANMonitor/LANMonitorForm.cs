using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Data.SQLite;

namespace LANMonitor
{
    public partial class LANMonitorForm : Form
    {
        bool BalloonVisible = false;
        bool ContextMenuVisible = false;
        public LANMonitorForm()
        {
            InitializeComponent();
            LoadAppValues(); // Load settings and devices cache from the database.
            GetInterfaces(); // Get network interfaces and pick the main or selected one.
        }

        private void LANMonitorForm_Resize(object sender, EventArgs e) // Minimize to tray.
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                LANMonitorNotify.ShowBalloonTip(3000, "LANMonitor", "LANMonitor is hidden, left click this icon to maximize.", ToolTipIcon.Info);  
            }
        }

        private void MenuFileSave_Click(object sender, EventArgs e) // Export the gridview values into a textbox.
        {
            SaveFileDialog file = new SaveFileDialog();
            file.FileName = "devices.txt";
            file.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (file.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(file.FileName))
                {
                    string mac = "";
                    sw.WriteLine("Host, MAC, FirstSeen, LastSeen, Description, InterfaceVendor");
                    foreach (DataGridViewRow row in LANDevicesList.Rows)
                    {
                        mac = row.Cells["MAC"].Value.ToString();
                        if (mac != SelectedInterface.MAC)
                            sw.WriteLine(row.Cells["Host"].Value + ", " + mac + ", " + FirstSeenList[mac] + ", " + LastSeenList[mac] + ", " + Descriptions[mac] + ", " + Vendors[mac]);
                    }
                }
            }

        }

        private void MenuFileExit_Click(object sender, EventArgs e) // Close the form from main menu.
        {
            Close();
        }

        private void TrayMenuOpen_Click(object sender, EventArgs e) // Open from tray icon.
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void TrayMenuExit_Click(object sender, EventArgs e) // Exit from tray icon.
        {
            Close();
        }

        private void LANMonitorForm_Load(object sender, EventArgs e)
        {
            LMStatusText.Text = "Scanning the devices for the first time, please wait.";
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MonitorNetwork(); // Monitor network for devices and handle them.
        }

        private void RefreshDevicesTimer_Tick(object sender, EventArgs e) // Refresh devices information by calling MonitorNetwork with the default or specified value.
        {
            if (!BackgroundWorker.IsBusy)
                BackgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0) // Display the devices for the first time.
            {
                DisplayDevices();
                LMStatusText.Text = "";
            }
            else if (e.ProgressPercentage == 1) // Display the devices after the first time handling the updates.
                DisplayDevicesUpdates();
            else
                ClearGUI(); // (2) - Clear the GUI and the reset the database.
        }

        private void LANDevicesList_MouseUp(object sender, MouseEventArgs e) // Prevent ordering of the the last column.
        {
            if ((LANDevicesList.Columns[8].Index == 8) && (LANDevicesList.Columns[8].DisplayIndex != 8))
                LANDevicesList.Columns[8].DisplayIndex = 8;
        }

        private void LANDevicesList_CellContentClick(object sender, DataGridViewCellEventArgs e) // Handle clicking the Notify checkboxes to allow or deny balloon notifications for the device. 
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 8)
                {
                    if (LANDevicesList.IsCurrentCellDirty) // This is needed to commit the new value of the Checkbox.
                        LANDevicesList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    if ((bool)LANDevicesList.Rows[e.RowIndex].Cells["Notify"].Value == true)
                        ExcludedList = ExcludedList.Replace(LANDevicesList.Rows[e.RowIndex].Cells["Host"].Value + ";", "");
                    else
                        ExcludedList += LANDevicesList.Rows[e.RowIndex].Cells["Host"].Value + ";";
                }
            }
        }

        private void LANDevicesList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) // Allow copying the cell value into the clipboard when you right click.
        {
            if(e.Button == MouseButtons.Right)
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(LANDevicesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), true);
                }
                catch
                {

                }
            }
        }

        private void LANDevicesList_SortCompare(object sender, DataGridViewSortCompareEventArgs e) // Sort the grid by columns.
        {
            if (e.Column.Index == 0)
            {
                Int64 a = Int64.Parse(e.CellValue1.ToString().Replace(".", "").Replace("N/A", "255255255255")); // In order to prepare IP addresses for sorting we remove the dots (.) turning them into numbers then parse them. When the cell does not have an IP address we replace "N/A" with 255255255255.
                Int64 b = Int64.Parse(e.CellValue2.ToString().Replace(".", "").Replace("N/A", "255255255255")); //
                e.SortResult = a.CompareTo(b);
                e.Handled = true;
            }
        }


        private void MenuHelpAbout_Click(object sender, EventArgs e) // Show about form.
        {
            AboutForm AboutWindow = new AboutForm();
            AboutWindow.StartPosition = FormStartPosition.CenterParent;
            AboutWindow.ShowDialog();
        }

        private void MenuToolsSettings_Click(object sender, EventArgs e) // Display settings form.
        {
            SettingsForm SettingsWindow = new SettingsForm();
            SettingsWindow.InterfacesString = InterfacesString;
            SettingsWindow.SelectedInterfaceName = SelectedInterfaceName;
            SettingsWindow.RefreshTime = RefreshTime;
            SettingsWindow.ScanLimit = ScanLimit;
            SettingsWindow.ShowDialog();
            SelectedInterfaceName = SettingsWindow.SelectedInterfaceName;
            RefreshTime = SettingsWindow.RefreshTime;
            ScanLimit = SettingsWindow.ScanLimit;
            RefreshDevicesTimer.Interval = RefreshTime;
        }

        private void LANMonitorForm_FormClosing(object sender, FormClosingEventArgs e) // Save settings on form close
        {
            SaveAppValues();
        }

        private void LANDevicesList_CellEndEdit(object sender, DataGridViewCellEventArgs e) // Allow adding and editing the description column
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    if (LANDevicesList.IsCurrentCellDirty) // This is needed to commit the new value of the cell.
                        LANDevicesList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    string description = LANDevicesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? LANDevicesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : "";


                    Descriptions[LANDevicesList.Rows[e.RowIndex].Cells[2].Value.ToString()] = description;
                }
            }
        }

        private void MenuToolsClearDevices_Click(object sender, EventArgs e) // Allow the devices to be deleted.
        {
            ClearDevices = true;
        }

        private void MenuToolsClearIF_Click(object sender, EventArgs e) // Flush the ARP cache for the interface.
        {
            FlushARPCache();
        }

        void ClearGUI() // Fully clear the GUI and the reset the database.
        {
            ColumnOrder = "0,1,2,3,4,5,6,7,8";
            SetColumnSetting();

            SQLiteConnection sqlitedbc = new SQLiteConnection("Data Source=LANMonitor.db;Version=3;");
            sqlitedbc.Open();

            string sqlcmd = "delete from settings";
            SQLiteCommand command = new SQLiteCommand(sqlcmd, sqlitedbc);
            command.ExecuteNonQuery();

            sqlcmd = "delete from devices";
            command = new SQLiteCommand(sqlcmd, sqlitedbc);
            command.ExecuteNonQuery();

            sqlitedbc.Close();

            LANDevicesList.Rows.Clear();
        }

        private void LANDevicesList_Sorted(object sender, EventArgs e)
        {
            GVList = new Dictionary<string,int>();
            int counter = 0;
            foreach (DataGridViewRow row in LANDevicesList.Rows)
            {
                GVList.Add(row.Cells["MAC"].Value.ToString(), counter);
                counter++;
            }
        }

        private void LANDevicesList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // Handle coloring for Status column cell values.
        {
            if (LANDevicesList.Rows[e.RowIndex].Cells[7].Value != null && !string.IsNullOrWhiteSpace(LANDevicesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) && LANDevicesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Online")
            {
                LANDevicesList.Rows[e.RowIndex].Cells[7].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
            }
            else
            {
                LANDevicesList.Rows[e.RowIndex].Cells[7].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
        }


        private void LANMonitorNotify_MouseMove(object sender, MouseEventArgs e) // Display the connected devices on mouse over the tray icon.
        {
            if (Connected != "" && !BalloonVisible && !ContextMenuVisible) // Only display devices when Connected has a value, no balloon tips are visible, and the notify icon contextmenu is closed.
                LANMonitorNotify.ShowBalloonTip(3000, "LANMonitor", "Connected: " + Connected, ToolTipIcon.Info);
        }

        private void LANMonitorNotify_BalloonTipShown(object sender, EventArgs e) // BalloonVisible is used to control displaying the tip from the previous block. It acts as enabler to allow the connected devices value to be displayed only when there are no tips displayed. This is done to reduce/prevent the flickering effect.
        {
            BalloonVisible = true;
        }

        private void LANMonitorNotify_BalloonTipClosed(object sender, EventArgs e)
        {
            BalloonVisible = false;
        }

        private void LANMonitorNotify_BalloonTipClicked(object sender, EventArgs e)
        {
            BalloonVisible = false;
        }

        private void LANMonitorNotify_MouseClick(object sender, MouseEventArgs e) // Handle clicks on notifyicon contextmenu.
        {
            if (e.Button == MouseButtons.Left) // On left click maximize the form.
            {
                this.Show();
                WindowState = FormWindowState.Normal;
            }
            else if (e.Button == MouseButtons.Right) // On right click show the context menu. ContextMenuVisible is used in combination with BalloonVisible to control displaying the connected devices. In other words, we do not want those specific notifications to be displayed when the menu is visible.
            {
                ContextMenuVisible = true;
                LANMonitorNotify.Visible = false;
                LANMonitorNotify.Visible = true;
            }
        }

        private void LANMonitorStausMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e) // Allow connected devices notification to be displayed after closing the contextmenu.
        {
            ContextMenuVisible = false;
        }
    }
}
