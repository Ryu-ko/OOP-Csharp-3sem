using System;

namespace Lab_3
{
     class Array
    {
        public int[] ar = new int[100];
        public string str;
        public Dvlp develop;
        public Array() { }
        public Array( int develID, string develFIO, string develCompany )
        {
            this.develop = new Dvlp(develID, develFIO, develCompany);
        }

        /// /////////////////////////////
        //методы
        public void EnterVal(params int[] values)
        {
            this.ar = values;
        }

        public void PrintVal()
        {
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] != 0)
                    Console.Write(ar[i] + "\t");
            }
            Console.WriteLine();
        }


        //Перегрузка

        public static Array operator *( Array arr1, Array arr2 )
        {
            Array arrP = new Array();
            for (int i = 0; i < arr2.ar.Length-1; i++)
            {
                arrP.ar[i] = arr1.ar[i] * arr2.ar[i];
            }
            return arrP;
        }

        public static bool operator true( Array arr )
        {
            for (short i = 0; i < arr.ar.Length; i++)
            {
                if (arr.ar[i] < 0)
                    return false;
            }
            return true;
        }
        
        public static bool operator false( Array arr )
        {
            for (short i = 0; i < arr.ar.Length; i++)
            {
                if (arr.ar[i] < 0)
                    return true;
            }
            return false;
        }


        public static explicit operator int( Array arr ) //если преобразование явное
        {
            return arr.ar.Length;
        }

        public static bool operator ==( Array arr1, Array arr2 )
        {
            for (int i = 0; i < arr1.ar.Length; i++)
            {
                if (arr1.ar[i] != arr2.ar[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=( Array arr1, Array arr2 )
        {
            for (int i = 0; i < arr1.ar.Length; i++)
            {
                if (arr1.ar[i] != arr2.ar[i])
                    return true;
            }
            return false;
        }

        public static bool operator <( Array arr1, Array arr2 )
        {
            if (StatisticOperations.sum(arr1) < StatisticOperations.sum(arr2))
                return true;
            else return false;
        }

        public static bool operator >( Array arr1, Array arr2 )
        {
            if (StatisticOperations.sum(arr1) > StatisticOperations.sum(arr2))
                return true;
            else return false;
        }

        // вложенный класс
        public class Date
        {

            public DateTime time;
            public Date()
            {
                this.time = new DateTime(2022, 10, 15, 16, 20, 0);
            }


            public void showDate()
            {
                Console.WriteLine("Дата создания: " + time);
            }

        }
    }

class Program
    {
        static void Main( string[] args )
        {

            Array arr1 = new Array();
            Array arr2 = new Array();
            Array arr3 = new Array();
            Array arr4 = new Array();

            arr1.EnterVal(2, 4, 7, 14, 7, 9);
            arr1.PrintVal();

            arr2.EnterVal(7, 1, 7, 1, 10, 1);
            arr2.PrintVal();

            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора * ");
            Array arrP = arr1 * arr2;
            arrP.PrintVal();
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора true ");
            if (arr1)
                Console.WriteLine("arr1 - true");
            else Console.WriteLine("arr1 - false");
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора int() ");
            Console.WriteLine((int)arr2);
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора == ");
            if (arr1 == arr2)
            { 
              Console.WriteLine("arr1 == arr2");
            }
            else Console.WriteLine("arr1 != arr2");
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора > ");
            Console.WriteLine("arr3:");
            Console.WriteLine();

            arr3.EnterVal(4, 4, 4, 4, 4, 1);
            arr3.PrintVal();

            Console.WriteLine("arr3.sum() = " + arr3.sum());

            Console.WriteLine("\narr4:");
            arr4.EnterVal(9, 11, 32, 54, 21, 12);
            arr4.PrintVal();
            Console.WriteLine("arr4.sum() = " + arr4.sum() + '\n');

            if (arr3 > arr4)
                Console.WriteLine("arr3 > arr4");
            else Console.WriteLine("arr3 < arr4");

             
            arrP.PrintVal();
            Console.WriteLine("\nСтатистические операции:  ");
            
            Console.WriteLine("Max в arrP: " + arrP.max());
            Console.WriteLine("Min в arr4: " + arr4.min());
            Console.WriteLine("Среднее в arr3: " + arr3.delta());
            Console.WriteLine("Размер arr2: " + arr2.size());


            Array arrNeg = new Array();
            arrNeg.EnterVal(4, -4, 2, -6, 7, -14);
            Array arrOut = arrNeg.neg();

            Console.WriteLine("\nУдалить отрицательные ");
            arrOut.PrintVal();
            Console.WriteLine();

            Array ownerArr = new Array(1, "lion", "Socks Rock");
            ownerArr.develop.PrintVal();


            Array arrStr = new Array();
            arrStr.str = "Hello World!";
            Console.WriteLine("\nВведите символ, который хотите найти в строке:");
            Console.WriteLine();
            string symbol = Console.ReadLine();
            arrStr.hasSymbol(symbol);


    }
    }
}