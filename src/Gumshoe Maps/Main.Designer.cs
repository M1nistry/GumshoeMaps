namespace Gumshoe_Maps
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelDgv = new System.Windows.Forms.Panel();
            this.dgvMaps = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCurrentMap = new System.Windows.Forms.Panel();
            this.labelDurationValue = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelMapValue = new System.Windows.Forms.Label();
            this.labelCurrentMap = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatusValue = new System.Windows.Forms.Label();
            this.panelDgvExtra = new System.Windows.Forms.Panel();
            this.dgvDrops = new System.Windows.Forms.DataGridView();
            this.numericZana = new System.Windows.Forms.NumericUpDown();
            this.labelZana = new System.Windows.Forms.Label();
            this.timerMap = new System.Windows.Forms.Timer(this.components);
            this.titleBar = new Gumshoe_Maps.TitleBar();
            this.dgvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDrops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
            this.panelCurrentMap.SuspendLayout();
            this.panelDgvExtra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZana)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDgv
            // 
            this.panelDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDgv.Controls.Add(this.dgvMaps);
            this.panelDgv.Location = new System.Drawing.Point(9, 113);
            this.panelDgv.Margin = new System.Windows.Forms.Padding(2);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(480, 241);
            this.panelDgv.TabIndex = 5;
            this.panelDgv.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDgv_Paint);
            // 
            // dgvMaps
            // 
            this.dgvMaps.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMaps.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaps.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.dgvMaps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.mapColumn,
            this.levelColumn,
            this.quantityColumn,
            this.qualityColumn,
            this.minusColumn,
            this.evenColumn,
            this.plusColumn});
            this.dgvMaps.Location = new System.Drawing.Point(1, 2);
            this.dgvMaps.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMaps.Name = "dgvMaps";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaps.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMaps.RowHeadersVisible = false;
            this.dgvMaps.RowTemplate.Height = 24;
            this.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaps.Size = new System.Drawing.Size(478, 234);
            this.dgvMaps.TabIndex = 5;
            this.dgvMaps.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaps_RowEnter);
            this.dgvMaps.SelectionChanged += new System.EventHandler(this.dgvMaps_SelectionChanged);
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "id";
            this.idColumn.HeaderText = "ID";
            this.idColumn.Name = "idColumn";
            this.idColumn.Visible = false;
            // 
            // mapColumn
            // 
            this.mapColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mapColumn.DataPropertyName = "name";
            this.mapColumn.HeaderText = "Map";
            this.mapColumn.MinimumWidth = 250;
            this.mapColumn.Name = "mapColumn";
            // 
            // levelColumn
            // 
            this.levelColumn.DataPropertyName = "level";
            this.levelColumn.HeaderText = "Level";
            this.levelColumn.Name = "levelColumn";
            this.levelColumn.Width = 35;
            // 
            // quantityColumn
            // 
            this.quantityColumn.DataPropertyName = "quantity";
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.Width = 50;
            // 
            // qualityColumn
            // 
            this.qualityColumn.DataPropertyName = "quality";
            this.qualityColumn.HeaderText = "Quality";
            this.qualityColumn.Name = "qualityColumn";
            this.qualityColumn.Width = 50;
            // 
            // minusColumn
            // 
            this.minusColumn.DataPropertyName = "-";
            this.minusColumn.HeaderText = "-";
            this.minusColumn.Name = "minusColumn";
            this.minusColumn.Width = 30;
            // 
            // evenColumn
            // 
            this.evenColumn.DataPropertyName = " ";
            this.evenColumn.HeaderText = " ";
            this.evenColumn.Name = "evenColumn";
            this.evenColumn.Width = 30;
            // 
            // plusColumn
            // 
            this.plusColumn.DataPropertyName = "+";
            this.plusColumn.HeaderText = "+";
            this.plusColumn.Name = "plusColumn";
            this.plusColumn.Width = 30;
            // 
            // panelCurrentMap
            // 
            this.panelCurrentMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCurrentMap.Controls.Add(this.labelDurationValue);
            this.panelCurrentMap.Controls.Add(this.labelId);
            this.panelCurrentMap.Controls.Add(this.labelDuration);
            this.panelCurrentMap.Controls.Add(this.labelMapValue);
            this.panelCurrentMap.Controls.Add(this.labelCurrentMap);
            this.panelCurrentMap.Location = new System.Drawing.Point(9, 59);
            this.panelCurrentMap.Name = "panelCurrentMap";
            this.panelCurrentMap.Size = new System.Drawing.Size(188, 49);
            this.panelCurrentMap.TabIndex = 4;
            this.panelCurrentMap.Visible = false;
            // 
            // labelDurationValue
            // 
            this.labelDurationValue.AutoSize = true;
            this.labelDurationValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDurationValue.Location = new System.Drawing.Point(75, 24);
            this.labelDurationValue.Name = "labelDurationValue";
            this.labelDurationValue.Size = new System.Drawing.Size(49, 13);
            this.labelDurationValue.TabIndex = 4;
            this.labelDurationValue.Text = "00:00:00";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Enabled = false;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelId.Location = new System.Drawing.Point(169, 2);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 12);
            this.labelId.TabIndex = 3;
            this.labelId.Visible = false;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDuration.Location = new System.Drawing.Point(24, 24);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(50, 13);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "Duration:";
            // 
            // labelMapValue
            // 
            this.labelMapValue.AutoSize = true;
            this.labelMapValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMapValue.Location = new System.Drawing.Point(75, 6);
            this.labelMapValue.Name = "labelMapValue";
            this.labelMapValue.Size = new System.Drawing.Size(0, 13);
            this.labelMapValue.TabIndex = 1;
            // 
            // labelCurrentMap
            // 
            this.labelCurrentMap.AutoSize = true;
            this.labelCurrentMap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCurrentMap.Location = new System.Drawing.Point(6, 5);
            this.labelCurrentMap.Name = "labelCurrentMap";
            this.labelCurrentMap.Size = new System.Drawing.Size(68, 13);
            this.labelCurrentMap.TabIndex = 0;
            this.labelCurrentMap.Text = "Current Map:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelStatus.Location = new System.Drawing.Point(17, 35);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Status:";
            // 
            // labelStatusValue
            // 
            this.labelStatusValue.AutoSize = true;
            this.labelStatusValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelStatusValue.Location = new System.Drawing.Point(54, 35);
            this.labelStatusValue.Name = "labelStatusValue";
            this.labelStatusValue.Size = new System.Drawing.Size(188, 13);
            this.labelStatusValue.TabIndex = 5;
            this.labelStatusValue.Text = "Awaiting a map to be selected to run...";
            // 
            // panelDgvExtra
            // 
            this.panelDgvExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDgvExtra.Controls.Add(this.dgvDrops);
            this.panelDgvExtra.Location = new System.Drawing.Point(9, 359);
            this.panelDgvExtra.Name = "panelDgvExtra";
            this.panelDgvExtra.Size = new System.Drawing.Size(479, 100);
            this.panelDgvExtra.TabIndex = 6;
            // 
            // dgvDrops
            // 
            this.dgvDrops.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDrops.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDrops.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDrops.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.dgvDrops.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDrops.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDrops.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDrops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrops.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvId,
            this.dataGridViewTextBoxColumn2,
            this.columnDrops});
            this.dgvDrops.Location = new System.Drawing.Point(2, 2);
            this.dgvDrops.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDrops.Name = "dgvDrops";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDrops.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDrops.RowHeadersVisible = false;
            this.dgvDrops.RowTemplate.Height = 24;
            this.dgvDrops.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvDrops.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrops.Size = new System.Drawing.Size(473, 94);
            this.dgvDrops.TabIndex = 6;
            // 
            // numericZana
            // 
            this.numericZana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.numericZana.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericZana.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.numericZana.Location = new System.Drawing.Point(446, 36);
            this.numericZana.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericZana.Name = "numericZana";
            this.numericZana.Size = new System.Drawing.Size(31, 16);
            this.numericZana.TabIndex = 23;
            this.numericZana.ValueChanged += new System.EventHandler(this.numericZana_ValueChanged);
            // 
            // labelZana
            // 
            this.labelZana.AutoSize = true;
            this.labelZana.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelZana.Location = new System.Drawing.Point(368, 36);
            this.labelZana.Name = "labelZana";
            this.labelZana.Size = new System.Drawing.Size(75, 13);
            this.labelZana.TabIndex = 22;
            this.labelZana.Text = "Zana quantity:";
            // 
            // timerMap
            // 
            this.timerMap.Interval = 1000;
            this.timerMap.Tick += new System.EventHandler(this.timerMap_Tick);
            // 
            // titleBar
            // 
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.SettingsVisible = true;
            this.titleBar.Size = new System.Drawing.Size(496, 22);
            this.titleBar.TabIndex = 2;
            this.titleBar.Title = "Gumshoe Maps v0.1";
            this.titleBar.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // dgvId
            // 
            this.dgvId.DataPropertyName = "id";
            this.dgvId.HeaderText = "ID";
            this.dgvId.Name = "dgvId";
            this.dgvId.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // columnDrops
            // 
            this.columnDrops.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnDrops.HeaderText = "Drops";
            this.columnDrops.Name = "columnDrops";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(496, 471);
            this.Controls.Add(this.numericZana);
            this.Controls.Add(this.labelZana);
            this.Controls.Add(this.panelDgv);
            this.Controls.Add(this.panelDgvExtra);
            this.Controls.Add(this.labelStatusValue);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelCurrentMap);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panelDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
            this.panelCurrentMap.ResumeLayout(false);
            this.panelCurrentMap.PerformLayout();
            this.panelDgvExtra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDgv;
        private System.Windows.Forms.Panel panelCurrentMap;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelMapValue;
        private System.Windows.Forms.Label labelCurrentMap;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatusValue;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelDurationValue;
        private System.Windows.Forms.DataGridView dgvMaps;
        private System.Windows.Forms.Panel panelDgvExtra;
        private System.Windows.Forms.DataGridView dgvDrops;
        internal TitleBar titleBar;
        private System.Windows.Forms.NumericUpDown numericZana;
        private System.Windows.Forms.Label labelZana;
        private System.Windows.Forms.Timer timerMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn evenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDrops;
    }
}

