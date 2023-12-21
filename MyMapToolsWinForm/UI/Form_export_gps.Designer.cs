namespace MapToolsWinForm
{
    partial class Form_export_gps
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_sel = new System.Windows.Forms.Button();
            this.comboBox_coord_type = new System.Windows.Forms.ComboBox();
            this.button_export = new System.Windows.Forms.Button();
            this.button_cencel = new System.Windows.Forms.Button();
            this.comboBox_file_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "轨迹名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "坐标类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "导出路径：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(126, 22);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(538, 21);
            this.textBox_name.TabIndex = 4;
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(126, 127);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(449, 21);
            this.textBox_path.TabIndex = 5;
            this.textBox_path.Text = "C:\\Users\\Administrator\\Desktop";
            // 
            // button_sel
            // 
            this.button_sel.Location = new System.Drawing.Point(589, 125);
            this.button_sel.Name = "button_sel";
            this.button_sel.Size = new System.Drawing.Size(75, 23);
            this.button_sel.TabIndex = 6;
            this.button_sel.Text = "浏览...";
            this.button_sel.UseVisualStyleBackColor = true;
            this.button_sel.Click += new System.EventHandler(this.button_sel_Click);
            // 
            // comboBox_coord_type
            // 
            this.comboBox_coord_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_coord_type.FormattingEnabled = true;
            this.comboBox_coord_type.Items.AddRange(new object[] {
            "WGS84",
            "GCJ02",
            "BD09"});
            this.comboBox_coord_type.Location = new System.Drawing.Point(127, 58);
            this.comboBox_coord_type.Name = "comboBox_coord_type";
            this.comboBox_coord_type.Size = new System.Drawing.Size(142, 20);
            this.comboBox_coord_type.TabIndex = 7;
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(156, 170);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(137, 38);
            this.button_export.TabIndex = 8;
            this.button_export.Text = "导出";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_cencel
            // 
            this.button_cencel.Location = new System.Drawing.Point(427, 170);
            this.button_cencel.Name = "button_cencel";
            this.button_cencel.Size = new System.Drawing.Size(137, 38);
            this.button_cencel.TabIndex = 9;
            this.button_cencel.Text = "取消";
            this.button_cencel.UseVisualStyleBackColor = true;
            this.button_cencel.Click += new System.EventHandler(this.button_cencel_Click);
            // 
            // comboBox_file_type
            // 
            this.comboBox_file_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_file_type.FormattingEnabled = true;
            this.comboBox_file_type.Items.AddRange(new object[] {
            "CSV格式",
            "KML格式"});
            this.comboBox_file_type.Location = new System.Drawing.Point(127, 93);
            this.comboBox_file_type.Name = "comboBox_file_type";
            this.comboBox_file_type.Size = new System.Drawing.Size(142, 20);
            this.comboBox_file_type.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "文件类型：";
            // 
            // Form_export_gps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 233);
            this.Controls.Add(this.comboBox_file_type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_cencel);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.comboBox_coord_type);
            this.Controls.Add(this.button_sel);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_export_gps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出轨迹";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_sel;
        private System.Windows.Forms.ComboBox comboBox_coord_type;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_cencel;
        private System.Windows.Forms.ComboBox comboBox_file_type;
        private System.Windows.Forms.Label label3;
    }
}