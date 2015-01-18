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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.trackBarRed = new System.Windows.Forms.TrackBar();
            this.trackBarGreen = new System.Windows.Forms.TrackBar();
            this.labelRed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarBlue = new System.Windows.Forms.TrackBar();
            this.labelHotkeys = new System.Windows.Forms.Label();
            this.labelMap = new System.Windows.Forms.Label();
            this.labelZana = new System.Windows.Forms.Label();
            this.labelCarto = new System.Windows.Forms.Label();
            this.buttonCartoHotkey = new Gumshoe_Maps.Flatbutton();
            this.buttonZanaHotkey = new Gumshoe_Maps.Flatbutton();
            this.buttonMapHotkey = new Gumshoe_Maps.Flatbutton();
            this.buttonCancel = new Gumshoe_Maps.Flatbutton();
            this.buttonApply = new Gumshoe_Maps.Flatbutton();
            this.buttonClose = new Gumshoe_Maps.Flatbutton();
            this.buttonMinimize = new Gumshoe_Maps.Flatbutton();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).BeginInit();
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
            this.titlePanel.Margin = new System.Windows.Forms.Padding(4);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(384, 27);
            this.titlePanel.TabIndex = 7;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(15, 5);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(58, 19);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Settings";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelColor.Location = new System.Drawing.Point(15, 49);
            this.labelColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(93, 17);
            this.labelColor.TabIndex = 8;
            this.labelColor.Text = "Theme/Color:";
            // 
            // trackBarRed
            // 
            this.trackBarRed.Location = new System.Drawing.Point(199, 46);
            this.trackBarRed.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarRed.Maximum = 255;
            this.trackBarRed.Name = "trackBarRed";
            this.trackBarRed.Size = new System.Drawing.Size(169, 56);
            this.trackBarRed.TabIndex = 9;
            this.trackBarRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRed.ValueChanged += new System.EventHandler(this.trackBarColor_ValueChanged);
            // 
            // trackBarGreen
            // 
            this.trackBarGreen.Location = new System.Drawing.Point(199, 73);
            this.trackBarGreen.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarGreen.Maximum = 255;
            this.trackBarGreen.Name = "trackBarGreen";
            this.trackBarGreen.Size = new System.Drawing.Size(169, 56);
            this.trackBarGreen.TabIndex = 13;
            this.trackBarGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarGreen.ValueChanged += new System.EventHandler(this.trackBarBlue_ValueChanged);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelRed.Location = new System.Drawing.Point(155, 49);
            this.labelRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(34, 17);
            this.labelRed.TabIndex = 15;
            this.labelRed.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(155, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Blue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(155, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Green";
            // 
            // trackBarBlue
            // 
            this.trackBarBlue.Location = new System.Drawing.Point(199, 101);
            this.trackBarBlue.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarBlue.Maximum = 255;
            this.trackBarBlue.Name = "trackBarBlue";
            this.trackBarBlue.Size = new System.Drawing.Size(169, 56);
            this.trackBarBlue.TabIndex = 14;
            this.trackBarBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBlue.ValueChanged += new System.EventHandler(this.trackBarGreen_ValueChanged);
            // 
            // labelHotkeys
            // 
            this.labelHotkeys.AutoSize = true;
            this.labelHotkeys.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelHotkeys.Location = new System.Drawing.Point(45, 145);
            this.labelHotkeys.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHotkeys.Name = "labelHotkeys";
            this.labelHotkeys.Size = new System.Drawing.Size(63, 17);
            this.labelHotkeys.TabIndex = 20;
            this.labelHotkeys.Text = "Hotkeys:";
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelMap.Location = new System.Drawing.Point(221, 146);
            this.labelMap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(76, 17);
            this.labelMap.TabIndex = 23;
            this.labelMap.Text = "Finish Map";
            // 
            // labelZana
            // 
            this.labelZana.AutoSize = true;
            this.labelZana.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelZana.Location = new System.Drawing.Point(208, 176);
            this.labelZana.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelZana.Name = "labelZana";
            this.labelZana.Size = new System.Drawing.Size(89, 17);
            this.labelZana.TabIndex = 25;
            this.labelZana.Text = "Toggle Zana";
            // 
            // labelCarto
            // 
            this.labelCarto.AutoSize = true;
            this.labelCarto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelCarto.Location = new System.Drawing.Point(207, 208);
            this.labelCarto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCarto.Name = "labelCarto";
            this.labelCarto.Size = new System.Drawing.Size(90, 17);
            this.labelCarto.TabIndex = 27;
            this.labelCarto.Text = "Toggle Carto";
            // 
            // buttonCartoHotkey
            // 
            this.buttonCartoHotkey.BackColor = System.Drawing.Color.Transparent;
            this.buttonCartoHotkey.FlatAppearance.BorderSize = 0;
            this.buttonCartoHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCartoHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCartoHotkey.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCartoHotkey.Location = new System.Drawing.Point(305, 203);
            this.buttonCartoHotkey.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCartoHotkey.Name = "buttonCartoHotkey";
            this.buttonCartoHotkey.OwnerDrawText = "";
            this.buttonCartoHotkey.Size = new System.Drawing.Size(39, 27);
            this.buttonCartoHotkey.TabIndex = 26;
            this.buttonCartoHotkey.Text = "F4";
            this.buttonCartoHotkey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCartoHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCartoHotkey.UseVisualStyleBackColor = false;
            // 
            // buttonZanaHotkey
            // 
            this.buttonZanaHotkey.BackColor = System.Drawing.Color.Transparent;
            this.buttonZanaHotkey.FlatAppearance.BorderSize = 0;
            this.buttonZanaHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZanaHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZanaHotkey.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonZanaHotkey.Location = new System.Drawing.Point(305, 171);
            this.buttonZanaHotkey.Margin = new System.Windows.Forms.Padding(4);
            this.buttonZanaHotkey.Name = "buttonZanaHotkey";
            this.buttonZanaHotkey.OwnerDrawText = "";
            this.buttonZanaHotkey.Size = new System.Drawing.Size(39, 27);
            this.buttonZanaHotkey.TabIndex = 24;
            this.buttonZanaHotkey.Text = "F3";
            this.buttonZanaHotkey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonZanaHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonZanaHotkey.UseVisualStyleBackColor = false;
            // 
            // buttonMapHotkey
            // 
            this.buttonMapHotkey.BackColor = System.Drawing.Color.Transparent;
            this.buttonMapHotkey.FlatAppearance.BorderSize = 0;
            this.buttonMapHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMapHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMapHotkey.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonMapHotkey.Location = new System.Drawing.Point(305, 141);
            this.buttonMapHotkey.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMapHotkey.Name = "buttonMapHotkey";
            this.buttonMapHotkey.OwnerDrawText = "";
            this.buttonMapHotkey.Size = new System.Drawing.Size(39, 27);
            this.buttonMapHotkey.TabIndex = 22;
            this.buttonMapHotkey.Text = "F2";
            this.buttonMapHotkey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMapHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMapHotkey.UseVisualStyleBackColor = false;
            this.buttonMapHotkey.Click += new System.EventHandler(this.buttonMapHotkey_Click);
            this.buttonMapHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonMapHotkey_KeyDown);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCancel.Location = new System.Drawing.Point(269, 283);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.OwnerDrawText = null;
            this.buttonCancel.Size = new System.Drawing.Size(72, 28);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonApply.Location = new System.Drawing.Point(177, 283);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.OwnerDrawText = null;
            this.buttonApply.Size = new System.Drawing.Size(61, 28);
            this.buttonApply.TabIndex = 18;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClose.Location = new System.Drawing.Point(355, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OwnerDrawText = null;
            this.buttonClose.Size = new System.Drawing.Size(29, 27);
            this.buttonClose.TabIndex = 21;
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
            this.buttonMinimize.Location = new System.Drawing.Point(315, 0);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.OwnerDrawText = "";
            this.buttonMinimize.Size = new System.Drawing.Size(29, 27);
            this.buttonMinimize.TabIndex = 20;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(384, 326);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).EndInit();
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