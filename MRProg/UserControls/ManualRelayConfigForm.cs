using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRProg.Module;

namespace MRProg.UserControls
{
    public partial class ManualRelayConfigForm : Form
    {
        private struct OneStruct
        {

            private ushort _value;

            public OneStruct(ushort value)
            {
                _value = value;
            }

            public string Port
            {
                get { return Ports[Common.GetBits(_value, 5, 6, 7) >> 5]; }
                set
                {
                    var bits = (ushort)Ports.IndexOf(value);
                    _value = Common.SetBits(_value, bits, 5, 6, 7);
                }
            }

            public string Pin
            {
                get { return Pins[Common.GetBits(_value, 2, 3, 4) >> 2]; }
                set
                {
                    var bits = (ushort)Pins.IndexOf(value);
                    _value = Common.SetBits(_value, bits, 2, 3, 4);
                }
            }

            public bool Pull
            {
                get { return Common.GetBit(_value, 15); }
                set { _value = Common.SetBit(_value, 15, value); }
            }

            public bool Inv
            {
                get { return Common.GetBit(_value, 8); }
                set { _value = Common.SetBit(_value, 8, value); }
            }

            public string Tip
            {
                get { return Types[Common.GetBits(_value, 9, 10, 11, 12) >> 9]; }
                set
                {
                    var bits = (ushort)Types.IndexOf(value);
                    _value = Common.SetBits(_value, bits, 9, 10, 11, 12);
                }
            }

            public ushort Value
            {
                get { return _value; }
            }
        }

        private class AllConfig
        {
            private string _header = "ConfigVersion1.0";
            private byte _discretOffset;
            private byte _relayOffset;
            private byte _diodeOffset;
            private byte _systemDiodeOffset;
            private byte _discretCount;
            private OneStruct[] _discretConfig;
            private byte _relayCount;
            private OneStruct[] _relayConfig;
            private byte _diodeCount;
            private OneStruct[] _diodeConfig;
            private byte _systemDiodeCount;
            private OneStruct[] _systemDiodeConfig;
            public AllConfig()
            {

                _discretConfig = new OneStruct[DISCRET_MAX];
                _relayConfig = new OneStruct[RELAY_MAX];
                _diodeConfig = new OneStruct[DIODE_MAX];
                _systemDiodeConfig = new OneStruct[SYSTEM_DIODE_MAX];
                _discretOffset = 20;
                _relayOffset = (byte)(_discretOffset + DISCRET_MAX * 2 + 1);
                _diodeOffset = (byte)(_relayOffset + RELAY_MAX * 2 + 1);
                _systemDiodeOffset = (byte)(_diodeOffset + DIODE_MAX * 2 + 1);
            }


