namespace MRProg.UserControls
{
    partial class MrModuleControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._versionLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._fuzeLable = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._clearButton = new System.Windows.Forms.Button();
            this._toBootloaderButton = new System.Windows.Forms.Button();
            this._chooseFile = new System.Windows.Forms.Button();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._workProgramCheckFile = new System.Windows.Forms.CheckBox();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._moduleNameLable = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogDevInfo = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this._versionLabel);
            this.groupBox1.Location = new System.Drawing.Point(3, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(64, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Версия";
            // 
            // _versionLabel
            // 
            this._versionLabel.AutoSize = true;
            this._versionLabel.Location = new System.Drawing.Point(16, 22);
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(22, 13);
            this._versionLabel.TabIndex = 1;
            this._versionLabel.Text = "ver";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this._fuzeLable);
            this.groupBox2.Location = new System.Drawing.Point(73, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фьюзы";
            // 
            // _fuzeLable
            // 
            this._fuzeLable.AutoSize = true;
            this._fuzeLable.Location = new System.Drawing.Point(24, 22);
            this._fuzeLable.Name = "_fuzeLable";
            this._fuzeLable.Size = new System.Drawing.Size(27, 13);
            this._fuzeLable.TabIndex = 2;
            this._fuzeLable.Text = "fuze";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this._clearButton);
            this.groupBox3.Controls.Add(this._toBootloaderButton);
            this.groupBox3.Controls.Add(this._chooseFile);
            this.groupBox3.Controls.Add(this._progressBar);
            this.groupBox3.Controls.Add(this._workProgramCheckFile);
            this.groupBox3.Location = new System.Drawing.Point(214, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 72);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Рабочая программа";
            // 
            // _clearButton
            // 
            this._clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._clearButton.Location = new System.Drawing.Point(595, 44);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(24, 23);
            this._clearButton.TabIndex = 10;
            this._clearButton.Text = "C";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this._clearModuleButton_Click);
            // 
            // _toBootloaderButton
            // 
            this._toBootloaderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._toBootloaderButton.Enabled = false;
            this._toBootloaderButton.Location = new System.Drawing.Point(595, 13);
            this._toBootloaderButton.Name = "_toBootloaderButton";
            this._toBootloaderButton.Size = new System.Drawing.Size(24, 23);
            this._toBootloaderButton.TabIndex = 8;
            this._toBootloaderButton.Text = "З";
            this._toBootloaderButton.UseVisualStyleBackColor = true;
            this._toBootloaderButton.Click += new System.EventHandler(this._toBootloaderButton_Click);
            // 
            // _chooseFile
            // 
            this._chooseFile.Location = new System.Drawing.Point(8, 17);
            this._chooseFile.Name = "_chooseFile";
            this._chooseFile.Size = new System.Drawing.Size(141, 23);
            this._chooseFile.TabIndex = 7;
            this._chooseFile.Text = "Выбрать файл";
            this._chooseFile.UseVisualStyleBackColor = true;
            this._chooseFile.Click += new System.EventHandler(this._chooseFile_Click);
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.BackColor = System.Drawing.SystemColors.Control;
            this._progressBar.Location = new System.Drawing.Point(8, 44);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(582, 23);
            this._progressBar.TabIndex = 4;
            // 
            // _workProgramCheckFile
            // 
            this._workProgramCheckFile.AutoSize = true;
            this._workProgramCheckFile.Location = new System.Drawing.Point(155, 22);
            this._workProgramCheckFile.Name = "_workProgramCheckFile";
            this._workProgramCheckFile.Size = new System.Drawing.Size(15, 14);
            this._workProgramCheckFile.TabIndex = 3;
            this._workProgramCheckFile.UseVisualStyleBackColor = true;
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "Файл прошивки (*.bin)|*.bin";
            // 
            // _moduleNameLable
            // 
            this._moduleNameLable.AutoSize = true;
            this._moduleNameLable.Location = new System.Drawing.Point(3, 4);
            this._moduleNameLable.Name = "_moduleNameLable";
            this._moduleNameLable.Size = new System.Drawing.Size(117, 13);
            this._moduleNameLable.TabIndex = 4;
            this._moduleNameLable.Text = "Модуль не определен";
            // 
            // openFileDialogDevInfo
            // 
            this.openFileDialogDevInfo.Filter = "Файл типа модуля (*.devInfo)|*.devInfo";
            this.openFileDialogDevInfo.Title = "Выбор файла типа модуля";
            // 
            // MrModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this._moduleNameLable);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MrModuleControl";
            this.Size = new System.Drawing.Size(848, 85);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.CheckBox _workProgramCheckFile;
        private System.Windows.Forms.Label _moduleNameLable;
        private System.Windows.Forms.Label _versionLabel;
        private System.Windows.Forms.Label _fuzeLable;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialogDevInfo;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _chooseFile;
        private System.Windows.Forms.Button _toBootloaderButton;
    }
}
