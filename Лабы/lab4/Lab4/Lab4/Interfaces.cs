using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
{
    internal interface Interfaces //Задается набор абстрактных методов, свойств, событий,
                                   //которые должны быть реализованы в производных классах
    {
        bool ToCompare( object obj );
        void Agreement()
        {
            Console.WriteLine(" --- Этот объект является интерфейсом ---");
        }


    }
    internal interface Interfaces2
    {
        void Agreement()
        {
            Console.WriteLine(" --- Все также интерефейс --- ");
        }

    }

}
