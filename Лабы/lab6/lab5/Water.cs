using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Water
    {
        public int square;
        private string typeOFWater;
        public string TypeOFWater
        {
            get { return typeOFWater; }
            set
            {
                if (value != "солёная" || value != "пресная" || value != "notDefined")
                {
                    throw new WaterException("Указан неверный тип воды");
                }
                else
                { typeOFWater = value; }
            }


        }
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
