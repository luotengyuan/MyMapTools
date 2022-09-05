namespace MapToolsWinForm
{
    partial class KeyWordForm
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
            this.textBoxKeyWord = new System.Windows.Forms.TextBox();
            this.buttonChack = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // textBoxKeyWord
            // 
            this.textBoxKeyWord.Location = new System.Drawing.Point(30, 48);
            this.textBoxKeyWord.Name = "textBoxKeyWord";
            this.textBoxKeyWord.Size = new System.Drawing.Size(299, 21);
            this.textBoxKeyWord.TabIndex = 1;
            // 
            // buttonChack
            // 
            this.buttonChack.AccessibleName = "KeyWordForm";
            this.buttonChack.Location = new System.Drawing.Point(30, 97);
            this.buttonChack.Name = "buttonChack";
            this.buttonChack.Size = new System.Drawing.Size(75, 23);
            this.buttonChack.TabIndex = 2;
            this.buttonChack.Text = "检测";
            this.buttonChack.UseVisualStyleBackColor = true;
            this.buttonChack.Click += new System.EventHandler(this.buttonChack_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.AccessibleName = "KeyWordForm";
            this.buttonSet.Location = new System.Drawing.Point(254, 97);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 3;
            this.buttonSet.Text = "设置";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // KeyWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 160);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonChack);
            this.Controls.Add(this.textBoxKeyWord);
            this.Controls.Add(this.label1);
            this.Name = "KeyWordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "口令设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKeyWord;
        private System.Windows.Forms.Button buttonChack;
        private System.Windows.Forms.Button buttonSet;
    }
}