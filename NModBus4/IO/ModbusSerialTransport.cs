using System;
using System.Diagnostics;
using System.IO;
using NModbus4.Message;
using NModBus4.Message;
using NModBus4.Message.Function12;

namespace NModbus4.IO
{
    /// <summary>
    ///     Transport for Serial protocols.
    ///     Refined Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    public abstract class ModbusSerialTransport : ModbusTransport
    {
        private bool _checkFrame = true;

        internal ModbusSerialTransport(IStreamResource streamResource)
            : base(streamResource)
        {
            Debug.Assert(streamResource != null, "Argument streamResource cannot be null.");
        }

        /// <summary>
        ///     Gets or sets a value indicating whether LRC/CRC frame checking is performed on messages.
        /// </summary>
        public bool CheckFrame
        {
            get { return _checkFrame; }
            set { _checkFrame = value; }
        }

        internal void DiscardInBuffer()
        {
            StreamResource.DiscardInBuffer();
        }

        internal override void Write(IModbusMessage message)
        {
            DiscardInBuffer();

            byte[] frame = BuildMessageFrame(message);
            Debug.WriteLine($"TX: {string.Join(", ", frame)}");
            StreamResource.Write(frame, 0, frame.Length);
        }

        internal override IModbusMessage CreateResponse<T>(byte[] frame)
        {
            IModbusMessage response = base.CreateResponse<T>(frame);

            // compare checksum
            if (CheckFrame && !ChecksumsMatch(response, frame))
            {
                string msg = $"Checksums failed to match {string.Join(", ", response.MessageFrame)} != {string.Join(", ", frame)}";
                Debug.WriteLine(msg);
                throw new IOException(msg);
            }

            return response;
        }

        internal abstract bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame);

        internal override void OnValidateResponse(IModbusMessage request, IModbusMessage response)
        {
            if (request.FunctionCode == Modbus.Function12)
            {
                if (/*request.MessageFrame[4] == Modbus.WriteMultipleRegisters*/request is Function12RequestWrite)
                {
                    byte[] innerResponse = new byte[8];
                    Array.ConstrainedCopy(response.MessageFrame, 4, innerResponse, 0, innerResponse.Length);
                    CreateResponse<WriteMultipleRegistersResponse>(innerResponse);
                }
                if (/*request.MessageFrame[4] == Modbus.ReadHoldingRegisters*/ request is Function12RequestRead)
                {
                    

                    int countinnerbyte = response.MessageFrame[6];
                    byte[] innerResponse = new byte[countinnerbyte+5];
                    Array.ConstrainedCopy(response.MessageFrame, 4, innerResponse, 0, innerResponse.Length);
                    CreateResponse<ReadHoldingInputRegistersResponse>(innerResponse);
                }


            }
        }
    }
}
