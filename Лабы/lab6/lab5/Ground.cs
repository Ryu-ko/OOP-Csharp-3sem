using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
     abstract class Ground : Continent
        {
        public int Precentage;
        public GeoBelt belt;
        public string Parent;
        public abstract bool TToCompare( object obj );
        public abstract void Info();
        public Ground()
        {

        }

        partial class Government : Ground
        {
            public object Vallet { get; private set; }
            public object HeadOfG { get; private set; }

            public override void Info()
            {
                Console.WriteLine("Cтрана - " + Name);
            }
            public Government() { }
            // public Government( string name, string head, string vallet, int humanity, string cont ){   }


            public override void PrintName()
            {
                base.PrintName();
            }
            public override bool TToCompare( object obj )
            {
                return true;
            }
            public override string ToString()                       //переопределение метода ToString()
            {
                return ($"Государство {this.Name}, население = {this.Humanity}, валюта - {this.Vallet}, глава гос-ва - {this.HeadOfG}");
            }

        }

    }
}
