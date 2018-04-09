using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRProg.Connection;
using MRProg.Devices;
using MRProg.UserControls;

namespace MRProg.Module
{
    public class ModuleManager
    {

        private const ushort MODULE_INFO_SIZE = 24;

        public async Task<ModuleInformation> ReadModuleInformation(IDeviceSpecification deviceSpecification, byte devicenumber,int i)
        {
            ModuleInformation moduleInformation=new ModuleInformation();
            try
            {

                     ushort[] answer = await ConnectionManager.Connection.ModbusMasterController.ReadHoldingRegistersAsync(devicenumber, (ushort)(deviceSpecification.StartAddInfo + MODULE_INFO_SIZE * i),
                         MODULE_INFO_SIZE, "Чтение информации о модуле");
                    byte[] answerBytes = Common.TOBYTES(answer, false);
                    char[] str = Common.GetChars(answerBytes).Select(o => o == '\0' ? ' ' : o).ToArray();
                    string str1 = new string(str, 0, 16);
                    string str2 = new string(str, 16, 16);
                    string str3 = new string(str, 32, 16);
                    var addingInfo = answerBytes.Skip(16).Select(o => (byte)o).Take(16).ToArray();
                     moduleInformation=new ModuleInformation(str1,addingInfo,str3,(byte)i);
                    moduleInformation.ModulePositionOnSpecification = deviceSpecification.ModuleTypes[i];
                moduleInformation.ControlType = deviceSpecification.ControlType;

            }
            catch (Exception e)
            {
                throw;
            }
            return moduleInformation;
        }



        /// <summary>
        /// Расшифровка типа модуля
        /// </summary>
        public static string ModuleTypeFriendlyName(ModuleType moduleType)
        {
            switch (moduleType)
            {
                case ModuleType.DISCRET_RELAY_16:
                    return "МСДР 761";
                case ModuleType.DISCRET_24_RELAY_8:
                    return "МСДР 901";
                case ModuleType.DISCRET_16:
                    return "МСД 801";
                case ModuleType.DISCRET_32:
                    return "МСД 761 ОБР";
                case ModuleType.DISCRET_RELAY_8:
                    return "МСДР 801";
                case ModuleType.POWER:
                    return "МПР 801";
                case ModuleType.ANALOG_8_I:
                    return "МСА 801 ТТ (8Т)";
                case ModuleType.ANALOG_4_I_4_U:
                    return "МСА 801 ТН (4Т 4Н)";
                case ModuleType.ANALOG_5_I_3_U:
                    return "МСА 762 (5Т 3Н)";
                case ModuleType.ANALOG_3_I_5_U:
                    return "МСА 763 (3Т 5Н)";
                case ModuleType.ANALOG_4_I_5_U:
                    return "МСА 771 (4Т 5Н)";
                case ModuleType.MKI:
                    return "МКИ";
                case ModuleType.MLK:
                    return "МЛК";
                case ModuleType.KL4_3I:
                    return "КЛ4-3И";
                case ModuleType.KL:
                    return "КЛ";
                case ModuleType.PT303:
                    return "PT 303";
                case ModuleType.EEPROM:
                    return "Eeprom";
                default:
                    return "Модуль неопределён";
            }
        }

    }
}
