using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal abstract class Ground : Continent
    {
        public int Precentage;
        public string Parent;
        public abstract bool TToCompare( object obj );
        public abstract void Info();
        public Ground()
        {
            Precentage = 21;
        }
    }
}
