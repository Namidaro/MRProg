using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus4.Data;
using NModbus4.Message;
using NModbus4.Utility;
using NModBus4.Extensions;

namespace NModBus4.Message
{
    public class Function12RequestWrite : AbstractModbusMessage, IModbusRequest
    {

        private int _minimumFrameSize;



        public Function12RequestWrite(byte functionCode, ushort startAddress, byte devicenumber, byte moduleNumber, ushort[] writeArray) : base(devicenumber, functionCode)
        {
            List<byte> customBytes = new List<byte>();
            var res = 0xF0| moduleNumber;
            customBytes.Add(Convert.ToByte(res));

                WriteMultipleRegistersRequest innerRequest =
                    new WriteMultipleRegistersRequest(devicenumber, startAddress, new RegisterCollection(writeArray));
            InnerReauest = innerRequest;
            byte[] crcforinnerRequest = ModbusUtility.CalculateCrc(innerRequest.MessageFrame);
                customBytes.AddRange(innerRequest.MessageFrame);
            customBytes.AddRange(crcforinnerRequest);
          

            MessageImpl.CustomBytesInRequest = customBytes.ToArray();
        }


        public WriteMultipleRegistersRequest InnerReauest { get; set; }

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
            
        }

        #endregion
    }
}
