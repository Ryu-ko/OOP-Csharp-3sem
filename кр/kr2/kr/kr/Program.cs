


namespace kr
{
    class Program
    {
        static void Main()
        {
            //3.

            Match match = new Match();
            Bolelshik b1 = new Bolelshik();
            Bolelshik b2 = new Bolelshik();


            match.GOL += b1.SayGOL;
            match.GOL += b2.SayGOL;

            match.Say();


            ///1

            SuperList<int> ints = new SuperList<int>();

            Console.WriteLine(ints.Add(20));
            Console.WriteLine(ints.Add(40));
            Console.WriteLine(ints.Add(1));

            foreach (var lst in ints)
            {
                Console.WriteLine(lst);
            }
            Console.WriteLine(ints.Find(20));

            List<char> list = new List<char>()
            {
                'q',
                'w',
                'e',
                'r',
                't',
                'y'
            };


        }
    }
}

