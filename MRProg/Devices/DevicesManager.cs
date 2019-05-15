using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRProg.Connection;

namespace MRProg.Devices
{
    public class DevicesManager
    {
        private bool IsDeviceIdentify = false;
        private string _deviceName = String.Empty;
        private string _fullVersion = String.Empty;
        private string _versionNumber = String.Empty;
        private IDeviceSpecification _currentDeviceSpecification;
        public static byte _deviceNumber;

        public DevicesManager()
        {

            AvailableDeviceSpecifications = new List<IDeviceSpecification>()
            {
                new KL4_3IDeviceSpecification(),
                new KlDeviceSpecification(),
                new MlkDeviceSpecification(),
                new MR761DeviceSpecification(),
                new MR761OBRDeviceSpecification(),
                new MR762DeviceSpecification(),
                new MR763DeviceSpecification(),
                new MR764DeviceSpecification(),
                new MR771DeviceSpecification(),
                new MR801DeviceSpecification(),
                new MR801NDeviceSpecification(),
                new MR901DeviceSpecification(),
                new MR902DeviceSpecification(),
                new PT303DeviceSpecification(),
                new ClearDeviceSpecification()
            };
        }

        public List<IDeviceSpecification> AvailableDeviceSpecifications { get; }

        public async Task<IDeviceSpecification> IdentifyDevice(byte devicenumber)
        {
            bool checkAllAdress = false;
            ushort[] answerforMr;
            ushort[] answerforOther;

            _currentDeviceSpecification = new UnsupportedDeviceSpecification();
            try
            {
                answerforMr = await ConnectionManager.Connection.ModbusMasterController.ReadHoldingRegistersAsync(devicenumber, 0x500,
                                    0x20, "Определение типа устройства");
                if (VersionForMR(answerforMr))
                {
                    return _currentDeviceSpecification;
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                answerforOther = await ConnectionManager.Connection.ModbusMasterController.ReadHoldingRegistersAsync(devicenumber, 0x1f00,
                    0x18, "Определение типа устройства");
                if (VersionForOther(answerforOther))
                {
                    return _currentDeviceSpecification;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return _currentDeviceSpecification;
        }

        private bool VersionForMR(ushort[] massUshorts)
        {

            byte[] answer = Common.TOBYTES(massUshorts, true);

            Common.SwapArrayItems(ref answer);

            var str = Common.GetChars(answer).Select(o => o == '\0' ? ' ' : o).ToArray();
            var str1 = new string(str, 0, 16);
            var str2 = new string(str, 16, 16);
            _deviceName = str1.Split(' ')[0] + str1.Split(' ')[1];
            if (_deviceName.Equals("MR801"))
            {
                var str3 = new string(str, 0, str.Length);
                if (str3.Contains("T12N5D58R51"))
                    _deviceName = "MR801N";
            }

            if (string.IsNullOrEmpty(str2))
            {
                _fullVersion = str1;
            }
            else
            {
                _fullVersion = str1 + ' ' + str2;
            }
            string[] param = this._fullVersion.Split(new[] { ' ', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            if (param.Length == 5)
            {
                this._versionNumber = param[4];
            }
            else if (param.Length > 5)
            {
                this._versionNumber = param[5];
            }
            else
            {
                this._versionNumber = string.Empty;
            }

            return IsDeviceConteins(_deviceName);
            Logger.Add(string.Format("Подключенное устройство - {0}", _deviceName));
        }

        private bool VersionForOther(ushort[] answerOther)
        {
            byte[] answer = Common.TOBYTES(answerOther, true);

            Common.SwapArrayItems(ref answer);

            var str = Common.GetChars(answer).Select(o => o == '\0' ? ' ' : o).ToArray();
            var str1 = new string(str, 0, 16);
            var str2 = new string(str, 16, 16);
            var str3 = new string(str, 32, 16);

            if (!str3.All(s => s == ' '))
            {
                _deviceName = str3.Split(' ')[0];

            }
            else
            {
                _deviceName = str1.Split(' ')[0];
            }
            if (String.IsNullOrEmpty(str3))
            {
                _fullVersion = str1;
            }
            else
            {
                _fullVersion = str3;
            }
            if (str1.All(o => o == ' ') && str3.All((o => o == ' ')))
            {
                _deviceName = "Незвестное усройство";
            }
            string[] param = this._fullVersion.Split(new[] { ' ', '\0' }, StringSplitOptions.RemoveEmptyEntries);
            if (param.Length == 5)
            {

                this._versionNumber = param[4];
            }
            else if (param.Length > 5)
            {

                this._versionNumber = param[5];
            }
            else
            {
                this._versionNumber = string.Empty;
            }

            Logger.Add(string.Format("Подключенное устройство - {0}", _deviceName));
            return IsDeviceConteins(_deviceName);
        }

        /// <summary>
        /// Проверка на содержание устройства в списке допустимых устройств
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        private bool IsDeviceConteins(string device)
        {
            foreach (var type in AvailableDeviceSpecifications)
            {
                if (type.DeviceName == device)
                {
                    _currentDeviceSpecification = type;
                    return true;
                }
            }
            return false;
        }

        public string GetDeviceName
        {
            get { return _deviceName; }
        }

        public string GetDeviceVersion
        {
            get { return _versionNumber; }
        }

        public static byte DeviceNumber
        {
            get { return _deviceNumber; }
            set { _deviceNumber = value; }
        }


    }
}
