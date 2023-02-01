using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class Ground : Planet
    {
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Суша, занимают {this.Precent}% от всей планеты");
        }
        public string Parent;
        public abstract void Info();
        public Ground()
        {
            Precent = 21;
        }

    }
}
