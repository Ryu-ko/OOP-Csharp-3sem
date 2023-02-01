
using System;
using System.Linq;

namespace lab10
{

    public class Program
    {
        public static void Main( string[] args )
        {
            string[] Month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine("Введите n:");
            int n =Convert.ToInt32( Console.ReadLine());

            //запрос выбирающий последовательность месяцев с длиной строки равной n
            IEnumerable<string> MonthLenth= from m in Month
                                            where m.Length <= n 
                                            select m;

            Console.WriteLine("\nВ последовательность из n строки");
            foreach (string i in MonthLenth)
            {
                Console.WriteLine(i);
            }


            //запрос возвращающий только летние и зимние месяцы
            IEnumerable<string> WintSummer = from m in Month
                                             where m == "June" || m == "July" || m == "August"|| m == "January" || m == "December" || m == "February"
                                             select m;

            Console.WriteLine("\nлетние и зимние месяцы");
            foreach (string i in WintSummer)
            {
                Console.WriteLine(i);
            }


            //запрос вывода месяцев в алфавитном порядке
            IEnumerable<string> AlfMonth = from m in Month
                                           orderby m ascending
                                           select m;

            Console.WriteLine("\nВ алфавитном порядке");
            foreach (string i in AlfMonth)
            {
                Console.WriteLine(i);
            }


            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х
            IEnumerable<string> Month4U = from m in Month
                                          where m.Length>=4 && m.Contains("u")
                                          select m;

            Console.WriteLine("\nCодержащие букву «u» и длиной имени не менее 4 - х");
            foreach (string i in Month4U)
            {
                Console.WriteLine(i);
            }

            //--------------------------------------------

            Airline a1 = new Airline("Италия", 12, "Airbus", "Понедельник", new DateTime(2022, 09, 11, 23, 00, 00));
            Airline a2 = new Airline("Минск", 123, "Airbus", "Вторник", new DateTime(2022, 09, 15, 16, 45, 00));
            Airline a3 = new Airline("Варшава", 75, "Airbus", "Вторник", new DateTime(2022, 09, 15, 19, 00, 00));
            Airline a4 = new Airline("Минск", 1012, "Belavia", "Среда", new DateTime(2022, 09, 20, 22, 45, 00));
            Airline a5 = new Airline("Москва", 151, "Аэрофлот", "Среда", new DateTime(2022, 12, 04, 15, 30, 00));
            Airline a6 = new Airline("Катар", 444, "TurkishAirlines", "Среда", new DateTime(2022, 12, 05, 07, 45, 00));
            Airline a7 = new Airline("ОАЭ", 812, "Fly Emirates", "Четверг", new DateTime(2022, 12, 10, 10, 00, 00));
            Airline a8 = new Airline("Минск", 315, "s7 Airlines", "Пятница", new DateTime(2022, 12, 29, 20, 30, 00));
            Airline a9 = new Airline("Лима", 785, "Airbus", "Суббота", new DateTime(2023, 01, 13, 19, 45, 00));
            Airline a10 = new Airline("Каир", 109, "TurkishAirlanes", "Воскресенье", new DateTime(2023, 02, 12, 12, 00, 00));

            List<Airline> Airlist = new List<Airline>();
            Airlist.Add(a1);
            Airlist.Add(a2);
            Airlist.Add(a3);
            Airlist.Add(a4);
            Airlist.Add(a5);
            Airlist.Add(a6);
            Airlist.Add(a7);
            Airlist.Add(a8);
            Airlist.Add(a9);
            Airlist.Add(a10);


            Console.WriteLine("\n\nСписок рейсов:");
            foreach (var el in Airlist)
            {
                Console.WriteLine(el);
            }

           

        //------1------
            Console.WriteLine("\n------Пункт назначения------");
            string dest = Console.ReadLine();

            IEnumerable<Airline> destin = from ar in Airlist
                                          where ar.Destination == dest
                                          select ar;



            Console.WriteLine("\n------список рейсов для заданного пункта назначения------");
            foreach (Airline i in destin)
            {
                Console.WriteLine(i);
            }
            
        //------2------

            Console.WriteLine("\nДень недели:");
            string dayW = Console.ReadLine();

            IEnumerable<Airline> DayWeek = from ar in Airlist
                                          where ar.Weekday == dayW
                                          select ar;

            Console.WriteLine("\n------список рейсов для заданного дня недели------");
            foreach (Airline r in DayWeek)
            {
                Console.WriteLine(r);
            }

        //------3------
            var MaxDay = Airlist
               .GroupBy(n => n.Weekday)
               .Select(n => new { День_недели = n.Key, Максимальный_номер_рейса = n.Max(x => x.Flight_Num) });

            Console.WriteLine("\n------максимальны по дню недели рейс------");
            foreach (var i in MaxDay)
            {
                Console.WriteLine(i);
            }

         //------4------
                Console.WriteLine("\nДень недели:");
                string dayW4 = Console.ReadLine();

                var DayLastFly = Airlist
                            .GroupBy(n => n.Weekday)
                            .Select(n => new {
                                    День_недели = n.Key,
                                    Время_вылета = n.Max(x => Convert.ToString(x.TimeOfDep.Hour)
                                + ":" + Convert.ToString(x.TimeOfDep.Minute))
                                });
                        // преобразование те с кажд элементо было то то 
         
            Console.WriteLine("\n------все рейсы в определенный день недели и с самым поздним временем вылета------");
            foreach (var i in DayWeek)
            {
                Console.WriteLine(i);
            }

            //------5------

            var DayTimeDep = Airlist
                .OrderBy(n => n.TimeOfDep.Hour);

            Console.WriteLine("\n------упорядоченные по дню и времени рейсы------");
            foreach (var i in DayTimeDep)
            {
                Console.WriteLine("{0}", i);
            }


            //------6------

            var TypeF = from x in Airlist
                           where x.Airplane_Type == "Airbus"
                           select x;

            Console.WriteLine("\n\nРейсы Airbus");

            Console.WriteLine("\n------количество рейсов для заданного типа самолета------");
            foreach (var i in TypeF)
            {
                Console.WriteLine(i);
            }
            

            //---------------------------------------------------
            // 5 операторов

            Console.WriteLine("\n\n-------------------Запрос из 5-и операторов---------------\n");
            IEnumerable<Airline> bigquery = Airlist
                                            .Where(n => n.Destination == "Минск")
                                            .OrderBy(n => n.id)
                                            .Take(6)
                                            .Select(n => n)
                                            .Concat(Airlist.Skip(2));

            foreach (Airline el in bigquery)
            {
                Console.WriteLine(el);
            }

            //---------------------------------------------------
            //  Join

            Airline a31 = new Airline("Афигы", 151, "s7 Airlanes", "Воскресенье", new DateTime(2023, 02, 02, 14, 50, 00));
            Airline a41 = new Airline("Катовице", 1012, "Turkish Airlanes", "Среда", new DateTime(2023, 4, 8, 14, 45, 00));
            Airline a51 = new Airline("Санкт-Петербург", 777, "Аэрофлот", "Пятница", new DateTime(2022, 12, 29, 21, 00, 00));
            Airline a61 = new Airline("Владивосток", 444, "Аэрофлот", "Суббота", new DateTime(2023, 01, 04, 12, 30, 00));

            List<Airline> list2 = new List<Airline>();
            list2.Add(a31);
            list2.Add(a41);
            list2.Add(a51);
            list2.Add(a61);
            Console.WriteLine("\n\n Оператор Join");
            int[] nums = { 123, 454, 151, 1012, 444, 999, 12 };

            var joinquery = Airlist.Join(
                                    list2,
                                    w => w.Flight_Num,
                                    q => q.Flight_Num,
                                    ( w, q ) => new
                                    {
                                        Рейс = w.Flight_Num + " " + w.Destination + " " + w.TimeOfDep,
                                        Совпадения_со_вторым = q.Destination + " " + q.Flight_Num + " " + q.TimeOfDep
                                    })
                                    .OrderBy(n => n.Совпадения_со_вторым); 
            
            foreach (var el in joinquery)
            {
                Console.WriteLine(el);
            }


        }
    }
}