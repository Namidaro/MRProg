namespace MRProg
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._panelControl = new MetroFramework.Controls.MetroPanel();
            this._openFolderButton = new MetroFramework.Controls.MetroButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._writeToDeviceButton = new MetroFramework.Controls.MetroButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._statisticBox = new System.Windows.Forms.RichTextBox();
            this._configurationButton = new MetroFramework.Controls.MetroButton();
            this._connectButton = new MetroFramework.Controls.MetroButton();
            this._comportLable = new MetroFramework.Controls.MetroLabel();
            this._deviceNumberTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this._deviceNameLabel = new MetroFramework.Controls.MetroLabel();
            this._readInformationButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this._panelControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._openFolderButton);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel2.Controls.Add(this._writeToDeviceButton);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1107, 506);
            this.splitContainer1.SplitterDistance = 759;
            this.splitContainer1.TabIndex = 0;
            // 
            // _panelControl
            // 
            this._panelControl.AutoScroll = true;
            this._panelControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_panelControl.BackgroundImage")));
            this._panelControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelControl.HorizontalScrollbar = true;
            this._panelControl.HorizontalScrollbarBarColor = true;
            this._panelControl.HorizontalScrollbarHighlightOnWheel = false;
            this._panelControl.HorizontalScrollbarSize = 10;
            this._panelControl.Location = new System.Drawing.Point(0, 0);
            this._panelControl.Name = "_panelControl";
            this._panelControl.Size = new System.Drawing.Size(755, 502);
            this._panelControl.TabIndex = 0;
            this._panelControl.VerticalScrollbar = true;
            this._panelControl.VerticalScrollbarBarColor = true;
            this._panelControl.VerticalScrollbarHighlightOnWheel = false;
            this._panelControl.VerticalScrollbarSize = 10;
            // 
            // _openFolderButton
            // 
            this._openFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._openFolderButton.Location = new System.Drawing.Point(6, 363);
            this._openFolderButton.Name = "_openFolderButton";
            this._openFolderButton.Size = new System.Drawing.Size(328, 23);
            this._openFolderButton.TabIndex = 5;
            this._openFolderButton.Text = "Выбрать каталог с рабочими программами";
            this._openFolderButton.UseSelectable = true;
            this._openFolderButton.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.panel9);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.panel8);
            this.groupBox6.Controls.Add(this.panel2);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(6, 213);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(328, 89);
            this.groupBox6.TabIndex = 72;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Информация о выбранной рабочей программе";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(29, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Версия рабочей программы соответствует выбранной ";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Location = new System.Drawing.Point(4, 61);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(20, 20);
            this.panel9.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(270, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Выбрана новая версия рабочей программы модуля";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Pink;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(4, 40);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(20, 20);
            this.panel8.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(88)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(4, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Выбрана старая версия рабочей программы модуля";
            // 
            // _writeToDeviceButton
            // 
            this._writeToDeviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._writeToDeviceButton.Location = new System.Drawing.Point(6, 392);
            this._writeToDeviceButton.Name = "_writeToDeviceButton";
            this._writeToDeviceButton.Size = new System.Drawing.Size(328, 23);
            this._writeToDeviceButton.TabIndex = 4;
            this._writeToDeviceButton.Text = "Записать в устройство";
            this._writeToDeviceButton.UseSelectable = true;
            this._writeToDeviceButton.Click += new System.EventHandler(this._writeToDeviceButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.panel11);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.panel10);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.panel7);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.panel6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.panel3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Location = new System.Drawing.Point(6, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 195);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Информация о состоянии модуля";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Работает программа устройства (без привязки к типу)";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Location = new System.Drawing.Point(6, 83);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(20, 20);
            this.panel11.TabIndex = 73;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Ошибка (загрузчик)";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Magenta;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Location = new System.Drawing.Point(6, 167);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(20, 20);
            this.panel10.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Работает загрузчик без привязки к типу устройства";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(6, 41);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 20);
            this.panel5.TabIndex = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 68;
            this.label10.Text = "Работает загрузчик";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(214)))), ((int)(((byte)(167)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(6, 62);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(20, 20);
            this.panel7.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(29, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "Работает программа устройства";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(6, 104);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 20);
            this.panel6.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Модуль неопределен или отсутствует";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(6, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Модуль без загрузчика";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(6, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Модуль установлен в неверную позицию";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(6, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._statisticBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Статистика";
            // 
            // _statisticBox
            // 
            this._statisticBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._statisticBox.Location = new System.Drawing.Point(6, 19);
            this._statisticBox.Name = "_statisticBox";
            this._statisticBox.Size = new System.Drawing.Size(328, 57);
            this._statisticBox.TabIndex = 0;
            this._statisticBox.Text = "";
            // 
            // _configurationButton
            // 
            this._configurationButton.Location = new System.Drawing.Point(20, 19);
            this._configurationButton.Name = "_configurationButton";
            this._configurationButton.Size = new System.Drawing.Size(97, 34);
            this._configurationButton.TabIndex = 1;
            this._configurationButton.Text = "Настройка сети";
            this._configurationButton.UseSelectable = true;
            this._configurationButton.Click += new System.EventHandler(this._configurationButton_Click);
            // 
            // _connectButton
            // 
            this._connectButton.Location = new System.Drawing.Point(123, 19);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(97, 34);
            this._connectButton.TabIndex = 2;
            this._connectButton.Text = "Подключиться ";
            this._connectButton.UseSelectable = true;
            this._connectButton.Click += new System.EventHandler(this._connectButton_Click);
            // 
            // _comportLable
            // 
            this._comportLable.AutoSize = true;
            this._comportLable.Location = new System.Drawing.Point(707, 30);
            this._comportLable.Name = "_comportLable";
            this._comportLable.Size = new System.Drawing.Size(48, 19);
            this._comportLable.TabIndex = 3;
            this._comportLable.Text = "COM0";
            // 
            // _deviceNumberTextBox
            // 
            // 
            // 
            // 
            this._deviceNumberTextBox.CustomButton.Image = null;
            this._deviceNumberTextBox.CustomButton.Location = new System.Drawing.Point(4, 1);
            this._deviceNumberTextBox.CustomButton.Name = "";
            this._deviceNumberTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._deviceNumberTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._deviceNumberTextBox.CustomButton.TabIndex = 1;
            this._deviceNumberTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._deviceNumberTextBox.CustomButton.UseSelectable = true;
            this._deviceNumberTextBox.CustomButton.Visible = false;
            this._deviceNumberTextBox.Lines = new string[] {
        "1"};
            this._deviceNumberTextBox.Location = new System.Drawing.Point(665, 30);
            this._deviceNumberTextBox.MaxLength = 32767;
            this._deviceNumberTextBox.Name = "_deviceNumberTextBox";
            this._deviceNumberTextBox.PasswordChar = '\0';
            this._deviceNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._deviceNumberTextBox.SelectedText = "";
            this._deviceNumberTextBox.SelectionLength = 0;
            this._deviceNumberTextBox.SelectionStart = 0;
            this._deviceNumberTextBox.ShortcutsEnabled = true;
            this._deviceNumberTextBox.Size = new System.Drawing.Size(26, 23);
            this._deviceNumberTextBox.TabIndex = 4;
            this._deviceNumberTextBox.Text = "1";
            this._deviceNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._deviceNumberTextBox.UseSelectable = true;
            this._deviceNumberTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._deviceNumberTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._deviceNumberTextBox.TextChanged += new System.EventHandler(this._deviceNumberTextBox_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(564, 30);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "№ устройства";
            // 
            // _deviceNameLabel
            // 
            this._deviceNameLabel.AutoSize = true;
            this._deviceNameLabel.Location = new System.Drawing.Point(502, 30);
            this._deviceNameLabel.Name = "_deviceNameLabel";
            this._deviceNameLabel.Size = new System.Drawing.Size(0, 0);
            this._deviceNameLabel.TabIndex = 6;
            // 
            // _readInformationButton
            // 
            this._readInformationButton.Enabled = false;
            this._readInformationButton.Location = new System.Drawing.Point(226, 19);
            this._readInformationButton.Name = "_readInformationButton";
            this._readInformationButton.Size = new System.Drawing.Size(97, 34);
            this._readInformationButton.TabIndex = 7;
            this._readInformationButton.Text = "Перечитать ";
            this._readInformationButton.UseSelectable = true;
            this._readInformationButton.Click += new System.EventHandler(this._readInformationButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 586);
            this.Controls.Add(this._readInformationButton);
            this.Controls.Add(this._deviceNameLabel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this._deviceNumberTextBox);
            this.Controls.Add(this._comportLable);
            this.Controls.Add(this._connectButton);
            this.Controls.Add(this._configurationButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MRProg";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Right;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroPanel _panelControl;
        private MetroFramework.Controls.MetroButton _configurationButton;
        private MetroFramework.Controls.MetroButton _connectButton;
        private MetroFramework.Controls.MetroLabel _comportLable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox _statisticBox;
        private MetroFramework.Controls.MetroTextBox _deviceNumberTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel _deviceNameLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton _openFolderButton;
        private MetroFramework.Controls.MetroButton _writeToDeviceButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel11;
        private MetroFramework.Controls.MetroButton _readInformationButton;
    }
}

