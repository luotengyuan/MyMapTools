using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.MapProviders;

namespace MapToolsWinForm
{
    public partial class ProxyForm : Form
    {
        public ProxyForm()
        {
            InitializeComponent();
            this.checkBoxProxy.Checked = GMapProvider.IsSocksProxy;
            this.textBoxIP.Text = "127.0.0.1";
            this.textBoxPort.Text = "1080";
        }

        public string GetProxyIp()
        {
            return this.textBoxIP.Text.Trim();
        }

        public int GetProxyPort()
        {
            return int.Parse(this.textBoxPort.Text.Trim());
        }

        public bool CheckProxyOn()
        {
            return this.checkBoxProxy.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
