using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRProg.Connection.Enum
{

    public enum BaudRates
    {
        BR1200 = 1200,
        BR2400 = 2400,
        BR4800 = 4800,
        BR9600 = 9600,
        BR19200 = 19200,
        BR38400 = 38400,
        BR57600 = 57600,
        BR115200 = 115200,
        BR230400 = 230400,
        BR460800 = 460800,
        BR921600 = 921600
    };

    public enum ModbusFunctions : byte
    {
        READ_WORDS = 0x04,
        WRITE_WORDS = 0x10
    }


    [Flags]
    public enum Func
    {
        WRITE = 0x01,
        READ = 0x02
    }
}
