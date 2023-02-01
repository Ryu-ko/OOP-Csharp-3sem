
namespace Pr {
    class Programm
    {
        
        //2
        class Author {
            public string Name { get; set; }
            public string Birthday { get; set; }
            public string Country { get; set; }

            public override bool Equals( object? obj )
            {
                return base.Equals(obj);
            }


        }

        static void Main( string[] args )
        {

            Author avt1 = new Author();
            Author avt2 = new Author();
            avt1.Name ="Кто то";
            avt1.Birthday = "21.10";
            avt2.Birthday = "21.10";


            //1a
            string str1;
            str1 = Convert.ToString(Console.ReadLine());
            string[] sub = str1.Split(' ');
            Console.WriteLine(sub[1]);

            //1b
            int[,] arr = { { 1, 1, 3, 5 }, { 7, 2, 1, 5 } };
            int max=0;
            int rows = arr.GetUpperBound(0) + 1;    // количество строк
            int columns = arr.Length / rows;      // количество столбцов

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (arr[i, j] > max)
                    { max = arr[i, j]; }
                }
            
            }
            Console.WriteLine(max);

        }



    }

}