namespace MapToolsWinForm
{
    partial class Form_regex_pattern_manage
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
            this.btn_pattern_del = new System.Windows.Forms.Button();
            this.clb_pattern_list = new System.Windows.Forms.CheckedListBox();
            this.tb_pattern_add = new System.Windows.Forms.TextBox();
            this.btn_pattern_add = new System.Windows.Forms.Button();
            this.btn_pattern_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_pattern_del
            // 
            this.btn_pattern_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pattern_del.Location = new System.Drawing.Point(701, 50);
            this.btn_pattern_del.Name = "btn_pattern_del";
            this.btn_pattern_del.Size = new System.Drawing.Size(75, 23);
            this.btn_pattern_del.TabIndex = 0;
            this.btn_pattern_del.Text = "删除选中";
            this.btn_pattern_del.UseVisualStyleBackColor = true;
            this.btn_pattern_del.Click += new System.EventHandler(this.btn_pattern_del_Click);
            // 
            // clb_pattern_list
            // 
            this.clb_pattern_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_pattern_list.FormattingEnabled = true;
            this.clb_pattern_list.Location = new System.Drawing.Point(30, 50);
            this.clb_pattern_list.Name = "clb_pattern_list";
            this.clb_pattern_list.Size = new System.Drawing.Size(665, 372);
            this.clb_pattern_list.TabIndex = 1;
            // 
            // tb_pattern_add
            // 
            this.tb_pattern_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pattern_add.Location = new System.Drawing.Point(30, 23);
            this.tb_pattern_add.Name = "tb_pattern_add";
            this.tb_pattern_add.Size = new System.Drawing.Size(665, 21);
            this.tb_pattern_add.TabIndex = 2;
            // 
            // btn_pattern_add
            // 
            this.btn_pattern_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pattern_add.Location = new System.Drawing.Point(701, 21);
            this.btn_pattern_add.Name = "btn_pattern_add";
            this.btn_pattern_add.Size = new System.Drawing.Size(75, 23);
            this.btn_pattern_add.TabIndex = 3;
            this.btn_pattern_add.Text = "添加";
            this.btn_pattern_add.UseVisualStyleBackColor = true;
            this.btn_pattern_add.Click += new System.EventHandler(this.btn_pattern_add_Click);
            // 
            // btn_pattern_exit
            // 
            this.btn_pattern_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pattern_exit.Location = new System.Drawing.Point(701, 79);
            this.btn_pattern_exit.Name = "btn_pattern_exit";
            this.btn_pattern_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_pattern_exit.TabIndex = 4;
            this.btn_pattern_exit.Text = "退出编辑";
            this.btn_pattern_exit.UseVisualStyleBackColor = true;
            this.btn_pattern_exit.Click += new System.EventHandler(this.btn_pattern_exit_Click);
            // 
            // Form_regex_pattern_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 435);
            this.Controls.Add(this.btn_pattern_exit);
            this.Controls.Add(this.btn_pattern_add);
            this.Controls.Add(this.tb_pattern_add);
            this.Controls.Add(this.clb_pattern_list);
            this.Controls.Add(this.btn_pattern_del);
            this.Name = "Form_regex_pattern_manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "正则表达式管理";
            this.Load += new System.EventHandler(this.Form_regex_pattern_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pattern_del;
        private System.Windows.Forms.CheckedListBox clb_pattern_list;
        private System.Windows.Forms.TextBox tb_pattern_add;
        private System.Windows.Forms.Button btn_pattern_add;
        private System.Windows.Forms.Button btn_pattern_exit;
    }
}