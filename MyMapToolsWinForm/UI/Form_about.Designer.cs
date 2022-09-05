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
            this.label3.Location = new System.Drawing.Point(178, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开发者：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 84);
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
            this.tb_version_log.Location = new System.Drawing.Point(180, 109);
            this.tb_version_log.Multiline = true;
            this.tb_version_log.Name = "tb_version_log";
            this.tb_version_log.ReadOnly = true;
            this.tb_version_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_version_log.Size = new System.Drawing.Size(566, 353);
            this.tb_version_log.TabIndex = 4;
            // 
            // lb_author
            // 
            this.lb_author.AutoSize = true;
            this.lb_author.Location = new System.Drawing.Point(238, 58);
            this.lb_author.Name = "lb_author";
            this.lb_author.Size = new System.Drawing.Size(29, 12);
            this.lb_author.TabIndex = 5;
            this.lb_author.Text = "Lois";
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
            // Form_about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 474);
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
    }
}