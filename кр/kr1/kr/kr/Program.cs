using System;

namespace kr 
{
    class Program
    {
        static void Main( string[] args )
        {

            var bag1 = new Bag("Bag 1", 2130);
            var bag2 = new Bag("Bag 2", 2130);

            
            Console.WriteLine( bag1.Sum.CompareTo(bag2.Sum)); //-1 когда перв меньше второго 

            //1a
            Console.WriteLine("Enter str: ");
            string str = Console.ReadLine();
            Console.WriteLine(str+str.Last());

            //1b

            int[,] arr = { { -4, 1, 3, -10 }, { -6, 1, -4, 2 } };

            int klv = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr[i, j] >=0 )
                    {
                        klv++;
                    }
                }

            }
            Console.WriteLine(klv);




        }


    }




}
