using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRProg.Connection;
using MRProg.Connection.Enum;
using MRProg.Devices;
using MRProg.UserControls;
using NModbus4.Utility;

namespace MRProg.Module
{
    public class ModuleWritterController
    {

        #region Const
        private const string LOAD_EEPROM = "LOADEeprom";
        private const string SAVE_EEPROM = "SAVEEeprom";
        private const string LOAD_FLASH = "LOAD_FLASH";
        private const string SAVE_FLASH = "SAVE_FLASH";
        private const string LOAD_RELAY = "LOAD_RELAY";
        private const string SAVE_RELAY = "SAVE_RELAY";
        private const string SAVE_WORK = "SAVE_WORK";
        private const string PAGE_TO_WRITEBUFFER = "PAGE_TO_WRITEBUFFER  ";
        private const string PAGE_TO_READBUFFER = "PAGE_TO_RAEDBUFFER  ";
        #endregion

        private ModuleInformation _moduleInformation;
        private int _pageCount = 16;
        private ushort _startPage;
        private ushort _currentPage;
        private TypeOfMemory _typeOfMemory;
        private byte _deviceNumber;
        private byte[] _data;
        private string _errorMessage = String.Empty;
        private bool _isMR = false;
        private ushort _crc;

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public ModuleWritterController Clone()
        {
            return new ModuleWritterController(_moduleInformation, _typeOfMemory, _deviceNumber);
        }
        public ModuleWritterController(ModuleInformation moduleInformation, TypeOfMemory memoryType, byte devicenumber, byte[] data, ushort startpage = 0, ushort count = 0)
        {
            _moduleInformation = moduleInformation;
            _typeOfMemory = memoryType;
            _deviceNumber = devicenumber;
            Data = data;
            if (moduleInformation.ControlType == ControlType.MRTYPE)
            {
                _isMR = true;
            }
            else
            {
                _isMR = false;
            }
            switch (memoryType)
            {
                case TypeOfMemory.EEPROM:
                    {
                        if ((_moduleInformation.Processor == ProcessorType.AT_MEGA_128) || (_moduleInformation.Processor == ProcessorType.AT_MEGA_2561))
                        {
                            this._pageCount = 4 * 1024 / 256;
                        }

                        if ((_moduleInformation.Processor == ProcessorType.AT_MEGA_16) || (_moduleInformation.Processor == ProcessorType.AT_MEGA_164))
                        {
                            this._pageCount = 1 * 512 / 128;
                        }


                        if ((_moduleInformation.Processor == ProcessorType.AT_MEGA_32_U4) || (_moduleInformation.Processor == ProcessorType.AT_MEGA_328_P))
                        {
                            this._pageCount = 1 * 1024 / 128;
                        }


                        break;
                    }
                case TypeOfMemory.BOOT_FLASH:
                    {

                        this._pageCount = count;
                        _startPage = startpage;
                        break;
                    }
                case TypeOfMemory.RALAY_DISCRET:
                    {
                        this._pageCount = 1;
                        this._startPage = 1020;
                        break;
                    }
                case TypeOfMemory.WORK:
                    {
                        if (_moduleInformation.Processor == ProcessorType.AT_MEGA_128)
                        {
                            _pageCount = 480;
                            break;
                        }
                        if (_moduleInformation.Processor == ProcessorType.AT_MEGA_2561)
                        {
                            _pageCount = 992;
                            break;
                        }
                        else
                        {
                            _pageCount = 96;
                            break;
                        }
                    }
            }
        }

