using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Directory(stat)и DirectoryInfo File FileInfo

namespace lab12
{
    internal class STSLog
    {


                   // запись в файл лога инфы о работе самого логгера
        public static void WriteLogInfo()             
        {
            string stsFilName = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");

            using (StreamWriter sw = new StreamWriter(stsFilName, true, System.Text.Encoding.Default)) //true, добавляются в конце|false, перезаписывается
            {
                sw.WriteLine("\n-----------------  STSLog  -----------------\n");
                sw.WriteLine("Имя файла лога: " + Path.GetFileName(stsFilName));
                sw.WriteLine("Полный путь лога: " + stsFilName);
                sw.WriteLine("Время записи лога: " + DateTime.Now);
            }
        }

                    // запись в файл лога инфы из остальных классов
        public static void WriteInLog( string message )
        {//BinaryWriter и BinaryReader.  StreaWriterStreamRider
            string stsFilName = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");

            using (StreamWriter sw = new StreamWriter(stsFilName, true, System.Text.Encoding.Default))
                sw.WriteLine(message);
        }


        //метод чтения
        public static string ReadLog()
        {
            string stsFilName = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");
            StreamReader sr = new StreamReader(stsFilName);
            return sr.ReadToEnd();
        }



                                  //---------------------------------------
        //Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный день/ диапазон времени/по ключевому слову.

                                        // за определенный день 
        public static void FindLogInfoDay( DateTime date )
        {
            string STSFil = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");
            string logInfo = ReadLog();

            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);//Исключить элементы массива, содержащие пустые строки, из результата.

            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }

                                  // по определенному слову
        public static void FindLogInfo( string keyWord )
        {
            string STSFil = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");

            string logInfo = ReadLog();

            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] keyWordArray = keyWord.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                for (int j = 0; j < keyWordArray.Length; j++)
                {
                    if (logInfoArray[i].Contains(keyWordArray[j]))
                    {
                        logInfoArray2[count] = logInfoArray[i];
                        count++;
                    }
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }

                                                // за определенный диапазон 
        public static void FindLogInfoTime( DateTime date1, DateTime date2 )
        {
            string STSFil = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\stslog.txt");
            string logInfo = ReadLog();
            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date1.ToString()) && logInfoArray[i].Contains(date2.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
                Console.WriteLine(logInfoArray2[i]);
        }
        

                                        //Удалите часть информации, оставьте только записи за текущий час.
        public static void DeleteLogInfo()
        {
            string STSFil = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSFillog.txt");
            string logInfo = ReadLog();

            string[] logInfoArray = logInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] logInfoArray2 = new string[logInfoArray.Length];
            int count = 0;

            DateTime date = DateTime.Now;
            date.AddHours(-1);

            for (int i = 0; i < logInfoArray.Length; i++)
            {
                if (logInfoArray[i].Contains(date.ToString()))
                {
                    logInfoArray2[count] = logInfoArray[i];
                    count++;
                }
            }
            string logInfo2 = "";
            for (int i = 0; i < count; i++)
                logInfo2 += logInfoArray2[i] + "\n";
            File.WriteAllText(STSFil, logInfo2);
        }



        public static void SearchLog()
        {
            string STSFil = Path.GetFullPath(@"F:\.Уник\2 курс\ООП С#\Лабы\lab12\STSFillog.txt");
            string logFile = STSLog.ReadLog();                                  /// string с самим логом полностью
            FileInfo logFileInfo = new FileInfo(STSFil);
            DateTime lastHour = DateTime.Now;
            lastHour.AddHours(-1);                                              /// записи за последний час

            if (logFileInfo.LastWriteTime < lastHour)                           /// выводим только записи за час
            {
                string writes = "\n=";                                          /// подстрока, считающая кол-во записей
                int i = 0, j = -1, count = -1;
                while (i != -1)                                                 /// механизм подсчета вхождений подстроки
                {
                    i = logFile.IndexOf(writes, j + 1);
                    j = i;
                    count++;
                }

                Console.WriteLine("Записей за текущий час: " + (count - 1));    /// -1 т.к. в конце есть еще одна "\n="
                Console.WriteLine("Вывод этих записей: ");
                Console.WriteLine(logFile);
            }
        }


    }
}
