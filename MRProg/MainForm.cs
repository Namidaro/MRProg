using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MRProg.Devices;
using MRProg.Connection;
using MRProg.Module;
using MRProg.UserControls;
using MRProg.Properties;

namespace MRProg
{
    public partial class MainForm : MetroForm
    {
        #region [Private Fields]
        private const string GOOD_REQUESTS_PATTERN = "Успешных запросов - {0}";
        private const string BAD_REQUESTS_PATTERN = "Неудачных запросов - {0}";
        private const string ALL_REQUESTS_PATTERN = "Всех запросов - {0}";
        private const string CONFIG_FILE_NAME = "BootConfig.ini";

        private IProgress<QueryReport> _queryProgress;
        private DevicesManager _deviceManager;
        private ModuleManager _moduleManager;
        private IDeviceSpecification _deviceSpecification;
        private CancellationTokenSource _cancellationTokenSource;
        private WriteButtonState _writeButtonState;
        #endregion

        #region [Ctor]
        public MainForm()
        {
            InitializeComponent();
            SetVersionInformation();
            _writeButtonState = WriteButtonState.WRITE;
            _deviceManager = new DevicesManager();
            DevicesManager.DeviceNumber = Convert.ToByte(_deviceNumberTextBox.Text);
            _moduleManager = new ModuleManager();
            _queryProgress = new Progress<QueryReport>(OnQueryProgressChanged);
            ConnectionManager.SelectedPort = Settings.Default.Port.ToString();
            ConnectionManager.BaudRate = Convert.ToInt32(comPortConfiguration.AllBaudRates.ElementAt(Settings.Default.BaundRates).Value);
            ConnectionManager.Progress = _queryProgress;
            _comportLable.Text = "COM" + ConnectionManager.SelectedPort;
        }
        #endregion

        private void _configurationButton_Click(object sender, EventArgs e)
        {
            SetConfiguration();
        }

        private void SetConfiguration()
        {
            comPortConfiguration.ShowConfiguration();
            _comportLable.Text = "COM" + ConnectionManager.SelectedPort;

        }
        private async void _connectButton_Click(object sender, EventArgs e)
        {
            await TryConnectToDevice();
        }

        private async Task TryConnectToDevice()
        {
            _panelControl.Controls.Clear();
            ConnectionManager.Connection = new ComConnection(Convert.ToByte(ConnectionManager.SelectedPort),Convert.ToInt32(ConnectionManager.BaudRate));
            if (ConnectionManager.Connection.TryOpenConnection())
            {
                try
                {
                    _deviceSpecification = await _deviceManager.IdentifyDevice(Convert.ToByte(_deviceNumberTextBox.Text));
                }
                catch (Exception exception)
                {
                    MessageErrorBox message = new MessageErrorBox(exception.Message, "Не удалось подключиться к устройству");
                    message.ShowErrorMessageForm();
                    return;
                }
                if (_deviceSpecification is UnsupportedDeviceSpecification)
                {
                    if (_deviceManager.GetDeviceName != String.Empty)
                    {
                        DialogResult dialogResult = MessageBox.Show(String.Format("Устройства {0} неизвестно. Обнулить привязку?", _deviceManager.GetDeviceName), string.Format("Неизвестное устройство"), MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            await CheckAndSetUnknownControlToLoader();
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Работа с {0} невозможна", _deviceManager.GetDeviceName));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Работа с подключенным устройством невозможна");
                    }
                }
                else
                {
                    await SetControl();
                }
            }
            _readInformationButton.Enabled = true;

        }

        private async Task SetControl()
        {
            if (_deviceSpecification.ControlType == ControlType.MLKTYPE)
            {
                await SetModuleControl();
            }
            else if (_deviceSpecification.ControlType == ControlType.MRTYPE)
            {
                await SetMrModuleControl();
            }
            else
            {
                await SetDeviceContol();
            }
        }
        private async Task CheckAndSetUnknownControlToLoader()
        {
            ModuleInformation _moduleInfo = await _moduleManager.ReadModuleInformation(_deviceSpecification, 1, 0);
            TryClearModuleBinding(_moduleInfo);
        }
        private async void TryClearModuleBinding(ModuleInformation _moduleInfo)
        {
            try
            {
                await ModuleWritterController.ClearModule(_moduleInfo);
            }
            catch (Exception e)
            {

            }
        }

