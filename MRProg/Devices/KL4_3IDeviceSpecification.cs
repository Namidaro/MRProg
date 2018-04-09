using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRProg.UserControls;

namespace MRProg.Devices
{
   public class KL4_3IDeviceSpecification: IDeviceSpecification
    {
        public List<ModuleType> ModuleTypes
        {
            get
            {
                return new List<ModuleType>
                {
                    ModuleType.KL4_3I
                };
            }
        }

        public string DeviceName
        {
            get { return "KL4_3I"; }
        }


        public ushort StartAddInfo
        {
            get { return 0x1F00; }
        }

        public ushort ModulesCount
        {
            get { return 1; }
        }
        public ushort StartAddVersion
        {
            get { return 0x500; }
        }


        public bool F12
        {
            get { return false; }
        }
        public ControlType ControlType
        {
            get { return ControlType.MLKTYPE; }
        }
    }
}
