using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal sealed class Sea : Water, Interfaces, Interfaces2//запрет на переопределение методов и св-в
    {
        public string TypeOfWater;
        public override bool ToCompare( object obj )
        {
            Sea sea = obj as Sea;
            if (sea != null)
            {
                return sea.Name == Name;
            }
            return false;
        }
        public override void Chain()
        {
            Console.WriteLine("Нижний уровень иерархии Water ---- Sea :" + Name);
        }
        public override string ToString()   //переопределение метода ToString()
        {
            return ($"Море: {this.Name}, занимает {this.Precent}% водной части континента, тип воды - {this.TypeOfWater}");
        }

        public override int GetHashCode()   //переопределение метода GetHashCode()
        {
            Console.WriteLine("\n-----Переопределение GetHashCode()-----");
            return base.GetHashCode();
        }                           
        public override bool Equals( object obj )   //переопределение метода Equals()
        {
            Console.WriteLine("\n-----Переопределение метода Equals()-----");
            Sea temp = obj as Sea;
            if (temp == null)
                return false;
            return (temp.Name == this.Name && temp.Precent == this.Precent &&
            temp.TypeOfWater == this.TypeOfWater);
        }

        bool Interfaces.ToCompare( object obj )
        {
            if (obj is Sea sea)
            {
                if (sea.TypeOfWater == TypeOfWater)
                {
                    Console.WriteLine($"\nОба моря имеют тип воды: {sea.TypeOfWater}");
                    return true;
                }
                else return false;
            }
            return false;
        }

        public Sea( string name, string type )
        {
            Name = name;
            TypeOfWater = type;
        }
        public Sea() { }
    }
}
