namespace Geschichtendatenbank
{
    partial class EditGeschichteDialog
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
            this.ID_textBox = new System.Windows.Forms.TextBox();
            this.Titel_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ID_textBox
            // 
            this.ID_textBox.Location = new System.Drawing.Point(33, 12);
            this.ID_textBox.Name = "ID_textBox";
            this.ID_textBox.Size = new System.Drawing.Size(100, 20);
            this.ID_textBox.TabIndex = 0;
            // 
            // Titel_textBox
            // 
            this.Titel_textBox.Location = new System.Drawing.Point(33, 38);
            this.Titel_textBox.Name = "Titel_textBox";
            this.Titel_textBox.Size = new System.Drawing.Size(242, 20);
            this.Titel_textBox.TabIndex = 1;
            // 
            // EditGeschichteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 275);
            this.Controls.Add(this.Titel_textBox);
            this.Controls.Add(this.ID_textBox);
            this.Name = "EditGeschichteDialog";
            this.Text = "Geschichte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID_textBox;
        private System.Windows.Forms.TextBox Titel_textBox;
    }
}