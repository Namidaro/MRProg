using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus4;
using NModbus4.Data;
using NModbus4.Message;
using NModbus4.Utility;

namespace NModBus4.Message.Function12
{
    public class Function12RequestRead: AbstractModbusMessage, IModbusRequest
    {

        private int _minimumFrameSize;



        public Function12RequestRead(byte functionCode, ushort startAddress, ushort numOfPoints, byte devicenumber, byte moduleNumber) : base(devicenumber, functionCode)
        {
            List<byte> customBytes = new List<byte>();
            var res = 0xF0 | moduleNumber;
            customBytes.Add(Convert.ToByte(res));
            ReadHoldingInputRegistersRequest innerRequest = new ReadHoldingInputRegistersRequest(Modbus.ReadInputRegisters,devicenumber,startAddress, numOfPoints);
            byte[] crcforinnerRequest = ModbusUtility.CalculateCrc(innerRequest.MessageFrame);
            customBytes.AddRange(innerRequest.MessageFrame);
            customBytes.AddRange(crcforinnerRequest);


            MessageImpl.CustomBytesInRequest = customBytes.ToArray();
        }




        #region Overrides of AbstractModbusMessage

        public override int MinimumFrameSize
        {
            get { return _minimumFrameSize; }
        }

        

        protected override void InitializeUnique(byte[] frame)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IModbusRequest

        public void ValidateResponse(IModbusMessage response)
        {
            //
        }


        #endregion
    }
}
