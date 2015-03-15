namespace Gumshoe_Maps
{
    partial class Reporting
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.buttonClose = new Gumshoe_Maps.Flatbutton();
            this.buttonMinimize = new Gumshoe_Maps.Flatbutton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.labelLeague = new System.Windows.Forms.Label();
            this.checkedListBoxLeague = new System.Windows.Forms.CheckedListBox();
            this.titlePanel.SuspendLayout();
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
            this.titlePanel.Size = new System.Drawing.Size(305, 22);
            this.titlePanel.TabIndex = 8;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClose.Location = new System.Drawing.Point(280, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OwnerDrawText = null;
            this.buttonClose.Size = new System.Drawing.Size(22, 22);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "×";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.UseVisualStyleBackColor = false;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonMinimize.Location = new System.Drawing.Point(250, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.OwnerDrawText = "";
            this.buttonMinimize.Size = new System.Drawing.Size(22, 22);
            this.buttonMinimize.TabIndex = 20;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(11, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(59, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Reporting";
            // 
            // labelLeague
            // 
            this.labelLeague.AutoSize = true;
            this.labelLeague.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelLeague.Location = new System.Drawing.Point(14, 38);
            this.labelLeague.Name = "labelLeague";
            this.labelLeague.Size = new System.Drawing.Size(46, 13);
            this.labelLeague.TabIndex = 9;
            this.labelLeague.Text = "League:";
            // 
            // checkedListBoxLeague
            // 
            this.checkedListBoxLeague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.checkedListBoxLeague.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxLeague.FormattingEnabled = true;
            this.checkedListBoxLeague.Location = new System.Drawing.Point(66, 38);
            this.checkedListBoxLeague.Name = "checkedListBoxLeague";
            this.checkedListBoxLeague.Size = new System.Drawing.Size(153, 92);
            this.checkedListBoxLeague.TabIndex = 10;
            // 
            // Reporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(305, 280);
            this.Controls.Add(this.checkedListBoxLeague);
            this.Controls.Add(this.labelLeague);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reporting";
            this.Text = "Reporting";
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private Flatbutton buttonClose;
        private Flatbutton buttonMinimize;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label labelLeague;
        private System.Windows.Forms.CheckedListBox checkedListBoxLeague;
    }
}