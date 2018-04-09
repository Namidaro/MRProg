namespace MRProg.Connection
{
    partial class comPortConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comPortConfiguration));
            this._portCb = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this._speedCb = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this._parityCb = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this._stopBitsCb = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this._dataBitsCb = new MetroFramework.Controls.MetroComboBox();
            this._readTimeOut = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this._writeTimeOut = new MetroFramework.Controls.MetroTextBox();
            this._applyButton = new MetroFramework.Controls.MetroButton();
            this._refreshPortButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // _portCb
            // 
            this._portCb.FormattingEnabled = true;
            this._portCb.ItemHeight = 23;
            this._portCb.Location = new System.Drawing.Point(83, 63);
            this._portCb.Name = "_portCb";
            this._portCb.Size = new System.Drawing.Size(93, 29);
            this._portCb.TabIndex = 0;
            this._portCb.UseSelectable = true;
            this._portCb.SelectedIndexChanged += new System.EventHandler(this._portCb_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(10, 68);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(39, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Порт";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(10, 103);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Скорость";
            // 
            // _speedCb
            // 
            this._speedCb.FormattingEnabled = true;
            this._speedCb.ItemHeight = 23;
            this._speedCb.Location = new System.Drawing.Point(83, 98);
            this._speedCb.Name = "_speedCb";
            this._speedCb.Size = new System.Drawing.Size(93, 29);
            this._speedCb.TabIndex = 2;
            this._speedCb.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(194, 68);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Чётность";
            // 
            // _parityCb
            // 
            this._parityCb.FormattingEnabled = true;
            this._parityCb.ItemHeight = 23;
            this._parityCb.Location = new System.Drawing.Point(273, 63);
            this._parityCb.Name = "_parityCb";
            this._parityCb.Size = new System.Drawing.Size(93, 29);
            this._parityCb.TabIndex = 4;
            this._parityCb.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(194, 103);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(73, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Стоп биты";
            // 
            // _stopBitsCb
            // 
            this._stopBitsCb.FormattingEnabled = true;
            this._stopBitsCb.ItemHeight = 23;
            this._stopBitsCb.Location = new System.Drawing.Point(273, 98);
            this._stopBitsCb.Name = "_stopBitsCb";
            this._stopBitsCb.Size = new System.Drawing.Size(93, 29);
            this._stopBitsCb.TabIndex = 6;
            this._stopBitsCb.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(10, 138);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 19);
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Длина";
            // 
            // _dataBitsCb
            // 
            this._dataBitsCb.FormattingEnabled = true;
            this._dataBitsCb.ItemHeight = 23;
            this._dataBitsCb.Location = new System.Drawing.Point(83, 133);
            this._dataBitsCb.Name = "_dataBitsCb";
            this._dataBitsCb.Size = new System.Drawing.Size(93, 29);
            this._dataBitsCb.TabIndex = 8;
            this._dataBitsCb.UseSelectable = true;
            // 
            // _readTimeOut
            // 
            // 
            // 
            // 
            this._readTimeOut.CustomButton.Image = null;
            this._readTimeOut.CustomButton.Location = new System.Drawing.Point(43, 1);
            this._readTimeOut.CustomButton.Name = "";
            this._readTimeOut.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._readTimeOut.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._readTimeOut.CustomButton.TabIndex = 1;
            this._readTimeOut.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._readTimeOut.CustomButton.UseSelectable = true;
            this._readTimeOut.CustomButton.Visible = false;
            this._readTimeOut.Lines = new string[] {
        "100"};
            this._readTimeOut.Location = new System.Drawing.Point(153, 168);
            this._readTimeOut.MaxLength = 32767;
            this._readTimeOut.Name = "_readTimeOut";
            this._readTimeOut.PasswordChar = '\0';
            this._readTimeOut.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._readTimeOut.SelectedText = "";
            this._readTimeOut.SelectionLength = 0;
            this._readTimeOut.SelectionStart = 0;
            this._readTimeOut.ShortcutsEnabled = true;
            this._readTimeOut.Size = new System.Drawing.Size(65, 23);
            this._readTimeOut.TabIndex = 10;
            this._readTimeOut.Text = "100";
            this._readTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._readTimeOut.UseSelectable = true;
            this._readTimeOut.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._readTimeOut.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(10, 168);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(131, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "TimeOut для чтения";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(10, 201);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(132, 19);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "TimeOut для записи";
            // 
            // _writeTimeOut
            // 
            // 
            // 
            // 
            this._writeTimeOut.CustomButton.Image = null;
            this._writeTimeOut.CustomButton.Location = new System.Drawing.Point(43, 1);
            this._writeTimeOut.CustomButton.Name = "";
            this._writeTimeOut.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._writeTimeOut.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._writeTimeOut.CustomButton.TabIndex = 1;
            this._writeTimeOut.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._writeTimeOut.CustomButton.UseSelectable = true;
            this._writeTimeOut.CustomButton.Visible = false;
            this._writeTimeOut.Lines = new string[] {
        "50"};
            this._writeTimeOut.Location = new System.Drawing.Point(153, 201);
            this._writeTimeOut.MaxLength = 32767;
            this._writeTimeOut.Name = "_writeTimeOut";
            this._writeTimeOut.PasswordChar = '\0';
            this._writeTimeOut.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._writeTimeOut.SelectedText = "";
            this._writeTimeOut.SelectionLength = 0;
            this._writeTimeOut.SelectionStart = 0;
            this._writeTimeOut.ShortcutsEnabled = true;
            this._writeTimeOut.Size = new System.Drawing.Size(65, 23);
            this._writeTimeOut.TabIndex = 12;
            this._writeTimeOut.Text = "50";
            this._writeTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._writeTimeOut.UseSelectable = true;
            this._writeTimeOut.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._writeTimeOut.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // _applyButton
            // 
            this._applyButton.Location = new System.Drawing.Point(38, 241);
            this._applyButton.Name = "_applyButton";
            this._applyButton.Size = new System.Drawing.Size(342, 23);
            this._applyButton.TabIndex = 14;
            this._applyButton.Text = "Применить";
            this._applyButton.UseSelectable = true;
            this._applyButton.Click += new System.EventHandler(this._applyButton_Click);
            // 
            // _refreshPortButton
            // 
            this._refreshPortButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_refreshPortButton.BackgroundImage")));
            this._refreshPortButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._refreshPortButton.Location = new System.Drawing.Point(53, 68);
            this._refreshPortButton.Name = "_refreshPortButton";
            this._refreshPortButton.Size = new System.Drawing.Size(22, 19);
            this._refreshPortButton.TabIndex = 15;
            this._refreshPortButton.UseSelectable = true;
            this._refreshPortButton.Click += new System.EventHandler(this._refreshPortButton_Click);
            // 
            // comPortConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 278);
            this.Controls.Add(this._refreshPortButton);
            this.Controls.Add(this._applyButton);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this._writeTimeOut);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this._readTimeOut);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this._dataBitsCb);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this._stopBitsCb);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this._parityCb);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this._speedCb);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this._portCb);
            this.Name = "comPortConfiguration";
            this.Text = "Настройка связи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.comPortConfiguration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox _portCb;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox _speedCb;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox _parityCb;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox _stopBitsCb;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox _dataBitsCb;
        private MetroFramework.Controls.MetroTextBox _readTimeOut;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox _writeTimeOut;
        private MetroFramework.Controls.MetroButton _applyButton;
        private MetroFramework.Controls.MetroButton _refreshPortButton;
    }
}