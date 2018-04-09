using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRProg.Module
{
    interface IModuleControlInerface
    {
        Task WriteFile();
        void SetFileFolder(string directoryPath, IEnumerable<string> filesName);
        Action<int> NeedRefreshAction { get; set; }
    }
}