        private async Task SetModuleControl()
        {
            _panelControl.Controls.Clear();
            ModuleControl control = new ModuleControl();
            ModuleInformation moduleInformation = await _moduleManager.ReadModuleInformation(_deviceSpecification, Convert.ToByte(_deviceNumberTextBox.Text), 0);
            control.Information = moduleInformation;
            control.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            control.Dock = DockStyle.Top;
            control.TypeModule = _deviceSpecification.ModuleTypes[0];
            (control as IModuleControlInerface).NeedRefreshAction += (i) =>
            {
                RefreshModule(i);
            };
            _panelControl.Controls.Add(control);
        }

        private async Task SetMrModuleControl()
        {
            _panelControl.Controls.Clear();
            int y = 0;
            try
            {
                for (int i = 0; i < _deviceSpecification.ModulesCount; i++)
                {
                    MrModuleControl control = new MrModuleControl();
                    ModuleInformation moduleInformation = await _moduleManager.ReadModuleInformation(_deviceSpecification, Convert.ToByte(_deviceNumberTextBox.Text), i);
                    control.Information = moduleInformation;
                    control.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                    control.TypeModule = _deviceSpecification.ModuleTypes[i];
                    control.Location = new Point(0, y);
                    control.Width = _panelControl.Width;
                    _panelControl.Controls.Add(control);
                    y = y + control.Height;
                    (control as IModuleControlInerface).NeedRefreshAction += (j) =>
                    {
                        RefreshModule(j);
                    };
                }
            }
            catch (Exception e)
            {
                MessageErrorBox message = new MessageErrorBox(e.Message, "Не удалось прочитать информацию о модулях");
                message.ShowErrorMessageForm();
            }
        }

        private async Task SetDeviceContol()
        {
            _panelControl.Controls.Clear();
            DeviceControl control = new DeviceControl();
            ModuleInformation moduleInformation = await _moduleManager.ReadModuleInformation(_deviceSpecification, Convert.ToByte(_deviceNumberTextBox.Text), 0);
            control.Information = moduleInformation;
            control.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            control.Dock = DockStyle.Top;
            control.TypeModule = _deviceSpecification.ModuleTypes[0];
            (control as IModuleControlInerface).NeedRefreshAction += (i) =>
            {
                RefreshModule(i);
            };
            _panelControl.Controls.Add(control);
        }

        private async Task RefreshModule(int modulenumber)
        {
            try
            {
                ModuleInformation moduleInformation = await _moduleManager.ReadModuleInformation(_deviceSpecification,
                    Convert.ToByte(_deviceNumberTextBox.Text), modulenumber);
                if (_deviceSpecification.ControlType == ControlType.MRTYPE)
                {
                    MrModuleControl control = _panelControl.Controls[modulenumber] as MrModuleControl;
                    control.Information = moduleInformation;
                }
                else if (_deviceSpecification.ControlType == ControlType.MLKTYPE)
                {
                    ModuleControl control = _panelControl.Controls[modulenumber] as ModuleControl;
                    control.Information = moduleInformation;
                }
                else
                {
                    DeviceControl control = _panelControl.Controls[modulenumber] as DeviceControl;
                    control.Information = moduleInformation;
                }
            }
            catch (Exception e)
            {
                MessageErrorBox message = new MessageErrorBox(e.Message, "Не удалось прочитать информацию о модуле");
                message.ShowErrorMessageForm();
                _panelControl.Controls.Remove(_panelControl.Controls[modulenumber]);
            }


        }

