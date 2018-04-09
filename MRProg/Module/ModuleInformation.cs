using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRProg.UserControls;

namespace MRProg.Module
{
    public class ModuleInformation
    {

        private ModuleType _modulepositionOnSpecification;

        /// <summary>
        /// Состояние модуля 
        /// </summary>
        public ModuleStates State { get; set; }


        /// <summary>
        /// Тип модуля
        /// </summary>
        public ModuleType ModuleType { get; private set; }


        /// <summary>
        /// Тип модуля в первой строке
        /// </summary>
        public ModuleType ModuleTypeFirstStr { get; private set; }

        /// <summary>
        /// Позиция модуля
        /// </summary>
        public byte ModulePosition { get; private set; }

        public ControlType ControlType { get; set; }
        /// <summary>
        /// Какой модуль должен стоять в этой позиции согласно спецификации
        /// </summary>
        public ModuleType ModulePositionOnSpecification
        {
            get { return _modulepositionOnSpecification; }
            set
            {
                _modulepositionOnSpecification = value;
                if (State == ModuleStates.WORK)
                {
                    if (_modulepositionOnSpecification != this.ModuleType)
                    {
                        this.State = ModuleStates.ANOUTHERPOSITION;
                    }
                }

            }
        }
        /// <summary>
        /// Версия загрузчика
        /// </summary>
        public double LoaderVersion { get; private set; }

        /// <summary>
        /// Версия прошивки
        /// </summary>
        public double ModuleVersion { get; private set; }
        /// <summary>
        /// Тип процессора
        /// </summary>
        public ProcessorType Processor { get; private set; }
        /// <summary>
        /// Свойство необходимо для определения типов модулей где их количество равно 1
        /// </summary>
        public string MlkType { get; private set; }
        /// <summary>
        /// Фьюзы
        /// </summary>
        public string Fuze { get; private set; }

        public string Modification = String.Empty;
        public string Revision = String.Empty;

        /// <summary>
        /// Размер буффера SPI
        /// </summary>
        public int SpiBufferSize
        {
            get
            {
                switch (Processor)
                {
                    case ProcessorType.AT_MEGA_16:
                    case ProcessorType.AT_MEGA_164:
                        {
                            return 0x20;
                        }
                    case ProcessorType.AT_MEGA_128:
                    case ProcessorType.AT_MEGA_2561:
                    case ProcessorType.AT_MEGA_32_U4:
                    case ProcessorType.AT_MEGA_328_P:
                        {
                            return 0x40;
                        }

                }
                return 0;
            }
        }
        /// <summary>
        /// Размер буффера flash
        /// </summary>
        public int FlashSize
        {
            get
            {
                switch (Processor)
                {
                    case ProcessorType.AT_MEGA_16:
                    case ProcessorType.AT_MEGA_164:
                    case ProcessorType.AT_MEGA_32_U4:
                    case ProcessorType.AT_MEGA_328_P:
                        {
                            return 0x40;
                        }
                    case ProcessorType.AT_MEGA_128:
                    case ProcessorType.AT_MEGA_2561:
                        {
                            return 0x80;
                        }

                }
                return 0;
            }
        }

        /// <summary>
        /// Текущий десятичный разделитель
        /// </summary>
        private static string DecimalSeparator
        {
            get { return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator; }
        }


