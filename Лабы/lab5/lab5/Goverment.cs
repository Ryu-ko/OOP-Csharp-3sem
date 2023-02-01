using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    partial class Government : Ground //Суть разделяемого класса (или, как его ещё называют, частичного класса) состоит в том, что несколько частей одного и того же класса могут располагаться в разных файлах, но при компиляции все эти части будут собраны воедино.
    {
        public Water water ;
        public string Cont ;
        public string HeadOfG;
        public string Vallet;

        public Government( string name, string head, string vallet, int humanity, string cont )
        {
            water = new Water();
            Name = name;
            HeadOfG = head;
            Vallet = vallet;
            Humanity = humanity;
            this.water = water;
            Cont = cont;
        }

        public override bool TToCompare( object obj )
        {
            return true;
        }
        public override void Info()
        {
            Console.WriteLine("Cтрана - " + Name);
        }

    }
}
