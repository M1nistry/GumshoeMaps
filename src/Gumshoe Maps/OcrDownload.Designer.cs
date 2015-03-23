namespace Gumshoe_Maps
{
    partial class OcrDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcrDownload));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxDownloadLog = new System.Windows.Forms.TextBox();
            this.labelExperience = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 46);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(281, 24);
            this.progressBar.TabIndex = 0;
            // 
            // textBoxDownloadLog
            // 
            this.textBoxDownloadLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDownloadLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.textBoxDownloadLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDownloadLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxDownloadLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDownloadLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDownloadLog.Location = new System.Drawing.Point(12, 76);
            this.textBoxDownloadLog.MaxLength = 800;
            this.textBoxDownloadLog.Multiline = true;
            this.textBoxDownloadLog.Name = "textBoxDownloadLog";
            this.textBoxDownloadLog.ReadOnly = true;
            this.textBoxDownloadLog.Size = new System.Drawing.Size(281, 66);
            this.textBoxDownloadLog.TabIndex = 1;
            this.textBoxDownloadLog.TabStop = false;
            // 
            // labelExperience
            // 
            this.labelExperience.AutoSize = true;
            this.labelExperience.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelExperience.Location = new System.Drawing.Point(9, 19);
            this.labelExperience.Name = "labelExperience";
            this.labelExperience.Size = new System.Drawing.Size(288, 13);
            this.labelExperience.TabIndex = 6;
            this.labelExperience.Text = "Downloading required files (12.5 mb) necesarry for first run...";
            // 
            // OcrDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(305, 154);
            this.Controls.Add(this.labelExperience);
            this.Controls.Add(this.textBoxDownloadLog);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OcrDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OcrDownload";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OcrDownload_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDownloadLog;
        internal System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelExperience;
    }
}