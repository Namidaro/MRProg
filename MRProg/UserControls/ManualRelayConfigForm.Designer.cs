namespace MRProg.UserControls
{
    partial class ManualRelayConfigForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._discretDgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._discretAcceptButton = new System.Windows.Forms.Button();
            this._discretCountTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._relayDgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._relayAcceptButton = new System.Windows.Forms.Button();
            this._relayCountTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._diodeDgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._diodeAcceptButton = new System.Windows.Forms.Button();
            this._diodeCountTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this._systemDiodeDgv = new System.Windows.Forms.DataGridView();
            this._systemDiodeAcceptButton = new System.Windows.Forms.Button();
            this._systemDiodeCountTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._discretDgv)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._relayDgv)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._diodeDgv)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._systemDiodeDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                             | System.Windows.Forms.AnchorStyles.Left)
                                                                            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(388, 233);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._discretDgv);
            this.tabPage2.Controls.Add(this._discretAcceptButton);
            this.tabPage2.Controls.Add(this._discretCountTb);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(380, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Дискреты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _discretDgv
            // 
            this._discretDgv.AllowUserToAddRows = false;
            this._discretDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                             | System.Windows.Forms.AnchorStyles.Left)
                                                                            | System.Windows.Forms.AnchorStyles.Right)));
            this._discretDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._discretDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._discretDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dataGridViewTextBoxColumn1,
                this.dataGridViewComboBoxColumn1,
                this.dataGridViewComboBoxColumn2,
                this.dataGridViewCheckBoxColumn1,
                this.dataGridViewCheckBoxColumn2});
            this._discretDgv.Location = new System.Drawing.Point(0, 37);
            this._discretDgv.Name = "_discretDgv";
            this._discretDgv.RowHeadersVisible = false;
            this._discretDgv.Size = new System.Drawing.Size(380, 170);
            this._discretDgv.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn1.HeaderText = "Порт";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 38;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn2.HeaderText = "Pin";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Width = 28;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Внутренняя подтяжка";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 112;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Инверсия сигнала";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 96;
            // 
            // _discretAcceptButton
            // 
            this._discretAcceptButton.Location = new System.Drawing.Point(133, 8);
            this._discretAcceptButton.Name = "_discretAcceptButton";
            this._discretAcceptButton.Size = new System.Drawing.Size(75, 23);
            this._discretAcceptButton.TabIndex = 6;
            this._discretAcceptButton.Text = "Принять";
            this._discretAcceptButton.UseVisualStyleBackColor = true;
            this._discretAcceptButton.Click += new System.EventHandler(this._discretAcceptButton_Click);
            // 
            // _discretCountTb
            // 
            this._discretCountTb.Location = new System.Drawing.Point(79, 10);
            this._discretCountTb.Name = "_discretCountTb";
            this._discretCountTb.Size = new System.Drawing.Size(48, 20);
            this._discretCountTb.TabIndex = 5;
            this._discretCountTb.Text = "0";
            this._discretCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._relayDgv);
            this.tabPage1.Controls.Add(this._relayAcceptButton);
            this.tabPage1.Controls.Add(this._relayCountTb);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(380, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Реле";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _relayDgv
            // 
            this._relayDgv.AllowUserToAddRows = false;
            this._relayDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                           | System.Windows.Forms.AnchorStyles.Left)
                                                                          | System.Windows.Forms.AnchorStyles.Right)));
            this._relayDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._relayDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Column1,
                this.Column2,
                this.Column3,
                this.Column4,
                this.Column5});
            this._relayDgv.Location = new System.Drawing.Point(0, 37);
            this._relayDgv.Name = "_relayDgv";
            this._relayDgv.RowHeadersVisible = false;
            this._relayDgv.Size = new System.Drawing.Size(380, 170);
            this._relayDgv.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Порт";
            this.Column2.Name = "Column2";
            this.Column2.Width = 38;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Pin";
            this.Column3.Name = "Column3";
            this.Column3.Width = 28;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Внутренняя подтяжка";
            this.Column4.Name = "Column4";
            this.Column4.Width = 112;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Инверсия сигнала";
            this.Column5.Name = "Column5";
            this.Column5.Width = 96;
            // 
            // _relayAcceptButton
            // 
            this._relayAcceptButton.Location = new System.Drawing.Point(133, 8);
            this._relayAcceptButton.Name = "_relayAcceptButton";
            this._relayAcceptButton.Size = new System.Drawing.Size(75, 23);
            this._relayAcceptButton.TabIndex = 2;
            this._relayAcceptButton.Text = "Принять";
            this._relayAcceptButton.UseVisualStyleBackColor = true;
            this._relayAcceptButton.Click += new System.EventHandler(this._relayAcceptButton_Click);
            // 
            // _relayCountTb
            // 
            this._relayCountTb.Location = new System.Drawing.Point(79, 10);
            this._relayCountTb.Name = "_relayCountTb";
            this._relayCountTb.Size = new System.Drawing.Size(48, 20);
            this._relayCountTb.TabIndex = 1;
            this._relayCountTb.Text = "0";
            this._relayCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._diodeDgv);
            this.tabPage3.Controls.Add(this._diodeAcceptButton);
            this.tabPage3.Controls.Add(this._diodeCountTb);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(380, 207);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Логические светодиоды";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _diodeDgv
            // 
            this._diodeDgv.AllowUserToAddRows = false;
            this._diodeDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                           | System.Windows.Forms.AnchorStyles.Left)
                                                                          | System.Windows.Forms.AnchorStyles.Right)));
            this._diodeDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._diodeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._diodeDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dataGridViewTextBoxColumn2,
                this.dataGridViewComboBoxColumn3,
                this.dataGridViewComboBoxColumn4,
                this.dataGridViewCheckBoxColumn3,
                this.dataGridViewCheckBoxColumn4});
            this._diodeDgv.Location = new System.Drawing.Point(0, 37);
            this._diodeDgv.Name = "_diodeDgv";
            this._diodeDgv.RowHeadersVisible = false;
            this._diodeDgv.Size = new System.Drawing.Size(380, 170);
            this._diodeDgv.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 5;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn3.HeaderText = "Порт";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Width = 38;
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn4.HeaderText = "Pin";
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            this.dataGridViewComboBoxColumn4.Width = 28;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn3.HeaderText = "Внутренняя подтяжка";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Width = 112;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn4.HeaderText = "Инверсия сигнала";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.Width = 96;
            // 
            // _diodeAcceptButton
            // 
            this._diodeAcceptButton.Location = new System.Drawing.Point(133, 8);
            this._diodeAcceptButton.Name = "_diodeAcceptButton";
            this._diodeAcceptButton.Size = new System.Drawing.Size(75, 23);
            this._diodeAcceptButton.TabIndex = 10;
            this._diodeAcceptButton.Text = "Принять";
            this._diodeAcceptButton.UseVisualStyleBackColor = true;
            this._diodeAcceptButton.Click += new System.EventHandler(this._diodeAcceptButton_Click);
            // 
            // _diodeCountTb
            // 
            this._diodeCountTb.Location = new System.Drawing.Point(79, 10);
            this._diodeCountTb.Name = "_diodeCountTb";
            this._diodeCountTb.Size = new System.Drawing.Size(48, 20);
            this._diodeCountTb.TabIndex = 9;
            this._diodeCountTb.Text = "0";
            this._diodeCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(234, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить в устройство";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this._systemDiodeDgv);
            this.tabPage4.Controls.Add(this._systemDiodeAcceptButton);
            this.tabPage4.Controls.Add(this._systemDiodeCountTb);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(380, 207);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Системные светодиоды";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // _systemDiodeDgv
            // 
            this._systemDiodeDgv.AllowUserToAddRows = false;
            this._systemDiodeDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                 | System.Windows.Forms.AnchorStyles.Left)
                                                                                | System.Windows.Forms.AnchorStyles.Right)));
            this._systemDiodeDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._systemDiodeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._systemDiodeDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.dataGridViewTextBoxColumn3,
                this.dataGridViewComboBoxColumn5,
                this.dataGridViewComboBoxColumn6,
                this.dataGridViewCheckBoxColumn5,
                this.dataGridViewCheckBoxColumn6,
                this.Column6});
            this._systemDiodeDgv.Location = new System.Drawing.Point(0, 33);
            this._systemDiodeDgv.Name = "_systemDiodeDgv";
            this._systemDiodeDgv.RowHeadersVisible = false;
            this._systemDiodeDgv.Size = new System.Drawing.Size(380, 170);
            this._systemDiodeDgv.TabIndex = 15;
            // 
            // _systemDiodeAcceptButton
            // 
            this._systemDiodeAcceptButton.Location = new System.Drawing.Point(133, 4);
            this._systemDiodeAcceptButton.Name = "_systemDiodeAcceptButton";
            this._systemDiodeAcceptButton.Size = new System.Drawing.Size(75, 23);
            this._systemDiodeAcceptButton.TabIndex = 14;
            this._systemDiodeAcceptButton.Text = "Принять";
            this._systemDiodeAcceptButton.UseVisualStyleBackColor = true;
            this._systemDiodeAcceptButton.Click += new System.EventHandler(this._systemDiodeAcceptButton_Click);
            // 
            // _systemDiodeCountTb
            // 
            this._systemDiodeCountTb.Location = new System.Drawing.Point(79, 6);
            this._systemDiodeCountTb.Name = "_systemDiodeCountTb";
            this._systemDiodeCountTb.Size = new System.Drawing.Size(48, 20);
            this._systemDiodeCountTb.TabIndex = 13;
            this._systemDiodeCountTb.Text = "0";
            this._systemDiodeCountTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Количество";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 5;
            // 
            // dataGridViewComboBoxColumn5
            // 
            this.dataGridViewComboBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn5.HeaderText = "Порт";
            this.dataGridViewComboBoxColumn5.Name = "dataGridViewComboBoxColumn5";
            this.dataGridViewComboBoxColumn5.Width = 38;
            // 
            // dataGridViewComboBoxColumn6
            // 
            this.dataGridViewComboBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn6.HeaderText = "Pin";
            this.dataGridViewComboBoxColumn6.Name = "dataGridViewComboBoxColumn6";
            this.dataGridViewComboBoxColumn6.Width = 28;
            // 
            // dataGridViewCheckBoxColumn5
            // 
            this.dataGridViewCheckBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn5.HeaderText = "Внутренняя подтяжка";
            this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
            this.dataGridViewCheckBoxColumn5.Width = 112;
            // 
            // dataGridViewCheckBoxColumn6
            // 
            this.dataGridViewCheckBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn6.HeaderText = "Инверсия сигнала";
            this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
            this.dataGridViewCheckBoxColumn6.Width = 96;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Тип";
            this.Column6.Name = "Column6";
            // 
            // ManualRelayConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(320, 300);
            this.Name = "ManualRelayConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурация реле и дискрет";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._discretDgv)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._relayDgv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._diodeDgv)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._systemDiodeDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _relayCountTb;
        private System.Windows.Forms.Button _relayAcceptButton;
        private System.Windows.Forms.DataGridView _relayDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridView _discretDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.Button _discretAcceptButton;
        private System.Windows.Forms.TextBox _discretCountTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView _diodeDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.Button _diodeAcceptButton;
        private System.Windows.Forms.TextBox _diodeCountTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView _systemDiodeDgv;
        private System.Windows.Forms.Button _systemDiodeAcceptButton;
        private System.Windows.Forms.TextBox _systemDiodeCountTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
    }
}