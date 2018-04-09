using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRProg.Devices;

namespace MRProg
{
    static class Program
    {
        public static Form MainFormReferense { private set; get; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainFormReferense = new MainForm();
            Application.Run(MainFormReferense);
        }
    }
}
