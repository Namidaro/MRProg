using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus4;
using NModbus4.Data;
using NModbus4.Message;
using NModbus4.Unme.Common;

namespace NModBus4.Message.Function12
{
   public class Function12ResponseWrite  : AbstractModbusMessageWithData<RegisterCollection>, IModbusMessage
    {
        public Function12ResponseWrite()
        {

        }

        public Function12ResponseWrite(byte functionCode, byte slaveAddress, RegisterCollection data)
            : base(slaveAddress, functionCode)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ByteCount = data.ByteCount;
            Data = data;
        }

        public byte ByteCount
        {
            get { return MessageImpl.ByteCount.Value; }
            set { MessageImpl.ByteCount = value; }
        }

        public override int MinimumFrameSize
        {
            get { return 3; }
        }

        public override string ToString()
        {
            string msg = $"Read {Data.Count} {(FunctionCode == Modbus.ReadHoldingRegisters ? "holding" : "input")} registers.";
            return msg;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            byte[] custombyte=new byte[frame.Length-4];
            Array.ConstrainedCopy(frame, 2, custombyte, 0, custombyte.Length);
            MessageImpl.CustomBytesInResponse = custombyte;
            BytesResult = custombyte;

        }

        
        public byte[] BytesResult { get; set; }
    }
}
