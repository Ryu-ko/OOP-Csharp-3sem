using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4 
{
    class Program
    {
       static void Main( string[] args )
        {


            Planet planet = new Planet("планета Земля");
            planet.Chain();

            Continent continent = new Continent("Австралия", 25200000);

            Island island = new Island("Токио", "Япония", "Фумио Кисида", "Йены", 125440000, "Восточная Азия", Convert.ToInt32(60 * Math.Pow(10, 6)), 8000000000);

            Sea sea = new Sea("Восточно-Китайское море", "солёная");

            sea.PrintName();
            Console.WriteLine(sea.ToString());

            Sea sea1 = new Sea("Черное море", "солёная");
            Console.WriteLine(sea.Equals(sea1));

            island.ShowHierarchy();
            island.Chain();

            Console.WriteLine("\nIsland.ToString() ");

            Console.WriteLine(island.ToString());

            object obj1 = new Sea("Черное море", "солёная");
            object obj2 = " ";
           
            Console.WriteLine("\nToCompare sea and obj's: ");
            sea1.ToCompare(obj1);
            Console.WriteLine(sea1.ToCompare(obj1));
            Console.WriteLine(sea1.ToCompare(obj2));
            Console.WriteLine(sea.ToCompare(continent));

            sea1.Precent = 13;

            Interfaces firstInterface = sea1;
            sea.Precent = 12;
            Console.Write("\nToCompare interface and obj1: ");
            Console.WriteLine(firstInterface.ToCompare(obj1));

            Government government = new Government("Германия", " Франк-Вальтер Штайнмайер", "EUR", 84079811, "Евразия", 8840000000);

            object[] someTypes = { sea, continent, government, island, firstInterface };
            Console.WriteLine("\n");
            foreach (var item in someTypes)
            {
                if (item is Ground)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("\n");


            foreach (var item in someTypes)
            {
                Interfaces fi = item as Interfaces;
                if (fi != null)
                {
                    Console.WriteLine(fi);
                   ((Interfaces)fi).Agreement(); //одноименные интерфейсы
                    ((Interfaces2)fi).Agreement();

                }
            }
            Console.WriteLine("\n\n");

            object cloneIsl = island.Clone();
            Console.Write("Equals cloneis and Island");
            Console.WriteLine(cloneIsl.Equals(island));

            Printer printer = new Printer();
            object[] lastarray = { planet, continent, sea, government, island, printer };
            foreach (var item in lastarray)
            {
                printer.IAmPrinting(item as Ground);
                Console.Write("");
            }
        }

    }


}