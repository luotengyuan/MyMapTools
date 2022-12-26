namespace MapToolsWinForm
{
    partial class Form_about
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_about));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_version_log = new System.Windows.Forms.TextBox();
            this.lb_author = new System.Windows.Forms.Label();
            this.lb_version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "版本：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开发者：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "版本记录：";
            // 
            // tb_version_log
            // 
            this.tb_version_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_version_log.Location = new System.Drawing.Point(180, 153);
            this.tb_version_log.Multiline = true;
            this.tb_version_log.Name = "tb_version_log";
            this.tb_version_log.ReadOnly = true;
            this.tb_version_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_version_log.Size = new System.Drawing.Size(566, 309);
            this.tb_version_log.TabIndex = 4;
            // 
            // lb_author
            // 
            this.lb_author.AutoSize = true;
            this.lb_author.Location = new System.Drawing.Point(238, 54);
            this.lb_author.Name = "lb_author";
            this.lb_author.Size = new System.Drawing.Size(131, 12);
            this.lb_author.TabIndex = 5;
            this.lb_author.Text = "Lois（QQ：234808404）";
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Location = new System.Drawing.Point(238, 37);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(47, 12);
            this.lb_version.TabIndex = 6;
            this.lb_version.Text = "V 0.0.1";
            // 
            // label1
            // 
            this.label1.Image = global::MapToolsWinForm.Properties.Resources.earth;
            this.label1.Location = new System.Drawing.Point(42, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 88);
            this.label1.TabIndex = 0;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(238, 118);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(245, 12);
            this.linkLabel3.TabIndex = 22;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://gitee.com/luotengyuan/MyMapTools";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(238, 96);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(251, 12);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/luotengyuan/MyMapTools";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "代码地址：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(238, 75);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(359, 12);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://blog.csdn.net/loutengyuan/article/details/126539427";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "功能说明：";
            // 
            // Form_about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 474);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.lb_author);
            this.Controls.Add(this.tb_version_log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_about";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于 MyMapTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_version_log;
        private System.Windows.Forms.Label lb_author;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
    }
}