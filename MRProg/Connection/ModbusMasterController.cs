using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus4.Device;


namespace MRProg.Connection
{
   public class ModbusMasterController
    {

        public IModbusMaster ModbusMaster { get; set; }
        public IProgress<QueryReport> Progress { get; set; }
        private QueryReport _queryReport = new QueryReport();
        public async Task WriteMultipleRegistersAsync(byte deviceNum, ushort startAddress, ushort[] writeArray, string queryName)
        {
            try
            {
                Logger.AddToFile(String.Format("Запрос {0} по адресу {1} ", queryName, startAddress), writeArray.ToArray());
                await ModbusMaster.WriteMultipleRegistersAsync(deviceNum, startAddress, writeArray);
                _queryReport.IsSuccess = true;
            }
            catch (Exception e)
            {
                _queryReport.IsSuccess = false;
                Logger.AddToFile(String.Format("Запрос {0}: по адресу {1} выдал ошибку: {2}", queryName, startAddress, e.Message));
                throw;
            }
            finally
            {
                Progress?.Report(_queryReport);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceNum">Номер устройства</param>
        /// <param name="startAddress">Стартовый адрес</param>
        /// <param name="moduletype">Тип модуля</param>
        /// <param name="moduleposition">Позиция модуля</param>
        /// <param name="writeArray">Данные для записи</param>
        /// <param name="queryName">Наименование запроса</param>
        /// <returns></returns>
        public async Task WriteMultipleRegistersAsyncFunction12(byte deviceNum, ushort startAddress,byte moduleposition,ushort[] writeArray, string queryName)
        {
            try
            {
                Logger.AddToFile(String.Format("Запрос {0} по адресу {1} ", queryName, startAddress), writeArray.ToArray());
                await ModbusMaster.ExecuteFunction12WriteAsync( startAddress,deviceNum,moduleposition, writeArray);
                _queryReport.IsSuccess = true;
            }
            catch (Exception e)
            {
                _queryReport.IsSuccess = false;
                Logger.AddToFile(String.Format("Запрос {0}: по адресу {1} выдал ошибку: {2}", queryName, startAddress, e.Message));
                throw;
            }
            finally
            {
                Progress?.Report(_queryReport);
            }
        }

        public async Task<ushort[]> ReadHoldingRegistersAsync(byte deviceNum, ushort startAddress, ushort numOfPoints, string queryName)
        {
            try
            {
                Logger.AddToFile(String.Format("Запрос  на чтение {0} байт  {1} по адресу {2}", numOfPoints, queryName, startAddress));
                ushort[] res = await ModbusMaster.ReadHoldingRegistersAsync(deviceNum, startAddress, numOfPoints);
                Logger.AddToFile("ОТВЕТ - ", res.ToArray());
                _queryReport.IsSuccess = true;
                return res;
            }
            catch (Exception e)
            {
                Logger.AddToFile(String.Format("Запрос  на чтение {0} байт  {1} по адресу {2}  выдал ошибку - {3}", numOfPoints, queryName, startAddress, e.Message));
                _queryReport.IsSuccess = false;
                throw;
            }
            finally
            {
                Progress?.Report(_queryReport);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceNum">Номер устройства</param>
        /// <param name="startAddress">Стартовый адресс</param>
        /// <param name="numOfPoints">Количество слов</param>
        /// <param name="moduletype">Тип модуля</param>
        /// <param name="moduleposition"></param>
        /// <param name="queryName"></param>
        /// <returns></returns>
        public async Task<ushort[]> ReadHoldingRegistersAsyncFunction12(byte deviceNum, ushort startAddress, ushort numOfPoints, byte moduleposition, string queryName)
        {
            try
            {
                Logger.AddToFile(String.Format("Запрос  на чтение {0} байт  {1} по адресу {2}", numOfPoints, queryName, startAddress));
                ushort[] res = await ModbusMaster.ExecuteFunction12ReadAsync(startAddress,numOfPoints,deviceNum,moduleposition);
                Logger.AddToFile("ОТВЕТ - ", res.ToArray());
                _queryReport.IsSuccess = true;
                return res;
            }
            catch (Exception e)
            {
                Logger.AddToFile(String.Format("Запрос  на чтение {0} байт  {1} по адресу {2}  выдал ошибку - {3}", numOfPoints, queryName, startAddress, e.Message));
                _queryReport.IsSuccess = false;
                throw;
            }
            finally
            {
                Progress?.Report(_queryReport);
            }
        }
    }
}
