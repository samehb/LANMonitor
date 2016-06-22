using System;
using System.Collections.Generic;
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
        void LoadAppValues() // Load settings and devices cache from the database.
        {
            LoadSettingsDB();
            if (ColumnOrder != "")
                SetColumnSetting();
            LoadMACDB();
        }

        void LoadSettingsDB() // Load settings from the database.
        {
            SQLiteConnection sqlitedbc = new SQLiteConnection("Data Source=LANMonitor.db;Version=3;");
            sqlitedbc.Open();

            string sqlcmd = "select * from settings limit 1";
            SQLiteCommand command = new SQLiteCommand(sqlcmd, sqlitedbc);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SelectedInterfaceName = reader["interface"].ToString();
                ExcludedList = reader["excluded"].ToString();
                RefreshTime = int.Parse(reader["refresh"].ToString());
                ScanLimit = int.Parse(reader["slimit"].ToString());
                ColumnOrder = reader["gvcolsort"].ToString();
            }

            sqlitedbc.Close();
        }

        void LoadMACDB() // Load previous devices from the database.
        {
            SQLiteConnection sqlitedbc = new SQLiteConnection("Data Source=LANMonitor.db;Version=3;");
            sqlitedbc.Open();
            string sqlcmd = "select * from devices";
            SQLiteCommand command = new SQLiteCommand(sqlcmd, sqlitedbc);
            SQLiteDataReader reader = command.ExecuteReader();

            macc = new Dictionary<string, string>();
            while (reader.Read())
            {
                macc.Add(reader["MAC"].ToString(), "N/A" + ";" + reader["Host"].ToString() + ";" + reader["MAC"].ToString() + ";" + "Offline" + ";" + reader["InterfaceVendor"].ToString());
                Vendors[reader["MAC"].ToString()] = reader["InterfaceVendor"].ToString();
                FirstSeenList.Add(reader["MAC"].ToString(), reader["FirstSeen"].ToString());
                LastSeenList.Add(reader["MAC"].ToString(), reader["LastSeen"].ToString());
                Descriptions.Add(reader["MAC"].ToString(), reader["Description"].ToString());
            }

            sqlitedbc.Close();
        }

        void SaveAppValues() // Save settings and devices into the database.
        {
            GetColumnSetting();
            SaveSettingsDB();
            SaveMACDB();
        }

        void SaveSettingsDB() // Insert settings into the database.
        {
            SQLiteConnection sqlitedbc = new SQLiteConnection("Data Source=LANMonitor.db;Version=3;");
            sqlitedbc.Open();

            string sqlcmd = "delete from settings";
            SQLiteCommand command = new SQLiteCommand(sqlcmd, sqlitedbc);
            command.ExecuteNonQuery();

            string sqlargs = "'" + SelectedInterfaceName + "','" + ExcludedList + "'," + RefreshTime + "," + ScanLimit + ",'" + ColumnOrder + "'";
            sqlcmd = "insert into settings (interface,excluded,refresh,slimit,gvcolsort) values (" + sqlargs + ")";
            command = new SQLiteCommand(sqlcmd, sqlitedbc);
            command.ExecuteNonQuery();

            sqlitedbc.Close();
        }

        void SaveMACDB() // Insert loaded devices into the database.
        {
            SQLiteConnection sqlitedbc = new SQLiteConnection("Data Source=LANMonitor.db;Version=3;");
            sqlitedbc.Open();

            string sqlcmd = "delete from devices";
            SQLiteCommand command = new SQLiteCommand(sqlcmd, sqlitedbc);
            command.ExecuteNonQuery();

            string sqlargs;
            string mac = "";

            foreach (DataGridViewRow row in LANDevicesList.Rows)
            {
                mac = row.Cells["MAC"].Value.ToString();
                if (mac != SelectedInterface.MAC)
                {
                    sqlargs = "'" + row.Cells["Host"].Value + "','" + mac + "','" + FirstSeenList[mac] + "','" + LastSeenList[mac] + "','" + Descriptions[mac] + "','" + Vendors[mac] + "'";
                    sqlcmd = "insert into devices (Host, MAC, FirstSeen, LastSeen, Description, InterfaceVendor) values (" + sqlargs + ")";
                    command = new SQLiteCommand(sqlcmd, sqlitedbc);
                    command.ExecuteNonQuery();
                }
            }

            sqlitedbc.Close();
        }

        private void GetColumnSetting() // Get column ordering from gridview to be stored in the database.
        {
            ColumnOrder = "";
            for (int i = 0; i < LANDevicesList.Columns.Count; i++)
            {
                ColumnOrder += LANDevicesList.Columns[i].DisplayIndex.ToString() + ",";
            }
            ColumnOrder = ColumnOrder.TrimEnd(',');
        }

        private void SetColumnSetting() // Set column ordering to the gridview after getting it from the database.
        {
            string[] ColumnEntries = ColumnOrder.Split(',');
            for (int i = 0; i < ColumnEntries.Count(); i++)
            {
                LANDevicesList.Columns[i].DisplayIndex = Convert.ToInt32(ColumnEntries[i]);
            }
        }
    }
}
