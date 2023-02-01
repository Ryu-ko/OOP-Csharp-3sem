using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba //3
{
        class Junior : Stajor
        {
            public string lang;
            public override void work()
            {
                Console.WriteLine("Junior is working!");
            }
        }
        class SenoirPomidor : Stajor
        {
            public string sallary;
            public int Age;
            public SenoirPomidor(int age)
            {
                Age = age;
            }
            public override void work()
            {
                Console.WriteLine("SenoirPomidor is working! And hes age is " + Age);
            }
        }
    }
