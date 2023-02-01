using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Government : Continent
    {
        public override string ToString()   //переопределение метода ToString()
        {
            return ($"Государство: {this.Name}, население: {this.Humanity}, валюта: {this.Vallet}, глава гос-ва - {this.HeadOfG}");
        }
        public Government( string name, string head, string vallet, int humanity, string ParentName, long Phumanity ) : base(ParentName, Phumanity)
        {
            Name = name;
            HeadOfG = head;
            Vallet = vallet;
            Humanity = humanity;
            PrecOfC = Convert.ToDouble(humanity) / Convert.ToDouble(Phumanity);
        }
        public string HeadOfG;
        public string Vallet;
        public override void Info()
        {
            Console.WriteLine("Cтрана: " + Name);
        }

        Continent cont;
        public Government() { 
            this.cont = new Continent();
        }

        public void ShowHierarchy()
        {
            Console.Write("Государство: " + Parent);
        }

    }
}
