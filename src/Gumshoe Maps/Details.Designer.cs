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
            this.titleLabel = new System.Windows.Forms.Label();
            this.panelAddDrop = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.textBoxUnique = new System.Windows.Forms.TextBox();
            this.labelUnique = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.checkBoxCarto = new System.Windows.Forms.CheckBox();
            this.checkBoxZana = new System.Windows.Forms.CheckBox();
            this.textBoxRarity = new System.Windows.Forms.TextBox();
            this.panelEvents = new System.Windows.Forms.Panel();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.labelMapDrop = new System.Windows.Forms.Label();
            this.labelAddDrop = new System.Windows.Forms.Label();
            this.labelMapDetails = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.buttonAdd = new Gumshoe_Maps.Flatbutton();
            this.buttonClose = new Gumshoe_Maps.Flatbutton();
            this.buttonMinimize = new Gumshoe_Maps.Flatbutton();
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
            this.panelAddDrop.Controls.Add(this.buttonAdd);
            this.panelAddDrop.Controls.Add(this.textBox1);
            this.panelAddDrop.Controls.Add(this.labelCurrency);
            this.panelAddDrop.Controls.Add(this.textBoxUnique);
            this.panelAddDrop.Controls.Add(this.labelUnique);
            this.panelAddDrop.Controls.Add(this.textBoxName);
            this.panelAddDrop.Controls.Add(this.textBoxLevel);
            this.panelAddDrop.Controls.Add(this.checkBoxCarto);
            this.panelAddDrop.Controls.Add(this.checkBoxZana);
            this.panelAddDrop.Controls.Add(this.textBoxRarity);
            this.panelAddDrop.Controls.Add(this.panelEvents);
            this.panelAddDrop.Controls.Add(this.labelMapDrop);
            this.panelAddDrop.Location = new System.Drawing.Point(14, 233);
            this.panelAddDrop.Name = "panelAddDrop";
            this.panelAddDrop.Size = new System.Drawing.Size(370, 105);
            this.panelAddDrop.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Armourer\'s Scrap",
            "Blacksmith\'s Whetstone",
            "Glassblower\'s Bauble",
            "Cartographer\'s Chisel",
            "Gemcutter\'s Prism",
            "Jeweller\'s",
            "Chromatic",
            "Fusing",
            "Transmutation",
            "Chance",
            "Alchemy",
            "Regal",
            "Augmentation",
            "Exalted",
            "Alteration",
            "Chaos",
            "Blessed",
            "Divine",
            "Scouring",
            "Mirror Kalandra",
            "Eternal",
            "Regret",
            "Vaal"});
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox1.Location = new System.Drawing.Point(60, 69);
            this.textBox1.MaxLength = 800;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 22);
            this.textBox1.TabIndex = 37;
            this.textBox1.Text = "Name";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelCurrency.Location = new System.Drawing.Point(2, 71);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(52, 13);
            this.labelCurrency.TabIndex = 36;
            this.labelCurrency.Text = "Currency:";
            // 
            // textBoxUnique
            // 
            this.textBoxUnique.AutoCompleteCustomSource.AddRange(new string[] {
            "Academy",
            "Crypt",
            "Dried Lake",
            "Dunes",
            "Dungeon",
            "Grotto",
            "Overgrown Ruin",
            "Tropical Island",
            "Arcade",
            "Arsenal",
            "Cemetery",
            "Mountain Ledge",
            "Sewer",
            "Thicket",
            "Wharf",
            "Ghetto",
            "Mud Geyser",
            "Reef",
            "Spider Lair",
            "Springs",
            "Vaal Pyramid",
            "Catacomb",
            "Overgrown Shrine",
            "Promenade",
            "Shore",
            "Spider Forest",
            "Tunnel",
            "Bog",
            "Coves",
            "Graveyard",
            "Pier",
            "Underground Sea",
            "Arachnid Nest",
            "Colonnade",
            "Dry Woods",
            "Strand",
            "Temple",
            "Jungle Valley",
            "Torture Chamber",
            "Waste Pool",
            "Mine",
            "Dry Peninsula",
            "Canyon",
            "Cells",
            "Dark Forest",
            "Gorge",
            "Maze",
            "Underground River",
            "Bazaar",
            "Necropolis",
            "Plateau",
            "Crematorium",
            "Precinct",
            "Shipyard",
            "Shrine",
            "Villa",
            "Palace"});
            this.textBoxUnique.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxUnique.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxUnique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxUnique.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUnique.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxUnique.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnique.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxUnique.Location = new System.Drawing.Point(60, 41);
            this.textBoxUnique.MaxLength = 800;
            this.textBoxUnique.Name = "textBoxUnique";
            this.textBoxUnique.Size = new System.Drawing.Size(185, 22);
            this.textBoxUnique.TabIndex = 35;
            this.textBoxUnique.Text = "Name";
            this.textBoxUnique.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUnique.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxUnique.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // labelUnique
            // 
            this.labelUnique.AutoSize = true;
            this.labelUnique.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelUnique.Location = new System.Drawing.Point(10, 43);
            this.labelUnique.Name = "labelUnique";
            this.labelUnique.Size = new System.Drawing.Size(44, 13);
            this.labelUnique.TabIndex = 34;
            this.labelUnique.Text = "Unique:";
            // 
            // textBoxName
            // 
            this.textBoxName.AutoCompleteCustomSource.AddRange(new string[] {
            "Academy",
            "Crypt",
            "Dried Lake",
            "Dunes",
            "Dungeon",
            "Grotto",
            "Overgrown Ruin",
            "Tropical Island",
            "Arcade",
            "Arsenal",
            "Cemetery",
            "Mountain Ledge",
            "Sewer",
            "Thicket",
            "Wharf",
            "Ghetto",
            "Mud Geyser",
            "Reef",
            "Spider Lair",
            "Springs",
            "Vaal Pyramid",
            "Catacomb",
            "Overgrown Shrine",
            "Promenade",
            "Shore",
            "Spider Forest",
            "Tunnel",
            "Bog",
            "Coves",
            "Graveyard",
            "Pier",
            "Underground Sea",
            "Arachnid Nest",
            "Colonnade",
            "Dry Woods",
            "Strand",
            "Temple",
            "Jungle Valley",
            "Torture Chamber",
            "Waste Pool",
            "Mine",
            "Dry Peninsula",
            "Canyon",
            "Cells",
            "Dark Forest",
            "Gorge",
            "Maze",
            "Underground River",
            "Bazaar",
            "Necropolis",
            "Plateau",
            "Crematorium",
            "Precinct",
            "Shipyard",
            "Shrine",
            "Villa",
            "Palace"});
            this.textBoxName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxName.Location = new System.Drawing.Point(168, 13);
            this.textBoxName.MaxLength = 800;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(77, 22);
            this.textBoxName.TabIndex = 33;
            this.textBoxName.Text = "Name";
            this.textBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
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
            this.textBoxLevel.Location = new System.Drawing.Point(129, 13);
            this.textBoxLevel.MaxLength = 800;
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.Size = new System.Drawing.Size(33, 22);
            this.textBoxLevel.TabIndex = 32;
            this.textBoxLevel.Text = "Level";
            this.textBoxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLevel.Enter += new System.EventHandler(this.textBoxLevel_Enter);
            this.textBoxLevel.Leave += new System.EventHandler(this.textBoxLevel_Leave);
            // 
            // checkBoxCarto
            // 
            this.checkBoxCarto.AutoSize = true;
            this.checkBoxCarto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxCarto.Location = new System.Drawing.Point(306, 16);
            this.checkBoxCarto.Name = "checkBoxCarto";
            this.checkBoxCarto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCarto.Size = new System.Drawing.Size(54, 17);
            this.checkBoxCarto.TabIndex = 31;
            this.checkBoxCarto.Text = ":Carto";
            this.checkBoxCarto.UseVisualStyleBackColor = true;
            // 
            // checkBoxZana
            // 
            this.checkBoxZana.AutoSize = true;
            this.checkBoxZana.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxZana.Location = new System.Drawing.Point(248, 16);
            this.checkBoxZana.Name = "checkBoxZana";
            this.checkBoxZana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxZana.Size = new System.Drawing.Size(54, 17);
            this.checkBoxZana.TabIndex = 30;
            this.checkBoxZana.Text = ":Zana";
            this.checkBoxZana.UseVisualStyleBackColor = true;
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
            this.textBoxRarity.Location = new System.Drawing.Point(60, 13);
            this.textBoxRarity.MaxLength = 800;
            this.textBoxRarity.Name = "textBoxRarity";
            this.textBoxRarity.Size = new System.Drawing.Size(63, 22);
            this.textBoxRarity.TabIndex = 29;
            this.textBoxRarity.Text = "Rarity";
            this.textBoxRarity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRarity.Enter += new System.EventHandler(this.textBoxRarity_Enter);
            this.textBoxRarity.Leave += new System.EventHandler(this.textBoxRarity_Leave);
            // 
            // panelEvents
            // 
            this.panelEvents.Controls.Add(this.listBoxEvents);
            this.panelEvents.Location = new System.Drawing.Point(62, 33);
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
            // labelMapDrop
            // 
            this.labelMapDrop.AutoSize = true;
            this.labelMapDrop.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelMapDrop.Location = new System.Drawing.Point(23, 17);
            this.labelMapDrop.Name = "labelMapDrop";
            this.labelMapDrop.Size = new System.Drawing.Size(31, 13);
            this.labelMapDrop.TabIndex = 10;
            this.labelMapDrop.Text = "Map:";
            // 
            // labelAddDrop
            // 
            this.labelAddDrop.AutoSize = true;
            this.labelAddDrop.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelAddDrop.Location = new System.Drawing.Point(21, 226);
            this.labelAddDrop.Name = "labelAddDrop";
            this.labelAddDrop.Size = new System.Drawing.Size(52, 13);
            this.labelAddDrop.TabIndex = 9;
            this.labelAddDrop.Text = "Add Drop";
            // 
            // labelMapDetails
            // 
            this.labelMapDetails.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelMapDetails.Location = new System.Drawing.Point(14, 25);
            this.labelMapDetails.Name = "labelMapDetails";
            this.labelMapDetails.Size = new System.Drawing.Size(370, 205);
            this.labelMapDetails.TabIndex = 11;
            this.labelMapDetails.Text = "Rarity: (0)\r\n{1}\r\nLevel: {2}\r\nQuantity: {3}\r\nQuality: {4}\r\n\r\n{5}";
            this.labelMapDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.AutoCompleteCustomSource.AddRange(new string[] {
            "Academy",
            "Crypt",
            "Dried Lake",
            "Dunes",
            "Dungeon",
            "Grotto",
            "Overgrown Ruin",
            "Tropical Island",
            "Arcade",
            "Arsenal",
            "Cemetery",
            "Mountain Ledge",
            "Sewer",
            "Thicket",
            "Wharf",
            "Ghetto",
            "Mud Geyser",
            "Reef",
            "Spider Lair",
            "Springs",
            "Vaal Pyramid",
            "Catacomb",
            "Overgrown Shrine",
            "Promenade",
            "Shore",
            "Spider Forest",
            "Tunnel",
            "Bog",
            "Coves",
            "Graveyard",
            "Pier",
            "Underground Sea",
            "Arachnid Nest",
            "Colonnade",
            "Dry Woods",
            "Strand",
            "Temple",
            "Jungle Valley",
            "Torture Chamber",
            "Waste Pool",
            "Mine",
            "Dry Peninsula",
            "Canyon",
            "Cells",
            "Dark Forest",
            "Gorge",
            "Maze",
            "Underground River",
            "Bazaar",
            "Necropolis",
            "Plateau",
            "Crematorium",
            "Precinct",
            "Shipyard",
            "Shrine",
            "Villa",
            "Palace"});
            this.textBoxNotes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxNotes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNotes.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotes.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxNotes.Location = new System.Drawing.Point(14, 344);
            this.textBoxNotes.MaxLength = 800;
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(370, 85);
            this.textBoxNotes.TabIndex = 38;
            this.textBoxNotes.Text = "Notes...";
            this.textBoxNotes.TextChanged += new System.EventHandler(this.textBoxNotes_TextChanged);
            this.textBoxNotes.Enter += new System.EventHandler(this.textBoxNotes_Enter);
            this.textBoxNotes.Leave += new System.EventHandler(this.textBoxNotes_Leave);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAdd.Location = new System.Drawing.Point(285, 68);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.OwnerDrawText = null;
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 38;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(396, 445);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.labelAddDrop);
            this.Controls.Add(this.panelAddDrop);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.labelMapDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Details";
            this.Text = "Details";
            this.VisibleChanged += new System.EventHandler(this.Details_VisibleChanged);
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
        private TextBox textBoxName;
        private TextBox textBoxUnique;
        private Label labelUnique;
        private TextBox textBox1;
        private Label labelCurrency;
        private Flatbutton buttonAdd;
        private Label labelMapDetails;
        private TextBox textBoxNotes;
    }
}