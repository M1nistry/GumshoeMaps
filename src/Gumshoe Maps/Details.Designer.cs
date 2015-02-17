using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    partial class Details
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.buttonClose = new Gumshoe_Maps.Flatbutton();
            this.buttonMinimize = new Gumshoe_Maps.Flatbutton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panelAddDrop = new System.Windows.Forms.Panel();
            this.labelMapDrop = new System.Windows.Forms.Label();
            this.labelAddDrop = new System.Windows.Forms.Label();
            this.panelEvents = new System.Windows.Forms.Panel();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.textBoxRarity = new System.Windows.Forms.TextBox();
            this.checkBoxZana = new System.Windows.Forms.CheckBox();
            this.checkBoxCarto = new System.Windows.Forms.CheckBox();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.titlePanel.SuspendLayout();
            this.panelAddDrop.SuspendLayout();
            this.panelEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.BlueViolet;
            this.titlePanel.Controls.Add(this.buttonClose);
            this.titlePanel.Controls.Add(this.buttonMinimize);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(396, 22);
            this.titlePanel.TabIndex = 7;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClose.Location = new System.Drawing.Point(369, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OwnerDrawText = null;
            this.buttonClose.Size = new System.Drawing.Size(22, 22);
            this.buttonClose.TabIndex = 23;
            this.buttonClose.Text = "×";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonMinimize.Location = new System.Drawing.Point(339, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.OwnerDrawText = "";
            this.buttonMinimize.Size = new System.Drawing.Size(22, 22);
            this.buttonMinimize.TabIndex = 22;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(11, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(42, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Details";
            // 
            // panelAddDrop
            // 
            this.panelAddDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddDrop.Controls.Add(this.textBoxLevel);
            this.panelAddDrop.Controls.Add(this.checkBoxCarto);
            this.panelAddDrop.Controls.Add(this.checkBoxZana);
            this.panelAddDrop.Controls.Add(this.textBoxRarity);
            this.panelAddDrop.Controls.Add(this.panelEvents);
            this.panelAddDrop.Controls.Add(this.labelMapDrop);
            this.panelAddDrop.Location = new System.Drawing.Point(14, 133);
            this.panelAddDrop.Name = "panelAddDrop";
            this.panelAddDrop.Size = new System.Drawing.Size(370, 100);
            this.panelAddDrop.TabIndex = 8;
            // 
            // labelMapDrop
            // 
            this.labelMapDrop.AutoSize = true;
            this.labelMapDrop.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelMapDrop.Location = new System.Drawing.Point(7, 15);
            this.labelMapDrop.Name = "labelMapDrop";
            this.labelMapDrop.Size = new System.Drawing.Size(31, 13);
            this.labelMapDrop.TabIndex = 10;
            this.labelMapDrop.Text = "Map:";
            // 
            // labelAddDrop
            // 
            this.labelAddDrop.AutoSize = true;
            this.labelAddDrop.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelAddDrop.Location = new System.Drawing.Point(18, 126);
            this.labelAddDrop.Name = "labelAddDrop";
            this.labelAddDrop.Size = new System.Drawing.Size(52, 13);
            this.labelAddDrop.TabIndex = 9;
            this.labelAddDrop.Text = "Add Drop";
            // 
            // panelEvents
            // 
            this.panelEvents.Controls.Add(this.listBoxEvents);
            this.panelEvents.Location = new System.Drawing.Point(59, 33);
            this.panelEvents.Name = "panelEvents";
            this.panelEvents.Size = new System.Drawing.Size(100, 0);
            this.panelEvents.TabIndex = 26;
            this.panelEvents.Visible = false;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.listBoxEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxEvents.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(2, 2);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(173, 13);
            this.listBoxEvents.TabIndex = 22;
            // 
            // textBoxRarity
            // 
            this.textBoxRarity.AutoCompleteCustomSource.AddRange(new string[] {
            "Normal",
            "Magic",
            "Rare",
            "Unique"});
            this.textBoxRarity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxRarity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxRarity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxRarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRarity.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxRarity.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRarity.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxRarity.Location = new System.Drawing.Point(44, 13);
            this.textBoxRarity.MaxLength = 800;
            this.textBoxRarity.Name = "textBoxRarity";
            this.textBoxRarity.Size = new System.Drawing.Size(63, 22);
            this.textBoxRarity.TabIndex = 29;
            this.textBoxRarity.Text = "Rarity";
            this.textBoxRarity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRarity.Enter += new System.EventHandler(this.textBoxRarity_Enter);
            this.textBoxRarity.Leave += new System.EventHandler(this.textBoxRarity_Leave);
            // 
            // checkBoxZana
            // 
            this.checkBoxZana.AutoSize = true;
            this.checkBoxZana.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxZana.Location = new System.Drawing.Point(234, 14);
            this.checkBoxZana.Name = "checkBoxZana";
            this.checkBoxZana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxZana.Size = new System.Drawing.Size(54, 17);
            this.checkBoxZana.TabIndex = 30;
            this.checkBoxZana.Text = ":Zana";
            this.checkBoxZana.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarto
            // 
            this.checkBoxCarto.AutoSize = true;
            this.checkBoxCarto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxCarto.Location = new System.Drawing.Point(294, 14);
            this.checkBoxCarto.Name = "checkBoxCarto";
            this.checkBoxCarto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCarto.Size = new System.Drawing.Size(54, 17);
            this.checkBoxCarto.TabIndex = 31;
            this.checkBoxCarto.Text = ":Carto";
            this.checkBoxCarto.UseVisualStyleBackColor = true;
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.AutoCompleteCustomSource.AddRange(new string[] {
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79"});
            this.textBoxLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLevel.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxLevel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLevel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxLevel.Location = new System.Drawing.Point(113, 13);
            this.textBoxLevel.MaxLength = 800;
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.Size = new System.Drawing.Size(33, 22);
            this.textBoxLevel.TabIndex = 32;
            this.textBoxLevel.Text = "Level";
            this.textBoxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLevel.Enter += new System.EventHandler(this.textBoxLevel_Enter);
            this.textBoxLevel.Leave += new System.EventHandler(this.textBoxLevel_Leave);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(396, 304);
            this.Controls.Add(this.labelAddDrop);
            this.Controls.Add(this.panelAddDrop);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Details";
            this.Text = "Details";
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.panelAddDrop.ResumeLayout(false);
            this.panelAddDrop.PerformLayout();
            this.panelEvents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel titlePanel;
        private Label titleLabel;
        private Flatbutton buttonClose;
        private Flatbutton buttonMinimize;
        private Panel panelAddDrop;
        private Label labelMapDrop;
        private Label labelAddDrop;
        private Panel panelEvents;
        private ListBox listBoxEvents;
        private TextBox textBoxRarity;
        private CheckBox checkBoxCarto;
        private CheckBox checkBoxZana;
        private TextBox textBoxLevel;
    }
}