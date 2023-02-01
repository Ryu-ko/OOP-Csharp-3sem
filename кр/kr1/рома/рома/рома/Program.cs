namespace laba
{
    class Program
    {
        //1b
        public static void BubbleSort(int[,] a)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = i + 1; k < 3; k++)
                    {
                        for (int m = j; m < 3; m++)
                        {
                            if (a[i, j] > a[k, m])
                            {
                                int t = a[i, j];
                                a[i, j] = a[k, m];
                                a[k, m] = t;
                            }
                        }

                    }
                }
            }
        }
        static void Main()
        {
            // 1a
            Console.WriteLine("str=");
            string str = Console.ReadLine();
            int half = str.Length / 2;
            string str2 = str.Substring(0, half);
            string str3 = str.Substring(half, half);
            Console.WriteLine(str2 + " " + str3);
            // 1b
            int[,] arr = new int[3, 3]
            {
                {5, 6, 12 },
                {9, 10, 3 },
                {1, 0, 2 },
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            BubbleSort(arr);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            //2
            string someStr = "it has some value";
            Console.WriteLine(someStr.ToString());
            Console.WriteLine(someStr.GetHashCode());
            Console.WriteLine(someStr.GetType());

            //3
            Stajor stajor1 = new Stajor();
            Junior junior1 = new Junior();
            SenoirPomidor senoirPomidor1 = new SenoirPomidor(19);

            List<string> data = new List<string>
            {
                stajor1.age, junior1.lang, senoirPomidor1.sallary
            };

            SenoirPomidor senoirPomidor2 = new SenoirPomidor(21);
            SenoirPomidor senoirPomidor3 = new SenoirPomidor(25);
            SenoirPomidor senoirPomidor4 = new SenoirPomidor(32);

            SenoirPomidor[] senoirArray = new SenoirPomidor[4] { senoirPomidor1, senoirPomidor2, senoirPomidor3, senoirPomidor4 };
            for (int i = 0; i < senoirArray.Length; i++)
            {
                if (senoirArray[i].Age >= 20 && senoirArray[i].Age <= 30)
                    senoirArray[i].work();
            }
        }
    }
    //2
    public class Stajor
    {
        public string name;
        public int birthday;
        public int startDate;
        public string Name
        {
            get
            {
                if (name != null) return name;
                else return null;
            }
            set { name = value; }
        }
        public int Birthday
        {
            get
            {
                if (birthday - 2020 > 18) return birthday;
                else
                    throw new AgeException("The student cannot be found.");
            }
            set { birthday = value; }
        }
        public int StartDate
        {
            get
            {
                if (startDate != null) return startDate;
                else return 0;
            }
            set { startDate = value; }
        }

        //3
        public string age;
        public virtual void work()
        {
            Console.WriteLine("Stajor is working!");
        }
    }
    //2
    public class AgeException : Exception
    {
        public AgeException() { }

        public AgeException(string message)
            : base(message) { }
    }
    //2
    static public class Statistics
    {
        public static void Years(this Stajor stajor)
        {
            Console.WriteLine("Стаж: " + (2022 - stajor.StartDate));
        }
    }
}
