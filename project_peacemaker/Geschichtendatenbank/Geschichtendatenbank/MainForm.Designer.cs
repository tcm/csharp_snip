namespace Geschichtendatenbank
{
    partial class MainForm
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
            this.MainForm_Uebersicht_dataGridView = new System.Windows.Forms.DataGridView();
            this.MainForm_Figuren_dataGridView = new System.Windows.Forms.DataGridView();
            this.Uebersicht_label = new System.Windows.Forms.Label();
            this.Figuren_label = new System.Windows.Forms.Label();
            this.Filter_label = new System.Windows.Forms.Label();
            this.Filter_Bezeichnung_textBox = new System.Windows.Forms.TextBox();
            this.Bezeichnung_label = new System.Windows.Forms.Label();
            this.Statusleiste_toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Filter_Entstehungsjahr_textBox = new System.Windows.Forms.TextBox();
            this.Entstehungsjahr_label = new System.Windows.Forms.Label();
            this.Meldung_textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Uebersicht_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Figuren_dataGridView)).BeginInit();
            this.Statusleiste_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainForm_Uebersicht_dataGridView
            // 
            this.MainForm_Uebersicht_dataGridView.AllowUserToAddRows = false;
            this.MainForm_Uebersicht_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainForm_Uebersicht_dataGridView.Location = new System.Drawing.Point(43, 56);
            this.MainForm_Uebersicht_dataGridView.MultiSelect = false;
            this.MainForm_Uebersicht_dataGridView.Name = "MainForm_Uebersicht_dataGridView";
            this.MainForm_Uebersicht_dataGridView.Size = new System.Drawing.Size(803, 178);
            this.MainForm_Uebersicht_dataGridView.TabIndex = 0;
            this.MainForm_Uebersicht_dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainForm_Uebersicht_dataGridView_RowEnter);
            // 
            // MainForm_Figuren_dataGridView
            // 
            this.MainForm_Figuren_dataGridView.AllowUserToAddRows = false;
            this.MainForm_Figuren_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainForm_Figuren_dataGridView.Location = new System.Drawing.Point(43, 262);
            this.MainForm_Figuren_dataGridView.Name = "MainForm_Figuren_dataGridView";
            this.MainForm_Figuren_dataGridView.Size = new System.Drawing.Size(324, 147);
            this.MainForm_Figuren_dataGridView.TabIndex = 1;
            // 
            // Uebersicht_label
            // 
            this.Uebersicht_label.AutoSize = true;
            this.Uebersicht_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Uebersicht_label.Location = new System.Drawing.Point(46, 28);
            this.Uebersicht_label.Name = "Uebersicht_label";
            this.Uebersicht_label.Size = new System.Drawing.Size(72, 13);
            this.Uebersicht_label.TabIndex = 2;
            this.Uebersicht_label.Text = "Uerbersicht";
            // 
            // Figuren_label
            // 
            this.Figuren_label.AutoSize = true;
            this.Figuren_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Figuren_label.Location = new System.Drawing.Point(43, 241);
            this.Figuren_label.Name = "Figuren_label";
            this.Figuren_label.Size = new System.Drawing.Size(49, 13);
            this.Figuren_label.TabIndex = 3;
            this.Figuren_label.Text = "Figuren";
            // 
            // Filter_label
            // 
            this.Filter_label.AutoSize = true;
            this.Filter_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_label.Location = new System.Drawing.Point(50, 446);
            this.Filter_label.Name = "Filter_label";
            this.Filter_label.Size = new System.Drawing.Size(39, 13);
            this.Filter_label.TabIndex = 4;
            this.Filter_label.Text = "Filter:";
            // 
            // Filter_Bezeichnung_textBox
            // 
            this.Filter_Bezeichnung_textBox.Location = new System.Drawing.Point(108, 444);
            this.Filter_Bezeichnung_textBox.Name = "Filter_Bezeichnung_textBox";
            this.Filter_Bezeichnung_textBox.Size = new System.Drawing.Size(144, 20);
            this.Filter_Bezeichnung_textBox.TabIndex = 5;
            // 
            // Bezeichnung_label
            // 
            this.Bezeichnung_label.AutoSize = true;
            this.Bezeichnung_label.Location = new System.Drawing.Point(108, 427);
            this.Bezeichnung_label.Name = "Bezeichnung_label";
            this.Bezeichnung_label.Size = new System.Drawing.Size(69, 13);
            this.Bezeichnung_label.TabIndex = 6;
            this.Bezeichnung_label.Text = "Bezeichnung";
            // 
            // Statusleiste_toolStrip
            // 
            this.Statusleiste_toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Statusleiste_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.Statusleiste_toolStrip.Location = new System.Drawing.Point(0, 475);
            this.Statusleiste_toolStrip.Name = "Statusleiste_toolStrip";
            this.Statusleiste_toolStrip.Size = new System.Drawing.Size(880, 25);
            this.Statusleiste_toolStrip.TabIndex = 7;
            this.Statusleiste_toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(108, 22);
            this.toolStripLabel1.Text = "Verbindungsstatus:";
            // 
            // Filter_Entstehungsjahr_textBox
            // 
            this.Filter_Entstehungsjahr_textBox.Location = new System.Drawing.Point(267, 443);
            this.Filter_Entstehungsjahr_textBox.Name = "Filter_Entstehungsjahr_textBox";
            this.Filter_Entstehungsjahr_textBox.Size = new System.Drawing.Size(100, 20);
            this.Filter_Entstehungsjahr_textBox.TabIndex = 8;
            this.Filter_Entstehungsjahr_textBox.Leave += new System.EventHandler(this.Filter_Entstehungsjahr_textBox_Leave);
            // 
            // Entstehungsjahr_label
            // 
            this.Entstehungsjahr_label.AutoSize = true;
            this.Entstehungsjahr_label.Location = new System.Drawing.Point(264, 427);
            this.Entstehungsjahr_label.Name = "Entstehungsjahr_label";
            this.Entstehungsjahr_label.Size = new System.Drawing.Size(83, 13);
            this.Entstehungsjahr_label.TabIndex = 9;
            this.Entstehungsjahr_label.Text = "Entstehungsjahr";
            // 
            // Meldung_textBox
            // 
            this.Meldung_textBox.Location = new System.Drawing.Point(661, 452);
            this.Meldung_textBox.Name = "Meldung_textBox";
            this.Meldung_textBox.Size = new System.Drawing.Size(219, 20);
            this.Meldung_textBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 500);
            this.Controls.Add(this.Meldung_textBox);
            this.Controls.Add(this.Entstehungsjahr_label);
            this.Controls.Add(this.Filter_Entstehungsjahr_textBox);
            this.Controls.Add(this.Statusleiste_toolStrip);
            this.Controls.Add(this.Bezeichnung_label);
            this.Controls.Add(this.Filter_Bezeichnung_textBox);
            this.Controls.Add(this.Filter_label);
            this.Controls.Add(this.Figuren_label);
            this.Controls.Add(this.Uebersicht_label);
            this.Controls.Add(this.MainForm_Figuren_dataGridView);
            this.Controls.Add(this.MainForm_Uebersicht_dataGridView);
            this.Name = "MainForm";
            this.Text = "Geschichtendatenbank";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Uebersicht_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Figuren_dataGridView)).EndInit();
            this.Statusleiste_toolStrip.ResumeLayout(false);
            this.Statusleiste_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainForm_Uebersicht_dataGridView;
        private System.Windows.Forms.DataGridView MainForm_Figuren_dataGridView;
        private System.Windows.Forms.Label Uebersicht_label;
        private System.Windows.Forms.Label Figuren_label;
        private System.Windows.Forms.Label Filter_label;
        private System.Windows.Forms.TextBox Filter_Bezeichnung_textBox;
        private System.Windows.Forms.Label Bezeichnung_label;
        private System.Windows.Forms.ToolStrip Statusleiste_toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox Filter_Entstehungsjahr_textBox;
        private System.Windows.Forms.Label Entstehungsjahr_label;
        private System.Windows.Forms.TextBox Meldung_textBox;
    }
}

