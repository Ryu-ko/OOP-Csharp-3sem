using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;

namespace lab15
{
    class Program
    {
        static void Main( string[] args )
        {
            First();
            Console.WriteLine();

            Second();
            Console.WriteLine();

            Third();
            Console.WriteLine();


            Forth();
            Console.WriteLine();

            Fifth();
            Console.WriteLine();

            Sixth();
            Console.WriteLine();

            
            Sevn();
            //Seventh(); /////////////
            Console.WriteLine();

            Eighth();
            Console.WriteLine();

            Console.ReadKey();
        }

        static void First()
        {
            for (int i = 0; i < 5; i++)
            {
                Stopwatch sw = new Stopwatch(); // точное измерение затраченного времени


                sw.Start();
                Task task = new Task(() => MulByVector(10000)); //умножение вектора размера 100000 на число,

                task.Start();
                Console.WriteLine($"ID: {task.Id}, статус: {task.Status}");
                task.Wait(); //останавливают основной поток до завершения задачи
                Console.WriteLine($"ID: {task.Id}, статус: {task.Status}");
                sw.Stop();

                Console.WriteLine($"Производительность: {sw.ElapsedMilliseconds}ms");//св-во Получает общее затраченное время в миллисекундах, измеренное текущим экземпляром.
                Console.WriteLine();
            }
        }

        static void MulByVector( int k, object ob = null )
        {
            Random random = new Random();
            List<int> vector = new List<int>();
            for (int i = 0; i < k; i++)
            {
                vector.Add(random.Next(1, 10));
            }
            vector = vector.Select(x => x * 10).ToList();
        }

        static void Second()
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();//токен отмены

            Task task = Task.Run(() => MulByVector(1000, cancellation), cancellation.Token);
            try
            { 
                Console.WriteLine("Задача отменена");
                cancellation.Cancel();
                task.Wait();
               

            }
            catch (Exception)
            {
                if (task.IsCanceled)
                    Console.WriteLine("Отмена");
            }
        }

        static void Third()
        {
            Task<int> first = new Task<int>(() => new Random().Next(1, 9) * 100);
            Task<int> second = new Task<int>(() => new Random().Next(0, 9) * 10);
            Task<int> third = new Task<int>(() => new Random().Next(0, 9));

            first.Start();
            second.Start();
            third.Start();

            first.Wait();
            second.Wait();
            third.Wait();

            Task<int> number = new Task<int>(() => first.Result + second.Result + third.Result);//описывает задачу, возвращающую значение типа < >
            number.Start();
            Console.WriteLine($"3. Number: {number.Result}");
        }


        static void Forth() // continuation task позволяют определить задачи, которые выполняются после завершения других задач
        {
            Task<int> task4 = new Task<int>(() => 100 + 10 + 1);
            Task show = task4.ContinueWith(sum => Console.WriteLine($"4.Sum = {sum.Result}"));
            
            task4.Start();
            show.Wait();

            Task<double> sqrt = new Task<double>(() => Math.Sqrt(49));

            TaskAwaiter<double> awaiter = sqrt.GetAwaiter(); //Предоставляет объект, который ожидает завершения асинхронной задачи.
                                               //// получаем объект продолжения 
            awaiter.OnCompleted(() => Console.WriteLine($"4. Result is: {sqrt.Result}"));
            sqrt.Start();
            sqrt.Wait();

            awaiter.GetResult();//делегат, содержащий код продолженияПо умолчанию – в разных потоках
            Thread.Sleep(10);
        }


        static void Factorial( int num )
        {
            int result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;

            Console.WriteLine($"Факториал числа {num} равен {result}");
        }

