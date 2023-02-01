using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    interface FirstInterface
    {
        bool TToCompare( object obj );
        void Agreement()
        {
            Console.WriteLine("--- Этот объект является интерфейсом ---");
        }
    }
}
