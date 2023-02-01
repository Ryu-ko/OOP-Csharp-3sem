using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    internal class Match
    {
        public delegate void Deleg();

        public event Deleg GOL;
        //добавить условие что произошло забитие гола
        public void Say()
        {
            GOL.Invoke();
        }

    }

    internal class Bolelshik
    {
        public void SayGOL()
        {
            Console.WriteLine("ГОЛ!!!!!");
        }

    }

}
