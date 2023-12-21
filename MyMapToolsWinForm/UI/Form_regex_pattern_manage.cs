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
    public partial class Form_regex_pattern_manage : Form
    {
        List<string> mRegexPatternList = new List<string>();
        bool isModify = false;

        public bool IsModify
        {
            get { return isModify; }
            set { isModify = value; }
        }

        public Form_regex_pattern_manage(List<string> patternList)
        {
            InitializeComponent();
            this.mRegexPatternList = patternList;
        }

        private void Form_regex_pattern_manage_Load(object sender, EventArgs e)
        {
            if (mRegexPatternList == null)
            {
                MessageBox.Show("传入的正则表达式为空");
                this.Close();
                return;
            }
            InitUI();
        }

        private void InitUI()
        {
            foreach (var item in mRegexPatternList)
            {
                clb_pattern_list.Items.Add(item, false);
            }
        }

        private void btn_pattern_add_Click(object sender, EventArgs e)
        {
            string pattern_add = tb_pattern_add.Text;
            if (string.IsNullOrWhiteSpace(pattern_add))
            {
                MessageBox.Show("请输入正则表达式");
                return;
            }
            clb_pattern_list.Items.Add(pattern_add, false);
            mRegexPatternList.Add(pattern_add);
        }

        private void btn_pattern_del_Click(object sender, EventArgs e)
        {
            if (clb_pattern_list.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中正则表达式");
                return;
            }
            for (int i = clb_pattern_list.Items.Count - 1; i > -1; i--)
            {
                if (clb_pattern_list.GetItemChecked(i))
                {
                    clb_pattern_list.Items.RemoveAt(i);
                    mRegexPatternList.RemoveAt(i);
                }
            }
            isModify = true;
        }

        private void btn_pattern_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