        public ModuleWritterController(ModuleInformation moduleInformation, TypeOfMemory memoryType, byte devicenumber, ushort startpage = 0, ushort count = 0)
        {
            _moduleInformation = moduleInformation;
            _typeOfMemory = memoryType;
            _deviceNumber = devicenumber;
            if (moduleInformation.ControlType == ControlType.MRTYPE)
            {
                _isMR = true;
            }
            else
            {
                _isMR = false;
            }
            switch (memoryType)
            {
                case TypeOfMemory.EEPROM:
                    {
                        if ((_moduleInformation.Processor == ProcessorType.AT_MEGA_128) || (_moduleInformation.Processor == ProcessorType.AT_MEGA_2561))
                        {
                            this._pageCount = 4 * 1024 / 256;
                        }

                        if ((_moduleInformation.Processor == ProcessorType.AT_MEGA_16) || (_moduleInformation.Processor == ProcessorType.AT_MEGA_164))
                        {
                            this._pageCount = 1 * 512 / 128;
                        }


                        if ((_moduleInformation.Processor == ProcessorType.AT_MEGA_32_U4) || (_moduleInformation.Processor == ProcessorType.AT_MEGA_328_P))
                        {
                            this._pageCount = 1 * 1024 / 128;
                        }


                        break;
                    }
                case TypeOfMemory.BOOT_FLASH:
                    {

                        this._pageCount = count;
                        _startPage = startpage;
                        break;
                    }
                case TypeOfMemory.RALAY_DISCRET:
                    {
                        this._pageCount = 1;
                        this._startPage = 1020;
                        break;
                    }
                case TypeOfMemory.WORK:
                    {
                        if (_moduleInformation.Processor == ProcessorType.AT_MEGA_128)
                        {
                            _pageCount = 480;
                            break;
                        }
                        else
                        {
                            _pageCount = 96;
                            break;
                        }
                    }
            }
        }
        public async Task ModuleToloader()
        {
            if (_moduleInformation.State == ModuleStates.LOADER)
            {
                return;
            }
            string name = "Перевод модуля в режим загрузчика";
            var res = Common.TOWORD(0, (byte)((Convert.ToByte(_moduleInformation.ModuleType) << 4) | _moduleInformation.ModulePosition));
            var writePageArray = new ushort[] { res, };

            try
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber, 0x3A0,
                               writePageArray, name);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при переводе в режим загрузчика");
            }
        }

        public static async Task ModuleToloader(ModuleInformation information)
        {
            if (information.State == ModuleStates.LOADER)
            {
                return;
            }
            string name = "Перевод модуля в режим загрузчика";
            var res = Common.TOWORD(0, (byte)((Convert.ToByte(information.ModuleType) << 4) | information.ModulePosition));
            var writePageArray = new ushort[] { res, };

            try
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(DevicesManager.DeviceNumber, 0x3A0,
                    writePageArray, name);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task ClearModule(ModuleInformation information)
        {
            ushort controlWord = 0;
            controlWord = Common.SetBits(controlWord, (ushort)information.ModuleType, 4, 5, 6, 7);
            controlWord = Common.SetBits(controlWord, information.ModulePosition, 0, 1, 2, 3);
            try
            {


                if (information.ControlType == ControlType.MRTYPE)
                {
                    await ModuleToloader(information);

                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(DevicesManager.DeviceNumber, 0, information.ModulePosition,
                        new ushort[8] { 0, 0, 0, 0, 0, 0, 0, 0 }, "Очитска модуля 2-ый этап");
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(DevicesManager.DeviceNumber, (ushort)(information.FlashSize + 1), information.ModulePosition,
                        new ushort[1] { 0x8001 }, "Очитска модуля 2-ый этап");

                }
                else
                {
                    ModuleMLKToloader(information);
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(DevicesManager.DeviceNumber, 0,
                        new ushort[8] { 0, 0, 0, 0, 0, 0, 0, 0 }, "Очитска модуля 2-ый этап");
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(DevicesManager.DeviceNumber, (ushort)(information.FlashSize + 1),
                        new ushort[1] { 0x8001 }, "Очитска модуля 2-ый этап");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        public static async Task WriteDevInfo(ModuleInformation information, string devinfo)
        {
            ushort controlWord = 0;
            controlWord = Common.SetBits(controlWord, (ushort)information.ModuleType, 4, 5, 6, 7);
            controlWord = Common.SetBits(controlWord, information.ModulePosition, 0, 1, 2, 3);
            var inBytes = Common.TOWORDS(devinfo.Select(o => (byte)o).ToArray(), false);
            try
            {


                if (information.ControlType == ControlType.MRTYPE)
                {

                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(DevicesManager.DeviceNumber, 0, information.ModulePosition,
                        inBytes, "Очитска модуля 2-ый этап");
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(DevicesManager.DeviceNumber, (ushort)(information.FlashSize+1), information.ModulePosition,
                        new ushort[1] { 0x8001 }, "Очитска модуля 2-ый этап");

                }
                else
                {

                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(DevicesManager.DeviceNumber, 0,
                        inBytes, "Очитска модуля 2-ый этап");
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(DevicesManager.DeviceNumber, (ushort)(information.FlashSize + 1),
                        new ushort[1] { 0x8001 }, "Очитска модуля 2-ый этап");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static void ModuleMLKToloader(ModuleInformation information)
        {

            if (information.State == ModuleStates.LOADER)
            {
                return;
            }
            string name = "Перевод модуля в режим загрузчика";

            try
            {
                byte[] buffer = new byte[] { 0x01, 0xff, 0x47, 0x4f, 0x20, 0x54, 0x4f, 0x20, 0x42, 0x4f, 0x4f, 0x54, 0x4c, 0x4f, 0x41, 0x44, 0x45, 0x52, 0x42, 0xef };

                ConnectionManager.Connection.Serialport.Write(buffer, 0, buffer.Length);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task ModuleMLKToWork(ModuleInformation information)
        {
            if (information.State == ModuleStates.WORK)
            {
                return;
            }
            string name = "Перевод модуля в рабочий режим";
            try
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(DevicesManager.DeviceNumber,
                    (ushort)(information.FlashSize + 1),
                    new ushort[] { 0x8002 }, name);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task WritePageAsync(ushort[] tempArrayUshortToWrite, ushort[] writePageArray)
        {
            string name = string.Empty;
            switch (this._typeOfMemory)
            {
                case TypeOfMemory.EEPROM:
                    name = SAVE_EEPROM;
                    break;
                case TypeOfMemory.BOOT_FLASH:
                    name = SAVE_FLASH;
                    break;
                case TypeOfMemory.RALAY_DISCRET:
                    name = SAVE_RELAY;
                    break;
                case TypeOfMemory.WORK:
                    name = SAVE_WORK;
                    break;
            }
            if (_isMR)
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(_deviceNumber, 0, _moduleInformation.ModulePosition,
                    tempArrayUshortToWrite.Take(_moduleInformation.SpiBufferSize).ToArray(), name);
            }
            else
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber, 0,
              tempArrayUshortToWrite.Take(_moduleInformation.SpiBufferSize).ToArray(), name);
            }


            if (tempArrayUshortToWrite.Length > _moduleInformation.SpiBufferSize)
            {
                name = name + " Part2";
                if (_isMR)
                {
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(_deviceNumber, (ushort)_moduleInformation.SpiBufferSize,
                        _moduleInformation.ModulePosition, tempArrayUshortToWrite.Skip(_moduleInformation.SpiBufferSize).ToArray(), name);
                }
                else
                {
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber,
                    (ushort)_moduleInformation.SpiBufferSize,
                    tempArrayUshortToWrite.Skip(_moduleInformation.SpiBufferSize).ToArray(), name);
                }

            }

            if (_isMR)
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(_deviceNumber,
                    (ushort)this._moduleInformation.FlashSize, _moduleInformation.ModulePosition, writePageArray, PAGE_TO_WRITEBUFFER + writePageArray[0]);
            }

            else
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber,
                (ushort)this._moduleInformation.FlashSize, writePageArray, PAGE_TO_WRITEBUFFER + writePageArray[0]);
            }

        }
        /// <summary>
        /// Чтение страниц
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="isCheck">Является ли чтение проверочным</param>
        /// <returns></returns>
        public async Task<byte[]> ReadPage(IProgress<LoadReport> progress, bool isCheck = false)
        {
            int arraySize = this._pageCount * this._moduleInformation.FlashSize * 2;
            var tempArray = new byte[arraySize];
            for (ushort i = _startPage; i < (_startPage + _pageCount); i++)
            {
                bool isLoadAgain = false;
                int badQueriesCount = 0;
                do
                {

                    try
                    {
                        var writePageArray = new ushort[] { i, (ushort)(Func.READ | (Func)this._typeOfMemory) };
                        byte[] checkingArray = Common.TOBYTES(await this.LoadPageAsync(writePageArray), true);


                        Array.Copy(checkingArray, 0, tempArray, (i - _startPage) * this._moduleInformation.FlashSize * 2, this._moduleInformation.FlashSize * 2);
                        if (!isCheck)
                        {
                            progress.Report(new LoadReport()
                            {
                                CurrentProgressCount = i - _startPage + 1,
                                TotalProgressCount = _pageCount
                            });
                        }
                        else
                        {
                            progress.Report(new LoadReport()
                            {
                                CurrentProgressCount = (i - _startPage + 1) + _pageCount,
                                IsCkeckResult = true
                            });
                        }
                        isLoadAgain = false;
                    }
                    catch (Exception e)
                    {
                        _errorMessage = e.Message;
                        isLoadAgain = true;
                        badQueriesCount++;
                    }
                } while (isLoadAgain && badQueriesCount < 3);


                if (badQueriesCount == 3)
                {
                    throw new Exception($"Страница {i} не была прочитана. " + Environment.NewLine + _errorMessage);
                }

            }
            progress.Report(new LoadReport() { CurrentProgressCount = 0, TotalProgressCount = 0 });
            return tempArray;
        }

        public async Task<ushort[]> LoadPageAsync(ushort[] writePageArray)
        {


            string name = string.Empty;
            switch (this._typeOfMemory)
            {
                case TypeOfMemory.EEPROM:
                    name = LOAD_EEPROM;
                    break;
                case TypeOfMemory.BOOT_FLASH:
                    name = LOAD_FLASH;
                    break;
                case TypeOfMemory.RALAY_DISCRET:
                    name = LOAD_RELAY;
                    break;
            }
            if (_isMR)
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(_deviceNumber,
                    (ushort)this._moduleInformation.FlashSize, _moduleInformation.ModulePosition, writePageArray, PAGE_TO_READBUFFER + writePageArray[0]);
            }
            else
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber,
                (ushort)this._moduleInformation.FlashSize, writePageArray, PAGE_TO_READBUFFER + writePageArray[0]);
            }


            List<ushort> ushorts = new List<ushort>();

            if (ushorts.Count < _moduleInformation.FlashSize)
            {
                name = name + " Part1";
                if (_isMR)
                {
                    ushorts.AddRange(await ConnectionManager.Connection.ModbusMasterController?.ReadHoldingRegistersAsyncFunction12(
                        _deviceNumber, 0, (ushort)_moduleInformation.SpiBufferSize, _moduleInformation.ModulePosition,
                        name));
                }
                else
                {
                    ushorts.AddRange(await ConnectionManager.Connection.ModbusMasterController?.ReadHoldingRegistersAsync(_deviceNumber, 0, (ushort)_moduleInformation.SpiBufferSize, name));
                }

            }


            if (ushorts.Count < _moduleInformation.FlashSize)
            {
                name = name + " Part2";
                if (_isMR)
                {
                    ushorts.AddRange(await ConnectionManager.Connection.ModbusMasterController?.ReadHoldingRegistersAsyncFunction12(
                        _deviceNumber, (ushort)_moduleInformation.SpiBufferSize, (ushort)_moduleInformation.SpiBufferSize, _moduleInformation.ModulePosition,
                        name));
                }
                else
                {
                    ushorts.AddRange(await ConnectionManager.Connection.ModbusMasterController?.ReadHoldingRegistersAsync(
                   _deviceNumber, (ushort)_moduleInformation.SpiBufferSize, (ushort)_moduleInformation.SpiBufferSize,
                   name));
                }

            }
            return ushorts.ToArray();
        }
        /// <summary>
        /// запись рабочей программы
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task StartSave(IProgress<LoadReport> progress)
        {
            if (Data.Length > this._pageCount * this._moduleInformation.FlashSize * 2)
            {
                throw new Exception("Неверный размер файла");
            }
            else
            {
                if ((Data.Length % (this._moduleInformation.FlashSize * 2)) == 0)
                {
                    _pageCount = (ushort)(Data.Length / (this._moduleInformation.FlashSize * 2));
                }
                else
                {
                    throw new Exception("Образ файловой системы некратен размеру страницы микроконтроллера");
                }
            }
            _currentPage = 0;
            try
            {

                await ModuleToloader();
                await Task.Delay(2000);
                await this.FillPage(progress);
                await WriteCRC();
                await Task.Delay(2500);
                await VerifyCRC();
                await Task.Delay(500);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task StartSaveForAnotherMemmoryType(IProgress<LoadReport> progress)
        {
            if (Data.Length > this._pageCount * this._moduleInformation.FlashSize * 2)
            {
                throw new Exception("Неверный размер файла");
            }
            else
            {
                if ((Data.Length % (this._moduleInformation.FlashSize * 2)) == 0)
                {
                    _pageCount = (ushort)(Data.Length / (this._moduleInformation.FlashSize * 2));
                }
                else
                {
                    throw new Exception("Образ файловой системы некратен размеру страницы микроконтроллера");
                }
            }
            _currentPage = 0;
            try
            {
                ModuleMLKToloader(_moduleInformation);
                await Task.Delay(2000);
                await this.FillPage(progress, true);
                await CheckResultWrite(progress);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private async Task CheckResultWrite(IProgress<LoadReport> progress)
        {
            List<int> listErrorPage = new List<int>();
            try
            {
                byte[] result = await this.ReadPage(progress, true);
                Common.SwapArrayItems(ref result);
                if (result.Length != Data.Length)
                {
                    MessageBox.Show("Длинна записанного и прочитанного файла не совпадает");
                    return;
                }
                for (int i = 0; i < Data.Length; i++)
                {
                    if (Data[i] != result[i])
                    {
                        if (Data[i] % (this._moduleInformation.FlashSize * 2) > 0)
                        {
                            listErrorPage.Add((Data[i] / (this._moduleInformation.FlashSize * 2)) + 1);
                        }
                        else
                        {
                            listErrorPage.Add(Data[i] / (this._moduleInformation.FlashSize * 2));
                        }
                    }
                }
                if (listErrorPage.Count != 0)
                {
                    string stringPageError = String.Empty;
                    foreach (var errorPage in listErrorPage)
                    {
                        stringPageError = errorPage.ToString() + ", ";
                    }
                    if (listErrorPage.Count == 1)
                    {
                        MessageBox.Show(" Cтраница " + stringPageError + " записана неверно");
                    }
                    else
                    {
                        MessageBox.Show(" Cтраницы " + stringPageError + " записаны неверно");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
        /// <summary>
        /// Запись страниц
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="isCkeck">Нужна ли проверка</param>
        /// <returns></returns>
        private async Task FillPage(IProgress<LoadReport> progress, bool isCkeck = false)
        {
            ushort address = 0;
            ushort startPage = _startPage;

            for (ushort i = startPage; i < (startPage + _pageCount); i++)
            {
                bool isLoadAgain = false;
                int badQueriesCount = 0;
                do
                {

                    try
                    {

                        int arraySize = this._moduleInformation.FlashSize * 2;
                        var tempArray = new byte[arraySize];
                        Array.Copy(this.Data, (i - startPage) * arraySize, tempArray, 0, arraySize);

                        var tempArrayUshortToWrite = Common.TOWORDS(tempArray, false);
                        var writePageArray = new ushort[] { i, (ushort)(Func.WRITE | (Func)this._typeOfMemory) };

                        await WritePageAsync(tempArrayUshortToWrite, writePageArray);
                        await Task.Delay(100);
                        //writePageArray = new ushort[] { i, (ushort)(Func.READ | (Func)this._typeOfMemory) };
                        //byte[] checkingArray = Common.TOBYTES(await LoadPageAsync(writePageArray), false);

                        //bool checkResult = checkingArray.SequenceEqual(tempArray);
                        if (!isCkeck)
                        {
                            progress.Report(new LoadReport() { CurrentProgressCount = i - startPage + 1, TotalProgressCount = _pageCount });
                        }
                        else
                        {
                            progress.Report(new LoadReport() { CurrentProgressCount = i - startPage + 1, TotalProgressCount = _pageCount * 2 });
                        }

                        //if (!checkResult)
                        //{
                        //    isLoadAgain = true;
                        //    badQueriesCount++;
                        //}
                        //else
                        //{
                        isLoadAgain = false;
                        //}
                    }
                    catch (Exception e)
                    {
                        _errorMessage = e.Message;
                        isLoadAgain = true;
                        badQueriesCount++;
                    }
                } while (isLoadAgain && badQueriesCount < 3);


                if (badQueriesCount == 3)
                {
                    progress.Report(new LoadReport() { CurrentProgressCount = 0, TotalProgressCount = 0 });
                    throw new Exception($"Страница {i} не была записана." + Environment.NewLine + _errorMessage);

                }

            }
            if (!isCkeck)
            {
                progress.Report(new LoadReport() { CurrentProgressCount = 0, TotalProgressCount = 0 });
            }

        }


        private async Task WriteCRC()
        {
            _crc = Common.SwapByte(Crc16.CalcCrcFast(this.Data, Data.Length));
            ushort[] data = new ushort[] { (ushort)_pageCount, 0x8000, _crc };
            try
            {
                if (_isMR)
                {
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(_deviceNumber, (ushort)this._moduleInformation.FlashSize, _moduleInformation.ModulePosition,
                        data, "запрос CRC");
                }
                else
                {
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber,
                        (ushort)this._moduleInformation.FlashSize, data, "запрос CRC");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка отправки CRC");
            }

        }

        private async Task VerifyCRC()
        {
            List<ushort> ushorts = new List<ushort>();
            try
            {
                if (_isMR)
                {
                    ushorts.AddRange(await ConnectionManager.Connection.ModbusMasterController?.ReadHoldingRegistersAsyncFunction12(_deviceNumber, (ushort)this._moduleInformation.FlashSize, 1, _moduleInformation.ModulePosition, "Чтение CRC"));
                }
                else
                {
                    await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber,
                        (ushort)this._moduleInformation.FlashSize, new ushort[1], "чтение CRC");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка чтения CRC");
            }
            if (_crc == ushorts[0])
            {
                ushort[] data = new ushort[] { 0x35AA };
                try
                {
                    if (_isMR)
                    {
                        await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(_deviceNumber, (ushort)(this._moduleInformation.FlashSize + 1), _moduleInformation.ModulePosition,
                            data, "запись сигнатуры");
                    }
                    else
                    {
                        await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsync(_deviceNumber,
                            (ushort)(this._moduleInformation.FlashSize + 1), data, "запись сигнатуры");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Ошибка записи сигнатуры");
                }

            }

        }

        public static async Task ModuleToWork(ModuleInformation information)
        {
            if (information.State == ModuleStates.WORK)
            {
                return;
            }
            ushort[] data = new ushort[] { 0x35AA };
            try
            {
                await ConnectionManager.Connection.ModbusMasterController?.WriteMultipleRegistersAsyncFunction12(DevicesManager.DeviceNumber, (ushort)(information.FlashSize + 1), information.ModulePosition,
                    data, "запись сигнатуры");

            }
            catch (Exception e)
            {
                throw new Exception("Ошибка записи сигнатуры");
            }
        }

    }
}
