using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace lab12
{
    internal class STSDirInfo
    {
        //a. Количестве файлов
        //b. Время создания
        //c. Количестве поддиректориев d. Список родительских директориев
        //e. Продемонстрируйте работу класса

        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12");

            string DirInfoLog = "";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.Exists)
                DirInfoLog = "\n----------  STSDirInfo ------------\n" +
                             "\nКоличество файлов:        " + dirInfo.GetFiles().Length +
                             "\nВремя создания:           " + dirInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + dirInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + dirInfo.Parent.Name;

            STSLog.WriteInLog(DirInfoLog);


        }

    }
}
