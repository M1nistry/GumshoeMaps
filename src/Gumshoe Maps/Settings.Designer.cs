using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    partial class Settings
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
            this.titlePanel = new Panel();
            this.titleLabel = new Label();
            this.labelColor = new Label();
            this.trackBarRed = new TrackBar();
            this.trackBarGreen = new TrackBar();
            this.labelRed = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.trackBarBlue = new TrackBar();
            this.labelHotkeys = new Label();
            this.labelMap = new Label();
            this.labelZana = new Label();
            this.labelCarto = new Label();
            this.buttonCartoHotkey = new Flatbutton();
            this.buttonZanaHotkey = new Flatbutton();
            this.buttonMapHotkey = new Flatbutton();
            this.buttonCancel = new Flatbutton();
            this.buttonApply = new Flatbutton();
            this.buttonClose = new Flatbutton();
            this.buttonMinimize = new Flatbutton();
            this.titlePanel.SuspendLayout();
            ((ISupportInitialize)(this.trackBarRed)).BeginInit();
            ((ISupportInitialize)(this.trackBarGreen)).BeginInit();
            ((ISupportInitialize)(this.trackBarBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = Color.BlueViolet;
            this.titlePanel.Controls.Add(this.buttonClose);
            this.titlePanel.Controls.Add(this.buttonMinimize);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = DockStyle.Top;
            this.titlePanel.Location = new Point(0, 0);
            this.titlePanel.Margin = new Padding(4, 4, 4, 4);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new Size(384, 27);
            this.titlePanel.TabIndex = 7;
            this.titlePanel.MouseDown += new MouseEventHandler(this.titlePanel_MouseDown);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new Point(15, 5);
            this.titleLabel.Margin = new Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new Size(58, 19);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Settings";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.ForeColor = SystemColors.ControlLight;
            this.labelColor.Location = new Point(15, 49);
            this.labelColor.Margin = new Padding(4, 0, 4, 0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new Size(93, 17);
            this.labelColor.TabIndex = 8;
            this.labelColor.Text = "Theme/Color:";
            // 
            // trackBarRed
            // 
            this.trackBarRed.Location = new Point(199, 46);
            this.trackBarRed.Margin = new Padding(4, 4, 4, 4);
            this.trackBarRed.Maximum = 255;
            this.trackBarRed.Name = "trackBarRed";
            this.trackBarRed.Size = new Size(169, 56);
            this.trackBarRed.TabIndex = 9;
            this.trackBarRed.TickStyle = TickStyle.None;
            this.trackBarRed.ValueChanged += new EventHandler(this.trackBarColor_ValueChanged);
            // 
            // trackBarGreen
            // 
            this.trackBarGreen.Location = new Point(199, 73);
            this.trackBarGreen.Margin = new Padding(4, 4, 4, 4);
            this.trackBarGreen.Maximum = 255;
            this.trackBarGreen.Name = "trackBarGreen";
            this.trackBarGreen.Size = new Size(169, 56);
            this.trackBarGreen.TabIndex = 13;
            this.trackBarGreen.TickStyle = TickStyle.None;
            this.trackBarGreen.ValueChanged += new EventHandler(this.trackBarBlue_ValueChanged);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.ForeColor = SystemColors.ControlLight;
            this.labelRed.Location = new Point(155, 49);
            this.labelRed.Margin = new Padding(4, 0, 4, 0);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new Size(34, 17);
            this.labelRed.TabIndex = 15;
            this.labelRed.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = SystemColors.ControlLight;
            this.label2.Location = new Point(155, 103);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(36, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Blue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = SystemColors.ControlLight;
            this.label3.Location = new Point(155, 75);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(48, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Green";
            // 
            // trackBarBlue
            // 
            this.trackBarBlue.Location = new Point(199, 101);
            this.trackBarBlue.Margin = new Padding(4, 4, 4, 4);
            this.trackBarBlue.Maximum = 255;
            this.trackBarBlue.Name = "trackBarBlue";
            this.trackBarBlue.Size = new Size(169, 56);
            this.trackBarBlue.TabIndex = 14;
            this.trackBarBlue.TickStyle = TickStyle.None;
            this.trackBarBlue.ValueChanged += new EventHandler(this.trackBarGreen_ValueChanged);
            // 
            // labelHotkeys
            // 
            this.labelHotkeys.AutoSize = true;
            this.labelHotkeys.ForeColor = SystemColors.ControlLight;
            this.labelHotkeys.Location = new Point(45, 145);
            this.labelHotkeys.Margin = new Padding(4, 0, 4, 0);
            this.labelHotkeys.Name = "labelHotkeys";
            this.labelHotkeys.Size = new Size(63, 17);
            this.labelHotkeys.TabIndex = 20;
            this.labelHotkeys.Text = "Hotkeys:";
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.ForeColor = SystemColors.ControlLight;
            this.labelMap.Location = new Point(221, 146);
            this.labelMap.Margin = new Padding(4, 0, 4, 0);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new Size(76, 17);
            this.labelMap.TabIndex = 23;
            this.labelMap.Text = "Finish Map";
            // 
            // labelZana
            // 
            this.labelZana.AutoSize = true;
            this.labelZana.ForeColor = SystemColors.ControlLight;
            this.labelZana.Location = new Point(208, 176);
            this.labelZana.Margin = new Padding(4, 0, 4, 0);
            this.labelZana.Name = "labelZana";
            this.labelZana.Size = new Size(89, 17);
            this.labelZana.TabIndex = 25;
            this.labelZana.Text = "Toggle Zana";
            // 
            // labelCarto
            // 
            this.labelCarto.AutoSize = true;
            this.labelCarto.ForeColor = SystemColors.ControlLight;
            this.labelCarto.Location = new Point(207, 208);
            this.labelCarto.Margin = new Padding(4, 0, 4, 0);
            this.labelCarto.Name = "labelCarto";
            this.labelCarto.Size = new Size(90, 17);
            this.labelCarto.TabIndex = 27;
            this.labelCarto.Text = "Toggle Carto";
            // 
            // buttonCartoHotkey
            // 
            this.buttonCartoHotkey.BackColor = Color.Transparent;
            this.buttonCartoHotkey.FlatAppearance.BorderSize = 0;
            this.buttonCartoHotkey.FlatStyle = FlatStyle.Flat;
            this.buttonCartoHotkey.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.buttonCartoHotkey.ForeColor = SystemColors.ControlLight;
            this.buttonCartoHotkey.Location = new Point(305, 203);
            this.buttonCartoHotkey.Margin = new Padding(4);
            this.buttonCartoHotkey.Name = "buttonCartoHotkey";
            this.buttonCartoHotkey.OwnerDrawText = "";
            this.buttonCartoHotkey.Size = new Size(39, 27);
            this.buttonCartoHotkey.TabIndex = 26;
            this.buttonCartoHotkey.Text = "F4";
            this.buttonCartoHotkey.TextAlign = ContentAlignment.TopCenter;
            this.buttonCartoHotkey.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.buttonCartoHotkey.UseVisualStyleBackColor = false;
            // 
            // buttonZanaHotkey
            // 
            this.buttonZanaHotkey.BackColor = Color.Transparent;
            this.buttonZanaHotkey.FlatAppearance.BorderSize = 0;
            this.buttonZanaHotkey.FlatStyle = FlatStyle.Flat;
            this.buttonZanaHotkey.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.buttonZanaHotkey.ForeColor = SystemColors.ControlLight;
            this.buttonZanaHotkey.Location = new Point(305, 171);
            this.buttonZanaHotkey.Margin = new Padding(4);
            this.buttonZanaHotkey.Name = "buttonZanaHotkey";
            this.buttonZanaHotkey.OwnerDrawText = "";
            this.buttonZanaHotkey.Size = new Size(39, 27);
            this.buttonZanaHotkey.TabIndex = 24;
            this.buttonZanaHotkey.Text = "F3";
            this.buttonZanaHotkey.TextAlign = ContentAlignment.TopCenter;
            this.buttonZanaHotkey.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.buttonZanaHotkey.UseVisualStyleBackColor = false;
            // 
            // buttonMapHotkey
            // 
            this.buttonMapHotkey.BackColor = Color.Transparent;
            this.buttonMapHotkey.FlatAppearance.BorderSize = 0;
            this.buttonMapHotkey.FlatStyle = FlatStyle.Flat;
            this.buttonMapHotkey.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.buttonMapHotkey.ForeColor = SystemColors.ControlLight;
            this.buttonMapHotkey.Location = new Point(305, 141);
            this.buttonMapHotkey.Margin = new Padding(4);
            this.buttonMapHotkey.Name = "buttonMapHotkey";
            this.buttonMapHotkey.OwnerDrawText = "";
            this.buttonMapHotkey.Size = new Size(39, 27);
            this.buttonMapHotkey.TabIndex = 22;
            this.buttonMapHotkey.Text = "F2";
            this.buttonMapHotkey.TextAlign = ContentAlignment.TopCenter;
            this.buttonMapHotkey.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.buttonMapHotkey.UseVisualStyleBackColor = false;
            this.buttonMapHotkey.Click += new EventHandler(this.buttonMapHotkey_Click);
            this.buttonMapHotkey.KeyDown += new KeyEventHandler(this.buttonMapHotkey_KeyDown);
            this.buttonMapHotkey.KeyPress += new KeyPressEventHandler(this.buttonMapHotkey_KeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = FlatStyle.Flat;
            this.buttonCancel.ForeColor = SystemColors.ControlLight;
            this.buttonCancel.Location = new Point(269, 283);
            this.buttonCancel.Margin = new Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.OwnerDrawText = null;
            this.buttonCancel.Size = new Size(72, 28);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.FlatStyle = FlatStyle.Flat;
            this.buttonApply.ForeColor = SystemColors.ControlLight;
            this.buttonApply.Location = new Point(177, 283);
            this.buttonApply.Margin = new Padding(4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.OwnerDrawText = null;
            this.buttonApply.Size = new Size(61, 28);
            this.buttonApply.TabIndex = 18;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new EventHandler(this.buttonApply_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = Color.Transparent;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = FlatStyle.Flat;
            this.buttonClose.ForeColor = SystemColors.ActiveCaptionText;
            this.buttonClose.Location = new Point(355, 0);
            this.buttonClose.Margin = new Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OwnerDrawText = null;
            this.buttonClose.Size = new Size(29, 27);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "×";
            this.buttonClose.TextAlign = ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = Color.Transparent;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = FlatStyle.Flat;
            this.buttonMinimize.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimize.ForeColor = SystemColors.ActiveCaptionText;
            this.buttonMinimize.Location = new Point(315, 0);
            this.buttonMinimize.Margin = new Padding(4);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.OwnerDrawText = "";
            this.buttonMinimize.Size = new Size(29, 27);
            this.buttonMinimize.TabIndex = 20;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.TextAlign = ContentAlignment.TopCenter;
            this.buttonMinimize.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new EventHandler(this.buttonMinimize_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new Size(384, 326);
            this.Controls.Add(this.labelCarto);
            this.Controls.Add(this.buttonCartoHotkey);
            this.Controls.Add(this.labelZana);
            this.Controls.Add(this.buttonZanaHotkey);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.buttonMapHotkey);
            this.Controls.Add(this.labelHotkeys);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.trackBarBlue);
            this.Controls.Add(this.trackBarGreen);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.trackBarRed);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new FormClosingEventHandler(this.Settings_FormClosing);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((ISupportInitialize)(this.trackBarRed)).EndInit();
            ((ISupportInitialize)(this.trackBarGreen)).EndInit();
            ((ISupportInitialize)(this.trackBarBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel titlePanel;
        private Flatbutton buttonClose;
        private Flatbutton buttonMinimize;
        private Label titleLabel;
        private Label labelColor;
        private TrackBar trackBarRed;
        private TrackBar trackBarGreen;
        private Label labelRed;
        private Label label2;
        private Label label3;
        private Flatbutton buttonApply;
        private Flatbutton buttonCancel;
        private TrackBar trackBarBlue;
        private Label labelHotkeys;
        private Flatbutton buttonMapHotkey;
        private Label labelMap;
        private Label labelZana;
        private Flatbutton buttonZanaHotkey;
        private Label labelCarto;
        private Flatbutton buttonCartoHotkey;
    }
}