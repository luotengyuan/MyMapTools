using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonTools;
using TerminalMapLib;

namespace MapToolsWinForm
{
    public partial class Form_display_info : Form
    {
        public TerminalMapDisplayInfo displayInfo;
        public Form_display_info(TerminalMapDisplayInfo displayInfo)
        {
            InitializeComponent();
            this.displayInfo = displayInfo;
            InitUI();
        }

        private void InitUI()
        {
            if (displayInfo == null)
            {
                displayInfo = new TerminalMapDisplayInfo(false, false, Color.Red, WeithType.MAX, true, Color.Black, WeithType.MAX);
            }
            // 边界
            cb_is_show_boundary.Checked = displayInfo.IsShowBoundary;

            // 路网
            cb_is_show_road.Checked = displayInfo.IsShowRoad;
            btn_road_color.BackColor = displayInfo.RoadColor;
            if (displayInfo.RoadDisplayType == DisplayType.STANDARD)
            {
                cb_road_display_type.SelectedIndex = 0;
            }
            else if (displayInfo.RoadDisplayType == DisplayType.CUSTOM)
            {
                cb_road_display_type.SelectedIndex = 1;
            }
            else
            {
                cb_road_display_type.SelectedIndex = 2;
            }
            if (displayInfo.RoadType == WeithType.MAX)
            {
                cb_road_weith_type.SelectedIndex = 0;
            }
            else if (displayInfo.RoadType == WeithType.MID)
            {
                cb_road_weith_type.SelectedIndex = 1;
            }
            else
            {
                cb_road_weith_type.SelectedIndex = 2;
            }
            int i = 0;
            foreach (RType rTpye in Enum.GetValues(typeof(RType)))
            {
                clb_road_display_type.Items.Add((int)rTpye + ":" + rTpye);
                if (displayInfo.RoadShowTag[i])
                {
                    clb_road_display_type.SetItemChecked(i, true);
                }
                else
                {
                    clb_road_display_type.SetItemChecked(i, false);
                }
                i++;
            }

            // ADAS
            cb_is_show_adas.Checked = displayInfo.IsShowAdas;
            btn_adas_color.BackColor = displayInfo.AdasColor;
            if (displayInfo.AdasDisplayType == DisplayType.STANDARD)
            {
                cb_adas_display_type.SelectedIndex = 0;
            }
            else if (displayInfo.AdasDisplayType == DisplayType.CUSTOM)
            {
                cb_adas_display_type.SelectedIndex = 1;
            }
            else
            {
                cb_adas_display_type.SelectedIndex = 2;
            }
            if (displayInfo.AdasType == WeithType.MAX)
            {
                cb_adas_weith_type.SelectedIndex = 0;
            }
            else if (displayInfo.AdasType == WeithType.MID)
            {
                cb_adas_weith_type.SelectedIndex = 1;
            }
            else
            {
                cb_adas_weith_type.SelectedIndex = 2;
            }
            i = 0;
            foreach (PType pTpye in Enum.GetValues(typeof(PType)))
            {
                clb_adas_display_type.Items.Add((int)pTpye + ":" + pTpye);
                if (displayInfo.AdasShowTag[i])
                {
                    clb_adas_display_type.SetItemChecked(i, true);
                }
                else
                {
                    clb_adas_display_type.SetItemChecked(i, false);
                }
                i++;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cb_is_show_boundary_CheckedChanged(object sender, EventArgs e)
        {
            displayInfo.IsShowBoundary = cb_is_show_boundary.Checked;
        }

        private void cb_is_show_road_CheckedChanged(object sender, EventArgs e)
        {
            displayInfo.IsShowRoad = cb_is_show_road.Checked;
        }

        private void cb_is_show_adas_CheckedChanged(object sender, EventArgs e)
        {
            displayInfo.IsShowAdas = cb_is_show_adas.Checked;
        }

        private void cb_road_weith_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_road_weith_type.SelectedIndex == 0)
            {
                displayInfo.RoadType = WeithType.MAX;
            }
            else if (cb_road_weith_type.SelectedIndex == 1)
            {
                displayInfo.RoadType = WeithType.MID;
            }
            else
            {
                displayInfo.RoadType = WeithType.MIN;
            }
        }

        private void cb_adas_weith_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_adas_weith_type.SelectedIndex == 0)
            {
                displayInfo.AdasType = WeithType.MAX;
            }
            else if (cb_adas_weith_type.SelectedIndex == 1)
            {
                displayInfo.AdasType = WeithType.MID;
            }
            else
            {
                displayInfo.AdasType = WeithType.MIN;
            }
        }

        private void btn_road_color_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                Color GetColor = ColorForm.Color;
                //GetColor就是用户选择的颜色，接下来就可以使用该颜色了
                btn_road_color.BackColor = GetColor;
                displayInfo.RoadColor = GetColor;
            }
        }

        private void btn_adas_color_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                Color GetColor = ColorForm.Color;
                //GetColor就是用户选择的颜色，接下来就可以使用该颜色了
                btn_adas_color.BackColor = GetColor;
                displayInfo.AdasColor = GetColor;
            }
        }

        private void clb_road_display_type_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            displayInfo.RoadShowTag[e.Index] = e.NewValue == CheckState.Checked;
        }

        private void clb_adas_display_type_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            displayInfo.AdasShowTag[e.Index] = e.NewValue == CheckState.Checked;
        }

        private void cb_road_display_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_road_display_type.SelectedIndex == 0)
            {
                displayInfo.RoadDisplayType = DisplayType.STANDARD;
                cb_road_weith_type.Enabled = false;
                btn_road_color.Enabled = false;
            }
            else if (cb_road_display_type.SelectedIndex == 1)
            {
                displayInfo.RoadDisplayType = DisplayType.CUSTOM;
                cb_road_weith_type.Enabled = true;
                btn_road_color.Enabled = true;
            }
            else
            {
                displayInfo.RoadDisplayType = DisplayType.ARROW;
                cb_road_weith_type.Enabled = false;
                btn_road_color.Enabled = true;
            }
        }

        private void cb_adas_display_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_adas_display_type.SelectedIndex == 0)
            {
                displayInfo.AdasDisplayType = DisplayType.STANDARD;
                cb_adas_weith_type.Enabled = false;
                btn_adas_color.Enabled = false;
            }
            else if (cb_adas_display_type.SelectedIndex == 1)
            {
                displayInfo.AdasDisplayType = DisplayType.CUSTOM;
                cb_adas_weith_type.Enabled = true;
                btn_adas_color.Enabled = true;
            }
            else
            {
                displayInfo.AdasDisplayType = DisplayType.ARROW;
                cb_adas_weith_type.Enabled = false;
                btn_adas_color.Enabled = false;
            }
        }
    }
}
