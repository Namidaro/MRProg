using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRProg.Connection
{
    public  static class ConnectionManager
    {
        private static Dictionary<byte, ComPortConfiguration> _comPortConfigurations = new Dictionary<byte, ComPortConfiguration>();
        public static string SelectedPort { get; set; }
        public static IProgress<QueryReport> Progress{ get; set; }

        public static ComConnection Connection { get; set; }

        public static ComPortConfiguration GetComConfig(byte portNumber)
        {
            if (_comPortConfigurations.ContainsKey(portNumber))
            {
                return _comPortConfigurations[portNumber];
            }
            return null;
        }

        public static void AddComConfiguration(byte number, ComPortConfiguration configuration)
        {
            if (_comPortConfigurations.ContainsKey(number))
            {
                _comPortConfigurations[number] = configuration;
            }
            else
            {
                _comPortConfigurations.Add(number, configuration);
            }
        }
        public static byte[] GetPorts()
        {
            var temp = SerialPort.GetPortNames().Select(o => byte.Parse(o.Replace("COM", ""))).ToList();
            temp.Sort();
            return temp.ToArray();
        }
    }
}
