namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.TelefonNumber_textBox = new System.Windows.Forms.TextBox();
            this.EmailAddress_textBox = new System.Windows.Forms.TextBox();
            this.VATNumber_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TelefonNumber_textBox
            // 
            this.TelefonNumber_textBox.Location = new System.Drawing.Point(108, 44);
            this.TelefonNumber_textBox.Name = "TelefonNumber_textBox";
            this.TelefonNumber_textBox.Size = new System.Drawing.Size(227, 20);
            this.TelefonNumber_textBox.TabIndex = 0;
            this.TelefonNumber_textBox.Leave += new System.EventHandler(this.TelefonNumber_textBox_Leave);
            // 
            // EmailAddress_textBox
            // 
            this.EmailAddress_textBox.Location = new System.Drawing.Point(108, 79);
            this.EmailAddress_textBox.Name = "EmailAddress_textBox";
            this.EmailAddress_textBox.Size = new System.Drawing.Size(227, 20);
            this.EmailAddress_textBox.TabIndex = 1;
            this.EmailAddress_textBox.Leave += new System.EventHandler(this.EmailAddress_textBox_Leave);
            // 
            // VATNumber_textBox
            // 
            this.VATNumber_textBox.Location = new System.Drawing.Point(108, 116);
            this.VATNumber_textBox.Name = "VATNumber_textBox";
            this.VATNumber_textBox.Size = new System.Drawing.Size(227, 20);
            this.VATNumber_textBox.TabIndex = 2;
            this.VATNumber_textBox.Leave += new System.EventHandler(this.VATNumber_textBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "TelefonNumber:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "EmailAddress:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "VATNumber:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 318);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VATNumber_textBox);
            this.Controls.Add(this.EmailAddress_textBox);
            this.Controls.Add(this.TelefonNumber_textBox);
            this.Name = "Form1";
            this.Text = "Regex Input Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TelefonNumber_textBox;
        private System.Windows.Forms.TextBox EmailAddress_textBox;
        private System.Windows.Forms.TextBox VATNumber_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