            public AllConfig(byte[] array)
            {
                _discretOffset = 20;
                _relayOffset = (byte)(_discretOffset + DISCRET_MAX * 2 + 1);
                _diodeOffset = (byte)(_relayOffset + DIODE_MAX * 2 + 1);
                _systemDiodeOffset = (byte)(_diodeOffset + DIODE_MAX * 2 + 1);

                if (array.Length != 256)
                {
                    throw new ArgumentException();
                }
                var crc = Crc16.CalcCrcFast(array, 256 - 2);
                if (Common.TOWORD(array[254], array[255]) != crc)
                {
                    MessageBox.Show("Ошибка CRC");
                    throw new ArgumentException();
                }
                var ascii = new ASCIIEncoding();
                if (_header != new string(ascii.GetChars(array, 0, _header.Length)))
                {
                    throw new ArgumentException();
                }
                var discretOffset = array[16];
                var relayOffset = array[17];
                var diodeOffset = array[18];
                var systemDiodeOffset = array[19];

                _discretCount = array[discretOffset];
                _discretConfig = new OneStruct[DISCRET_MAX];

                for (int i = 0; i < DISCRET_MAX; i++)
                {
                    if (i < _discretCount)
                    {
                        _discretConfig[i] =
                            new OneStruct(Common.TOWORD(array[discretOffset + i * 2 + 2], array[discretOffset + i * 2 + 1]));
                    }
                    else
                    {
                        _discretConfig[i] = new OneStruct();
                    }
                }

                _relayCount = array[relayOffset];
                _relayConfig = new OneStruct[RELAY_MAX];
                for (int i = 0; i < RELAY_MAX; i++)
                {
                    if (i < _relayCount)
                    {
                        _relayConfig[i] =
                            new OneStruct(Common.TOWORD(array[relayOffset + i * 2 + 2], array[relayOffset + i * 2 + 1]));
                    }
                    else
                    {
                        _relayConfig[i] = new OneStruct();
                    }
                }

                _diodeCount = array[diodeOffset];
                _diodeConfig = new OneStruct[DIODE_MAX];
                for (int i = 0; i < DIODE_MAX; i++)
                {
                    if (i < _diodeCount)
                    {
                        _diodeConfig[i] =
                            new OneStruct(Common.TOWORD(array[diodeOffset + i * 2 + 2], array[diodeOffset + i * 2 + 1]));
                    }
                    else
                    {
                        _diodeConfig[i] = new OneStruct();
                    }
                }

                _systemDiodeCount = array[systemDiodeOffset];
                _systemDiodeConfig = new OneStruct[SYSTEM_DIODE_MAX];
                for (int i = 0; i < _systemDiodeCount; i++)
                {
                    if (i < _systemDiodeCount)
                    {
                        _systemDiodeConfig[i] =
                            new OneStruct(Common.TOWORD(array[systemDiodeOffset + i * 2 + 2], array[systemDiodeOffset + i * 2 + 1]));
                    }
                    else
                    {
                        _systemDiodeConfig[i] = new OneStruct();
                    }
                }

            }
            public byte[] ToBytes()
            {
                var res = new List<byte>();
                var ascii = new ASCIIEncoding();
                byte[] add = ascii.GetBytes(_header);
                res.AddRange(add);

                res.Add(_discretOffset);
                res.Add(_relayOffset);
                res.Add(_diodeOffset);
                res.Add(_systemDiodeOffset);

                res.Add(_discretCount);
                res.AddRange(Common.TOBYTES(_discretConfig.Select(o => o.Value).ToArray(), false));

                res.Add(_relayCount);
                res.AddRange(Common.TOBYTES(_relayConfig.Select(o => o.Value).ToArray(), false));

                res.Add(_diodeCount);
                res.AddRange(Common.TOBYTES(_diodeConfig.Select(o => o.Value).ToArray(), false));

                res.Add(_systemDiodeCount);
                res.AddRange(Common.TOBYTES(_systemDiodeConfig.Select(o => o.Value).ToArray(), false));


                var array = new byte[256];
                Array.Copy(res.ToArray(), array, res.Count);
                var crc = Crc16.CalcCrcFast(array, array.Length - 2);
                array[array.Length - 2] = Common.HIBYTE(crc);
                array[array.Length - 1] = Common.LOBYTE(crc);
                return array;
            }

            public OneStruct[] Relays
            {
                get { return _relayConfig; }
                set { _relayConfig = value; }
            }

            public OneStruct[] Discrets
            {
                get { return _discretConfig; }
                set { _discretConfig = value; }
            }

            public OneStruct[] Diodes
            {
                get { return _diodeConfig; }
                set { _diodeConfig = value; }
            }

            public OneStruct[] SystemDiodes
            {
                get { return _systemDiodeConfig; }
                set { _systemDiodeConfig = value; }
            }

            public byte DiscretCount
            {
                get { return _discretCount; }
                set { _discretCount = value; }
            }

            public byte RelayCount
            {
                get { return _relayCount; }
                set { _relayCount = value; }
            }

            public byte DiodeCount
            {
                get { return _diodeCount; }
                set { _diodeCount = value; }
            }

            public byte SystemDiodeCount
            {
                get { return _systemDiodeCount; }
                set { _systemDiodeCount = value; }
            }
        }

        private static List<string> Ports
        {
            get
            {
                return new List<string>
                {
                    "Port A",
                    "Port B",
                    "Port C",
                    "Port D",
                    "Port E",
                    "Port F",
                    "Port G"
                };
            }
        }

        private static List<string> Pins
        {
            get
            {
                return new List<string>
                {
                    "Пин 0",
                    "Пин 1",
                    "Пин 2",
                    "Пин 3",
                    "Пин 4",
                    "Пин 5",
                    "Пин 6",
                    "Пин 7"
                };
            }
        }

        private static List<string> Types
        {
            get
            {
                return new List<string>
                {
                    "Питание",
                    "Ошибки"
                };
            }
        }

