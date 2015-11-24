namespace WindowsFormsApplication5
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
            this.button1_query = new System.Windows.Forms.Button();
            this.message_textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.disconnect_button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1_query
            // 
            this.button1_query.Location = new System.Drawing.Point(278, 117);
            this.button1_query.Name = "button1_query";
            this.button1_query.Size = new System.Drawing.Size(245, 56);
            this.button1_query.TabIndex = 0;
            this.button1_query.Text = "Query";
            this.button1_query.UseVisualStyleBackColor = true;
            this.button1_query.Click += new System.EventHandler(this.button1_query_Click);
            // 
            // message_textBox1
            // 
            this.message_textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.message_textBox1.Location = new System.Drawing.Point(779, -1);
            this.message_textBox1.Name = "message_textBox1";
            this.message_textBox1.Size = new System.Drawing.Size(63, 20);
            this.message_textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 221);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(677, 242);
            this.dataGridView1.TabIndex = 2;
            // 
            // disconnect_button1
            // 
            this.disconnect_button1.Location = new System.Drawing.Point(723, 502);
            this.disconnect_button1.Name = "disconnect_button1";
            this.disconnect_button1.Size = new System.Drawing.Size(106, 36);
            this.disconnect_button1.TabIndex = 3;
            this.disconnect_button1.Text = "Disconnect";
            this.disconnect_button1.UseVisualStyleBackColor = true;
            this.disconnect_button1.Click += new System.EventHandler(this.disconnect_button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 550);
            this.Controls.Add(this.disconnect_button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.message_textBox1);
            this.Controls.Add(this.button1_query);
            this.Name = "Form1";
            this.Text = "Firebird Connection Test";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_query;
        private System.Windows.Forms.TextBox message_textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button disconnect_button1;
    }
}

