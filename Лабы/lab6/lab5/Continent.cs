using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Continent
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new NameException("\"Название\" - обязательное поле, не может принимать значения null");
                }
                else { name = value; }

            }
        }
        public double PrecOfC;
        private long humanity;
        public long Humanity
        {
            get { return humanity; }
            set
            {
                if (value < 0)
                {
                    throw new HumanityExceprtion("Население не может быть отрицательным");

                }
                else { humanity = value; }

            }
        }
        public Continent( string name, long humanity )
        {
            PrecOfC = 100;
            Name = name;
            Humanity = humanity;
        }

        public Continent() { }

        public virtual void PrintName()
        {
            Console.WriteLine("Название объекта - " + Name);
        }

        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Континент {this.Name}, население = {this.Humanity}");
        }

    }
}
