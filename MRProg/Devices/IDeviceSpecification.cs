using System.Collections.Generic;
using MRProg.UserControls;

namespace MRProg.Devices
{
    public interface IDeviceSpecification
    {
        List<ModuleType> ModuleTypes { get; }
        string DeviceName { get; }
        ushort StartAddInfo { get; }
        ushort ModulesCount { get; }
        ushort StartAddVersion { get; }
        ControlType ControlType { get; }
        bool F12 { get; }
    }
}