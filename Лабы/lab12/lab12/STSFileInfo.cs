using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab12
{
    internal class STSFileInfo
    {
        //a. Полный путь
        //b. Размер, расширение, имя
        //c. Дата создания, изменения
        //d. Продемонстрируйте работу класса

        public static void GetFileInfo() 
        {
            string classLogInfo = "\n---------  STSFileInfo  -----------\n";
            string path = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");

            string fileInfoLog = "";

            FileInfo fileInfo = new FileInfo(path); 

            if (fileInfo.Exists) 
            {
                fileInfoLog = classLogInfo +
                              "\nПолный путь: " + path +
                              "\nИмя файла: " + fileInfo.Name +
                              "\nРазмер файла: " + fileInfo.Length + " KB" +
                              "\nРасширение: " + fileInfo.Extension +
                              "\nДата изменения: " + fileInfo.LastWriteTime;

                STSLog.WriteInLog(fileInfoLog); 

            }

        }
    }
}
