namespace tkezelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tcTabpages = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.allowDate = new System.Windows.Forms.CheckBox();
            this.setMaxMonth = new System.Windows.Forms.ComboBox();
            this.setMaxYear = new System.Windows.Forms.ComboBox();
            this.setMinMonth = new System.Windows.Forms.ComboBox();
            this.setMinYear = new System.Windows.Forms.ComboBox();
            this.setEpulet = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.setMegnevezes = new System.Windows.Forms.TextBox();
            this.tpPrint = new System.Windows.Forms.TabPage();
            this.setPrintList = new System.Windows.Forms.CheckedListBox();
            this.setPrintName = new System.Windows.Forms.TextBox();
            this.btnPrintAdd = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tpExcel = new System.Windows.Forms.TabPage();
            this.btnExcelImport = new System.Windows.Forms.Button();
            this.tbDatabase = new System.Windows.Forms.TabPage();
            this.setDatabaseName = new System.Windows.Forms.TextBox();
            this.btnReconnect = new System.Windows.Forms.Button();
            this.setDatabasePassword = new System.Windows.Forms.TextBox();
            this.setDatabaseUsername = new System.Windows.Forms.TextBox();
            this.setDatabasePort = new System.Windows.Forms.TextBox();
            this.setDatabaseHost = new System.Windows.Forms.TextBox();
            this.setProvider = new System.Windows.Forms.ComboBox();
            this.tpEpuletek = new System.Windows.Forms.TabPage();
            this.btnEpuletAdd = new System.Windows.Forms.Button();
            this.tbEpuletAdd = new System.Windows.Forms.TextBox();
            this.getBevetel = new System.Windows.Forms.TextBox();
            this.getKiadas = new System.Windows.Forms.TextBox();
            this.getEgyenleg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.getTeljesEgyenleg = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tcTabpages.SuspendLayout();
            this.tpQuery.SuspendLayout();
            this.tpPrint.SuspendLayout();
            this.tpExcel.SuspendLayout();
            this.tbDatabase.SuspendLayout();
            this.tpEpuletek.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tcTabpages
            // 
            this.tcTabpages.Controls.Add(this.tpQuery);
            this.tcTabpages.Controls.Add(this.tpPrint);
            this.tcTabpages.Controls.Add(this.tpExcel);
            this.tcTabpages.Controls.Add(this.tbDatabase);
            this.tcTabpages.Controls.Add(this.tpEpuletek);
            this.tcTabpages.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcTabpages.ItemSize = new System.Drawing.Size(96, 18);
            this.tcTabpages.Location = new System.Drawing.Point(0, 0);
            this.tcTabpages.Name = "tcTabpages";
            this.tcTabpages.SelectedIndex = 0;
            this.tcTabpages.Size = new System.Drawing.Size(1007, 82);
            this.tcTabpages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcTabpages.TabIndex = 3;
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.label1);
            this.tpQuery.Controls.Add(this.allowDate);
            this.tpQuery.Controls.Add(this.setMaxMonth);
            this.tpQuery.Controls.Add(this.setMaxYear);
            this.tpQuery.Controls.Add(this.setMinMonth);
            this.tpQuery.Controls.Add(this.setMinYear);
            this.tpQuery.Controls.Add(this.setEpulet);
            this.tpQuery.Controls.Add(this.btnQuery);
            this.tpQuery.Controls.Add(this.setMegnevezes);
            this.tpQuery.Location = new System.Drawing.Point(4, 22);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuery.Size = new System.Drawing.Size(999, 56);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "Lekérdezés";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "-";
            this.label1.Visible = false;
            // 
            // allowDate
            // 
            this.allowDate.AutoSize = true;
            this.allowDate.Checked = true;
            this.allowDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.allowDate.Location = new System.Drawing.Point(819, 3);
            this.allowDate.Name = "allowDate";
            this.allowDate.Size = new System.Drawing.Size(102, 50);
            this.allowDate.TabIndex = 7;
            this.allowDate.Text = "Havi lekérdezés";
            this.allowDate.UseVisualStyleBackColor = true;
            this.allowDate.CheckedChanged += new System.EventHandler(this.btnPreview_checked);
            // 
            // setMaxMonth
            // 
            this.setMaxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setMaxMonth.FormattingEnabled = true;
            this.setMaxMonth.Items.AddRange(new object[] {
            "végéig",
            "Január",
            "Február",
            "Március",
            "Április",
            "Május",
            "Június",
            "Július",
            "Augusztus",
            "Szeptember",
            "Október",
            "November",
            "December"});
            this.setMaxMonth.Location = new System.Drawing.Point(311, 3);
            this.setMaxMonth.Name = "setMaxMonth";
            this.setMaxMonth.Size = new System.Drawing.Size(70, 21);
            this.setMaxMonth.TabIndex = 6;
            this.setMaxMonth.Visible = false;
            // 
            // setMaxYear
            // 
            this.setMaxYear.DropDownHeight = 128;
            this.setMaxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setMaxYear.FormattingEnabled = true;
            this.setMaxYear.IntegralHeight = false;
            this.setMaxYear.ItemHeight = 13;
            this.setMaxYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.setMaxYear.Location = new System.Drawing.Point(256, 3);
            this.setMaxYear.Name = "setMaxYear";
            this.setMaxYear.Size = new System.Drawing.Size(49, 21);
            this.setMaxYear.TabIndex = 5;
            this.setMaxYear.Visible = false;
            // 
            // setMinMonth
            // 
            this.setMinMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setMinMonth.FormattingEnabled = true;
            this.setMinMonth.Items.AddRange(new object[] {
            "év",
            "Január",
            "Február",
            "Március",
            "Április",
            "Május",
            "Június",
            "Július",
            "Augusztus",
            "Szeptember",
            "Október",
            "November",
            "December"});
            this.setMinMonth.Location = new System.Drawing.Point(154, 3);
            this.setMinMonth.Name = "setMinMonth";
            this.setMinMonth.Size = new System.Drawing.Size(80, 21);
            this.setMinMonth.TabIndex = 4;
            // 
            // setMinYear
            // 
            this.setMinYear.DropDownHeight = 128;
            this.setMinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setMinYear.FormattingEnabled = true;
            this.setMinYear.IntegralHeight = false;
            this.setMinYear.ItemHeight = 13;
            this.setMinYear.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.setMinYear.Location = new System.Drawing.Point(99, 3);
            this.setMinYear.Name = "setMinYear";
            this.setMinYear.Size = new System.Drawing.Size(49, 21);
            this.setMinYear.TabIndex = 3;
            // 
            // setEpulet
            // 
            this.setEpulet.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.setEpulet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.setEpulet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setEpulet.FormattingEnabled = true;
            this.setEpulet.Items.AddRange(new object[] {
            "Összes"});
            this.setEpulet.Location = new System.Drawing.Point(3, 3);
            this.setEpulet.Name = "setEpulet";
            this.setEpulet.Size = new System.Drawing.Size(90, 21);
            this.setEpulet.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(921, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 50);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "Lekérdezés";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.query);
            // 
            // setMegnevezes
            // 
            this.setMegnevezes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.setMegnevezes.Location = new System.Drawing.Point(3, 30);
            this.setMegnevezes.Name = "setMegnevezes";
            this.setMegnevezes.Size = new System.Drawing.Size(231, 20);
            this.setMegnevezes.TabIndex = 0;
            // 
            // tpPrint
            // 
            this.tpPrint.Controls.Add(this.setPrintList);
            this.tpPrint.Controls.Add(this.setPrintName);
            this.tpPrint.Controls.Add(this.btnPrintAdd);
            this.tpPrint.Controls.Add(this.btnPreview);
            this.tpPrint.Controls.Add(this.btnPrint);
            this.tpPrint.Location = new System.Drawing.Point(4, 22);
            this.tpPrint.Name = "tpPrint";
            this.tpPrint.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrint.Size = new System.Drawing.Size(999, 56);
            this.tpPrint.TabIndex = 1;
            this.tpPrint.Text = "Nyomtatás";
            this.tpPrint.UseVisualStyleBackColor = true;
            // 
            // setPrintList
            // 
            this.setPrintList.Dock = System.Windows.Forms.DockStyle.Right;
            this.setPrintList.FormattingEnabled = true;
            this.setPrintList.Location = new System.Drawing.Point(520, 3);
            this.setPrintList.Name = "setPrintList";
            this.setPrintList.Size = new System.Drawing.Size(326, 50);
            this.setPrintList.TabIndex = 5;
            this.setPrintList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.setPrintList_remove);
            // 
            // setPrintName
            // 
            this.setPrintName.Location = new System.Drawing.Point(0, 19);
            this.setPrintName.Name = "setPrintName";
            this.setPrintName.Size = new System.Drawing.Size(300, 20);
            this.setPrintName.TabIndex = 0;
            // 
            // btnPrintAdd
            // 
            this.btnPrintAdd.Location = new System.Drawing.Point(306, 19);
            this.btnPrintAdd.Name = "btnPrintAdd";
            this.btnPrintAdd.Size = new System.Drawing.Size(61, 20);
            this.btnPrintAdd.TabIndex = 4;
            this.btnPrintAdd.Text = "Hozzáad";
            this.btnPrintAdd.UseVisualStyleBackColor = true;
            this.btnPrintAdd.Click += new System.EventHandler(this.btnPrintAdd_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPreview.Location = new System.Drawing.Point(846, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 50);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Előnézet";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(921, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 50);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Nyomtatás";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tpExcel
            // 
            this.tpExcel.Controls.Add(this.btnExcelImport);
            this.tpExcel.Location = new System.Drawing.Point(4, 22);
            this.tpExcel.Name = "tpExcel";
            this.tpExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tpExcel.Size = new System.Drawing.Size(999, 56);
            this.tpExcel.TabIndex = 2;
            this.tpExcel.Text = "Excel";
            this.tpExcel.UseVisualStyleBackColor = true;
            // 
            // btnExcelImport
            // 
            this.btnExcelImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExcelImport.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelImport.Image")));
            this.btnExcelImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcelImport.Location = new System.Drawing.Point(3, 3);
            this.btnExcelImport.Name = "btnExcelImport";
            this.btnExcelImport.Size = new System.Drawing.Size(75, 50);
            this.btnExcelImport.TabIndex = 0;
            this.btnExcelImport.Text = "Importálás";
            this.btnExcelImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcelImport.UseVisualStyleBackColor = true;
            this.btnExcelImport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // tbDatabase
            // 
            this.tbDatabase.Controls.Add(this.setDatabaseName);
            this.tbDatabase.Controls.Add(this.btnReconnect);
            this.tbDatabase.Controls.Add(this.setDatabasePassword);
            this.tbDatabase.Controls.Add(this.setDatabaseUsername);
            this.tbDatabase.Controls.Add(this.setDatabasePort);
            this.tbDatabase.Controls.Add(this.setDatabaseHost);
            this.tbDatabase.Controls.Add(this.setProvider);
            this.tbDatabase.Location = new System.Drawing.Point(4, 22);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tbDatabase.Size = new System.Drawing.Size(999, 56);
            this.tbDatabase.TabIndex = 3;
            this.tbDatabase.Text = "Adatbázis";
            this.tbDatabase.UseVisualStyleBackColor = true;
            // 
            // setDatabaseName
            // 
            this.setDatabaseName.Location = new System.Drawing.Point(412, 30);
            this.setDatabaseName.Name = "setDatabaseName";
            this.setDatabaseName.Size = new System.Drawing.Size(100, 20);
            this.setDatabaseName.TabIndex = 6;
            this.setDatabaseName.Text = "Database";
            // 
            // btnReconnect
            // 
            this.btnReconnect.Location = new System.Drawing.Point(518, 30);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(75, 20);
            this.btnReconnect.TabIndex = 7;
            this.btnReconnect.Text = "Csatlakozás";
            this.btnReconnect.UseVisualStyleBackColor = true;
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // setDatabasePassword
            // 
            this.setDatabasePassword.Location = new System.Drawing.Point(276, 30);
            this.setDatabasePassword.Name = "setDatabasePassword";
            this.setDatabasePassword.Size = new System.Drawing.Size(100, 20);
            this.setDatabasePassword.TabIndex = 5;
            this.setDatabasePassword.UseSystemPasswordChar = true;
            // 
            // setDatabaseUsername
            // 
            this.setDatabaseUsername.Location = new System.Drawing.Point(170, 30);
            this.setDatabaseUsername.Name = "setDatabaseUsername";
            this.setDatabaseUsername.Size = new System.Drawing.Size(100, 20);
            this.setDatabaseUsername.TabIndex = 4;
            this.setDatabaseUsername.Text = "Username";
            // 
            // setDatabasePort
            // 
            this.setDatabasePort.Location = new System.Drawing.Point(109, 30);
            this.setDatabasePort.Name = "setDatabasePort";
            this.setDatabasePort.Size = new System.Drawing.Size(36, 20);
            this.setDatabasePort.TabIndex = 3;
            this.setDatabasePort.Text = "Port";
            // 
            // setDatabaseHost
            // 
            this.setDatabaseHost.Location = new System.Drawing.Point(3, 30);
            this.setDatabaseHost.Name = "setDatabaseHost";
            this.setDatabaseHost.Size = new System.Drawing.Size(100, 20);
            this.setDatabaseHost.TabIndex = 2;
            this.setDatabaseHost.Text = "Host";
            // 
            // setProvider
            // 
            this.setProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setProvider.FormattingEnabled = true;
            this.setProvider.Items.AddRange(new object[] {
            "Access adatbázis (Fájlból)",
            "MySQL (Online adatbázis)"});
            this.setProvider.Location = new System.Drawing.Point(3, 3);
            this.setProvider.Name = "setProvider";
            this.setProvider.Size = new System.Drawing.Size(183, 21);
            this.setProvider.TabIndex = 0;
            this.setProvider.SelectedIndexChanged += new System.EventHandler(this.setProvider_SelectedIndexChanged);
            // 
            // tpEpuletek
            // 
            this.tpEpuletek.Controls.Add(this.btnEpuletAdd);
            this.tpEpuletek.Controls.Add(this.tbEpuletAdd);
            this.tpEpuletek.Location = new System.Drawing.Point(4, 22);
            this.tpEpuletek.Name = "tpEpuletek";
            this.tpEpuletek.Padding = new System.Windows.Forms.Padding(3);
            this.tpEpuletek.Size = new System.Drawing.Size(999, 56);
            this.tpEpuletek.TabIndex = 4;
            this.tpEpuletek.Text = "Új Társasház";
            this.tpEpuletek.UseVisualStyleBackColor = true;
            // 
            // btnEpuletAdd
            // 
            this.btnEpuletAdd.Location = new System.Drawing.Point(192, 4);
            this.btnEpuletAdd.Name = "btnEpuletAdd";
            this.btnEpuletAdd.Size = new System.Drawing.Size(75, 20);
            this.btnEpuletAdd.TabIndex = 1;
            this.btnEpuletAdd.Text = "Hozzáadás";
            this.btnEpuletAdd.UseVisualStyleBackColor = true;
            this.btnEpuletAdd.Click += new System.EventHandler(this.btnEpuletAdd_Click);
            // 
            // tbEpuletAdd
            // 
            this.tbEpuletAdd.Location = new System.Drawing.Point(4, 4);
            this.tbEpuletAdd.Name = "tbEpuletAdd";
            this.tbEpuletAdd.Size = new System.Drawing.Size(181, 20);
            this.tbEpuletAdd.TabIndex = 0;
            // 
            // getBevetel
            // 
            this.getBevetel.Location = new System.Drawing.Point(309, 6);
            this.getBevetel.Name = "getBevetel";
            this.getBevetel.ReadOnly = true;
            this.getBevetel.Size = new System.Drawing.Size(100, 20);
            this.getBevetel.TabIndex = 5;
            this.getBevetel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // getKiadas
            // 
            this.getKiadas.Location = new System.Drawing.Point(415, 6);
            this.getKiadas.Name = "getKiadas";
            this.getKiadas.ReadOnly = true;
            this.getKiadas.Size = new System.Drawing.Size(100, 20);
            this.getKiadas.TabIndex = 6;
            this.getKiadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // getEgyenleg
            // 
            this.getEgyenleg.Location = new System.Drawing.Point(521, 6);
            this.getEgyenleg.Name = "getEgyenleg";
            this.getEgyenleg.ReadOnly = true;
            this.getEgyenleg.Size = new System.Drawing.Size(100, 20);
            this.getEgyenleg.TabIndex = 7;
            this.getEgyenleg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.getTeljesEgyenleg);
            this.panel1.Controls.Add(this.getBevetel);
            this.panel1.Controls.Add(this.getEgyenleg);
            this.panel1.Controls.Add(this.getKiadas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 485);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 55);
            this.panel1.TabIndex = 8;
            // 
            // getTeljesEgyenleg
            // 
            this.getTeljesEgyenleg.Location = new System.Drawing.Point(521, 29);
            this.getTeljesEgyenleg.Name = "getTeljesEgyenleg";
            this.getTeljesEgyenleg.ReadOnly = true;
            this.getTeljesEgyenleg.Size = new System.Drawing.Size(100, 20);
            this.getTeljesEgyenleg.TabIndex = 8;
            this.getTeljesEgyenleg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvData
            // 
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvData.Location = new System.Drawing.Point(0, 82);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvData.Size = new System.Drawing.Size(1007, 403);
            this.dgvData.TabIndex = 9;
            this.dgvData.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.set_row);
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_click);
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cell_value_changed);
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.column_resize);
            this.dgvData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.format_error);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.remove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1007, 540);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcTabpages);
            this.Name = "Main";
            this.Text = "Társasházkezelő Szoftver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exit);
            this.Load += new System.EventHandler(this.init);
            this.tcTabpages.ResumeLayout(false);
            this.tpQuery.ResumeLayout(false);
            this.tpQuery.PerformLayout();
            this.tpPrint.ResumeLayout(false);
            this.tpPrint.PerformLayout();
            this.tpExcel.ResumeLayout(false);
            this.tbDatabase.ResumeLayout(false);
            this.tbDatabase.PerformLayout();
            this.tpEpuletek.ResumeLayout(false);
            this.tpEpuletek.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpPrint;
        public System.Windows.Forms.TextBox setMegnevezes;
        public System.Windows.Forms.ComboBox setEpulet;
        public System.Windows.Forms.TextBox getBevetel;
        public System.Windows.Forms.TextBox getKiadas;
        public System.Windows.Forms.TextBox getEgyenleg;
        public System.Windows.Forms.ComboBox setMinYear;
        public System.Windows.Forms.ComboBox setMinMonth;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.TextBox setPrintName;
        public System.Windows.Forms.ComboBox setMaxMonth;
        public System.Windows.Forms.ComboBox setMaxYear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.CheckBox allowDate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox getTeljesEgyenleg;
        private System.Windows.Forms.TabPage tpExcel;
        private System.Windows.Forms.Button btnExcelImport;
        private System.Windows.Forms.TabPage tbDatabase;
        private System.Windows.Forms.Button btnPrintAdd;
        private System.Windows.Forms.TabPage tpEpuletek;
        public System.Windows.Forms.ComboBox setProvider;
        public System.Windows.Forms.TextBox setDatabasePassword;
        public System.Windows.Forms.TextBox setDatabaseUsername;
        public System.Windows.Forms.TextBox setDatabasePort;
        public System.Windows.Forms.TextBox setDatabaseHost;
        private System.Windows.Forms.Button btnQuery;
        public System.Windows.Forms.CheckedListBox setPrintList;
        private System.Windows.Forms.Button btnEpuletAdd;
        public System.Windows.Forms.TextBox tbEpuletAdd;
        private System.Windows.Forms.Button btnReconnect;
        public System.Windows.Forms.TextBox setDatabaseName;
        public System.Windows.Forms.TabPage tpQuery;
        public System.Windows.Forms.TabControl tcTabpages;
    }
}