        /// <summary>
        /// Преобразует тип модуля в строку
        /// </summary>
        public string ModuleTypeString
        {
            get
            {
                string moduleTypeString = String.Empty;

                switch (this.ModuleType)
                {
                    case ModuleType.DISCRET_RELAY_16:
                        {
                            moduleTypeString = "SDR SB";
                            break;
                        }
                    case ModuleType.DISCRET_16:
                        {
                            moduleTypeString = "SD SA";
                            break;
                        }
                    case ModuleType.DISCRET_32:
                        {
                            moduleTypeString = "SD SB";
                            break;
                        }
                    case ModuleType.DISCRET_RELAY_8:
                        {
                            moduleTypeString = "SDR SA";
                            break;
                        }
                    case ModuleType.POWER:
                        {
                            moduleTypeString = "POWER SA";
                            break;
                        }
                    case ModuleType.ANALOG_8_I:
                        {
                            moduleTypeString = "ANALOG SA";
                            break;
                        }
                    case ModuleType.ANALOG_4_I_4_U:
                        {
                            moduleTypeString = "ANALOG SB";
                            break;
                        }
                    case ModuleType.ANALOG_5_I_3_U:
                        {
                            moduleTypeString = "ANALOG SC";
                            break;
                        }
                    case ModuleType.ANALOG_3_I_5_U:
                        {
                            moduleTypeString = "ANALOG SD";
                            break;
                        }
                    case ModuleType.ANALOG_4_I_5_U:
                        {
                            moduleTypeString = "ANALOG SE";
                            break;
                        }
                    case ModuleType.MKI:
                        {
                            moduleTypeString = "BOARD SB";
                            break;
                        }
                    case ModuleType.MLK:
                        {
                            moduleTypeString = "MLK   ";
                            break;
                        }
                    case ModuleType.KL:
                        {
                            moduleTypeString = "KL    ";
                            break;
                        }
                    case ModuleType.KL4_3I:
                        {
                            moduleTypeString = "KL4_3I";
                            break;
                        }
                    case ModuleType.PT303:
                        {
                            moduleTypeString ="PT303 ";
                            break;
                        }
                    case ModuleType.CLEAR:
                        {
                            moduleTypeString = "Незвестное устройство{0}";
                            break;
                        }
                }
                return moduleTypeString;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                var moduleConfiguration = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.ModuleType = ModuleType.NONE;
                this.Modification = moduleConfiguration[2];
                this.Revision = moduleConfiguration[3];
                if (moduleConfiguration[0] == "POWER")
                {
                    if (moduleConfiguration[1] == "SA")
                    {
                        this.ModuleType = ModuleType.POWER;
                    }
                }

                if (moduleConfiguration[0] == "SDR")
                {
                    if (moduleConfiguration[1] == "SA")
                    {
                        this.ModuleType = ModuleType.DISCRET_RELAY_8;
                    }
                    else if (moduleConfiguration[1] == "SB")
                    {
                        this.ModuleType = ModuleType.DISCRET_RELAY_16;
                    }
                    else if (moduleConfiguration[1] == "SC")
                    {
                        this.ModuleType = ModuleType.DISCRET_24_RELAY_8;
                    }
                }

                if (moduleConfiguration[0] == "SD")
                {
                    if (moduleConfiguration[1] == "SA")
                    {
                        this.ModuleType = ModuleType.DISCRET_16;
                    }
                }

                if (moduleConfiguration[0] == "ANALOG")
                {
                    switch (moduleConfiguration[1])
                    {
                        case "SA":
                            this.ModuleType = ModuleType.ANALOG_8_I;
                            break;
                        case "SB":
                            this.ModuleType = ModuleType.ANALOG_4_I_4_U;
                            break;
                        case "SC":
                            this.ModuleType = ModuleType.ANALOG_5_I_3_U;
                            break;
                        case "SD":
                            this.ModuleType = ModuleType.ANALOG_3_I_5_U;
                            break;
                        case "SE":
                            this.ModuleType = ModuleType.ANALOG_4_I_5_U;
                            break;
                    }
                }

                if (moduleConfiguration[0] == "BOARD")
                {
                    if (moduleConfiguration[1] == "SB")
                    {
                        this.ModuleType = ModuleType.MKI;
                    }
                }

                if ((moduleConfiguration[0] == "MLK"))
                {
                    this.ModuleType = ModuleType.MLK;
                    this.MlkType = moduleConfiguration[1];
                }
                if (moduleConfiguration[0] == "KL")
                {
                    this.ModuleType = ModuleType.KL;
                    this.MlkType = moduleConfiguration[1];
                }
                if (moduleConfiguration[0] == "PT303")
                {
                    this.ModuleType = ModuleType.PT303;
                    this.MlkType = moduleConfiguration[1];
                }
                if ((moduleConfiguration[0] == "KL4_3I"))
                {
                    this.ModuleType = ModuleType.KL4_3I;
                    this.MlkType = moduleConfiguration[1];
                }
            }
        }

