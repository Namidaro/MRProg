using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MRProg.Module;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using MRProg.Connection;
using MRProg.Devices;

namespace MRProg.UserControls
{
    public partial class ModuleControl : UserControl, IModuleControlInerface
    {
        #region Const

        private const string NO_MODULE = "Нет модуля";
        private const string SELECT_FILE = "Выбрать файл";
        private const string READY = "Готово к записи";
        private const string WRITTING = "Идёт запись";
        private const string ERROR = "Ошибка";
        private const string WRITE_OK = "Успешно";
        private const string ERROR_OPEN_FILE = "Ошибка открытия файла";
        private const string ERROR_READ = " (ОШИБКА ЧТЕНИЯ)";

        private const string VERSION_ATTENTION_PATTERN =
            "Версия прошивки модуля {0} соответствует или выше версии выбранного файла";

        private const string VERSION_ERROR_PATTERN = "Программная ошибка определение версий модуля {0}";

        private const string ERROR_PERFORM_STEP =
            "Исключение при увеличение полосы записи. Приложение продолжит работу.";

        private const string CRITICAL_ERROR_INCORRECT_POSITION = "ПРОГРАММНАЯ ОШИБКА. НЕВЕРНАЯ ПОЗИЦИЯ МОДУЛЯ {0}";
        private const string INCORRECT_MODULE_PATTERN = "Установлен неверный модуль {0}";
        private const string ERROR_WTITTING_STOP = "Ошибка. Запись модулей остановлена.";
        private const string START_WRITTING_PATTERN = "Начата прошивка модуля {0}";
        private const string MODULE_WRITE_OK_PATTERN = "Модуль {0} успешно прошит";
        private const string MODULE_WRITE_FAIL_PATTERN = "Ошибка. Модуль {0} остался в режиме загрузчика";
        private const string REWRITING_MODULE_PATTERN = "Начата повторная запись прошивки модуля {0}";
        private const string CONTINUE_WRITE_MODULE_PATTERN = "Продолжена запись прошивки модуля {0}";
        private const string INCORRECT_FILE = "Некорректный файл";
        #endregion

        #region Private Fields
        private string _moduleName;
        private string _moduleVersion;
        private string _fuze;
        private string _filePath;
        private byte[] _data;
        private byte[] _dataEeprom;
        private byte[] _dataDiscretRelay;
        private byte[] _dataFlash;
        private ModuleStates _state;
        private ModuleFileStates _stateFile;
        private ModuleInformation _moduleInformation;
        private ModuleType _type;
        private IProgress<LoadReport> progressWork;
        private IProgress<LoadReport> progressFlash;
        private IProgress<LoadReport> progressRelay;
        private IProgress<LoadReport> progressEProm;
        IProgress<LoadReport> _currentprogress;

        #endregion

