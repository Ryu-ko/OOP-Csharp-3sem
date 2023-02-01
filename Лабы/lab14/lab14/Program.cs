using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    class Program
    {           
        
       //--- static EventWaitHandle evenReady;   // предствялет поток синхронизированного события
      //----  static EventWaitHandle oddReady;

        static void Main( string[] args )
        {
            First();
            Second();
            Third();
            Fourth();
            Fifth();

        }


        private static void First()
        {
            var allProcesses = Process.GetProcesses();
            Console.WriteLine("Информация о процессах:");
            Console.Write("{0,-10}", "ID:");
            Console.Write("{0,-70}", "Process Name:");
            Console.Write("{0,-20}", "Priority:");
            Console.Write("{0,-10}", "Memory:\n");

            foreach (Process process in allProcesses)
            {
                Console.Write("{0,-10}", $"{process.Id}");
                Console.Write("{0,-70}", $"{process.ProcessName}");
                Console.Write("{0,-20}", $"{process.BasePriority}");
                Console.Write("{0,-10}", $"{process.WorkingSet64}");

                Console.WriteLine();
            }
        }

        private static void Second()
        {
                // ------- 2. текущий домен с процессами ----------

            AppDomain domain = AppDomain.CurrentDomain;  // // возвращает текущий домен приложения для текущего объекта Thread, AppDomain - домен приложения, ктр является изолированной средой, в которой приложение

            Console.WriteLine("\n\nТекущий домен:         " + domain.FriendlyName);
            Console.WriteLine("Базовый каталог:       " + domain.BaseDirectory);
            Console.WriteLine("Детали конфигурации:   " + domain.SetupInformation);
            Console.WriteLine("Все сборки в домене:\n");

            foreach (Assembly ass in domain.GetAssemblies())
                Console.WriteLine(ass.GetName().Name);

            //////1
            //////Создайте новый домен.
            //AppDomain newDomain = AppDomain.CreateDomain("New domain");
            ///////Загрузите туда сборку.
            //newDomain.Load(new AssemblyName("lab14"));
            //Console.WriteLine("Name of the new domain: " + newDomain.FriendlyName + "\nAssamblies of new domain:");
            //foreach (Assembly a in newDomain.GetAssemblies())
            //{
            //    Console.WriteLine(a.GetName().Name);
            //}
            ///////Выгрузите домен.
            //AppDomain.Unload(newDomain);
            //Console.WriteLine("\nPress any key\n");
            //Console.ReadKey();

            ////2
            //AppDomain newDomain = AppDomain.CreateDomain("New Domain"); // создание нового домена
            //newDomain.Load(Assembly.GetExecutingAssembly().FullName);   // загрузка сборки
            //AppDomain.Unload(newDomain);                                // выгрузка домена + всех содержащихся в нём сборок

            ////3
            ////Создайте новый домен.Загрузите туда сборку.Выгрузите домен.
            //AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            //newDomain.Load(Assembly.GetExecutingAssembly().GetName());
            //AppDomain.Unload(newDomain);


        }

        private static void Third()
        {
            // ------- 3. записи в файл и на консоль простых чисел от 1 до n ----------

            Thread NumbersThread = new Thread(new ParameterizedThreadStart(WriteNums));   // создаем новый поток
            
            Console.Write("\nЗадайте число: "); 
            int numb = Convert.ToInt32(Console.ReadLine());
            
            NumbersThread.Start(numb);  // запускаем его

            Thread.Sleep(2000);   // приостанавливает выполнение потока, в котором он был вызван

            Console.WriteLine("--------------------");
            Console.WriteLine("Приоритет:   " + NumbersThread.Priority);
            Thread.Sleep(100);
            Console.WriteLine("Имя потока:  " + NumbersThread.Name);
            Thread.Sleep(100);
            Console.WriteLine("ID потока:   " + NumbersThread.ManagedThreadId);
            Console.WriteLine("---------------------");

            Thread.Sleep(1000);

            Thread.Sleep(2000);  // приостанавливает выполнение потока, в котором он был вызван

            void WriteNums( object number )
            {
                int num = (int)number;

                using (StreamWriter sw = new StreamWriter(@"F:\.Уник\2 курс\ООП С#\Лабы\lab14\lab14\numbers.txt", false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < num; i++)
                    {
                        sw.WriteLine(i);

                        Console.WriteLine(i);

                        Thread.Sleep(500);
                    }
                }
            }

/*------------------
            bool countOdd = true; // показывает начинаем работу или нет
            bool countEven = true;

            if (countOdd && countEven)
            {
                evenReady = new AutoResetEvent(false); // объект-событие - позволяет при получении сигнала переключить данный объект-событие из сигнального в несигнальное состояние. false обозначает что объект сразу находится в несигнальном состоянии
                oddReady = new AutoResetEvent(true); // Must be true for the starting thread.
            }
            else
            {
                evenReady = new ManualResetEvent(true);
                oddReady = new ManualResetEvent(true);
            }

            Thread countThreadOdd = new Thread(oddThread);
            Thread countThreadEven = new Thread(evenThread);

            //Thread Start
            if (countOdd)
                countThreadOdd.Start(numb);

            if (countEven)
                countThreadEven.Start(numb);

            //main thread will untill below thread is in exection mode

            if (countOdd)
                countThreadOdd.Join();

            if (countEven)
                countThreadEven.Join();

            Console.WriteLine("Done");

            */
        }


        private static void Fourth()
        {

            Console.WriteLine("\nПотоки чётных и нечётных чисел:");
                  // четн
            Thread evenThread = new Thread(Methods.EvenNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;
            evenThread.Start();
            evenThread.Join();  // сначала чётные                 
            // блокирует выполнение вызвавшего его потока до тех пор, пока не завершится поток, для которого был вызван данный метод 
            Console.WriteLine();

                 // нечетн
            Thread oddThread = new Thread(Methods.OddNumbers);
            oddThread.Priority = ThreadPriority.BelowNormal;
            oddThread.Start();
            oddThread.Join();   //нечётн
          
            Console.WriteLine("\n");


        }


        private static void Fifth()
        {
            // System.Threading.Timer класс позволяет запускать определенные действия по истечению некоторого периода времени:
            TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);// устанавливаем метод обратного вызова


            Timer timer = new Timer(timerCallback, null, 500, 1000);       /* null - параметр, которого нет, 500 - время, через которое запустится процесс с таймером, 
                                                                            * 1000 - периодичность таймера (интервал между вызовами метода делегата). */
            Thread.Sleep(5000);               
            // 500 - ждем и не закрываем поток
            timer.Change(Timeout.Infinite, 2000);                           // уничтожение таймера

            void WhatTimeIsIt( object obj )
            {
                Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            }

        }

/*
        // 4-2

        public static void oddThread( object num )
        {
            string Path = @"F:\.Уник\2 курс\ООП С#\Лабы\lab14\lab14\EvenAndOddNumbers.txt";

            for (int i = 1; i < (int)num; i += 2)
            {
                evenReady.WaitOne();    // блокируем текущий поток (evenReady), пока текущий WaitHandle получает сигнал (потому что состояние события находится в несигнальном состоянии)
                Console.WriteLine(i);
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(i);
                }
                oddReady.Set();     // позволяет продолжиться одному или нескольким ожидаемым потокам (сигнализируем что oddReady в сигнальном состоянии)
            }
        }

        public static void evenThread( object num )
        {
            string Path = @"F:\.Уник\2 курс\ООП С#\Лабы\lab14\lab14\EvenAndOddNumbers.txt";

            for (int i = 0; i < (int)num; i += 2)
            {
                oddReady.WaitOne();
                Console.WriteLine(i);
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(i);
                }
                evenReady.Set();
            }
        }
*/

    }


    class Methods
    {
        public static void OddNumbers()
        {
            using (StreamWriter sw = new StreamWriter(@"F:\.Уник\2 курс\ООП С#\Лабы\lab14\lab14\Нечетн.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i <= 20; i++)
                {
                    if (i % 2 != 0)
                    {

                        sw.WriteLine(i);
                        Console.Write($"{i} ");
                        Thread.Sleep(120);

                    }
                }
            }
        }

        public static void EvenNumbers()
        {
            using (StreamWriter sw = new StreamWriter(@"F:\.Уник\2 курс\ООП С#\Лабы\lab14\lab14\Четные.txt", true, System.Text.Encoding.Default))
            {
                for (int i = 0; i <= 20; i++)
                {
                    if (i % 2 == 0)
                    {

                        sw.WriteLine(i);
                        Console.Write($"{i} ");
                        Thread.Sleep(120);

                    }
                }
            }
        }





    }
}