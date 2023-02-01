using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
	internal class Island : Ground, IComparable<Island>
    {
        public Water water;
     
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
            Console.WriteLine("Остров - " + Name);
        }
        public Island( string name, string country, int humanity )
        {
            water = new Water(10000, "солёная");
            Name = name;
            Parent = country;
            Humanity = humanity;
        }

        public Island() {
            Name = this.Name;
                }
        public object Clone()
        {
            return new Island()
            {
                Name = this.Name,
                Humanity = this.Humanity,
                Parent = this.Parent,
            };
        }

        int IComparable<Island>.CompareTo( Island? other )
        {
            if (other.GetType() != GetType())
                return -1;
            if (other == null)
                return -1;
            return Name.CompareTo(other.Name);

        }

    }
}