        #region Properteis
        public ModuleControl()
        {
            InitializeComponent();
            progressWork = new Progress<LoadReport>(OnProgressChangedWork);
            progressFlash = new Progress<LoadReport>(OnProgressChangedFlash);
            progressRelay = new Progress<LoadReport>(OnProgressChangedRelay);
            progressEProm = new Progress<LoadReport>(OnProgressChangedEProm);
        }
        /// <summary>
        /// Название модуля
        /// </summary>
        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                _moduleName = value;
                _moduleNameLable.Text = _moduleName;
            }
        }
        /// <summary>
        /// Версия модуля
        /// </summary>
        public string ModuleVersion
        {
            get { return _moduleVersion; }
            set
            {
                _moduleVersion = value;
                _versionLable.Text = _moduleVersion;
                _moduleNameLable.Text = _moduleVersion;
            }
        }
        /// <summary>
        /// Фьюзы
        /// </summary>
        public string Fuze
        {
            get { return _fuze; }
            set
            {
                _fuze = value;
                _fuzeLable.Text = _fuze;
            }
        }
        /// <summary>
        /// Состояние в котором находится модуль
        /// </summary>
        public ModuleStates State
        {
            get { return _state; }
            set
            {
                this._state = value;
                try
                {
                    SetState();
                    //if (this.IsHandleCreated)
                    //{
                    //    this.Invoke(new Action(this.SetState));
                    //}
                }
                catch (Exception e)
                {
                    //Logger.Add("Ошибка переключения состояния");
                    //Logger.Add(e.Message);
                }
            }
        }


        public ModuleFileStates FileState
        {
            get { return _stateFile; }
            set
            {
                this._stateFile = value;
                try
                {

                    SetFileState();

                }
                catch (Exception e)
                {

                }
            }
        }
        public ModuleInformation Information
        {
            get { return _moduleInformation; }
            set
            {
                _moduleInformation = value;
                if (value != null)
                {
                    if (_moduleInformation.State == ModuleStates.LOADER)
                    {
                        this.ModuleVersion = _moduleInformation.LoaderVersion.ToString("F1");
                    }
                    else
                    {
                        this.ModuleVersion = _moduleInformation.ModuleVersion.ToString("F1");

                    }
                    this.State = _moduleInformation.State;
                    this.Fuze = _moduleInformation.Fuze;
                    this.ModuleName = ModuleManager.ModuleTypeFriendlyName(_moduleInformation.ModuleType);

                }

            }
        }

        /// <summary>
        /// Путь к файлу прошивки
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                SetFilePath();

            }
        }
        /// <summary>
        /// Фильтр файла прошивки
        /// </summary>
        public string FileFilter
        {
            get
            {
                return String.Format(@"Файл прошивки (*.bin)|*{0}* M* R* *.*.bin", new string(this.Information.ModuleTypeString.Take(this.Information.ModuleTypeString.Length - 1).ToArray()));
                //  return String.Format("Файл прошивки (*.bin)|*{0} {1} {2}*.bin", this.ModuleTypeString, this.Modification,this.Revision);
            }
        }

        /// <summary>
        /// Регулярное выражение для имени файла
        /// </summary>
        public string FileRegexString
        {
            get
            {
                /*return String.Format(@"[\w\S\s]* {0} {1} {2} [\w\S\s]*\.bin", this.Information.ModuleTypeString, this.Information.Modification, this.Information.Revision);*/
                string type = this.Information.ModuleTypeString;
                return type + @"\sSA{1}\s{1}MA{1}\sRA{1}\s\S{3}";
            }
        }
        /// <summary>
        /// Прошивка виде слов
        /// </summary>
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public byte[] DataEeprom
        {
            get { return _dataEeprom; }
            set { _data = value; }
        }

        public byte[] DataDiscretRelay
        {
            get { return _dataDiscretRelay; }
            set { _data = value; }
        }
        public byte[] DataFlash
        {
            get { return _dataFlash; }
            set { _data = value; }
        }

        public ModuleType TypeModule
        {
            get { return _type; }
            set
            {
                _type = value;
                ModuleName = ModuleManager.ModuleTypeFriendlyName(value);
            }
        }
        #endregion

        private void OnProgressChangedWork(LoadReport loadReport)
        {
            if (_progressBar.Maximum != loadReport.TotalProgressCount)
            {
                this._progressBar.Maximum = loadReport.TotalProgressCount;
            }

            this._progressBar.Value = loadReport.CurrentProgressCount;
        }
        private void OnProgressChangedFlash(LoadReport loadReport)
        {
            if (_flashbootProgressBar.Maximum != loadReport.TotalProgressCount && !loadReport.IsCkeckResult)
            {
                this._flashbootProgressBar.Maximum = loadReport.TotalProgressCount;
            }

            this._flashbootProgressBar.Value = loadReport.CurrentProgressCount;
        }
        private void OnProgressChangedRelay(LoadReport loadReport)
        {
            if (_relayProgressBar.Maximum != loadReport.TotalProgressCount && !loadReport.IsCkeckResult)
            {
                this._relayProgressBar.Maximum = loadReport.TotalProgressCount;
            }

            this._relayProgressBar.Value = loadReport.CurrentProgressCount;
        }
        private void OnProgressChangedEProm(LoadReport loadReport)
        {
            if (_eepromProgressBar.Maximum != loadReport.TotalProgressCount && !loadReport.IsCkeckResult)
            {
                this._eepromProgressBar.Maximum = loadReport.TotalProgressCount;
            }

            this._eepromProgressBar.Value = loadReport.CurrentProgressCount;
        }

        private bool VerefyFile()
        {
            return !((this._data.Length != 0) & ((this.Data.Length % this.Information.FlashSize) == 0));
        }
        private void OpenFile()
        {
            this._openFileDialogWorkProgramm.FileName = string.Empty;
            _openFileDialogWorkProgramm.Filter = FileFilter;
            if (this._openFileDialogWorkProgramm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.FilePath = this._openFileDialogWorkProgramm.FileName;

                }
                catch (Exception)
                {
                    MessageBox.Show(ERROR_OPEN_FILE);
                }
            }
        }
        private async void _chooseFile_Click(object sender, EventArgs e)
        {
            switch (State)
            {
                case ModuleStates.ERROR_WORK_STRING:
                    {
                        //this.SetFilePath();
                        //ErrorButtonClick();
                        return;
                    }

                case ModuleStates.CLEAR:
                    {
                        if (openFileDialogDevInfo.ShowDialog() == DialogResult.OK)
                        {
                            var devInfo = File.ReadAllText(openFileDialogDevInfo.FileName);
                            try
                            {
                                await ModuleWritterController.WriteDevInfo(_moduleInformation, devInfo);
                                MessageBox.Show("Тип устройства успешно записан");
                                NeedRefreshAction?.Invoke(_moduleInformation.ModulePosition);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception);
                                throw;
                            }

                        }
                        return;
                    }
                case ModuleStates.WITHOUTTYPE:
                    {

                        return;
                    }
                default:
                    {
                        this.OpenFile();
                        break;
                    }
            }
        }

        private void SetFilePath()
        {
            _data = File.ReadAllBytes(this._filePath);
            _workProgramCheckBox.Enabled = true;
            string versionString = String.Empty;

            if (this.VerefyFile())
            {
                this.FileState = ModuleFileStates.CHOICEANOTHERFILE;
                Logger.Add(string.Format("Для модуля {0} выбран неккоректный файл прошивки", this.Information.ModulePosition));
                this._chooseFile.Text = INCORRECT_FILE;
                return;
            }
            try
            {
                Regex reg = new Regex(FileRegexString);

                foreach (var match in reg.Matches(_filePath))
                {
                    match.ToString();
                    versionString = match.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[4];
                }


                versionString = versionString.Replace(".",
                     Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

                Logger.AddToFile(String.Format("Выбран файл - {0}, Размер - {1} Байт", this._filePath,
                    File.ReadAllBytes(this._filePath).Length));

                if (double.Parse(versionString) == this.Information.ModuleVersion)
                {
                    this.FileState = ModuleFileStates.WORK_FILE;
                    Logger.Add(string.Format(VERSION_ATTENTION_PATTERN, this.Information.ModulePosition));
                }

                if (double.Parse(versionString) < this.Information.ModuleVersion)
                {
                    this.FileState = ModuleFileStates.CURRENTVERSIONHIGHER;
                }

                if (double.Parse(versionString) > this.Information.ModuleVersion)
                {
                    this.FileState = ModuleFileStates.CURRENTVERSIONLESS;
                    // this.BackColor = Color.FromArgb(255, 238, 88);
                }

            }
            catch (Exception)
            {
                this.FileState = ModuleFileStates.CHOICEANOTHERFILE;
                Logger.Add(string.Format(VERSION_ERROR_PATTERN, this.Information.ModulePosition));
            }
        }

        private void SetFileState()
        {
            switch (_stateFile)
            {
                case ModuleFileStates.CURRENTVERSIONLESS:
                    {
                        if (Path.GetFileName(this._filePath) != null)
                        {
                            this._workProgramCheckBox.Text = Path.GetFileName(this._filePath);
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = true;
                        }
                        else
                        {
                            this._workProgramCheckBox.Enabled = false;
                        }
                        this._progressBar.Value = 0;
                        this._chooseFile.Text = READY;

                        _chooseFile.BackColor = Color.FromArgb(255, 238, 88);
                        break;
                    }

                case ModuleFileStates.CURRENTVERSIONHIGHER:
                    {
                        if (Path.GetFileName(this._filePath) != null)
                        {
                            this._workProgramCheckBox.Text = Path.GetFileName(this._filePath);
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = false;
                        }
                        else
                        {
                            this._workProgramCheckBox.Enabled = false;
                        }

                        this._progressBar.Value = 0;
                        this._chooseFile.Text = READY;
                        this._chooseFile.BackColor = Color.Pink;
                        break;
                    }
                case ModuleFileStates.CHOICEANOTHERFILE:
                    {
                        if (Path.GetFileName(this._filePath) != null)
                        {
                            this._workProgramCheckBox.Text = Path.GetFileName(this._filePath);
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = true;
                        }
                        else
                        {
                            this._workProgramCheckBox.Enabled = false;
                        }
                        _chooseFile.Text = "Неверный файл";
                        this._chooseFile.BackColor = Color.FromArgb(255, 238, 88);

                        _chooseFile.Enabled = true;
                        break;
                    }
                case ModuleFileStates.WORK_FILE:
                    {
                        if (_workProgramCheckBox.Text != null)
                        {
                            _chooseFile.BackColor = Color.Green;
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = true;
                        }
                        else
                        {
                            _chooseFile.BackColor = Color.Green;
                            this._workProgramCheckBox.Enabled = false;
                            _workProgramCheckBox.Checked = false;
                        }
                    }
                    break;
            }
        }
        private void SetState()
        {
            switch (_state)
            {
                case ModuleStates.WORK:
                    {
                        this.Enabled = true;
                        _toWorkState.Enabled = false;
                        _toLoaderState.Enabled = true;
                        if (_workProgramCheckBox.Text != null)
                        {
                            _chooseFile.BackColor = SystemColors.Control;
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = false;
                        }
                        else
                        {
                            _chooseFile.BackColor = SystemColors.Control;
                            this._workProgramCheckBox.Enabled = false;
                            _workProgramCheckBox.Checked = false;
                        }
                        if (_eepromCheckBox.Text != "")
                        {
                            this._eepromCheckBox.Enabled = true;
                            _eepromCheckBox.Checked = false;
                        }
                        else
                        {
                            this._eepromCheckBox.Enabled = false;
                        }
                        if (_relayDiscretCheckBox.Text != "")
                        {
                            this._relayDiscretCheckBox.Enabled = true;
                            _relayDiscretCheckBox.Checked = false;
                        }
                        else
                        {
                            this._relayDiscretCheckBox.Enabled = false;
                        }
                        if (_flashCheckBox.Text != "")
                        {
                            this._flashCheckBox.Enabled = true;
                            _flashCheckBox.Checked = false;
                        }
                        else
                        {
                            this._flashCheckBox.Enabled = false;
                        }
                        this.groupBox1.BackColor = Color.Green;
                        this.groupBox2.BackColor = Color.Green;
                        this.groupBox3.BackColor = Color.Green;
                        this.groupBox4.BackColor = Color.Green;
                        this.groupBox5.BackColor = Color.Green;
                        this.groupBox6.BackColor = Color.Green;

                        _writeEepromButton.Enabled = false;
                        _writeRelayDiscretButton.Enabled = false;
                        _writeFlashButton.Enabled = false;
                        _readEepromButton.Enabled = false;
                        _readDiscretRelayButton1.Enabled = false;
                        metroButton16.Enabled = false;
                        readFlashButton.Enabled = false;
                        _chooseFileEepromButton.Enabled = false;
                        _chooseFileRelayButton.Enabled = false;
                        _chooseFlashFileButton.Enabled = false;


                        this.BackColor = Color.Green;
                        this._chooseFile.Text = "Выбрать файл";
                        this._progressBar.Value = 0;
                        break;
                    }
                case ModuleStates.LOADER:
                    {
                        this.Enabled = true;
                        _toLoaderState.Enabled = false;
                        _toWorkState.Enabled = true;
                        if (Path.GetFileName(this._filePath) != null)
                        {
                            _chooseFile.BackColor = SystemColors.Control;
                            this._workProgramCheckBox.Text = Path.GetFileName(this._filePath);
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = false;
                        }
                        else
                        {
                            _chooseFile.BackColor = SystemColors.Control;
                            _workProgramCheckBox.Checked = false;
                            this._workProgramCheckBox.Enabled = false;
                        }
                        if (_eepromCheckBox.Text != "")
                        {
                            this._eepromCheckBox.Enabled = true;
                            _eepromCheckBox.Checked = false;
                        }
                        else
                        {
                            this._eepromCheckBox.Enabled = false;
                        }
                        if (_relayDiscretCheckBox.Text != "")
                        {
                            this._relayDiscretCheckBox.Enabled = true;
                            _relayDiscretCheckBox.Checked = false;
                        }
                        else
                        {
                            this._relayDiscretCheckBox.Enabled = false;
                        }
                        if (_flashCheckBox.Text != "")
                        {
                            this._flashCheckBox.Enabled = true;
                            _flashCheckBox.Checked = false;
                        }
                        else
                        {
                            this._flashCheckBox.Enabled = false;
                        }
                        this.groupBox1.BackColor = Color.FromArgb(165, 214, 167);
                        this.groupBox2.BackColor = Color.FromArgb(165, 214, 167);
                        this.groupBox3.BackColor = Color.FromArgb(165, 214, 167);
                        this.groupBox4.BackColor = Color.FromArgb(165, 214, 167);
                        this.groupBox5.BackColor = Color.FromArgb(165, 214, 167);
                        this.groupBox6.BackColor = Color.FromArgb(165, 214, 167);
                        this.BackColor = Color.FromArgb(165, 214, 167);

                        _writeEepromButton.Enabled = true;
                        _writeRelayDiscretButton.Enabled = true;
                        _writeFlashButton.Enabled = true;
                        _readEepromButton.Enabled = true;
                        _readDiscretRelayButton1.Enabled = true;
                        metroButton16.Enabled = true;
                        readFlashButton.Enabled = true;
                        _chooseFileEepromButton.Enabled = true;
                        _chooseFileRelayButton.Enabled = true;
                        _chooseFlashFileButton.Enabled = true;
                        this._chooseFile.Text = "Выбрать файл";
                        this._progressBar.Value = 0;
                        break;
                    }

                case ModuleStates.ERROR_READ_MODULE:
                    {

                        this.groupBox1.BackColor = Color.Red;
                        this.groupBox2.BackColor = Color.Red;
                        this.groupBox3.BackColor = Color.Red;
                        this.groupBox4.BackColor = Color.Red;
                        this.groupBox5.BackColor = Color.Red;
                        this.groupBox6.BackColor = Color.Red;
                        this.BackColor = Color.Red;
                        this.Enabled = false;
                        //this._moduleNameLable.Text = ModuleManager.ModuleTypeFriendlyName(Information.ModulePositionOnSpecification) + " (Отсутсвует)";
                        ////this._mainButton.BackColor = SystemColors.Control;
                        //this.BackColor = SystemColors.Control;
                        //this._chooseFile.Text = "Нет модуля";
                        //this._workProgramCheckBox.Checked = false;
                        //this._workProgramCheckBox.Text = Path.GetFileName(this._filePath);
                        //this._progressBar.Value = 0;
                        //this.Enabled = false;
                        ////this.Caption = ModuleData.ModuleTypeFriendlyName(this._moduleType);
                        //this._fuzeLable.Text = string.Empty;
                        //this._versionLable.Text = String.Empty;
                        break;
                    }

                case ModuleStates.CLEAR:
                    {

                        if (Path.GetFileName(this._filePath) != null)
                        {
                            _chooseFile.BackColor = SystemColors.Control;
                            this._workProgramCheckBox.Text = Path.GetFileName(this._filePath);
                            this._workProgramCheckBox.Enabled = true;
                            _workProgramCheckBox.Checked = false;
                        }
                        else
                        {
                            _chooseFile.BackColor = SystemColors.Control;
                            _workProgramCheckBox.Checked = false;
                            this._workProgramCheckBox.Enabled = false;
                        }
                        this.Enabled = true;
                        _toWorkState.Enabled = false;
                        _toLoaderState.Enabled = false;
                        _chooseFile.Text = "Выбор типа устройства";

                        _writeEepromButton.Enabled = false;
                        _writeRelayDiscretButton.Enabled = false;
                        _writeFlashButton.Enabled = false;
                        _readEepromButton.Enabled = false;
                        _readDiscretRelayButton1.Enabled = false;
                        metroButton16.Enabled = false;
                        readFlashButton.Enabled = false;
                        _chooseFileEepromButton.Enabled = false;
                        _chooseFileRelayButton.Enabled = false;
                        _chooseFlashFileButton.Enabled = false;

                        this.groupBox1.BackColor = Color.FromArgb(66, 165, 245);
                        this.groupBox2.BackColor = Color.FromArgb(66, 165, 245);
                        this.groupBox3.BackColor = Color.FromArgb(66, 165, 245);
                        this.groupBox4.BackColor = Color.FromArgb(66, 165, 245);
                        this.groupBox5.BackColor = Color.FromArgb(66, 165, 245);
                        this.groupBox6.BackColor = Color.FromArgb(66, 165, 245);
                        this.BackColor = Color.FromArgb(66, 165, 245);

                        break;

                    }

                case ModuleStates.ERROR_WORK_STRING:
                    {
                        this.groupBox1.BackColor = Color.Magenta;
                        this.groupBox2.BackColor = Color.Magenta;
                        this.groupBox3.BackColor = Color.Magenta;
                        this.groupBox4.BackColor = Color.Magenta;
                        this.groupBox5.BackColor = Color.Magenta;
                        this.groupBox6.BackColor = Color.Magenta;
                        this.BackColor = Color.Magenta;
                        this.Enabled = false;
                        break;
                    }

                case ModuleStates.WITHOUTTYPE:
                    {
                        this.Enabled = true;

                        _toWorkState.Enabled = false;
                        _toLoaderState.Enabled = true;
                        _chooseFile.Text = "Тип не определен";

                        _writeEepromButton.Enabled = false;
                        _writeRelayDiscretButton.Enabled = false;
                        _writeFlashButton.Enabled = false;
                        _readEepromButton.Enabled = false;
                        _readDiscretRelayButton1.Enabled = false;
                        metroButton16.Enabled = false;
                        readFlashButton.Enabled = false;
                        _chooseFileEepromButton.Enabled = false;
                        _chooseFileRelayButton.Enabled = false;
                        _chooseFlashFileButton.Enabled = false;

                        this.groupBox1.BackColor = Color.RoyalBlue;
                        this.groupBox2.BackColor = Color.RoyalBlue;
                        this.groupBox3.BackColor = Color.RoyalBlue;
                        this.groupBox4.BackColor = Color.RoyalBlue;
                        this.groupBox5.BackColor = Color.RoyalBlue;
                        this.groupBox6.BackColor = Color.RoyalBlue;
                        this.BackColor = Color.RoyalBlue;
                        break;

                    }

                case ModuleStates.OK:
                    {
                        //this._mainButton.BackColor = Color.Green;
                        //this._mainButton.Text = WRITE_OK;
                        //this._mainCheckBox.Checked = false;
                        //this.Enabled = true;
                        break;
                    }

            }
        }



        public async Task WriteFile()
        {
            if (_workProgramCheckBox.Checked)
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.WORK, DevicesManager.DeviceNumber, _data);
                try
                {
                    await controller.StartSave(progressWork);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            if (_eepromCheckBox.Checked)
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.EEPROM, DevicesManager.DeviceNumber, _dataEeprom);
                try
                {
                    await controller.StartSaveForAnotherMemmoryType(progressEProm);
                    _eepromCheckBox.Checked = false;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            if (_relayDiscretCheckBox.Checked)
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.RALAY_DISCRET, DevicesManager.DeviceNumber, _dataDiscretRelay);
                try
                {
                    await controller.StartSaveForAnotherMemmoryType(progressRelay);
                    _relayDiscretCheckBox.Checked = false;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            if (_flashCheckBox.Checked)
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.BOOT_FLASH, DevicesManager.DeviceNumber, _dataFlash,
                    (ushort)Convert.ToUInt16(_startReadPage.Text), (ushort)Convert.ToUInt16(_countReadPage.Text));
                try
                {
                    await controller.StartSaveForAnotherMemmoryType(progressFlash);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

        public Action<int> NeedRefreshAction { get; set; }

        private void _chooseFileEepromButton_Click(object sender, EventArgs e)
        {
            string[] filename;
            if (!(_openFileDialogEeprom.FileName == String.Empty))
            {
                filename = _openFileDialogEeprom.FileName.Split('\\');
                _openFileDialogEeprom.FileName = filename[filename.Length - 1];
            }
            else
            {
                _openFileDialogEeprom.FileName = String.Empty;
            }
            var flag = this._openFileDialogEeprom.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this._eepromCheckBox.Text = this._openFileDialogEeprom.FileName;
                this._eepromCheckBox.Checked = true;
                this._eepromCheckBox.Enabled = true;
                _dataEeprom = File.ReadAllBytes(this._openFileDialogEeprom.FileName);

            }
        }

        private void _chooseFileRelayButton_Click(object sender, EventArgs e)
        {
            string[] filename;
            if (!(_openFileDialogRelayDiscret.FileName == String.Empty))
            {
                filename = _openFileDialogRelayDiscret.FileName.Split('\\');
                _openFileDialogRelayDiscret.FileName = filename[filename.Length - 1];
            }
            else
            {
                _openFileDialogRelayDiscret.FileName = String.Empty;
            }
            var flag = this._openFileDialogRelayDiscret.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this._relayDiscretCheckBox.Text = this._openFileDialogRelayDiscret.FileName;
                this._relayDiscretCheckBox.Checked = true;
                this._relayDiscretCheckBox.Enabled = true;
                _dataDiscretRelay = File.ReadAllBytes(this._openFileDialogRelayDiscret.FileName);

            }
        }

        private void _chooseFlashFileButton_Click(object sender, EventArgs e)
        {
            string[] filename;
            if (!(_openFileDialogFlash.FileName == String.Empty))
            {
                filename = _openFileDialogFlash.FileName.Split('\\');
                _openFileDialogFlash.FileName = filename[filename.Length - 1];
            }
            else
            {
                _openFileDialogFlash.FileName = String.Empty;
            }
            var flag = this._openFileDialogFlash.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this._flashCheckBox.Text = this._openFileDialogFlash.FileName;
                this._flashCheckBox.Enabled = true;
                this._flashCheckBox.Checked = true;
                _dataFlash = File.ReadAllBytes(this._openFileDialogFlash.FileName);

            }
        }

        private async void _writeEepromButton_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation,
                    TypeOfMemory.EEPROM, DevicesManager.DeviceNumber, _dataEeprom);
                await controller.StartSaveForAnotherMemmoryType(progressEProm);
                _eepromCheckBox.Checked = false;
                MessageBox.Show("Запись файла завершена");
            }
            catch (Exception exception)
            {
                MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Неудалось записать файл Eeprom");
                messageErrorBox.ShowErrorMessageForm();
            }
        }

        private async void _writeDiscretRelayButton_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation,
                    TypeOfMemory.RALAY_DISCRET, DevicesManager.DeviceNumber, _dataDiscretRelay);
                await controller.StartSaveForAnotherMemmoryType(progressEProm);
                _relayDiscretCheckBox.Checked = false;
                MessageBox.Show("Запись файла  завершена");
            }
            catch (Exception exception)
            {
                MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Неудалось записать файл ");
                messageErrorBox.ShowErrorMessageForm();
            }
        }

        private async void _writeFlashButton_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation,
                    TypeOfMemory.BOOT_FLASH, DevicesManager.DeviceNumber, _dataFlash, (ushort)Convert.ToUInt16(_startReadPage.Text), (ushort)Convert.ToUInt16(_countReadPage.Text));
                await controller.StartSaveForAnotherMemmoryType(progressFlash);
                _flashCheckBox.Checked = false;
                MessageBox.Show("Запись файла завершена");
            }
            catch (Exception exception)
            {
                MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Неудалось записать файл Flash");
                messageErrorBox.ShowErrorMessageForm();
            }
        }

        private async void _toLoaderState_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Перевести в режим загрузчика?", "Внимание", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                ModuleWritterController.DeviceToloader(_moduleInformation);
                Thread.Sleep(500);
                ConnectionManager.Connection.Serialport.BaudRate = 230400;
                MessageBox.Show("Запрос на перевод в режим загрузчика отправлен");
                NeedRefreshAction?.Invoke(_moduleInformation.ModulePosition);
            }
            catch (Exception exception)
            {
                MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Ошибка перевода в режим загрузчика");
                messageErrorBox.ShowErrorMessageForm();
            }
        }

        private async void _readDiscretRelayButton1_Click(object sender, EventArgs e)
        {
            string[] filename;
            if (!(_saveFileDialogRelayDiscret.FileName == String.Empty))
            {
                filename = _saveFileDialogRelayDiscret.FileName.Split('\\');
                _saveFileDialogRelayDiscret.FileName = filename[filename.Length - 1];
            }
            else
            {
                _saveFileDialogRelayDiscret.FileName = String.Empty;
            }

            if (this._saveFileDialogRelayDiscret.ShowDialog() == DialogResult.OK)
            {
                this._relayDiscretCheckBox.Text = this._saveFileDialogRelayDiscret.FileName;
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.RALAY_DISCRET, DevicesManager.DeviceNumber);
                try
                {
                    byte[] result = await controller.ReadPage(progressRelay);
                    Common.SwapArrayItems(ref result);
                    File.WriteAllBytes(this._saveFileDialogRelayDiscret.FileName, result);
                    MessageBox.Show("Файл успешно сохранен");
                }
                catch (Exception exception)
                {
                    MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Неудалось прочитать файл");
                    messageErrorBox.ShowErrorMessageForm();
                }
            }
        }

        private async void readFlashButton_Click(object sender, EventArgs e)
        {
            string[] filename;
            if (!(_saveFileDialogFlash.FileName == String.Empty))
            {
                filename = _saveFileDialogFlash.FileName.Split('\\');
                _saveFileDialogFlash.FileName = filename[filename.Length - 1];
            }
            else
            {
                _saveFileDialogFlash.FileName = String.Empty;
            }

            if (this._saveFileDialogFlash.ShowDialog() == DialogResult.OK)
            {

                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.BOOT_FLASH, DevicesManager.DeviceNumber,
                    (ushort)Convert.ToUInt16(_startReadPage.Text), (ushort)Convert.ToUInt16(_countReadPage.Text));
                try
                {
                    byte[] result = await controller.ReadPage(progressFlash);
                    Common.SwapArrayItems(ref result);
                    File.WriteAllBytes(this._saveFileDialogFlash.FileName, result);
                    MessageBox.Show("Файл успешно сохранен");
                }
                catch (Exception exception)
                {
                    MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Неудалось прочитать файл Flash");
                    messageErrorBox.ShowErrorMessageForm();
                }
            }
        }

        private async void _readEepromButton_Click(object sender, EventArgs e)
        {
            string[] filename;
            if (!(_saveFileDialogEeprom.FileName == String.Empty))
            {
                filename = _saveFileDialogEeprom.FileName.Split('\\');
                _saveFileDialogEeprom.FileName = filename[filename.Length - 1];
            }
            else
            {
                _saveFileDialogEeprom.FileName = String.Empty;
            }

            if (this._saveFileDialogEeprom.ShowDialog() == DialogResult.OK)
            {
                this._eepromCheckBox.Text = this._saveFileDialogEeprom.FileName;
                ModuleWritterController controller = new ModuleWritterController(this._moduleInformation, TypeOfMemory.EEPROM, DevicesManager.DeviceNumber);
                try
                {
                    byte[] result = await controller.ReadPage(progressEProm);
                    Common.SwapArrayItems(ref result);
                    File.WriteAllBytes(this._saveFileDialogEeprom.FileName, result);
                    MessageBox.Show("Файл успешно сохранен");
                }
                catch (Exception exception)
                {
                    MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Неудалось прочитать файл Eeprom");
                    messageErrorBox.ShowErrorMessageForm();
                }
            }
        }

        private void _chooseFile_Click_1(object sender, EventArgs e)
        {
            switch (State)
            {
                case ModuleStates.CLEAR:
                    {
                        //if (this.SetDevInfo != null)
                        //{
                        //    this.SetDevInfo.Invoke(this);
                        //}
                        return;
                    }
                case ModuleStates.WITHOUTTYPE:
                    {
                        //if (this.SetDevInfo != null)
                        //{
                        //    this.SetDevInfo.Invoke(this);
                        //}
                        return;
                    }
                default:
                    {
                        this.OpenFile();
                        break;
                    }
            }
        }

        private void _toWorkState_Click(object sender, EventArgs e)
        {
            TryDeviceToWork();
        }

        private async void TryDeviceToWork()
        {
            try
            {
                await ModuleWritterController.DeviceToWork(_moduleInformation);
                await Task.Delay(1500);
                ConnectionManager.Connection.Serialport.BaudRate = 115200;
                MessageBox.Show("Запрос на перевод модуля в рабочий режим отправлен");
                NeedRefreshAction?.Invoke(_moduleInformation.ModulePosition);
            }
            catch (Exception exception)
            {
                MessageErrorBox messageErrorBox = new MessageErrorBox(exception.Message, "Ошибка перевода в режим загрузчика");
                messageErrorBox.ShowErrorMessageForm();
            }
        }

        private async void metroButton16_Click(object sender, EventArgs e)
        {
            await TryManualRelayConfig();
        }
        private async Task TryManualRelayConfig()
        {
            ManualRelayConfigForm f1 = new ManualRelayConfigForm(progressRelay);
            try
            {
                await f1.SetLoader(new ModuleWritterController(this._moduleInformation, TypeOfMemory.RALAY_DISCRET,
                    DevicesManager.DeviceNumber));
                f1.ShowDialog(Program.MainFormReferense);
            }
            catch
            {

            }
        }

        public void SetFileFolder(string directoryPath, IEnumerable<string> filesNames)
        {
            this._openFileDialogWorkProgramm.InitialDirectory = directoryPath;
            if ((this._moduleInformation.State == ModuleStates.NO_MODULE) | (this._moduleInformation.State == ModuleStates.ANOUTHERPOSITION))
            {
                return;
            }

            var patternString = this.FileRegexString;
            var fileNameRegex = new Regex(patternString);

            foreach (var filesName in filesNames)
            {
                var path = Path.GetFileName(filesName);
                if (path == null)
                {
                    continue;
                }
                if (fileNameRegex.IsMatch(path))
                {
                    this._filePath = filesName;
                    this.SetFilePath();
                    return;
                }

            }
        }

        private async void _clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                await ModuleWritterController.ClearModule(_moduleInformation);
                MessageBox.Show("Очистка модуля прошла успешна");
                NeedRefreshAction?.Invoke(_moduleInformation.ModulePosition);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не удалось очистить модуль");
                NeedRefreshAction?.Invoke(_moduleInformation.ModulePosition);
            }
        }

    }
}
