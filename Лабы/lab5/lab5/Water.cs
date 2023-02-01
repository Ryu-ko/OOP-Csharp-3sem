using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Water
    {
        public int square;
        public string typeOFWater;

        public Water() 
        { 
            square = 999;
            typeOFWater = "nonDef";
        }
        public Water( int sq, string typeOW )
        { 
            square= sq;
           typeOFWater = typeOW;   
        
        }

        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Тип воды объекта - {this.typeOFWater}, занимает {this.square} м^2");
        }


    }
}
