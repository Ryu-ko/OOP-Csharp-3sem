using System;
using System.Text;

namespace laba
{
    interface ICompare
    {
        void CompareMethod();
    }
    class Program
    {
        public class Person
        {
            public string Name { get; }
            public Person(string name) => Name = name;
        }
        public class Shop : ICompare
        {
            public string[] arra1 = {"ауди", "рино"};
            public int[] arra2 = { 10, 20 };
            public virtual void CompareMethod()
            {
                if (arra2[0] > arra2[1])
                {
                    Console.WriteLine("У Ауди больше ассортимент");
                }
                if (arra2[0] < arra2[1])
                {
                    Console.WriteLine("У Рино больше ассортимент");
                }
            }
            public Shop()
            {

            }
            Person[] personal;
            public Shop(Person[] people) => personal = people;
            // индексатор
            public Person this[int index]
            {
                get => personal[index];
                set => personal[index] = value;
            }
        }
        static void Main(string[] args)
        {
            //1а
            Shop shop1 = new Shop();
            shop1.CompareMethod();
            string s = Console.ReadLine();
            char[] array = s.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'о')
                {
                    array[i] = 'а';
                }
                if (array[i] == 'д')
                {
                    array[i + 1] = 'ж';
                }
                Console.Write(array[i]);
            }
            //1б
            int[,] nums2 = new int[8, 8];
            for (int i = 0; i < 8; i = i + 2)
            {
                for (int j = 0; j < 8; j++)
                {
                    nums2[i, j] = 1;
                }
            }
            for (int i = 1; i < 8; i = i + 2)
            {
                for (int j = 0; j < 8; j++)
                {
                    nums2[i, j] = 0;
                }
            }
            int space = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(nums2[i, j] + " ");
                    space++;
                    if (space % 8 == 0)
                        Console.WriteLine();
                }
            }


            // 2
            var microsoft = new Shop(new[]
            {
                new Person("Tom"), new Person("Bob"), new Person("Sam"), new Person("Alice")
            });
            // получаем объект из индексатора
            Person firstPerson = microsoft[0];
            Console.WriteLine(firstPerson.Name);  // Tom
        }

    }
}
