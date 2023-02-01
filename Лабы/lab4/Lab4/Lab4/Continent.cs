using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Continent : Ground
    {
        public override string ToString()      //переопределение метода ToString()
        {
            return ($"Континент: {this.Name}.  Население: {this.Humanity}");
        }
        public double PrecOfC;
        public long Humanity;
        public Continent( string name, long humanity )
        {
            PrecOfC = 100;
            Name = name;
            Humanity = humanity;
        }
        public Continent() { 
        
        }
        public override void Info()
        {
            Console.WriteLine("Континет: " + Name);
        }

    }
}
