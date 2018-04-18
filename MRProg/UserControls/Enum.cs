
using System;

namespace MRProg.UserControls
{
    /// <summary>
    /// Состояние в котором находится модуль
    /// </summary>
    public enum ModuleStates
    {
        NO_MODULE,
       /// PRELOADER,
        LOADER,
        OK,
        ERROR_WORK_STRING,
        ERROR_WRITEFILE_TO_MODULE,
        WORK,
        ERROR_READ_MODULE,
        CLEAR,
        WITHOUTTYPE,
        ANOUTHERPOSITION,
        //CURRENTVERSIONLESS,
        //CURRENTVERSIONHIGHER,
        //CHOICEANOTHERFILE
            
    };

    public enum ModuleFileStates
    {
        NOFILE,
        WORK_FILE,
        CURRENTVERSIONLESS,
        CURRENTVERSIONHIGHER,
        CHOICEANOTHERFILE

    };
    /// <summary>
    /// 
    /// </summary>
    public enum ProcessorType
    {
        NONE = 0,
        AT_MEGA_16 = 0x1E9403,
        AT_MEGA_164 = 0x1E940A,
        AT_MEGA_128 = 0x1E9702,
        AT_MEGA_2561 = 0X1E9802,
        AT_MEGA_328_P = 0x1E950F,
        AT_MEGA_32_U4 = 0X1E9587,
        HIGH_DENSITY_DEVICES = 0x414
    }

    public enum ModuleType
    {
        DISCRET_RELAY_16 = 0,   //МСДР 761
        DISCRET_16 = 1,         //МСД 801
        DISCRET_RELAY_8 = 2,    //МСДР 801
        POWER = 3,              //МПР 801
        ANALOG_8_I = 4,         //МСА 801 ТТ
        ANALOG_4_I_4_U = 5,     //МСА 801 ТН
        ANALOG_5_I_3_U = 6,     //МСА 762 5Т3Н
        ANALOG_3_I_5_U = 7,     //МСА 763 3Т5Н
        ANALOG_4_I_5_U = 8,     //МСА 771 4Т5Н
        DISCRET_32 = 9,         //МСД 761 УБР
        DISCRET_24_RELAY_8 = 11,//МСДР 901
        MKI = 14,               //МЦП 801
        MLK = 30,
        KL = 31,
        KL4_3I = 32,
        PT303 = 33,
        EEPROM = 100,
        NONE = 0xFF,
        CLEAR,
        ERROR,
        WITHOUTTYPE
    }

    public enum ControlType
    {
        MLKTYPE=0,
        MRTYPE,
        DEVICETYPE
    }
    [Flags]
    public enum TypeOfMemory
    {
        WORK,
        EEPROM = 0x10,
        BOOT_FLASH = 0x20,
        RALAY_DISCRET = 0x30
    }

    public enum WriteButtonState
    {
        WRITE,
        STOP
    }
}
