using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRProg.UserControls;

namespace MRProg.Devices
{
    class MR761OBRDeviceSpecification:IDeviceSpecification
    {
        public List<ModuleType> ModuleTypes
        {
            get
            {
                return new List<ModuleType>
                {
                    ModuleType.MKI,
                    ModuleType.POWER,
                    ModuleType.DISCRET_RELAY_8,
                    ModuleType.DISCRET_16,
                    ModuleType.DISCRET_RELAY_16,
                    ModuleType.DISCRET_32,
                };
            }
        }

        public string DeviceName
        {
            get { return "MR761OBR"; }
        }


        public ushort StartAddInfo
        {
            get { return 0x300; }
        }

        public ushort ModulesCount
        {
            get { return 6; }
        }

        public ushort StartAddVersion
        {
            get { return 0x500; }
        }


        public bool F12
        {
            get { return true; }
        }
        public ControlType ControlType
        {
            get { return ControlType.MRTYPE; }
        }
    }
}
