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
            this.components = new System.ComponentModel.Container();
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxOptIn = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(288, 22);
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
            this.titleLabel.Size = new System.Drawing.Size(49, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Settings";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelColor.Location = new System.Drawing.Point(11, 40);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(72, 13);
            this.labelColor.TabIndex = 8;
            this.labelColor.Text = "Theme/Color:";
            // 
            // trackBarRed
            // 
            this.trackBarRed.Location = new System.Drawing.Point(149, 37);
            this.trackBarRed.Maximum = 255;
            this.trackBarRed.Name = "trackBarRed";
            this.trackBarRed.Size = new System.Drawing.Size(127, 45);
            this.trackBarRed.TabIndex = 9;
            this.trackBarRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRed.ValueChanged += new System.EventHandler(this.trackBarColor_ValueChanged);
            // 
            // trackBarGreen
            // 
            this.trackBarGreen.Location = new System.Drawing.Point(149, 59);
            this.trackBarGreen.Maximum = 255;
            this.trackBarGreen.Name = "trackBarGreen";
            this.trackBarGreen.Size = new System.Drawing.Size(127, 45);
            this.trackBarGreen.TabIndex = 13;
            this.trackBarGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarGreen.ValueChanged += new System.EventHandler(this.trackBarColor_ValueChanged);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelRed.Location = new System.Drawing.Point(116, 40);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 15;
            this.labelRed.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(116, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Blue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(116, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Green";
            // 
            // trackBarBlue
            // 
            this.trackBarBlue.Location = new System.Drawing.Point(149, 82);
            this.trackBarBlue.Maximum = 255;
            this.trackBarBlue.Name = "trackBarBlue";
            this.trackBarBlue.Size = new System.Drawing.Size(127, 45);
            this.trackBarBlue.TabIndex = 14;
            this.trackBarBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBlue.ValueChanged += new System.EventHandler(this.trackBarColor_ValueChanged);
            // 
            // labelHotkeys
            // 
            this.labelHotkeys.AutoSize = true;
            this.labelHotkeys.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelHotkeys.Location = new System.Drawing.Point(34, 118);
            this.labelHotkeys.Name = "labelHotkeys";
            this.labelHotkeys.Size = new System.Drawing.Size(49, 13);
            this.labelHotkeys.TabIndex = 20;
            this.labelHotkeys.Text = "Hotkeys:";
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelMap.Location = new System.Drawing.Point(164, 119);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(58, 13);
            this.labelMap.TabIndex = 23;
            this.labelMap.Text = "Finish Map";
            // 
            // labelZana
            // 
            this.labelZana.AutoSize = true;
            this.labelZana.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelZana.Location = new System.Drawing.Point(154, 143);
            this.labelZana.Name = "labelZana";
            this.labelZana.Size = new System.Drawing.Size(68, 13);
            this.labelZana.TabIndex = 25;
            this.labelZana.Text = "Toggle Zana";
            // 
            // labelCarto
            // 
            this.labelCarto.AutoSize = true;
            this.labelCarto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelCarto.Location = new System.Drawing.Point(153, 169);
            this.labelCarto.Name = "labelCarto";
            this.labelCarto.Size = new System.Drawing.Size(68, 13);
            this.labelCarto.TabIndex = 27;
            this.labelCarto.Text = "Toggle Carto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(15, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Public opt-in:";
            // 
            // checkBoxOptIn
            // 
            this.checkBoxOptIn.AutoSize = true;
            this.checkBoxOptIn.Location = new System.Drawing.Point(207, 204);
            this.checkBoxOptIn.Name = "checkBoxOptIn";
            this.checkBoxOptIn.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOptIn.TabIndex = 29;
            this.checkBoxOptIn.UseVisualStyleBackColor = true;
            this.checkBoxOptIn.CheckedChanged += new System.EventHandler(this.checkBoxOptIn_CheckedChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelInfo.Location = new System.Drawing.Point(233, 204);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(13, 13);
            this.labelInfo.TabIndex = 30;
            this.labelInfo.Text = "?";
            this.toolTip.SetToolTip(this.labelInfo, "Opt-in to submit your map data to the public database.\r\nThis will allow your subm" +
        "itted data to increase the quality\r\nof reporting generated at the end of a leagu" +
        "e.");
            // 
            // buttonCartoHotkey
            // 
            this.buttonCartoHotkey.BackColor = System.Drawing.Color.Transparent;
            this.buttonCartoHotkey.FlatAppearance.BorderSize = 0;
            this.buttonCartoHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCartoHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCartoHotkey.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCartoHotkey.Location = new System.Drawing.Point(229, 165);
            this.buttonCartoHotkey.Name = "buttonCartoHotkey";
            this.buttonCartoHotkey.OwnerDrawText = "";
            this.buttonCartoHotkey.Size = new System.Drawing.Size(47, 22);
            this.buttonCartoHotkey.TabIndex = 26;
            this.buttonCartoHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCartoHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCartoHotkey.UseVisualStyleBackColor = false;
            this.buttonCartoHotkey.Click += new System.EventHandler(this.buttonCartoHotkey_Click);
            this.buttonCartoHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonCartoHotkey_KeyDown);
            // 
            // buttonZanaHotkey
            // 
            this.buttonZanaHotkey.BackColor = System.Drawing.Color.Transparent;
            this.buttonZanaHotkey.FlatAppearance.BorderSize = 0;
            this.buttonZanaHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZanaHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZanaHotkey.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonZanaHotkey.Location = new System.Drawing.Point(229, 139);
            this.buttonZanaHotkey.Name = "buttonZanaHotkey";
            this.buttonZanaHotkey.OwnerDrawText = "";
            this.buttonZanaHotkey.Size = new System.Drawing.Size(47, 22);
            this.buttonZanaHotkey.TabIndex = 24;
            this.buttonZanaHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonZanaHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonZanaHotkey.UseVisualStyleBackColor = false;
            this.buttonZanaHotkey.Click += new System.EventHandler(this.buttonZanaHotkey_Click);
            this.buttonZanaHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonZanaHotkey_KeyDown);
            // 
            // buttonMapHotkey
            // 
            this.buttonMapHotkey.BackColor = System.Drawing.Color.Transparent;
            this.buttonMapHotkey.FlatAppearance.BorderSize = 0;
            this.buttonMapHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMapHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMapHotkey.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonMapHotkey.Location = new System.Drawing.Point(229, 115);
            this.buttonMapHotkey.Name = "buttonMapHotkey";
            this.buttonMapHotkey.OwnerDrawText = "";
            this.buttonMapHotkey.Size = new System.Drawing.Size(47, 22);
            this.buttonMapHotkey.TabIndex = 22;
            this.buttonMapHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMapHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMapHotkey.UseVisualStyleBackColor = false;
            this.buttonMapHotkey.Click += new System.EventHandler(this.buttonMapHotkey_Click);
            this.buttonMapHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonMapHotkey_KeyDown);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCancel.Location = new System.Drawing.Point(222, 239);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.OwnerDrawText = null;
            this.buttonCancel.Size = new System.Drawing.Size(54, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonApply.Location = new System.Drawing.Point(153, 239);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.OwnerDrawText = null;
            this.buttonApply.Size = new System.Drawing.Size(46, 23);
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
            this.buttonClose.Location = new System.Drawing.Point(266, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OwnerDrawText = null;
            this.buttonClose.Size = new System.Drawing.Size(22, 22);
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
            this.buttonMinimize.Location = new System.Drawing.Point(236, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.OwnerDrawText = "";
            this.buttonMinimize.Size = new System.Drawing.Size(22, 22);
            this.buttonMinimize.TabIndex = 20;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(288, 275);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.checkBoxOptIn);
            this.Controls.Add(this.label1);
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
        private Label label1;
        private CheckBox checkBoxOptIn;
        private Label labelInfo;
        private ToolTip toolTip;
    }
}