        private const int RELAY_MAX = 32;
        private const int DISCRET_MAX = 32;
        private const int DIODE_MAX = 32;
        private const int SYSTEM_DIODE_MAX = 8;
        private IProgress<LoadReport> _progress;

        AllConfig _config = new AllConfig();
        private ModuleWritterController _moduleWritterController;

        public async Task SetLoader(ModuleWritterController moduleWritterController)
        {
            try
            {
                _moduleWritterController = moduleWritterController;
                byte[] result = await _moduleWritterController.ReadPage(_progress);
                _config = new AllConfig(result);
            }
            catch (Exception e)
            {
                MessageErrorBox me = new MessageErrorBox(e.Message, "Создать конфигурацию по умолчанию?");
                bool res = me.ShowErrorMessageForm();
                if (res)
                {
                    _config = new AllConfig();
                }

            }

            ShowRelay();
            ShowDiscret();
            ShowDiode();
            ShowSystemDiode();

        }

        public ManualRelayConfigForm(IProgress<LoadReport> progress)
        {
            InitializeComponent();
            _progress = progress;
            Column2.DataSource = Ports;
            Column3.DataSource = Pins;

            dataGridViewComboBoxColumn1.DataSource = Ports;
            dataGridViewComboBoxColumn2.DataSource = Pins;

            dataGridViewComboBoxColumn3.DataSource = Ports;
            dataGridViewComboBoxColumn4.DataSource = Pins;

            dataGridViewComboBoxColumn5.DataSource = Ports;
            dataGridViewComboBoxColumn6.DataSource = Pins;
            Column6.DataSource = Types;
        }

        private void _relayAcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var count = int.Parse(_relayCountTb.Text);
                if ((count < 0) || (count > RELAY_MAX))
                {
                    throw new ArgumentException();
                }


