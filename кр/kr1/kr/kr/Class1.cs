using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{

     internal class Bag : IComparable
        {
            public string Name { get; set; }
            public int Sum { get; set; }
            public Bag( string name, int sum )
            {
                Name = name; Sum = sum;
            }
            public int CompareTo( object? o )
            {
                if (o is Bag bag)
                    return Sum.CompareTo(bag.Sum);

                else throw new ArgumentException("Некорректное значение параметра");
            }



        }




}
