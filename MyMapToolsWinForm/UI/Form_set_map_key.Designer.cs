namespace MapToolsWinForm
{
    partial class Form_set_map_key
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
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.button_create = new System.Windows.Forms.Button();
            this.button_verify = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key：";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(91, 30);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(367, 21);
            this.textBoxKey.TabIndex = 1;
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(91, 69);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 2;
            this.button_create.Text = "去创建";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_verify
            // 
            this.button_verify.Location = new System.Drawing.Point(237, 69);
            this.button_verify.Name = "button_verify";
            this.button_verify.Size = new System.Drawing.Size(75, 23);
            this.button_verify.TabIndex = 3;
            this.button_verify.Text = "验证";
            this.button_verify.UseVisualStyleBackColor = true;
            this.button_verify.Click += new System.EventHandler(this.button_verify_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(383, 69);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 4;
            this.button_apply.Text = "设置";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // Form_set_map_key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 121);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_verify);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_set_map_key";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置地图Key";
            this.Load += new System.EventHandler(this.Form_set_map_key_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_verify;
        private System.Windows.Forms.Button button_apply;
    }
}