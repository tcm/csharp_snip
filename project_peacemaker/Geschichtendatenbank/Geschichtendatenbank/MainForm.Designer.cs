﻿namespace Geschichtendatenbank
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
            this.Filter_Titel_textBox = new System.Windows.Forms.TextBox();
            this.Titel_label = new System.Windows.Forms.Label();
            this.Statusleiste_toolStrip = new System.Windows.Forms.ToolStrip();
            this.Beschriftung_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.DBStatus_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.Filter_Entstehungsjahr_textBox = new System.Windows.Forms.TextBox();
            this.Entstehungsjahr_label = new System.Windows.Forms.Label();
            this.Meldung_textBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neueGeschichteAnlegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Uebersicht_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Figuren_dataGridView)).BeginInit();
            this.Statusleiste_toolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            // Filter_Titel_textBox
            // 
            this.Filter_Titel_textBox.Location = new System.Drawing.Point(108, 444);
            this.Filter_Titel_textBox.Name = "Filter_Titel_textBox";
            this.Filter_Titel_textBox.Size = new System.Drawing.Size(144, 20);
            this.Filter_Titel_textBox.TabIndex = 5;
            this.Filter_Titel_textBox.Leave += new System.EventHandler(this.Filter_Titel_textBox_Leave);
            // 
            // Titel_label
            // 
            this.Titel_label.AutoSize = true;
            this.Titel_label.Location = new System.Drawing.Point(108, 427);
            this.Titel_label.Name = "Titel_label";
            this.Titel_label.Size = new System.Drawing.Size(27, 13);
            this.Titel_label.TabIndex = 6;
            this.Titel_label.Text = "Titel";
            // 
            // Statusleiste_toolStrip
            // 
            this.Statusleiste_toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Statusleiste_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Beschriftung_toolStripLabel,
            this.DBStatus_toolStripLabel});
            this.Statusleiste_toolStrip.Location = new System.Drawing.Point(0, 488);
            this.Statusleiste_toolStrip.Name = "Statusleiste_toolStrip";
            this.Statusleiste_toolStrip.Size = new System.Drawing.Size(928, 25);
            this.Statusleiste_toolStrip.TabIndex = 7;
            this.Statusleiste_toolStrip.Text = "toolStrip1";
            // 
            // Beschriftung_toolStripLabel
            // 
            this.Beschriftung_toolStripLabel.Name = "Beschriftung_toolStripLabel";
            this.Beschriftung_toolStripLabel.Size = new System.Drawing.Size(108, 22);
            this.Beschriftung_toolStripLabel.Text = "Verbindungsstatus:";
            // 
            // DBStatus_toolStripLabel
            // 
            this.DBStatus_toolStripLabel.Name = "DBStatus_toolStripLabel";
            this.DBStatus_toolStripLabel.Size = new System.Drawing.Size(22, 22);
            this.DBStatus_toolStripLabel.Text = "---";
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
            this.Meldung_textBox.Enabled = false;
            this.Meldung_textBox.Location = new System.Drawing.Point(661, 452);
            this.Meldung_textBox.Name = "Meldung_textBox";
            this.Meldung_textBox.Size = new System.Drawing.Size(219, 20);
            this.Meldung_textBox.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.bearbeitenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(928, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem1.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueGeschichteAnlegenToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // neueGeschichteAnlegenToolStripMenuItem
            // 
            this.neueGeschichteAnlegenToolStripMenuItem.Name = "neueGeschichteAnlegenToolStripMenuItem";
            this.neueGeschichteAnlegenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.neueGeschichteAnlegenToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.neueGeschichteAnlegenToolStripMenuItem.Text = "neue Geschichte anlegen";
            this.neueGeschichteAnlegenToolStripMenuItem.Click += new System.EventHandler(this.neueGeschichteAnlegenToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 513);
            this.Controls.Add(this.Meldung_textBox);
            this.Controls.Add(this.Entstehungsjahr_label);
            this.Controls.Add(this.Filter_Entstehungsjahr_textBox);
            this.Controls.Add(this.Statusleiste_toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Titel_label);
            this.Controls.Add(this.Filter_Titel_textBox);
            this.Controls.Add(this.Filter_label);
            this.Controls.Add(this.Figuren_label);
            this.Controls.Add(this.Uebersicht_label);
            this.Controls.Add(this.MainForm_Figuren_dataGridView);
            this.Controls.Add(this.MainForm_Uebersicht_dataGridView);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Geschichtendatenbank";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Uebersicht_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainForm_Figuren_dataGridView)).EndInit();
            this.Statusleiste_toolStrip.ResumeLayout(false);
            this.Statusleiste_toolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainForm_Uebersicht_dataGridView;
        private System.Windows.Forms.DataGridView MainForm_Figuren_dataGridView;
        private System.Windows.Forms.Label Uebersicht_label;
        private System.Windows.Forms.Label Figuren_label;
        private System.Windows.Forms.Label Filter_label;
        private System.Windows.Forms.TextBox Filter_Titel_textBox;
        private System.Windows.Forms.Label Titel_label;
        private System.Windows.Forms.ToolStrip Statusleiste_toolStrip;
        private System.Windows.Forms.ToolStripLabel Beschriftung_toolStripLabel;
        private System.Windows.Forms.TextBox Filter_Entstehungsjahr_textBox;
        private System.Windows.Forms.Label Entstehungsjahr_label;
        private System.Windows.Forms.TextBox Meldung_textBox;
        private System.Windows.Forms.ToolStripLabel DBStatus_toolStripLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neueGeschichteAnlegenToolStripMenuItem;
    }
}