                _config.RelayCount = (byte)count;
                this.ShowRelay();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Введите целое число от 0 до {0}", DISCRET_MAX));
            }
        }

        private void ShowRelay()
        {
            _relayCountTb.Text = _config.RelayCount.ToString();
            _relayDgv.Rows.Clear();
            for (int i = 0; i < _config.RelayCount; i++)
            {
                _relayDgv.Rows.Add
                (
                    (i + 1).ToString(),
                    _config.Relays[i].Port,
                    _config.Relays[i].Pin,
                    _config.Relays[i].Pull,
                    _config.Relays[i].Inv
                );
            }
        }
        private void ShowDiscret()
        {
            _discretCountTb.Text = _config.DiscretCount.ToString();
            _discretDgv.Rows.Clear();
            for (int i = 0; i < _config.DiscretCount; i++)
            {
                _discretDgv.Rows.Add
                (
                    (i + 1).ToString(),
                    _config.Discrets[i].Port,
                    _config.Discrets[i].Pin,
                    _config.Discrets[i].Pull,
                    _config.Discrets[i].Inv
                );
            }
        }
        private void _discretAcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var count = int.Parse(_discretCountTb.Text);
                if ((count < 0) || (count > DISCRET_MAX))
                {
                    throw new ArgumentException();
                }
                _config.DiscretCount = (byte)count;
                this.ShowDiscret();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Введите целое число от 0 до {0}", DISCRET_MAX));
            }
        }

        private void _diodeAcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var count = int.Parse(_diodeCountTb.Text);
                if ((count < 0) || (count > DIODE_MAX))
                {
                    throw new ArgumentException();
                }


                _config.DiodeCount = (byte)count;
                this.ShowDiode();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Введите целое число от 0 до {0}", DIODE_MAX));
            }
        }

        private void ShowDiode()
        {
            _diodeCountTb.Text = _config.DiodeCount.ToString();
            _diodeDgv.Rows.Clear();
            for (int i = 0; i < _config.DiodeCount; i++)
            {
                _diodeDgv.Rows.Add
                (
                    (i + 1).ToString(),
                    _config.Diodes[i].Port,
                    _config.Diodes[i].Pin,
                    _config.Diodes[i].Pull,
                    _config.Diodes[i].Inv
                );
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var relays = new OneStruct[RELAY_MAX];
            for (int i = 0; i < _relayDgv.Rows.Count; i++)
            {

                relays[i] = new OneStruct();
                relays[i].Port = _relayDgv.Rows[i].Cells[1].Value.ToString();
                relays[i].Pin = _relayDgv.Rows[i].Cells[2].Value.ToString();
                relays[i].Pull = Convert.ToBoolean(_relayDgv.Rows[i].Cells[3].Value);
                relays[i].Inv = Convert.ToBoolean(_relayDgv.Rows[i].Cells[4].Value);
            }
            _config.Relays = relays;


            var discrets = new OneStruct[DISCRET_MAX];
            for (int i = 0; i < _discretDgv.Rows.Count; i++)
            {

                discrets[i] = new OneStruct();
                discrets[i].Port = _discretDgv.Rows[i].Cells[1].Value.ToString();
                discrets[i].Pin = _discretDgv.Rows[i].Cells[2].Value.ToString();
                discrets[i].Pull = Convert.ToBoolean(_discretDgv.Rows[i].Cells[3].Value);
                discrets[i].Inv = Convert.ToBoolean(_discretDgv.Rows[i].Cells[4].Value);
            }
            _config.Discrets = discrets;


            var diodes = new OneStruct[DIODE_MAX];
            for (int i = 0; i < _diodeDgv.Rows.Count; i++)
            {

                diodes[i] = new OneStruct();
                diodes[i].Port = _diodeDgv.Rows[i].Cells[1].Value.ToString();
                diodes[i].Pin = _diodeDgv.Rows[i].Cells[2].Value.ToString();
                diodes[i].Pull = Convert.ToBoolean(_diodeDgv.Rows[i].Cells[3].Value);
                diodes[i].Inv = Convert.ToBoolean(_diodeDgv.Rows[i].Cells[4].Value);
            }
            _config.Diodes = diodes;


            var systemDiodes = new OneStruct[SYSTEM_DIODE_MAX];
            for (int i = 0; i < _systemDiodeDgv.Rows.Count; i++)
            {

                systemDiodes[i] = new OneStruct();
                systemDiodes[i].Port = _systemDiodeDgv.Rows[i].Cells[1].Value.ToString();
                systemDiodes[i].Pin = _systemDiodeDgv.Rows[i].Cells[2].Value.ToString();
                systemDiodes[i].Pull = Convert.ToBoolean(_systemDiodeDgv.Rows[i].Cells[3].Value);
                systemDiodes[i].Inv = Convert.ToBoolean(_systemDiodeDgv.Rows[i].Cells[4].Value);
                systemDiodes[i].Tip = _systemDiodeDgv.Rows[i].Cells[5].Value.ToString();
            }
            _config.SystemDiodes = systemDiodes;



            //_moduleWritterController = _moduleWritterController.Clone();
            //_moduleWritterController.Fail += HandlerHelper.CreateActionHandler(Program.MainFormReferense, () => MessageBox.Show("Ошибка. Конфигурация не записана в устройство"));

            var aer = _config.ToBytes(); //File.ReadAllBytes(fileName);
            Common.SwapArrayItems(ref aer);
            _moduleWritterController.Data = aer;
            try
            {
                await _moduleWritterController.StartSaveForAnotherMemmoryType( _progress);
                MessageBox.Show("Файл успешно записан");
            }
            catch (Exception exception)
            {
                MessageErrorBox me = new MessageErrorBox(exception.Message, "Ошибка.Конфигурация не записана в устройство");
                me.ShowErrorMessageForm();
            }

        }

        private void _systemDiodeAcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var count = int.Parse(_systemDiodeCountTb.Text);
                if ((count < 0) || (count > SYSTEM_DIODE_MAX))
                {
                    throw new ArgumentException();
                }


                _config.SystemDiodeCount = (byte)count;
                this.ShowSystemDiode();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Введите целое число от 0 до {0}", SYSTEM_DIODE_MAX));
            }
        }

        private void ShowSystemDiode()
        {
            _systemDiodeCountTb.Text = _config.SystemDiodeCount.ToString();
            _systemDiodeDgv.Rows.Clear();
            for (int i = 0; i < _config.SystemDiodeCount; i++)
            {
                _systemDiodeDgv.Rows.Add
                (
                    (i + 1).ToString(),
                    _config.SystemDiodes[i].Port,
                    _config.SystemDiodes[i].Pin,
                    _config.SystemDiodes[i].Pull,
                    _config.SystemDiodes[i].Inv,
                    _config.SystemDiodes[i].Tip
                );
            }
        }

    }
}
