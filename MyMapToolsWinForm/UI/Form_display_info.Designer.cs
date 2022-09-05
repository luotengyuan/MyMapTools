namespace MapToolsWinForm
{
    partial class Form_display_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_display_info));
            this.cb_is_show_boundary = new System.Windows.Forms.CheckBox();
            this.cb_is_show_road = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_road_display_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_road_weith_type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_road_color = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_adas_display_type = new System.Windows.Forms.ComboBox();
            this.cb_adas_weith_type = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clb_adas_display_type = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_adas_color = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_is_show_adas = new System.Windows.Forms.CheckBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cel = new System.Windows.Forms.Button();
            this.clb_road_display_type = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_is_show_boundary
            // 
            this.cb_is_show_boundary.AutoSize = true;
            this.cb_is_show_boundary.Location = new System.Drawing.Point(15, 20);
            this.cb_is_show_boundary.Name = "cb_is_show_boundary";
            this.cb_is_show_boundary.Size = new System.Drawing.Size(96, 16);
            this.cb_is_show_boundary.TabIndex = 0;
            this.cb_is_show_boundary.Text = "是否显示边界";
            this.cb_is_show_boundary.UseVisualStyleBackColor = true;
            this.cb_is_show_boundary.CheckedChanged += new System.EventHandler(this.cb_is_show_boundary_CheckedChanged);
            // 
            // cb_is_show_road
            // 
            this.cb_is_show_road.AutoSize = true;
            this.cb_is_show_road.Location = new System.Drawing.Point(15, 20);
            this.cb_is_show_road.Name = "cb_is_show_road";
            this.cb_is_show_road.Size = new System.Drawing.Size(96, 16);
            this.cb_is_show_road.TabIndex = 1;
            this.cb_is_show_road.Text = "是否显示路网";
            this.cb_is_show_road.UseVisualStyleBackColor = true;
            this.cb_is_show_road.CheckedChanged += new System.EventHandler(this.cb_is_show_road_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cb_is_show_boundary);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "边界";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cb_road_display_type);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_road_weith_type);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_road_color);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cb_is_show_road);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 143);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "路网";
            // 
            // cb_road_display_type
            // 
            this.cb_road_display_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_road_display_type.FormattingEnabled = true;
            this.cb_road_display_type.Items.AddRange(new object[] {
            "标准",
            "自定义",
            "方向箭头"});
            this.cb_road_display_type.Location = new System.Drawing.Point(98, 45);
            this.cb_road_display_type.Name = "cb_road_display_type";
            this.cb_road_display_type.Size = new System.Drawing.Size(75, 20);
            this.cb_road_display_type.TabIndex = 11;
            this.cb_road_display_type.SelectedIndexChanged += new System.EventHandler(this.cb_road_display_type_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "显示类型:";
            // 
            // cb_road_weith_type
            // 
            this.cb_road_weith_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_road_weith_type.FormattingEnabled = true;
            this.cb_road_weith_type.Items.AddRange(new object[] {
            "大",
            "中",
            "小"});
            this.cb_road_weith_type.Location = new System.Drawing.Point(444, 45);
            this.cb_road_weith_type.Name = "cb_road_weith_type";
            this.cb_road_weith_type.Size = new System.Drawing.Size(75, 20);
            this.cb_road_weith_type.TabIndex = 9;
            this.cb_road_weith_type.SelectedIndexChanged += new System.EventHandler(this.cb_road_weith_type_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "显示大小:";
            // 
            // btn_road_color
            // 
            this.btn_road_color.Location = new System.Drawing.Point(272, 43);
            this.btn_road_color.Name = "btn_road_color";
            this.btn_road_color.Size = new System.Drawing.Size(75, 23);
            this.btn_road_color.TabIndex = 7;
            this.btn_road_color.UseVisualStyleBackColor = true;
            this.btn_road_color.Click += new System.EventHandler(this.btn_road_color_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "显示类型:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "显示颜色:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cb_adas_display_type);
            this.groupBox3.Controls.Add(this.cb_adas_weith_type);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.clb_adas_display_type);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btn_adas_color);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cb_is_show_adas);
            this.groupBox3.Location = new System.Drawing.Point(12, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(898, 311);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ADAS点";
            // 
            // cb_adas_display_type
            // 
            this.cb_adas_display_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_adas_display_type.FormattingEnabled = true;
            this.cb_adas_display_type.Items.AddRange(new object[] {
            "标准",
            "自定义",
            "方向箭头"});
            this.cb_adas_display_type.Location = new System.Drawing.Point(98, 44);
            this.cb_adas_display_type.Name = "cb_adas_display_type";
            this.cb_adas_display_type.Size = new System.Drawing.Size(75, 20);
            this.cb_adas_display_type.TabIndex = 13;
            this.cb_adas_display_type.SelectedIndexChanged += new System.EventHandler(this.cb_adas_display_type_SelectedIndexChanged);
            // 
            // cb_adas_weith_type
            // 
            this.cb_adas_weith_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_adas_weith_type.FormattingEnabled = true;
            this.cb_adas_weith_type.Items.AddRange(new object[] {
            "大",
            "中",
            "小"});
            this.cb_adas_weith_type.Location = new System.Drawing.Point(444, 44);
            this.cb_adas_weith_type.Name = "cb_adas_weith_type";
            this.cb_adas_weith_type.Size = new System.Drawing.Size(75, 20);
            this.cb_adas_weith_type.TabIndex = 13;
            this.cb_adas_weith_type.SelectedIndexChanged += new System.EventHandler(this.cb_adas_weith_type_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "显示类型:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "显示大小:";
            // 
            // clb_adas_display_type
            // 
            this.clb_adas_display_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_adas_display_type.FormattingEnabled = true;
            this.clb_adas_display_type.Location = new System.Drawing.Point(98, 76);
            this.clb_adas_display_type.MultiColumn = true;
            this.clb_adas_display_type.Name = "clb_adas_display_type";
            this.clb_adas_display_type.Size = new System.Drawing.Size(785, 212);
            this.clb_adas_display_type.TabIndex = 11;
            this.clb_adas_display_type.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_adas_display_type_ItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "显示类型:";
            // 
            // btn_adas_color
            // 
            this.btn_adas_color.Location = new System.Drawing.Point(270, 42);
            this.btn_adas_color.Name = "btn_adas_color";
            this.btn_adas_color.Size = new System.Drawing.Size(75, 23);
            this.btn_adas_color.TabIndex = 9;
            this.btn_adas_color.UseVisualStyleBackColor = true;
            this.btn_adas_color.Click += new System.EventHandler(this.btn_adas_color_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "显示颜色:";
            // 
            // cb_is_show_adas
            // 
            this.cb_is_show_adas.AutoSize = true;
            this.cb_is_show_adas.Location = new System.Drawing.Point(15, 20);
            this.cb_is_show_adas.Name = "cb_is_show_adas";
            this.cb_is_show_adas.Size = new System.Drawing.Size(108, 16);
            this.cb_is_show_adas.TabIndex = 2;
            this.cb_is_show_adas.Text = "是否显示ADAS点";
            this.cb_is_show_adas.UseVisualStyleBackColor = true;
            this.cb_is_show_adas.CheckedChanged += new System.EventHandler(this.cb_is_show_adas_CheckedChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(285, 534);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cel
            // 
            this.btn_cel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cel.Location = new System.Drawing.Point(545, 534);
            this.btn_cel.Name = "btn_cel";
            this.btn_cel.Size = new System.Drawing.Size(75, 23);
            this.btn_cel.TabIndex = 6;
            this.btn_cel.Text = "取消";
            this.btn_cel.UseVisualStyleBackColor = true;
            this.btn_cel.Click += new System.EventHandler(this.btn_cel_Click);
            // 
            // clb_road_display_type
            // 
            this.clb_road_display_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_road_display_type.FormattingEnabled = true;
            this.clb_road_display_type.Location = new System.Drawing.Point(110, 144);
            this.clb_road_display_type.MultiColumn = true;
            this.clb_road_display_type.Name = "clb_road_display_type";
            this.clb_road_display_type.Size = new System.Drawing.Size(785, 52);
            this.clb_road_display_type.TabIndex = 9;
            this.clb_road_display_type.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_road_display_type_ItemCheck);
            // 
            // Form_display_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 565);
            this.Controls.Add(this.clb_road_display_type);
            this.Controls.Add(this.btn_cel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_display_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "测试数据显示信息设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_is_show_boundary;
        private System.Windows.Forms.CheckBox cb_is_show_road;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_road_color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clb_adas_display_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_adas_color;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_is_show_adas;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cel;
        private System.Windows.Forms.CheckedListBox clb_road_display_type;
        private System.Windows.Forms.ComboBox cb_road_weith_type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_adas_weith_type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_road_display_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_adas_display_type;
        private System.Windows.Forms.Label label8;
    }
}