        public ModuleInformation()
        {
            this.State = ModuleStates.NO_MODULE;
        }

        public ModuleInformation(string str1, byte[] str2, string str3, byte modulePosition)
        {

            this.ModulePosition = modulePosition;
            Fuze = "Нет";

            try
            {
                if ((String.IsNullOrEmpty(str1) & str2.All(o => o == 0) & String.IsNullOrEmpty(str3))) //000

                {
                    this.State = ModuleStates.NO_MODULE;
                    this.ModuleType = ModuleType.NONE;
                    return;
                }
                if (((!String.IsNullOrEmpty(str1)) & (!str2.All(o => o == 0)) & String.IsNullOrEmpty(str3))) //110
                {
                    this.State = ModuleStates.WITHOUTTYPE;
                    this.ModuleType = ModuleType.WITHOUTTYPE;
                    return;
                }

                if ((String.IsNullOrEmpty(str1) & str2.All(o => o == 0) & (!String.IsNullOrEmpty(str3))) || //001
                    ((!String.IsNullOrEmpty(str1)) & str2.All(o => o == 0) & String.IsNullOrEmpty(str3)) || //100
                    ((!String.IsNullOrEmpty(str1)) & str2.All(o => o == 0) & (!String.IsNullOrEmpty(str3)))) //101
                {
                    this.State = ModuleStates.ERROR_READ_MODULE;
                    this.ModuleType = ModuleType.ERROR;
                    return;
                }
                if ((str1.All(o => o == ' ') & (!str2.All(o => o == 0)) & (str3.All(o => o == ' ')))) ///010
                {
                    this.State = ModuleStates.CLEAR;
                    this.ModuleType = ModuleType.CLEAR;
                    ParseLoaderString(str2);
                    return;
                }
                else
                {
                    this.ParseWorkString(str1);
                }

                ParseLoaderString(str2);
                this.ModuleTypeString = str3;

            }
            catch (Exception e)
            {
                this.State = ModuleStates.NO_MODULE;
                this.ModuleType = ModuleType.NONE;

            }
        }

        /// <summary>
        /// Разбор строки рабочей программы
        /// </summary>
        /// <param name="str"></param>
        private void ParseWorkString(string str)
        {
            if (String.IsNullOrEmpty(str) || str.All(s=> s==' '))
            {
                this.State = ModuleStates.LOADER;
                return;
            }

            if (str.Contains("Error"))
            {
                this.State = ModuleStates.ERROR_WORK_STRING;

                return;
            }

            this.State = ModuleStates.WORK;

            var strings = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double version;
            if (Double.TryParse(strings[3].Replace(".", DecimalSeparator), out version))
            {
                this.ModuleVersion = version;
            }
        }


        private void ParseLoaderString(byte[] str2)
        {
            if (str2[3] == (byte)' ')
            {
                var fuses = str2.Take(12).Skip(8).ToArray();


                string result = string.Empty;
                foreach (var i in fuses)
                {
                    result = result + i.ToString("X") + " ";
                }
                result = result.Trim().Replace(' ', '.');
                Fuze = result;


                int proc = 0;
                str2.Take(7).Skip(4).Select
                    (o =>
                        proc = (proc << 8) + o).
                    ToArray();

                var vers = new string(str2.Skip(13).Select(o => (char)o).ToArray());

                this.Processor = (ProcessorType)proc;
                double version;
                if (Double.TryParse(vers.Replace(".", DecimalSeparator), out version))
                {
                    this.LoaderVersion = version;
                }
            }


            if (str2[3] == (byte)'*')
            {
                var ascii = new ASCIIEncoding();
                var devIdStr = new string(ascii.GetChars(str2, 4, 3));
                var revIdStr = new string(ascii.GetChars(str2, 8, 4));
                string result = string.Format("Dev = 0x{0} Rev = 0x{1}", devIdStr, revIdStr);
                Fuze = result;
            }
        }
    }
}
