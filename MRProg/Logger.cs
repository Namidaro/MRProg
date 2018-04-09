using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRProg
{
   public static class Logger
    {
        private static FileInfo _logFile;
        private const string LOG_FOLDER_NAME = "BootloaderLogs";
        public static RichTextBox Output;
        private static readonly List<string> Records = new List<string>();
        private static readonly List<string> LogData = new List<string>(100);
        private const int MAX_SIZE_FOLDER = 50;
        public static bool IsLogging { get; set; }

        public static void GetFolderSize()
        {
            try
            {
                var allFiles = Directory.GetFiles(LOG_FOLDER_NAME);
                long size = 0;
                foreach (var file in allFiles)
                {
                    FileInfo a = new FileInfo(file);
                    size += a.Length;
                }
                int sizeMb = (int)(size / 0x100000);
                if (sizeMb > MAX_SIZE_FOLDER)
                {
                    MessageBox.Show(string.Format("Размер папки логов превышает {0} МБ. Рекомендуется очистка.",
                        MAX_SIZE_FOLDER));
                }
            }
            catch (Exception)
            {


            }
        }

        static Logger()
        {

            if (Directory.Exists(LOG_FOLDER_NAME))
            {
                GetFolderSize();
            }
            else
            {
                Directory.CreateDirectory(LOG_FOLDER_NAME);
            }
            var pathString = string.Format("{0}\\{1}.log", LOG_FOLDER_NAME,
                DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));

            Logger._logFile = new FileInfo(pathString);
        }



        public static void Clear()
        {
            Records.Clear();
            Logger.Print();
        }

        public static void Add(string record)
        {
            if (IsLogging)
            {
                if (string.IsNullOrEmpty(record))
                {
                    return;
                }
                var result = string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), record);

                Logger.Records.Add(result);
                Logger.LogData.Add(result);
                Logger.Print();
            }
            else
            {
                return;
            }

        }

        public static void AddToFile(string name, byte[] array)
        {
            var result = name;
            foreach (var value in array)
            {
                result += string.Format("{0:X2}.", value);
            }
            AddToFile(result);
        }

        public static void AddToFile(string name, ushort[] array)
        {
            var result = name;
            foreach (var value in array)
            {
                result += string.Format("{0:X4}.", value);
            }
            AddToFile(result);
        }

        public static void AddToFile(string message)
        {
            if (IsLogging)
            {
                var result = string.Format("{0} {1}", DateTime.Now.ToLongTimeString(), message) + Environment.NewLine;
                Logger.LogData.Add(result);
                if (Logger.LogData.Count > 10000)
                {
                    PrintToFile();
                }
            }

        }

        public static bool PrintToFile()
        {
            try
            {
                if (!Directory.Exists(LOG_FOLDER_NAME))
                {
                    Directory.CreateDirectory(LOG_FOLDER_NAME);
                }

                using (var writter = Logger._logFile.AppendText())
                {
                    foreach (var record in LogData)
                    {
                        writter.WriteLine(record);
                    }
                }
                Logger.LogData.Clear();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка доступа к диску");
                return false;
            }
        }


        private static void Print()
        {
            if (Output == null)
            {
                return;
            }
            Output.Invoke(new Action(() =>
            {
                Logger.Output.Lines = Logger.Records.ToArray();
                Logger.Output.SelectionStart = Logger.Output.TextLength;
                Logger.Output.ScrollToCaret();
            }));
        }

        public static void DeleteLog()
        {
            try
            {
                if (Directory.Exists(LOG_FOLDER_NAME))
                {
                    foreach (var fileName in Directory.GetFiles(LOG_FOLDER_NAME))
                    {

                        if (Path.GetFileName(fileName) == Path.GetFileName(_logFile.FullName))
                        {
                            continue;
                        }

                        if (Path.GetExtension(fileName) == ".log")
                        {
                            File.Delete(fileName);
                        }

                    }

                    Logger.Add("Логи удалёны");
                }
                else
                {
                    Logger.Add("Логи не найдены");
                }

            }
            catch (Exception)
            {
                Logger.Add("Ошибка удаления логов");
            }
        }
    }

}

