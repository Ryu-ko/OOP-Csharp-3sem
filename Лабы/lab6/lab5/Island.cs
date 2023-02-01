using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Island : Ground, ICloneable, FirstInterface
    {
        public Water water;
        public Island( string name, string country, int humanity )
        {
            water = new Water(10000, "солёная");
            Name = name;
            Parent = country;
            Humanity = humanity;

        }
        public Island()
        { }

        bool FirstInterface.TToCompare( object obj )
        {
            Island isl = obj as Island;
            if (isl != null)
            {
                return isl.Name == Name && isl.Humanity == Humanity && isl.Parent == Parent && isl.water.square == water.square && isl.water.TypeOFWater == water.TypeOFWater;
            }
            return false;

        }
        public override bool TToCompare( object obj )
        {
            Island isl = obj as Island;
            if (isl != null)
            {
                return isl.Name == Name;
            }
            return false;

        }
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Остров {this.Name}, относится к гос-ву {this.Parent}, население острова  = {this.Humanity}");
        }
        public override void Info()
        {
            Console.WriteLine("Остров:  " + Name);

        }

        public object Clone()
        {
            return new Island()
            {
                Name = this.Name,
                Humanity = this.Humanity,
                Parent = this.Parent
            };
        }

    }
}