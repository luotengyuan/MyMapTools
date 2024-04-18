using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapToolsWinForm
{
    public partial class Form_load_copy : Form
    {
        public string content = null;
        public Form_load_copy()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string temp = tb_load_copy_content.Text;
            if (string.IsNullOrWhiteSpace(temp))
            {
                MyMessageBox.ShowTipMessage("加载内容为空");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                this.Close();
            }
            else
            {
                content = temp;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Close();
        }
    }
}
