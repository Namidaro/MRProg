using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRProg.Connection.Enum;

namespace MRProg.Connection
{
    public class ComPortConfiguration
    {
        //  private readonly string _portName;
        private BaudRates _baudRate = BaudRates.BR115200;
        private int _dataBits = 8;
        private StopBits _stopBits = StopBits.One;
        private Parity _parity = Parity.None;

        private int _readTimeOut = 200;
        private int _writeTimeOut = 100;
        private int _on = 0;
        private int _off = 0;



        public BaudRates BaudRateProperty
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        public int DataBitsProperty
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public StopBits StopBitsProperty
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        public Parity ParityProperty
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public int ReadTimeOut
        {
            get { return _readTimeOut; }
            set { _readTimeOut = value; }
        }

        public int WriteTimeOut
        {
            get { return _writeTimeOut; }
            set { _writeTimeOut = value; }
        }
    }
}
