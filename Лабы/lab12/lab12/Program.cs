using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
     class Program
    {
        static void Main( string[] args )
        {

            STSLog.WriteLogInfo();
            STSDiskInfo.GetDiskInfo();
            STSFileInfo.GetFileInfo();
            STSDirInfo.GetDirInfo();

            //STSFileManager

            STSFileManager.GetList(@"F:\");
            STSFileManager.CreateDir(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect");

            STSFileManager.CreateFile(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect\STSdirinfo.txt");
            STSFileManager.CopyFile(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect\STSdirinfo.txt", @"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect\Copy_STSdirinfo.txt");

            STSFileManager.CopyFiles(@"F:\.Уник\2 курс\ООП С#\Лабы", @"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSFiles", @"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect");


            STSFileManager.ZipFiles(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect\STSFiles", @"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSInspect\STSFiles.zip", @"F:\.Уник\2 курс\ООП С#\Лабы\lab12\ForZip");

            //Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный день/ диапазон времени/по ключевому слову. Посчитайте количество записей в нем.
            //Удалите часть информации, оставьте только записи за текущий час.

            STSLog.ReadLog();
            STSLog.SearchLog();
            STSLog.DeleteLogInfo();

            STSLog.FindLogInfo("STSDiskInfo");
           //STSLog.FindLogInfoDay(new DateTime(2022, 12, 10, 22, 15, 05));
            STSLog.FindLogInfoTime(new DateTime(2022, 12, 21, 11, 50, 59), new DateTime(2022, 12, 22, 10, 37, 10));
        }


    }
}
