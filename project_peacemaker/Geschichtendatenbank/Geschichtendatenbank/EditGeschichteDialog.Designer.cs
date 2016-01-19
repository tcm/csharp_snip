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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Speichern_button = new System.Windows.Forms.Button();
            this.Entstehungsjahr_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Neuer_Datensatz_button = new System.Windows.Forms.Button();
            this.Autor_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Genre_comboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Land_comboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Text_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ID_textBox
            // 
            this.ID_textBox.Enabled = false;
            this.ID_textBox.Location = new System.Drawing.Point(108, 11);
            this.ID_textBox.Name = "ID_textBox";
            this.ID_textBox.Size = new System.Drawing.Size(57, 20);
            this.ID_textBox.TabIndex = 0;
            // 
            // Titel_textBox
            // 
            this.Titel_textBox.Location = new System.Drawing.Point(108, 39);
            this.Titel_textBox.Name = "Titel_textBox";
            this.Titel_textBox.Size = new System.Drawing.Size(212, 20);
            this.Titel_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Titel:";
            // 
            // Speichern_button
            // 
            this.Speichern_button.Location = new System.Drawing.Point(19, 275);
            this.Speichern_button.Name = "Speichern_button";
            this.Speichern_button.Size = new System.Drawing.Size(127, 33);
            this.Speichern_button.TabIndex = 4;
            this.Speichern_button.Text = "Speichern";
            this.Speichern_button.UseVisualStyleBackColor = true;
            this.Speichern_button.Click += new System.EventHandler(this.Speichern_button_Click);
            // 
            // Entstehungsjahr_textBox
            // 
            this.Entstehungsjahr_textBox.Location = new System.Drawing.Point(108, 65);
            this.Entstehungsjahr_textBox.Name = "Entstehungsjahr_textBox";
            this.Entstehungsjahr_textBox.Size = new System.Drawing.Size(57, 20);
            this.Entstehungsjahr_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Entstehungsjahr:";
            // 
            // Neuer_Datensatz_button
            // 
            this.Neuer_Datensatz_button.Location = new System.Drawing.Point(185, 275);
            this.Neuer_Datensatz_button.Name = "Neuer_Datensatz_button";
            this.Neuer_Datensatz_button.Size = new System.Drawing.Size(135, 33);
            this.Neuer_Datensatz_button.TabIndex = 7;
            this.Neuer_Datensatz_button.Text = "Neuer Datensatz";
            this.Neuer_Datensatz_button.UseVisualStyleBackColor = true;
            this.Neuer_Datensatz_button.Click += new System.EventHandler(this.Neuer_Datensatz_button_Click);
            // 
            // Autor_comboBox
            // 
            this.Autor_comboBox.FormattingEnabled = true;
            this.Autor_comboBox.Location = new System.Drawing.Point(108, 91);
            this.Autor_comboBox.Name = "Autor_comboBox";
            this.Autor_comboBox.Size = new System.Drawing.Size(145, 21);
            this.Autor_comboBox.TabIndex = 8;
           
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Autor:";
            // 
            // Genre_comboBox
            // 
            this.Genre_comboBox.FormattingEnabled = true;
            this.Genre_comboBox.Location = new System.Drawing.Point(108, 118);
            this.Genre_comboBox.Name = "Genre_comboBox";
            this.Genre_comboBox.Size = new System.Drawing.Size(145, 21);
            this.Genre_comboBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Genre:";
            // 
            // Land_comboBox
            // 
            this.Land_comboBox.FormattingEnabled = true;
            this.Land_comboBox.Location = new System.Drawing.Point(108, 145);
            this.Land_comboBox.Name = "Land_comboBox";
            this.Land_comboBox.Size = new System.Drawing.Size(145, 21);
            this.Land_comboBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Land:";
            // 
            // Text_richTextBox
            // 
            this.Text_richTextBox.Location = new System.Drawing.Point(108, 173);
            this.Text_richTextBox.Name = "Text_richTextBox";
            this.Text_richTextBox.Size = new System.Drawing.Size(212, 70);
            this.Text_richTextBox.TabIndex = 14;
            this.Text_richTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Text:";
            // 
            // EditGeschichteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 320);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Text_richTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Land_comboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Genre_comboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Autor_comboBox);
            this.Controls.Add(this.Neuer_Datensatz_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Entstehungsjahr_textBox);
            this.Controls.Add(this.Speichern_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Speichern_button;
        private System.Windows.Forms.TextBox Entstehungsjahr_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Neuer_Datensatz_button;
        private System.Windows.Forms.ComboBox Autor_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Genre_comboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Land_comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Text_richTextBox;
        private System.Windows.Forms.Label label7;
    }
}