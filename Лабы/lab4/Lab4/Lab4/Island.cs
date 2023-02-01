using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Island : Government, ICloneable
    {
        public override string ToString()     //переопределение метода ToString()
        {
            return ($"Остров {this.Name}, относится к гос-ву {this.Parent}, население острова  = {this.Humanity}");
        }
        public override void Chain()
        {
            Console.WriteLine("\n\nКонтинет - Страна -  Остров");
            Console.WriteLine("Вы сейчас находитесь тут  " + Name + "\t конец цепочки");
        }
        public override void Info()
        {
            Console.WriteLine("Остров:  " + Name);
        }
        public Island( string name, string country, string head, string vallet, int humanity, string continent, int ParentHumanity, long Chu ) : base(country, head, vallet, ParentHumanity, continent, Chu)
        {
            Name = name;
            Parent = country;
            Humanity = humanity;
        }
        public Island() { }
        public new void ShowHierarchy()
        {
            base.ShowHierarchy();
            Console.Write(",к нему относится остров: " + Name);
        }

        public object Clone()
        {
            return new Island()
            {
                Name = this.Name,
                Humanity = this.Humanity,
                Parent = this.Parent,
                Vallet = this.Vallet,
                HeadOfG = this.HeadOfG
            };
        }
    }
}
