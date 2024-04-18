namespace MapToolsWinForm
{
    partial class Form_load_gps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_load_gps));
            this.label1 = new System.Windows.Forms.Label();
            this.cb_file_format = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_file_path = new System.Windows.Forms.TextBox();
            this.btn_load_file = new System.Windows.Forms.Button();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lv_route_info = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_min_speed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_coord_type = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_jump_num = new System.Windows.Forms.TextBox();
            this.cb_filter_0_point = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_filter_repeat_point = new System.Windows.Forms.CheckBox();
            this.tb_type_scale = new System.Windows.Forms.TextBox();
            this.cb_type_enable = new System.Windows.Forms.CheckBox();
            this.cb_type_slt_row = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_lon_enable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_lon_slt_row = new System.Windows.Forms.ComboBox();
            this.tb_time_scale = new System.Windows.Forms.TextBox();
            this.cb_lat_enable = new System.Windows.Forms.CheckBox();
            this.tb_acc_scale = new System.Windows.Forms.TextBox();
            this.cb_lat_slt_row = new System.Windows.Forms.ComboBox();
            this.tb_alt_scale = new System.Windows.Forms.TextBox();
            this.cb_dir_enable = new System.Windows.Forms.CheckBox();
            this.tb_speed_scale = new System.Windows.Forms.TextBox();
            this.cb_dir_slt_row = new System.Windows.Forms.ComboBox();
            this.tb_dir_scale = new System.Windows.Forms.TextBox();
            this.cb_speed_enable = new System.Windows.Forms.CheckBox();
            this.tb_lat_scale = new System.Windows.Forms.TextBox();
            this.cb_speed_slt_row = new System.Windows.Forms.ComboBox();
            this.tb_lon_scale = new System.Windows.Forms.TextBox();
            this.cb_alt_enable = new System.Windows.Forms.CheckBox();
            this.cb_time_slt_row = new System.Windows.Forms.ComboBox();
            this.cb_alt_slt_row = new System.Windows.Forms.ComboBox();
            this.cb_time_enable = new System.Windows.Forms.CheckBox();
            this.cb_acc_enable = new System.Windows.Forms.CheckBox();
            this.cb_acc_slt_row = new System.Windows.Forms.ComboBox();
            this.cb_separator = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_regex_pattern_manage = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_regex_pattern = new System.Windows.Forms.ComboBox();
            this.btn_load_copy = new System.Windows.Forms.Button();
            this.tb_interpolation_meter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件类型：";
            // 
            // cb_file_format
            // 
            this.cb_file_format.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_file_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_file_format.FormattingEnabled = true;
            this.cb_file_format.Items.AddRange(new object[] {
            "CSV/TXT：lon, lat, dir, speed, alt, time",
            "EXCEL：lon, lat, dir, speed, alt, time",
            "Nmea：$GPRMC,071402.0,A,2429.608288,N,11805.238504,E,20.1,297.2,110316,,,A*53",
            "KML：Point",
            "ISA：av2hp-->location:lon, lat, dir, speed, accuracy",
            "正则匹配：lon\\s+=\\s+(\\d+\\.\\d+)\\s+lat\\s+=\\s+(\\d+\\.\\d+)\\s+prob\\s+=\\s+(\\d+\\.\\d+)",
            "KML：LineString"});
            this.cb_file_format.Location = new System.Drawing.Point(72, 12);
            this.cb_file_format.Name = "cb_file_format";
            this.cb_file_format.Size = new System.Drawing.Size(763, 20);
            this.cb_file_format.TabIndex = 1;
            this.cb_file_format.SelectedIndexChanged += new System.EventHandler(this.cb_file_format_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "文件路径：";
            // 
            // tb_file_path
            // 
            this.tb_file_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_file_path.Location = new System.Drawing.Point(72, 80);
            this.tb_file_path.Name = "tb_file_path";
            this.tb_file_path.Size = new System.Drawing.Size(795, 21);
            this.tb_file_path.TabIndex = 3;
            // 
            // btn_load_file
            // 
            this.btn_load_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load_file.Location = new System.Drawing.Point(873, 78);
            this.btn_load_file.Name = "btn_load_file";
            this.btn_load_file.Size = new System.Drawing.Size(75, 23);
            this.btn_load_file.TabIndex = 5;
            this.btn_load_file.Text = "加载文件";
            this.btn_load_file.UseVisualStyleBackColor = true;
            this.btn_load_file.Click += new System.EventHandler(this.btn_load_file_Click);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_confirm.Location = new System.Drawing.Point(266, 590);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 7;
            this.btn_confirm.Text = "确定";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(710, 590);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lv_route_info);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 459);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轨迹信息";
            // 
            // lv_route_info
            // 
            this.lv_route_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_route_info.Location = new System.Drawing.Point(6, 18);
            this.lv_route_info.Name = "lv_route_info";
            this.lv_route_info.Size = new System.Drawing.Size(659, 434);
            this.lv_route_info.TabIndex = 56;
            this.lv_route_info.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.tb_type_scale);
            this.panel1.Controls.Add(this.cb_type_enable);
            this.panel1.Controls.Add(this.cb_type_slt_row);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cb_lon_enable);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_lon_slt_row);
            this.panel1.Controls.Add(this.tb_time_scale);
            this.panel1.Controls.Add(this.cb_lat_enable);
            this.panel1.Controls.Add(this.tb_acc_scale);
            this.panel1.Controls.Add(this.cb_lat_slt_row);
            this.panel1.Controls.Add(this.tb_alt_scale);
            this.panel1.Controls.Add(this.cb_dir_enable);
            this.panel1.Controls.Add(this.tb_speed_scale);
            this.panel1.Controls.Add(this.cb_dir_slt_row);
            this.panel1.Controls.Add(this.tb_dir_scale);
            this.panel1.Controls.Add(this.cb_speed_enable);
            this.panel1.Controls.Add(this.tb_lat_scale);
            this.panel1.Controls.Add(this.cb_speed_slt_row);
            this.panel1.Controls.Add(this.tb_lon_scale);
            this.panel1.Controls.Add(this.cb_alt_enable);
            this.panel1.Controls.Add(this.cb_time_slt_row);
            this.panel1.Controls.Add(this.cb_alt_slt_row);
            this.panel1.Controls.Add(this.cb_time_enable);
            this.panel1.Controls.Add(this.cb_acc_enable);
            this.panel1.Controls.Add(this.cb_acc_slt_row);
            this.panel1.Location = new System.Drawing.Point(683, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 434);
            this.panel1.TabIndex = 55;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_interpolation_meter);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tb_min_speed);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_coord_type);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_jump_num);
            this.groupBox2.Controls.Add(this.cb_filter_0_point);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cb_filter_repeat_point);
            this.groupBox2.Location = new System.Drawing.Point(4, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 127);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他设置";
            // 
            // tb_min_speed
            // 
            this.tb_min_speed.Location = new System.Drawing.Point(55, 100);
            this.tb_min_speed.Name = "tb_min_speed";
            this.tb_min_speed.Size = new System.Drawing.Size(75, 21);
            this.tb_min_speed.TabIndex = 57;
            this.tb_min_speed.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "速度>=：";
            // 
            // cb_coord_type
            // 
            this.cb_coord_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_coord_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_coord_type.FormattingEnabled = true;
            this.cb_coord_type.Items.AddRange(new object[] {
            "WGS84",
            "GCJ02",
            "BD09"});
            this.cb_coord_type.Location = new System.Drawing.Point(55, 44);
            this.cb_coord_type.Name = "cb_coord_type";
            this.cb_coord_type.Size = new System.Drawing.Size(75, 20);
            this.cb_coord_type.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "坐标系：";
            // 
            // tb_jump_num
            // 
            this.tb_jump_num.Location = new System.Drawing.Point(55, 72);
            this.tb_jump_num.Name = "tb_jump_num";
            this.tb_jump_num.Size = new System.Drawing.Size(75, 21);
            this.tb_jump_num.TabIndex = 55;
            this.tb_jump_num.Text = "0";
            // 
            // cb_filter_0_point
            // 
            this.cb_filter_0_point.AutoSize = true;
            this.cb_filter_0_point.Location = new System.Drawing.Point(10, 20);
            this.cb_filter_0_point.Name = "cb_filter_0_point";
            this.cb_filter_0_point.Size = new System.Drawing.Size(102, 16);
            this.cb_filter_0_point.TabIndex = 1;
            this.cb_filter_0_point.Text = "过滤坐标为0点";
            this.cb_filter_0_point.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "跳跃数：";
            // 
            // cb_filter_repeat_point
            // 
            this.cb_filter_repeat_point.AutoSize = true;
            this.cb_filter_repeat_point.Location = new System.Drawing.Point(118, 20);
            this.cb_filter_repeat_point.Name = "cb_filter_repeat_point";
            this.cb_filter_repeat_point.Size = new System.Drawing.Size(84, 16);
            this.cb_filter_repeat_point.TabIndex = 0;
            this.cb_filter_repeat_point.Text = "过滤重复点";
            this.cb_filter_repeat_point.UseVisualStyleBackColor = true;
            // 
            // tb_type_scale
            // 
            this.tb_type_scale.Location = new System.Drawing.Point(195, 275);
            this.tb_type_scale.Name = "tb_type_scale";
            this.tb_type_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_type_scale.TabIndex = 57;
            this.tb_type_scale.Text = "1.0";
            // 
            // cb_type_enable
            // 
            this.cb_type_enable.AutoSize = true;
            this.cb_type_enable.Location = new System.Drawing.Point(4, 279);
            this.cb_type_enable.Name = "cb_type_enable";
            this.cb_type_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_type_enable.TabIndex = 55;
            this.cb_type_enable.Text = "类型";
            this.cb_type_enable.UseVisualStyleBackColor = true;
            // 
            // cb_type_slt_row
            // 
            this.cb_type_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type_slt_row.FormattingEnabled = true;
            this.cb_type_slt_row.Location = new System.Drawing.Point(59, 275);
            this.cb_type_slt_row.Name = "cb_type_slt_row";
            this.cb_type_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_type_slt_row.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 54;
            this.label4.Text = "放大比";
            // 
            // cb_lon_enable
            // 
            this.cb_lon_enable.AutoSize = true;
            this.cb_lon_enable.Checked = true;
            this.cb_lon_enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lon_enable.Enabled = false;
            this.cb_lon_enable.Location = new System.Drawing.Point(4, 46);
            this.cb_lon_enable.Name = "cb_lon_enable";
            this.cb_lon_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_lon_enable.TabIndex = 32;
            this.cb_lon_enable.Text = "经度";
            this.cb_lon_enable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "选择列";
            // 
            // cb_lon_slt_row
            // 
            this.cb_lon_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lon_slt_row.FormattingEnabled = true;
            this.cb_lon_slt_row.Location = new System.Drawing.Point(59, 42);
            this.cb_lon_slt_row.Name = "cb_lon_slt_row";
            this.cb_lon_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_lon_slt_row.TabIndex = 33;
            // 
            // tb_time_scale
            // 
            this.tb_time_scale.Location = new System.Drawing.Point(195, 241);
            this.tb_time_scale.Name = "tb_time_scale";
            this.tb_time_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_time_scale.TabIndex = 52;
            this.tb_time_scale.Text = "yyyy-MM-dd HH:mm:ss";
            // 
            // cb_lat_enable
            // 
            this.cb_lat_enable.AutoSize = true;
            this.cb_lat_enable.Checked = true;
            this.cb_lat_enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lat_enable.Enabled = false;
            this.cb_lat_enable.Location = new System.Drawing.Point(4, 78);
            this.cb_lat_enable.Name = "cb_lat_enable";
            this.cb_lat_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_lat_enable.TabIndex = 34;
            this.cb_lat_enable.Text = "纬度";
            this.cb_lat_enable.UseVisualStyleBackColor = true;
            // 
            // tb_acc_scale
            // 
            this.tb_acc_scale.Location = new System.Drawing.Point(195, 206);
            this.tb_acc_scale.Name = "tb_acc_scale";
            this.tb_acc_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_acc_scale.TabIndex = 51;
            this.tb_acc_scale.Text = "1.0";
            // 
            // cb_lat_slt_row
            // 
            this.cb_lat_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lat_slt_row.FormattingEnabled = true;
            this.cb_lat_slt_row.Location = new System.Drawing.Point(59, 74);
            this.cb_lat_slt_row.Name = "cb_lat_slt_row";
            this.cb_lat_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_lat_slt_row.TabIndex = 35;
            // 
            // tb_alt_scale
            // 
            this.tb_alt_scale.Location = new System.Drawing.Point(195, 171);
            this.tb_alt_scale.Name = "tb_alt_scale";
            this.tb_alt_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_alt_scale.TabIndex = 50;
            this.tb_alt_scale.Text = "1.0";
            // 
            // cb_dir_enable
            // 
            this.cb_dir_enable.AutoSize = true;
            this.cb_dir_enable.Location = new System.Drawing.Point(4, 109);
            this.cb_dir_enable.Name = "cb_dir_enable";
            this.cb_dir_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_dir_enable.TabIndex = 36;
            this.cb_dir_enable.Text = "方向";
            this.cb_dir_enable.UseVisualStyleBackColor = true;
            // 
            // tb_speed_scale
            // 
            this.tb_speed_scale.Location = new System.Drawing.Point(195, 138);
            this.tb_speed_scale.Name = "tb_speed_scale";
            this.tb_speed_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_speed_scale.TabIndex = 49;
            this.tb_speed_scale.Text = "1.0";
            // 
            // cb_dir_slt_row
            // 
            this.cb_dir_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dir_slt_row.FormattingEnabled = true;
            this.cb_dir_slt_row.Location = new System.Drawing.Point(59, 105);
            this.cb_dir_slt_row.Name = "cb_dir_slt_row";
            this.cb_dir_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_dir_slt_row.TabIndex = 37;
            // 
            // tb_dir_scale
            // 
            this.tb_dir_scale.Location = new System.Drawing.Point(195, 105);
            this.tb_dir_scale.Name = "tb_dir_scale";
            this.tb_dir_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_dir_scale.TabIndex = 48;
            this.tb_dir_scale.Text = "1.0";
            // 
            // cb_speed_enable
            // 
            this.cb_speed_enable.AutoSize = true;
            this.cb_speed_enable.Location = new System.Drawing.Point(4, 140);
            this.cb_speed_enable.Name = "cb_speed_enable";
            this.cb_speed_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_speed_enable.TabIndex = 38;
            this.cb_speed_enable.Text = "速度";
            this.cb_speed_enable.UseVisualStyleBackColor = true;
            // 
            // tb_lat_scale
            // 
            this.tb_lat_scale.Location = new System.Drawing.Point(195, 74);
            this.tb_lat_scale.Name = "tb_lat_scale";
            this.tb_lat_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_lat_scale.TabIndex = 47;
            this.tb_lat_scale.Text = "1.0";
            // 
            // cb_speed_slt_row
            // 
            this.cb_speed_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_speed_slt_row.FormattingEnabled = true;
            this.cb_speed_slt_row.Location = new System.Drawing.Point(59, 136);
            this.cb_speed_slt_row.Name = "cb_speed_slt_row";
            this.cb_speed_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_speed_slt_row.TabIndex = 39;
            // 
            // tb_lon_scale
            // 
            this.tb_lon_scale.Location = new System.Drawing.Point(195, 42);
            this.tb_lon_scale.Name = "tb_lon_scale";
            this.tb_lon_scale.Size = new System.Drawing.Size(127, 21);
            this.tb_lon_scale.TabIndex = 46;
            this.tb_lon_scale.Text = "1.0";
            // 
            // cb_alt_enable
            // 
            this.cb_alt_enable.AutoSize = true;
            this.cb_alt_enable.Location = new System.Drawing.Point(4, 175);
            this.cb_alt_enable.Name = "cb_alt_enable";
            this.cb_alt_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_alt_enable.TabIndex = 40;
            this.cb_alt_enable.Text = "高度";
            this.cb_alt_enable.UseVisualStyleBackColor = true;
            // 
            // cb_time_slt_row
            // 
            this.cb_time_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_time_slt_row.FormattingEnabled = true;
            this.cb_time_slt_row.Location = new System.Drawing.Point(59, 241);
            this.cb_time_slt_row.Name = "cb_time_slt_row";
            this.cb_time_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_time_slt_row.TabIndex = 45;
            // 
            // cb_alt_slt_row
            // 
            this.cb_alt_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_alt_slt_row.FormattingEnabled = true;
            this.cb_alt_slt_row.Location = new System.Drawing.Point(59, 171);
            this.cb_alt_slt_row.Name = "cb_alt_slt_row";
            this.cb_alt_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_alt_slt_row.TabIndex = 41;
            // 
            // cb_time_enable
            // 
            this.cb_time_enable.AutoSize = true;
            this.cb_time_enable.Location = new System.Drawing.Point(4, 245);
            this.cb_time_enable.Name = "cb_time_enable";
            this.cb_time_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_time_enable.TabIndex = 44;
            this.cb_time_enable.Text = "时间";
            this.cb_time_enable.UseVisualStyleBackColor = true;
            // 
            // cb_acc_enable
            // 
            this.cb_acc_enable.AutoSize = true;
            this.cb_acc_enable.Location = new System.Drawing.Point(4, 210);
            this.cb_acc_enable.Name = "cb_acc_enable";
            this.cb_acc_enable.Size = new System.Drawing.Size(48, 16);
            this.cb_acc_enable.TabIndex = 42;
            this.cb_acc_enable.Text = "精度";
            this.cb_acc_enable.UseVisualStyleBackColor = true;
            // 
            // cb_acc_slt_row
            // 
            this.cb_acc_slt_row.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_acc_slt_row.FormattingEnabled = true;
            this.cb_acc_slt_row.Location = new System.Drawing.Point(59, 206);
            this.cb_acc_slt_row.Name = "cb_acc_slt_row";
            this.cb_acc_slt_row.Size = new System.Drawing.Size(130, 20);
            this.cb_acc_slt_row.TabIndex = 43;
            // 
            // cb_separator
            // 
            this.cb_separator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_separator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_separator.FormattingEnabled = true;
            this.cb_separator.Items.AddRange(new object[] {
            "小写逗号（,）",
            "大写逗号（，）",
            "小写分号（;）",
            "大写分号（；）",
            "空格（ ）"});
            this.cb_separator.Location = new System.Drawing.Point(907, 12);
            this.cb_separator.Name = "cb_separator";
            this.cb_separator.Size = new System.Drawing.Size(121, 20);
            this.cb_separator.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(858, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "分隔符：";
            // 
            // btn_regex_pattern_manage
            // 
            this.btn_regex_pattern_manage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_regex_pattern_manage.Location = new System.Drawing.Point(953, 43);
            this.btn_regex_pattern_manage.Name = "btn_regex_pattern_manage";
            this.btn_regex_pattern_manage.Size = new System.Drawing.Size(75, 23);
            this.btn_regex_pattern_manage.TabIndex = 37;
            this.btn_regex_pattern_manage.Text = "语句管理";
            this.btn_regex_pattern_manage.UseVisualStyleBackColor = true;
            this.btn_regex_pattern_manage.Click += new System.EventHandler(this.btn_regex_pattern_manage_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "正则语句：";
            // 
            // cb_regex_pattern
            // 
            this.cb_regex_pattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_regex_pattern.FormattingEnabled = true;
            this.cb_regex_pattern.Items.AddRange(new object[] {
            "lon\\s+=\\s+(\\d+\\.\\d+)\\s+lat\\s+=\\s+(\\d+\\.\\d+)\\s+prob\\s+=\\s+(\\d+\\.\\d+)"});
            this.cb_regex_pattern.Location = new System.Drawing.Point(72, 45);
            this.cb_regex_pattern.Name = "cb_regex_pattern";
            this.cb_regex_pattern.Size = new System.Drawing.Size(875, 20);
            this.cb_regex_pattern.TabIndex = 38;
            // 
            // btn_load_copy
            // 
            this.btn_load_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load_copy.Location = new System.Drawing.Point(953, 78);
            this.btn_load_copy.Name = "btn_load_copy";
            this.btn_load_copy.Size = new System.Drawing.Size(75, 23);
            this.btn_load_copy.TabIndex = 39;
            this.btn_load_copy.Text = "拷贝加载";
            this.btn_load_copy.UseVisualStyleBackColor = true;
            this.btn_load_copy.Click += new System.EventHandler(this.btn_load_copy_Click);
            // 
            // tb_interpolation_meter
            // 
            this.tb_interpolation_meter.Location = new System.Drawing.Point(243, 44);
            this.tb_interpolation_meter.Name = "tb_interpolation_meter";
            this.tb_interpolation_meter.Size = new System.Drawing.Size(75, 21);
            this.tb_interpolation_meter.TabIndex = 59;
            this.tb_interpolation_meter.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(164, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "插值距离(M)：";
            // 
            // Form_load_gps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 626);
            this.Controls.Add(this.btn_load_copy);
            this.Controls.Add(this.cb_regex_pattern);
            this.Controls.Add(this.btn_regex_pattern_manage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_separator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.btn_load_file);
            this.Controls.Add(this.tb_file_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_file_format);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_load_gps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加载轨迹";
            this.Load += new System.EventHandler(this.Form_load_gps_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_file_format;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_file_path;
        private System.Windows.Forms.Button btn_load_file;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_lon_enable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_lon_slt_row;
        private System.Windows.Forms.TextBox tb_time_scale;
        private System.Windows.Forms.CheckBox cb_lat_enable;
        private System.Windows.Forms.TextBox tb_acc_scale;
        private System.Windows.Forms.ComboBox cb_lat_slt_row;
        private System.Windows.Forms.TextBox tb_alt_scale;
        private System.Windows.Forms.CheckBox cb_dir_enable;
        private System.Windows.Forms.TextBox tb_speed_scale;
        private System.Windows.Forms.ComboBox cb_dir_slt_row;
        private System.Windows.Forms.TextBox tb_dir_scale;
        private System.Windows.Forms.CheckBox cb_speed_enable;
        private System.Windows.Forms.TextBox tb_lat_scale;
        private System.Windows.Forms.ComboBox cb_speed_slt_row;
        private System.Windows.Forms.TextBox tb_lon_scale;
        private System.Windows.Forms.CheckBox cb_alt_enable;
        private System.Windows.Forms.ComboBox cb_time_slt_row;
        private System.Windows.Forms.ComboBox cb_alt_slt_row;
        private System.Windows.Forms.CheckBox cb_time_enable;
        private System.Windows.Forms.CheckBox cb_acc_enable;
        private System.Windows.Forms.ComboBox cb_acc_slt_row;
        private System.Windows.Forms.ComboBox cb_separator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lv_route_info;
        private System.Windows.Forms.ComboBox cb_coord_type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_type_scale;
        private System.Windows.Forms.CheckBox cb_type_enable;
        private System.Windows.Forms.ComboBox cb_type_slt_row;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_jump_num;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_filter_0_point;
        private System.Windows.Forms.CheckBox cb_filter_repeat_point;
        private System.Windows.Forms.TextBox tb_min_speed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_regex_pattern_manage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_regex_pattern;
        private System.Windows.Forms.Button btn_load_copy;
        private System.Windows.Forms.TextBox tb_interpolation_meter;
        private System.Windows.Forms.Label label10;
    }
}