using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba
{
    internal class Class1
    {
        interface IWrite
        {
            string Write();
        }
        class Memory : IWrite
        {
            public string name;
            public int memory_amount;
            public virtual string Write()
            {
                string str = "some_str";
                return str;
            }
            public static int operator ==(Memory memory1, Memory memory2)
            {
                if (memory1.memory_amount > memory2.memory_amount)
                    Console.WriteLine("Память у 1ой больше 2ой");
                else
                    Console.WriteLine("Память у 2ой больше 1ой");
                return 0;
            }
            public static int operator !=(Memory memory1, Memory memory2)
            {
                Console.WriteLine("false");
                return 0;
            }
        }
        class Electronic : Memory
        {
            public string type;
        }
        class Flash : Memory
        {
            public string amount;
            public override string Write()
            {
                string str2 = "some_other_str";
                return str2;
            }
        }
        static public void Main()
        {
            //3
            Memory memory1 = new Memory();
            Memory memory2 = new Memory();
            Electronic electronic1 = new Electronic();
            Electronic electronic2 = new Electronic();
            Flash flash1 = new Flash();
            Flash flash2 = new Flash();
            List<string> data = new List<string>() 
            { 
                memory1.name, memory2.name, electronic1.type, electronic2.type, flash1.amount, flash2.amount 
            };
            Console.WriteLine(flash1.Write());
        }
    }
}