        private void OnQueryProgressChanged(QueryReport report)
        {
            _statisticBox.Lines = new[]
            {
                string.Format(ALL_REQUESTS_PATTERN, report.AllQueriesCount),
                string.Format(GOOD_REQUESTS_PATTERN, report.SuccessQueriesCount),
                string.Format(BAD_REQUESTS_PATTERN, report.FailedQueriesCount)
            };
        }

        public void SetVersionInformation()
        {
            FileInfo f = new FileInfo(Application.ExecutablePath);
            _statisticBox.Text = "MRProg от " + f.LastWriteTime.ToString().Split(' ')[0];
        }

        private void _writeToDeviceButton_Click(object sender, EventArgs e)
        {
            TryWriteToDevice();
        }

        private async void TryWriteToDevice()
        {
            try
            {
                if (_writeButtonState == WriteButtonState.WRITE)
                {
                    _writeToDeviceButton.Text = "Остановить запись";
                    await WriteToDevice();
                }
                if (_writeButtonState == WriteButtonState.STOP)
                {
                    _cancellationTokenSource.Cancel();
                    _writeToDeviceButton.Text = "Записать в устройство";
                    _writeToDeviceButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async Task WriteToDevice()
        {
            _writeButtonState = WriteButtonState.STOP;
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
            int i = 0;
            //_writeToDeviceButton.Enabled = false;

            foreach (Control control in _panelControl.Controls)
            {
                IModuleControlInerface c = control as IModuleControlInerface;
                if (c != null)
                {
                    if (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        try
                        {
                            await c.WriteFile();
                            await RefreshModule(i);
                        }
                        catch (Exception e)
                        {
                            if (_deviceSpecification.ControlType == ControlType.MRTYPE)
                            {

                                MessageErrorBox messageErrorBox =
                                    new MessageErrorBox(e.Message,
                                        "Неудалось записать файл прошивки" + Environment.NewLine + "Продолжить запись");
                                if (!messageErrorBox.ShowErrorMessageForm())
                                {
                                    _writeButtonState = WriteButtonState.WRITE;
                                    _writeToDeviceButton.Text = "Записать в устройство";
                                    _writeToDeviceButton.Enabled = true;
                                    return;
                                }

                            }
                            else
                            {
                                MessageErrorBox messageErrorBox =
                                    new MessageErrorBox(e.Message, "Неудалось записать файл прошивки");
                                messageErrorBox.ShowErrorMessageForm();
                                _writeButtonState = WriteButtonState.WRITE;
                                _writeToDeviceButton.Text = "Записать в устройство";
                                _writeToDeviceButton.Enabled = true;
                            }

                        }
                        finally
                        {
                            await RefreshModule(i);
                            i++;

                        }
                    }

                }
            }
            _writeButtonState = WriteButtonState.WRITE;
            _writeToDeviceButton.Text = "Записать в устройство";
            _writeToDeviceButton.Enabled = true;
            MessageBox.Show("Запись файлов в устройство завершена");

        }

        private void _deviceNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            DevicesManager.DeviceNumber = Convert.ToByte(_deviceNumberTextBox.Text);
        }

        public string LoadFolder()
        {
            var folderBrowser = new FolderBrowserDialog();
            if (File.Exists(CONFIG_FILE_NAME))
            {
                folderBrowser.SelectedPath = File.ReadAllText(CONFIG_FILE_NAME);
            }

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string result = folderBrowser.SelectedPath;
                File.WriteAllText(CONFIG_FILE_NAME, result);

                var allFiles = Directory.GetFiles(result);

                foreach (var control in _panelControl.Controls)
                {
                    (control as IModuleControlInerface).SetFileFolder(result, allFiles);
                }

                return result;
            }
            return null;
        }

        private async void _readInformationButton_Click(object sender, EventArgs e)
        {
            await SetControl();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void _openFolderButton_Click(object sender, EventArgs e)
        {
            var path = LoadFolder();
            if (!string.IsNullOrEmpty(path))
            {
                this._openFolderButton.Text = path;
            }
        }
    }
}
