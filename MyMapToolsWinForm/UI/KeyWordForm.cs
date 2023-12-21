using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapToolsWinForm
{
    public partial class KeyWordForm : Form
    {
        public KeyWordForm()
        {
            InitializeComponent();
        }

        private void buttonChack_Click(object sender, EventArgs e)
        {
            Chack();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            TerminalMapLib.TerminalMapTool.Chack(textBoxKeyWord.Text);
            Properties.Settings.Default.Setting_key_word = textBoxKeyWord.Text;
            Properties.Settings.Default.Save();
            Chack();
        }

        private void Chack()
        {
            if (TerminalMapLib.TerminalMapTool.IsChack())
            {
                MessageBox.Show("口令OK");
            }
            else
            {
                MessageBox.Show("口令Fail");
            }
        }
    }
}
