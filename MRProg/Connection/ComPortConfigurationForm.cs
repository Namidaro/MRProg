using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MRProg.Connection.Enum;
using MRProg.Properties;

namespace MRProg.Connection
{
    public partial class comPortConfiguration : MetroForm
    {
        static comPortConfiguration Instance= new comPortConfiguration();
        public static void ShowConfiguration()
        {

            if (!Instance.Visible)
            {
                Instance.ShowDialog();
            }

        }

        private static Dictionary<Parity, string> Paritys
        {
            get
            {
                return new Dictionary<Parity, string>
                {
                    {Parity.None, "Нет"},
                    {Parity.Even, "Чёт"},
                    {Parity.Odd, "Нечёт"},
                    {Parity.Mark, "Маркер"},
                    {Parity.Space, "Пробел"}
                };
            }
        }

        private static Dictionary<StopBits, string> AllStopBits
        {
            get
            {
                return new Dictionary<StopBits, string>
                {
                    {StopBits.One, "1"},
                    {StopBits.OnePointFive, "1.5"},
                    {StopBits.Two, "2"}
                };
            }
        }

        public static Dictionary<BaudRates, string> AllBaudRates
        {
            get
            {
                return new Dictionary<BaudRates, string>
                {
                    {BaudRates.BR1200, "1200"},
                    {BaudRates.BR2400, "2400"},
                    {BaudRates.BR4800, "4800"},
                    {BaudRates.BR9600, "9600"},
                    {BaudRates.BR19200, "19200"},
                    {BaudRates.BR38400, "38400"},
                    {BaudRates.BR57600, "57600"},
                    {BaudRates.BR115200, "115200"},
                    {BaudRates.BR230400, "230400"},
                    {BaudRates.BR460800, "460800"},
                    {BaudRates.BR921600, "921600"}
                };
            }
        }
        public comPortConfiguration()
        {
            InitializeComponent();
            int index = 0;
            bool flag = false;
            _stopBitsCb.DataSource = AllStopBits.Values.ToList();
            _speedCb.DataSource = AllBaudRates.Values.ToList();
            _parityCb.DataSource = Paritys.Values.ToList();
            _dataBitsCb.DataSource = new[] { 8 };
            var ports = ConnectionManager.GetPorts();
            for (int i = 0; i < ports.Length; i++)
            {
                if (ports[i] == Settings.Default.Port)
                {
                    index = i;
                    flag = true;
                }
            }
            _portCb.DataSource = ports;
            if (flag)
            {
                _portCb.SelectedIndex = index;
               
            }
            SetPortConfigurationFromSettings();
        }



        private void SetPortConfiguration(ComPortConfiguration comPortConfiguration)
        {
            _speedCb.SelectedItem = AllBaudRates[comPortConfiguration.BaudRateProperty];
            _stopBitsCb.SelectedItem = AllStopBits[comPortConfiguration.StopBitsProperty];
            _parityCb.SelectedItem = Paritys[comPortConfiguration.ParityProperty];
            _writeTimeOut.Text = comPortConfiguration.WriteTimeOut.ToString();
            _readTimeOut.Text = comPortConfiguration.ReadTimeOut.ToString();
            _dataBitsCb.SelectedItem = comPortConfiguration.DataBitsProperty;
        }

        private void SetSettings()
        {
            Settings.Default.Port = Convert.ToInt32(_portCb.SelectedItem.ToString());
            Settings.Default.BaundRates = _speedCb.SelectedIndex;
            Settings.Default.ParityProperty = _parityCb.SelectedIndex;
            Settings.Default.DataBitsProperty = _dataBitsCb.SelectedIndex;
            Settings.Default.StopBitsProperty = _stopBitsCb.SelectedIndex;
            Settings.Default.ReadTimeOut = _readTimeOut.Text;
            Settings.Default.WriteTimeOut = _writeTimeOut.Text;
            Settings.Default.Save();
        }

        private void SetPortConfigurationFromSettings()
        {
            _speedCb.SelectedIndex =Settings.Default.BaundRates;
           _parityCb.SelectedIndex = Settings.Default.ParityProperty;
          _dataBitsCb.SelectedIndex = Settings.Default.DataBitsProperty;
            _stopBitsCb.SelectedIndex =Settings.Default.StopBitsProperty;
            _readTimeOut.Text = Settings.Default.ReadTimeOut;
            _writeTimeOut.Text= Settings.Default.ReadTimeOut;
            Settings.Default.Save();
        }

        private ComPortConfiguration GetPortConfiguration()
        {
            ComPortConfiguration res = new ComPortConfiguration();
            res.BaudRateProperty = AllBaudRates.Keys.First(o => AllBaudRates[o] == _speedCb.SelectedItem.ToString());
            res.StopBitsProperty = AllStopBits.Keys.First(o => AllStopBits[o] == _stopBitsCb.SelectedItem.ToString());
            res.ParityProperty = Paritys.Keys.First(o => Paritys[o] == _parityCb.SelectedItem.ToString());
            res.ReadTimeOut = int.Parse(_readTimeOut.Text);
            res.WriteTimeOut = int.Parse(_writeTimeOut.Text);
            res.DataBitsProperty = Convert.ToInt32(_dataBitsCb.SelectedItem);
            return res;
        }

        private void _portCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var portNum = byte.Parse(_portCb.SelectedItem.ToString());

            ComPortConfiguration config= ConnectionManager.GetComConfig(portNum);

            if (config == null)
            {
                config = GetPortConfiguration();
               ConnectionManager.AddComConfiguration(Convert.ToByte(_portCb.Text),config ); 
            }
            SetPortConfiguration(config);
        }
        private async  void _applyButton_Click(object sender, EventArgs e)
        {
            ConnectionManager.SelectedPort = _portCb.Text;
            ConnectionManager.AddComConfiguration(Convert.ToByte(_portCb.Text),GetPortConfiguration());
            ConnectionManager.Connection?.UpdateConfiguration();
            SetSettings();
            this.Hide();

        }

        private void comPortConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void _refreshPortButton_Click(object sender, EventArgs e)
        {
            int index = 0;
            bool flag = false;
            var ports = ConnectionManager.GetPorts();
            for (int i = 0; i < ports.Length; i++)
            {
                if (ports[i] == Settings.Default.Port)
                {
                    index = i;
                    flag = true;
                }
            }
            _portCb.DataSource = ports;
            if (flag)
            {
                _portCb.SelectedIndex = index;
            }
        }
    }
}
