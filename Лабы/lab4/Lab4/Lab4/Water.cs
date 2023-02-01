using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class Water : Planet 
    {
        public abstract bool ToCompare( object obj );
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Все водные ресурсы системы, занимают {this.Precent}%");
        }
        public Water()
        {
            Precent = 71;
        }
    }
}
