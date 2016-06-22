using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANMonitor
{
    public partial class SettingsForm : Form
    {
        public int ScanLimit { get; set; }
        public string SelectedInterfaceName { get; set; }
        public string InterfacesString { get; set; }
        public int RefreshTime { get; set; }

        //public Interfaces;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] interfaces = InterfacesString.TrimEnd(';').Split(';');
            InterfaceSelectCB.Items.AddRange(interfaces);
            InterfaceSelectCB.SelectedIndex = InterfaceSelectCB.FindString(SelectedInterfaceName + "|");
            RefreshTB.Text = RefreshTime.ToString();
            ScanLimitTB.Text = ScanLimit.ToString();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelectedInterfaceName = InterfaceSelectCB.Text.Split('|')[0];
            int temp;
            if (int.TryParse(ScanLimitTB.Text, out temp))
                ScanLimit = temp > 254 ? ScanLimit : temp;
            if (int.TryParse(RefreshTB.Text, out temp))
                RefreshTime = temp;
        }
    }
}
