namespace tkezelo
{
    partial class ExcelBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelBuilder));
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.import = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDatabaseExport = new System.Windows.Forms.Button();
            this.setColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setEpulet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTable
            // 
            this.dgvTable.BackgroundColor = System.Drawing.Color.White;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.GridColor = System.Drawing.Color.White;
            this.dgvTable.Location = new System.Drawing.Point(293, 54);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.Size = new System.Drawing.Size(577, 448);
            this.dgvTable.TabIndex = 0;
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.BackgroundColor = System.Drawing.Color.White;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.import});
            this.dgvColumns.GridColor = System.Drawing.Color.White;
            this.dgvColumns.Location = new System.Drawing.Point(3, 54);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.Size = new System.Drawing.Size(284, 448);
            this.dgvColumns.TabIndex = 3;
            this.dgvColumns.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumns_CellContentClick);
            this.dgvColumns.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.show_table);
            // 
            // import
            // 
            this.import.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.import.HeaderText = "import";
            this.import.Name = "import";
            this.import.Width = 41;
            // 
            // btnDatabaseExport
            // 
            this.btnDatabaseExport.Image = ((System.Drawing.Image)(resources.GetObject("btnDatabaseExport.Image")));
            this.btnDatabaseExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDatabaseExport.Location = new System.Drawing.Point(795, 0);
            this.btnDatabaseExport.Name = "btnDatabaseExport";
            this.btnDatabaseExport.Size = new System.Drawing.Size(75, 51);
            this.btnDatabaseExport.TabIndex = 4;
            this.btnDatabaseExport.Text = "Mentés";
            this.btnDatabaseExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDatabaseExport.UseVisualStyleBackColor = true;
            this.btnDatabaseExport.Click += new System.EventHandler(this.btnExcelImport_Click);
            // 
            // setColumn
            // 
            this.setColumn.AllowDrop = true;
            this.setColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setColumn.FormattingEnabled = true;
            this.setColumn.Location = new System.Drawing.Point(3, 30);
            this.setColumn.Name = "setColumn";
            this.setColumn.Size = new System.Drawing.Size(256, 21);
            this.setColumn.TabIndex = 5;
            this.setColumn.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Épület:";
            // 
            // setEpulet
            // 
            this.setEpulet.AllowDrop = true;
            this.setEpulet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setEpulet.FormattingEnabled = true;
            this.setEpulet.Location = new System.Drawing.Point(46, 6);
            this.setEpulet.Name = "setEpulet";
            this.setEpulet.Size = new System.Drawing.Size(213, 21);
            this.setEpulet.TabIndex = 8;
            this.setEpulet.SelectedIndexChanged += new System.EventHandler(this.setEpulet_SelectedIndexChanged);
            // 
            // ExcelBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 504);
            this.Controls.Add(this.setEpulet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setColumn);
            this.Controls.Add(this.btnDatabaseExport);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.dgvTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelBuilder";
            this.Text = "Excel importáló";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTable;
        public System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.DataGridViewCheckBoxColumn import;
        private System.Windows.Forms.Button btnDatabaseExport;
        public System.Windows.Forms.ComboBox setColumn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox setEpulet;

    }
}

