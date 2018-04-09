using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus4;
using NModbus4.Data;
using NModbus4.Message;

namespace NModBus4.Message.Function12
{
    class Function12ResponseRead : AbstractModbusMessageWithData<RegisterCollection>, IModbusMessage
    {

        public Function12ResponseRead()
        {
        }

        public Function12ResponseRead(byte functionCode, byte slaveAddress, RegisterCollection data)
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
            byte[] custombyte = new byte[frame.Length - 4];
            Array.ConstrainedCopy(frame, 2, custombyte, 0, custombyte.Length);
            MessageImpl.CustomBytesInResponse = custombyte;
            BytesResult = custombyte;

            ByteInnerCount = frame[6];
            byte[] answer = new byte[ByteInnerCount];
            Array.ConstrainedCopy(custombyte, 5, answer, 0, ByteInnerCount);
            InnerData = new RegisterCollection(answer);
            BytesResult = frame.Skip(3).ToArray();
        }

        public byte[] BytesResult { get; set; }

        public byte ByteInnerCount { get; set; }
        public RegisterCollection InnerData { get; set; }
    }
}
