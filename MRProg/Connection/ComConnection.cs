using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Serial;
using NModbus4.Device;


namespace MRProg.Connection
{
    public class ComConnection
    {
        public ModbusMasterController ModbusMasterController { get; set; }

        public SerialPort Serialport
        {
            get { return _serialport; }
            set { _serialport = value; }
        }

        private ComPortConfiguration _comPortConfiguration;
        private SerialPort _serialport;
        private byte _portNumber;

        internal ComConnection(byte portnumber)
        {
            _portNumber = portnumber;
            if (ConnectionManager.Connection != null)
            {
                ConnectionManager.Connection.Serialport.Close();
            }
            Serialport = new SerialPort(string.Format("COM{0}", _portNumber));
            UpdateConfiguration();
        }
        
        public void UpdateConfiguration()
        {
            _comPortConfiguration = ConnectionManager.GetComConfig(_portNumber);
            if (_comPortConfiguration == null)
            {
                _comPortConfiguration = new ComPortConfiguration();

                ConnectionManager.AddComConfiguration(_portNumber, _comPortConfiguration);

            }
            Serialport.BaudRate = (int)_comPortConfiguration.BaudRateProperty;
            Serialport.StopBits = _comPortConfiguration.StopBitsProperty;
            Serialport.Parity = _comPortConfiguration.ParityProperty;
            Serialport.DataBits = _comPortConfiguration.DataBitsProperty;
            Serialport.ReadTimeout = _comPortConfiguration.ReadTimeOut;
            Serialport.WriteTimeout = _comPortConfiguration.WriteTimeOut;
        }

        public bool TryOpenConnection()
        {
            try
            {

                if (!Serialport.IsOpen)
                {
                    Serialport.Open();
                    ModbusMasterController = new ModbusMasterController()
                    {
                        ModbusMaster = ModbusSerialMaster.CreateRtu(new SerialPortAdapter(Serialport))
                    };
                    ModbusMasterController.Progress = ConnectionManager.Progress; ;
                };
                
               return true;

        }
            catch (Exception e)
            {
                MessageErrorBox me = new MessageErrorBox(e.Message, "Ошибка при открытии порта");
        me.ShowErrorMessageForm();
                return false;
            }
}
    }
}
