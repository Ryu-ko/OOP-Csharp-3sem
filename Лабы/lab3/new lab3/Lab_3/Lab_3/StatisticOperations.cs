using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
     static internal class StatisticOperations
    {

        public static int sum( this Array arr )
        {
            int sum = 0;
            for (int i = 0; i < arr.ar.Length; i++)
            {
                sum += arr.ar[i];
            }
            return sum;
        }
        public static int max( this Array arr )
        {
            int max = -99999;
            foreach (int x in arr.ar)
            {
                if (x > max) max = x;
            }
            return max;
        }
        public static int min( this Array arr )
        {
            int min = 999999;
            foreach (int x in arr.ar)
            {
                if (x < min) min = x;
            }
            return min;
        }
        public static int delta( this Array arr )
        {
            return Math.Abs(StatisticOperations.max(arr)) - Math.Abs(StatisticOperations.min(arr));
        }
        public static int size( this Array arr )
        {
            return arr.ar.Length ;
        }


        public static Array neg( this Array arr )
        {
            Array newArr = new Array();

            for (int i = 0; i < arr.ar.Length -1 ; i++)
            {
                if (arr.ar[i] > 0)
                {
                    if (i > 0 && newArr.ar[i - 1] == arr.ar[i]) { }

                    else
                        newArr.ar[i] = arr.ar[i];
                }

                else if (arr.ar[i] < 0)
                {
                    newArr.ar[i] = arr.ar[i + 1];
                }
            }
            return newArr;
        }

        public static void hasSymbol( this Array arr, string c ) 
        {
            int index = arr.str.IndexOf(c);
            if (index == -1)
                Console.WriteLine("Такого символа нет в строке!");
            else Console.WriteLine("Символ " + c + " присутсвует в строке под индексом " + index);

        }

    }
}
