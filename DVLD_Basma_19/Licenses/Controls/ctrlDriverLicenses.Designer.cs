namespace DVLD_Basma_19
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbcDriverLicenses = new System.Windows.Forms.TabControl();
            this.tbpLocal = new System.Windows.Forms.TabPage();
            this.lblLocalLicensesRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbpInternational = new System.Windows.Forms.TabPage();
            this.lblInternationalLicensesRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.InternationalLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseInfoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDriverLicenses.SuspendLayout();
            this.tbpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.showLicenseInfoToolStripMenuItem.SuspendLayout();
            this.tbpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.InternationalLicenseHistorytoolStripMenuItem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcDriverLicenses
            // 
            this.tbcDriverLicenses.Controls.Add(this.tbpLocal);
            this.tbcDriverLicenses.Controls.Add(this.tbpInternational);
            this.tbcDriverLicenses.Location = new System.Drawing.Point(17, 32);
            this.tbcDriverLicenses.Name = "tbcDriverLicenses";
            this.tbcDriverLicenses.SelectedIndex = 0;
            this.tbcDriverLicenses.Size = new System.Drawing.Size(1050, 253);
            this.tbcDriverLicenses.TabIndex = 0;
            // 
            // tbpLocal
            // 
            this.tbpLocal.Controls.Add(this.lblLocalLicensesRecords);
            this.tbpLocal.Controls.Add(this.label5);
            this.tbpLocal.Controls.Add(this.label1);
            this.tbpLocal.Controls.Add(this.dgvLocalLicensesHistory);
            this.tbpLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpLocal.Location = new System.Drawing.Point(4, 22);
            this.tbpLocal.Name = "tbpLocal";
            this.tbpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLocal.Size = new System.Drawing.Size(1042, 266);
            this.tbpLocal.TabIndex = 0;
            this.tbpLocal.Text = "Local";
            this.tbpLocal.UseVisualStyleBackColor = true;
            // 
            // lblLocalLicensesRecords
            // 
            this.lblLocalLicensesRecords.AutoSize = true;
            this.lblLocalLicensesRecords.Location = new System.Drawing.Point(116, 202);
            this.lblLocalLicensesRecords.Name = "lblLocalLicensesRecords";
            this.lblLocalLicensesRecords.Size = new System.Drawing.Size(27, 20);
            this.lblLocalLicensesRecords.TabIndex = 136;
            this.lblLocalLicensesRecords.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 135;
            this.label5.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenses History:";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.showLicenseInfoToolStripMenuItem;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(21, 26);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1015, 173);
            this.dgvLocalLicensesHistory.TabIndex = 0;
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            // 
            // tbpInternational
            // 
            this.tbpInternational.Controls.Add(this.lblInternationalLicensesRecords);
            this.tbpInternational.Controls.Add(this.label3);
            this.tbpInternational.Controls.Add(this.label2);
            this.tbpInternational.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tbpInternational.Location = new System.Drawing.Point(4, 22);
            this.tbpInternational.Name = "tbpInternational";
            this.tbpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInternational.Size = new System.Drawing.Size(1042, 227);
            this.tbpInternational.TabIndex = 1;
            this.tbpInternational.Text = "International";
            this.tbpInternational.UseVisualStyleBackColor = true;
            // 
            // lblInternationalLicensesRecords
            // 
            this.lblInternationalLicensesRecords.AutoSize = true;
            this.lblInternationalLicensesRecords.Location = new System.Drawing.Point(125, 200);
            this.lblInternationalLicensesRecords.Name = "lblInternationalLicensesRecords";
            this.lblInternationalLicensesRecords.Size = new System.Drawing.Size(19, 13);
            this.lblInternationalLicensesRecords.TabIndex = 136;
            this.lblInternationalLicensesRecords.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 135;
            this.label3.Text = "# Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "International Licenses History:";
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHistory.ContextMenuStrip = this.InternationalLicenseHistorytoolStripMenuItem;
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(27, 26);
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(996, 166);
            this.dgvInternationalLicensesHistory.TabIndex = 1;
            // 
            // InternationalLicenseHistorytoolStripMenuItem
            // 
            this.InternationalLicenseHistorytoolStripMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem2});
            this.InternationalLicenseHistorytoolStripMenuItem.Name = "InternationalLicenseHistorytoolStripMenuItem";
            this.InternationalLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbcDriverLicenses);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 289);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = global::DVLD_Basma_19.Properties.Resources.License_View_325;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.ShowShortcutKeys = false;
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // showLicenseInfoToolStripMenuItem2
            // 
            this.showLicenseInfoToolStripMenuItem2.Image = global::DVLD_Basma_19.Properties.Resources.License_View_325;
            this.showLicenseInfoToolStripMenuItem2.Name = "showLicenseInfoToolStripMenuItem2";
            this.showLicenseInfoToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.showLicenseInfoToolStripMenuItem2.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem2.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem2_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1081, 307);
            this.tbcDriverLicenses.ResumeLayout(false);
            this.tbpLocal.ResumeLayout(false);
            this.tbpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.showLicenseInfoToolStripMenuItem.ResumeLayout(false);
            this.tbpInternational.ResumeLayout(false);
            this.tbpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.InternationalLicenseHistorytoolStripMenuItem.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDriverLicenses;
        private System.Windows.Forms.TabPage tbpLocal;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.TabPage tbpInternational;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLocalLicensesRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInternationalLicensesRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
        private System.Windows.Forms.ContextMenuStrip showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip InternationalLicenseHistorytoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem2;
    }
}
