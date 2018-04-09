using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRProg
{
    public class Common
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static double ConvertVersionFromString(string[] version)
        {
            if (version != null)
            {
                try
                {
                    var versionInString =
                        string.Concat(version[0].Replace("T", string.Empty), CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator,
                            version[1].Replace("T", string.Empty));

                    return Convert.ToDouble(versionInString);
                }
                catch
                {
                    return 0;
                }

            }
            return 0;
        }
        /// <summary>
        /// Преобразует Int в массив ushort
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ushort[] IntToUshorts(int value)
        {
            return new[] { (ushort)value, (ushort)(value >> 16) };

        }
        /// <summary>
        /// Преобразует строковое значение версии в численное
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        public static double VersionConverter(string ver)
        {
            double versionFloat = 0;
            ver = ver.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace("H", string.Empty).Replace("S", string.Empty).Replace("T", string.Empty);

            versionFloat = Convert.ToDouble(ver);
            return versionFloat;
        }

        /// <summary>
        /// Приводит число к 2-м значащим цифрам
        /// </summary>
        /// <param name="number">Исходное значение</param>
        /// <returns>Приведённое значение</returns>
        public static double NumberToThreeChar(double number)
        {

            if (Math.Abs(number) < 10)
            {
                return Math.Round(number, 1);
            }
            return Math.Round(number, 0);
        }

        /// <summary>
        /// Приводит число к 4-м значащим цифрам
        /// </summary>
        /// <param name="number">Исходное значение</param>
        /// <returns>Приведённое значение</returns>
        public static double NumberToFourChar(double number)
        {

            if (Math.Abs(number) < 10)
            {
                return Math.Round(number, 3);
            }
            if (Math.Abs(number) < 100)
            {
                return Math.Round(number, 2);
            }
            if (Math.Abs(number) < 1000)
            {
                return Math.Round(number, 1);
            }
            return Math.Round(number, 0);
        }

        /// <summary>
        /// Извлекает массив bool из заданаго диапазона
        /// </summary>
        /// <param name="bitArray">Исходный массив</param>
        /// <param name="startIndex">Индекс начала</param>
        /// <param name="endIndex">Индекс конца</param>
        /// <returns></returns>
        public static bool[] GetBitsArray(BitArray bitArray, int startIndex, int endIndex)
        {
            var lenght = endIndex - startIndex + 1;
            var bits = new bool[lenght];
            for (int i = 0; i < lenght; i++)
            {
                bits[i] = bitArray[i + startIndex];
            }
            return bits;
        }

        /// <summary>
        /// Извлекает массив bool из заданаго диапазона
        /// </summary>
        /// <param name="ushortArray"></param>
        /// <param name="startIndex">Индекс начала</param>
        /// <param name="endIndex">Индекс конца</param>
        /// <returns></returns>
        public static bool[] GetBitsArray(ushort[] ushortArray, int startIndex, int endIndex)
        {
            var bitArray = new BitArray(Common.TOBYTES(ushortArray, false));
            var lenght = endIndex - startIndex + 1;
            var bits = new bool[lenght];
            for (int i = 0; i < lenght; i++)
            {
                bits[i] = bitArray[i + startIndex];
            }
            return bits;
        }

        /// <summary>
        /// Возвращает младший байт слова
        /// </summary>
        /// <param name="v">Слово.</param>
        /// <returns>Мл.байт</returns>
        public static byte LOBYTE(int v)
        {
            return (byte)(v & 0xff);
        }
        /// <summary>
        /// Возвращает старший байт слова.
        /// </summary>
        /// <param name="v">Слово.</param>
        /// <returns>Ст.байт</returns>
        public static byte HIBYTE(int v)
        {
            return (byte)(v >> 8);
        }
        /// <summary>
        /// Конвертирует 2 байта в слово
        /// </summary>
        /// <param name="high">Ст.байт</param>
        /// <param name="low">Мл.байт</param>
        /// <returns>Слово.</returns>
        public static ushort TOWORD(byte high, byte low)
        {
            UInt16 ret = (UInt16)high;
            return (ushort)((ushort)(ret << 8) + (ushort)low);
        }
        /// <summary>
        /// Конвертирует 2 слова 16-разрядных в 32-разрядное
        /// </summary>
        /// <param name="first">Старший байт старшего слова</param>
        /// <param name="second">Младший байт старшего слова</param>
        /// <param name="third">Старший байт младшего слова</param>
        /// <param name="fourth">Младший байт младшего слова</param>
        /// <returns>32-разрядное слово</returns>
        public static UInt32 ToWord32(byte first, byte second, byte third, byte fourth)
        {
            return (UInt32)((first << 24) + (second << 16) + (third << 8) + fourth);
        }
        /// <summary>
        /// Конвертирует 2 ushort в long
        /// </summary>
        /// <param name="Word1">1й ushort</param>
        /// <param name="Word2">2й ushort</param>
        /// <returns>Int</returns>
        public static int UshortUshortToInt(ushort Word1, ushort Word2)
        {
            string d1 = Word1.ToString("X2");
            string d2 = Word2.ToString("X2");
            if (d2.Length < 4)
                do
                {
                    d2 = "0" + d2;
                } while (d2.Length < 4);

            return System.Int32.Parse(d1 + d2, System.Globalization.NumberStyles.HexNumber);
        }
        //0000001000000101
        /// <summary>
        /// Конвертирует массив байт в массив слов. 
        /// </summary>
        /// <param name="bytes">Массив байт</param>
        /// <param name="bDirect"> Порядок байт.false - реверс,true - обычный</param>
        /// <returns></returns>
        public static ushort[] TOWORDS(byte[] bytes, bool bDirect)
        {

            if (0 != (bytes.Length % 2))
            {
                bytes = new byte[bytes.Length + 1];
            }
            ushort[] ret = new ushort[bytes.Length / 2];
            int j = 0;
            for (int i = 0; i < bytes.Length; i += 2)
            {
                if (bDirect)
                {
                    ret[j++] = TOWORD(bytes[i], bytes[i + 1]);
                }
                else
                {
                    ret[j++] = TOWORD(bytes[i + 1], bytes[i]);
                }

            }
            return ret;
        }

        /// <summary>
        /// Меняет местами ст. и мл. байт слова.
        /// </summary>
        /// <param name="val">Слово.</param>
        /// <returns>Реверснутое слово.</returns>
        public static ushort SwapByte(ushort val)
        {
            return TOWORD(LOBYTE(val), HIBYTE(val));
        }

        /// <summary>
        /// Меняет попарно местами элементы массива. 
        /// </summary>
        /// <param name="array">Массив.</param>
        /// <returns>Реверснутый массив.</returns>
        public static void SwapArrayItems<T>(ref T[] array)
        {
            T temp;
            try
            {
                for (int i = 0; i < array.Length; i += 2)
                {
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }


        }
        /// <summary>
        /// Представляет байт в виде двоичного числа вида '01010101'
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="reverse">Инвертировать порядок</param>
        /// <returns></returns>
        public static string ByteToMask(byte value, bool reverse)
        {
            var chars = Convert.ToString(value, 2).PadLeft(8, '0').ToCharArray();
            if (reverse)
            {
                Array.Reverse(chars);
            }

            return new string(chars);
        }

        /// <summary>
        /// Конвертирует BitArray в строку вида '010001'
        /// </summary>
        /// <param name="bits">Битовое представление</param>
        /// <returns>Строковое представление</returns>
        public static string BitsToString(BitArray bits)
        {
            string ret = "";
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                {
                    ret += "1";
                }
                else
                {
                    ret += "0";
                }
            }
            return ret;
        }

        /// <summary>
        /// Конвертирует строку вида '010001' в BitArray
        /// </summary>
        /// <param name="str">Строковое представление</param>
        /// <returns>Битовое представление</returns>
        public static BitArray StringToBits(string str)
        {
            bool[] bMas = new bool[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if ('1' == str[i])
                {
                    bMas[i] = true;
                }
                else if ('0' == str[i])
                {
                    bMas[i] = false;
                }
                else
                {
                    throw new ApplicationException("Строку " + str + " невозможно сконвертировать в биты. Символ " + bMas[i].ToString());
                }
            }

            return new BitArray(bMas);
        }

        /// <summary>
        /// Конвертирует массив слов в массив байт
        /// </summary>
        /// <param name="words"> Массив слов.</param>
        /// <param name="bDirect">Порядок байт. true - обычный, false - ст.байт меняем местом с мл.байтом.</param>
        /// <returns>Массив байт.</returns>
        public static byte[] TOBYTES(ushort[] words, bool bDirect)
        {
            byte[] buffer = new byte[words.Length * 2];
            for (int i = 0, j = 0; i < words.Length; i++)
            {
                if (bDirect)
                {
                    buffer[j++] = Common.HIBYTE(words[i]);
                    buffer[j++] = Common.LOBYTE(words[i]);

                }
                else
                {
                    buffer[j++] = Common.LOBYTE(words[i]);
                    buffer[j++] = Common.HIBYTE(words[i]);
                }
            }
            return buffer;
        }

        /// <summary>
        /// Конвертирует слово в массив байт
        /// </summary>
        /// <param name="word">слово</param>
        /// <returns>массив байт</returns>
        public static byte[] TOBYTE(ushort word /*, bool bDirect*/)
        {
            byte[] buffer = new byte[2];
            buffer[0] = Common.HIBYTE(word);
            buffer[1] = Common.LOBYTE(word);
            return buffer;
        }

        /// <summary>
        /// Конвертирует коллекцию битов в слово
        /// </summary>
        /// <param name="bits">Колекция битов</param>
        /// <returns>Слово</returns>
        public static ushort BitsToUshort(BitArray bits)
        {
            ushort temp = 0;
            for (int i = 0; i < bits.Count; i++)
            {
                temp += bits[i] ? (ushort)(Math.Pow(2, i)) : (ushort)0;
            }
            return temp;
        }


        public static string VersionLiteral(string Ver)
        {
            if (Ver.Contains("S"))
                return "S";
            else if (Ver.Contains("H"))
                return "H";
            else return string.Empty;
        }

        /// <summary>
        /// Устанавливает бит в слове
        /// </summary>
        /// <param name="value">Слово</param>
        /// <param name="index">Номер бита в слове</param>
        /// <param name="bit">Значение бита</param>
        /// <returns>Слово после установки бита</returns>
        public static ushort SetBit(ushort value, int index, bool bit)
        {
            ushort ret = value;
            ushort temp = (ushort)(Math.Pow(2, index));
            ret = bit ? (ushort)(value |= temp) : (ushort)(value & ~temp);
            return ret;
        }

        /// <summary>
        /// Возвращает значения бита в слове
        /// </summary>
        /// <param name="value">Слово</param>
        /// <param name="index">Номер бита</param>
        /// <returns>Значение бита</returns>
        public static bool GetBit(ushort value, int index)
        {
            return 0 != (value & (ushort)(Math.Pow(2, index)));
        }

        public static bool GetBit(int value, int index)
        {
            return 0 != (value & (int)(Math.Pow(2, index)));
        }



        /// <summary>
        /// Возвращает значения битов в слове маской 
        /// ВНИМАНИЕ : если нужно число, а не маска, нужно сдвинуть рез-тат на n бит, где n = номер начального бита.
        /// Пример : int number = GetBits(value,8,9) >> 8
        /// </summary>
        /// <param name="value">Слово</param>
        /// <param name="indexes">Номера битов</param>
        /// <returns>Выходное слово - содержит значения битов, передаваемых в indexes</returns>
        public static ushort GetBits(ushort value, params int[] indexes)
        {
            ushort mask = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                mask |= (ushort)(1 << indexes[i]);
            }
            return (ushort)(value & mask);
        }

        /// <summary>
        /// Устанавливает биты в слове по маске. Внимание -номера битов должны идти по возрастанию, без пропусков.
        /// </summary>
        /// <param name="value">Слово</param>
        /// <param name="bits">Битовая маска</param>
        /// <param name="indexes">Номера устанавливаемых битов</param>
        /// <returns>Входное слово после выставления битов</returns>
        public static ushort SetBits(ushort value, ushort bits, params int[] indexes)
        {
            ushort mask = Common.GetBits(ushort.MaxValue, indexes);
            value = (ushort)(value & ~mask);
            return (ushort)(value | (bits << indexes[0]));
        }
        /// <summary>
        /// Преобразование массива байт в массив ASCII символов
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static char[] GetChars(byte[] byteArray)
        {
            System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
            return ASCII.GetChars(byteArray);
        }

        public static string CharsToString(char[] charArray)
        {
            string res = string.Empty;
            for (int i = 0; i < charArray.Length; i++)
            {
                res += charArray[i];
            }
            int f = res.IndexOf("\0");

            if (f > -1)
            {
                string resTmp = string.Empty;
                for (int i = 0; i < f; i++)
                {
                    resTmp += res[i];
                }
                res = resTmp;
            }

            return res;
        }
        /// <summary>
        /// Обработчик события, вызывающий подписанный метод
        /// </summary>
        /// <param name="handler">Метод, подписанный на событие</param>
        /// <returns></returns>
        public static Action RaiseAction(Action handler)
        {
            return () =>
            {
                if (handler != null)
                {
                    handler.Invoke();
                }
            };
        }
        /// <summary>
        /// Обобщенный обработчик события, вызывающий подписанный метод
        /// </summary>
        /// <typeparam name="T">Тип параметра</typeparam>
        /// <param name="handler">Метод, подписанный на событие</param>
        /// <returns></returns>
        public static Action<T> RaiseAction<T>(Action<T> handler)
        {
            return (o) =>
            {
                if (handler != null)
                {
                    handler.Invoke(o);
                }
            };
        }

        /// <summary>
        /// Обработчик события, вызывающий подписанный метод
        /// </summary>
        /// <param name="handler">Метод, подписанный на событие</param>
        public static void RaiseAction1<T>(Action<T> handler)
        {
            if (handler != null)
            {
                handler.Invoke(default(T));
            }
        }
    }
}
