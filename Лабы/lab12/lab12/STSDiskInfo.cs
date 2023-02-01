using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace lab12
{
    internal class STSDiskInfo
    {
        public static void GetDiskInfo()
        {
            //для вывода информации о
            //a.свободном месте на диске
            //b.Файловой системе
            //c.Для каждого существующего диска - имя, объем, доступный объем, метка тома.
            //d.Продемонстрируйте работу класса
            string classLogInfo = "\n--------- STSDiskInfo ---------\n";
            string DiskInfo = "";/// сюда будет записываться вся информация из метода GetDrives()

            DriveInfo[] drives = DriveInfo.GetDrives();    ///GetDrives() - получение массива

            DiskInfo = "\nИмя диска:                " + drives[0].Name +
                       "\nФайловая система:         " + drives[0].DriveFormat +
                       "\nДоступное место:          " + drives[0].AvailableFreeSpace / 1024 / 1024 + " MB" +
                       "\nРазмер диска:             " + drives[0].TotalSize / 1024 / 1024 + " MB" +
                       "\nМетка тома диска:         " + drives[0].VolumeLabel + "\n" +

                       "\nИмя диска:                " + drives[1].Name +
                       "\nФайловая система:         " + drives[1].DriveFormat +
                       "\nДоступное место:          " + drives[1].AvailableFreeSpace / 1024 / 1024 + " MB" +
                       "\nРазмер диска:             " + drives[1].TotalSize / 1024 / 1024 + " MB" +
                       "\nМетка тома диска:         " + drives[1].VolumeLabel;

            string DiskInfoLog = classLogInfo + DiskInfo;
            STSLog.WriteInLog(DiskInfoLog);
        }
    }
}