        static void Fifth()
        {
            int[] arr1 = new int[1000000];
            int[] arr2 = new int[1000000];

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
                //-----For
            Parallel.For(0, arr1.Length, t => arr1[t] = t); //позволяет распараллеливать циклы и последовательность блоков кода
                     //указание начального и конечного значения счётчика  и тела цикла в виде объекта делегата
            
            stopwatch2.Stop();
            Console.WriteLine($"Parallel.For: {stopwatch2.Elapsed}");       // вывод повторяющегося события

            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            for (int i = 0; i < arr2.Length; i++)
                arr2[i] = i + 1;

            stopwatch3.Stop();
            Console.WriteLine("for: " + stopwatch3.Elapsed);            // вывод повторяющегося события
            
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
                    //-----ForEach
            Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4 }, Factorial);
                                    //коллекция, делегат, выполняющийся один раз за итерацию для каждого перебираемого элемента коллекции

            stopwatch4.Stop();
            
            Console.WriteLine("Parallel.Foreach: " + stopwatch4.Elapsed);   // вывод повторяющегося события

            Stopwatch stopwatch5 = new Stopwatch();
            stopwatch5.Start();
            foreach (var m in new List<int>() { 1, 2, 3, 4 })
            {
                Factorial(m);
            }
            
            stopwatch5.Stop();
            Console.WriteLine("foreach: " + stopwatch5.Elapsed);              // вывод повторяющегося события
            Console.WriteLine();
        }


        static void Sixth()
        {
            int count = 0;
            int maxCount = 100;
            Parallel.Invoke(() =>   // в качестве параметра принимает массив объектов Action
            {
                while (count < maxCount)        // выполняется на одном ядре целевой машины
                {
                    count++;
                    Console.WriteLine($"1: {count}");
                }
            }, () =>
            {
                while (count < maxCount)         // выполняется на другом ядре целевой машины
                {
                    count++;
                    Console.WriteLine($"2: {count}");
                }
            });
        }

        static void Seventh()
        {
            BlockingCollection<string> bc = new BlockingCollection<string>(5);      // Коллекция, которая осуществляет блокировку и ожидает, пока не появится возможность
                                                                                    // выполнить действие по добавлению или извлечению элемента

            Task[] sellers = new Task[10]
            {
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Стол"); Console.WriteLine("Товар поступил");} }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Шкаф");Console.WriteLine("Товар поступил"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Зеркало");Console.WriteLine("Товар поступил"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Что-то"); Console.WriteLine("Товар поступил");} }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Картина"); Console.WriteLine("Товар поступил");} }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Вещь"); Console.WriteLine("Товар поступил");} }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Котик"); Console.WriteLine("Товар поступил");} }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Собачка"); Console.WriteLine("Товар поступил");} }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Телевизор");Console.WriteLine("Товар поступил"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Холодильник"); Console.WriteLine("Товар поступил");} }),

            };

            Task[] consumers = new Task[5]
            {
                new Task(() => { while (true) { Thread.Sleep(300); bc.Take(); Console.WriteLine("Товар забрали");} }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); Console.WriteLine("Товар забрали");} }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); Console.WriteLine("Товар забрали");} }),
                new Task(() => { while (true) { Thread.Sleep(400); bc.Take(); Console.WriteLine("Товар забрали");} }),
                new Task(() => { while (true) { Thread.Sleep(250); bc.Take(); Console.WriteLine("Товар забрали"); } })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                {
                    i.Start();
                    //i.Wait();

                }


            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                {
                    i.Start();
                    i.Wait();

                }

            int count = 1;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(900);
                    Console.Clear();
                    Console.WriteLine("--- СКЛАД ---");

                    foreach (var i in bc)
                        Console.WriteLine(i);
                }
            }
        }

        static void Eighth()
        {
            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(1000);
                Console.WriteLine($"Факториал равен {result}");
            }

            async void FactorialAsync() 

            {
                Console.WriteLine("Начало метода FactorialAsync");
                await Task.Run(() => Factorial());                  // выполняется асинхронно
                Console.WriteLine("\nКонец метода FactorialAsync");
            }
            FactorialAsync();
        }








        public static void Sevn()
        {
            BlockingCollection<Product> products = new();
            Task provider1 = new(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product()))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 1 добавил товар");
                    Thread.Sleep(170);
                }
            });
            Task provider2 = new(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product()))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 2 добавил товар");
                    Thread.Sleep(200);
                }
            });
            Task provider3 = new(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product()))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 3 добавил товар");
                    Thread.Sleep(600);
                }
            });
            Task provider4 = new(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product()))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 4 добавил товар");
                    Thread.Sleep(300);
                }
            });
            Task provider5 = new(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product()))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 5 добавил товар");
                    Thread.Sleep(250);
                }
            });

            Task client1 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 1 забрал продукт");
                    }
                }
            });
            Task client2 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 2 забрал продукт");
                    }
                }
            });
            Task client3 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 3 забрал продукт");
                    }
                }
            });
            Task client4 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 4 забрал продукт");
                    }
                }
            });
            Task client5 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 5 забрал продукт");
                    }
                }
            });
            Task client6 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 6 забрал продукт");
                    }
                }
            });
            Task client7 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 7 забрал продукт");
                    }
                }
            });
            Task client8 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 8 забрал продукт");
                    }
                }
            });
            Task client9 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 9 забрал продукт");
                    }
                }
            });
            Task client10 = new(() =>
            {
                Product prod = new();
                while (true)
                {
                    if (products.TryTake(out prod) && prod is not null)
                    {
                        Console.WriteLine("Клиент 10 забрал продукт");
                    }
                }
            });

            provider1.Start();
            provider2.Start();
            provider3.Start();
            provider4.Start();
            provider5.Start();

            client1.Start();
            client2.Start();
            client3.Start();
            client4.Start();
            client5.Start();
            client6.Start();
            client7.Start();
            client8.Start();
            client9.Start();
            client10.Start();

            provider5.Wait();
        }


    }

}