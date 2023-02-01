using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
{
    internal class Planet
    {
        public string Name;
        public int Precent;
        public virtual void Chain()
        {
            Console.WriteLine("Ваш уровень: " + Name);
        }
        public Planet( string name )
        {
            this.Name = name;
            Precent = 100;
        }
        
        public Planet() 
        {
            
        }
        public void PrintName()
        {
            Console.WriteLine("Название объекта: " + Name);
        }
        public override string ToString()    //переопределение метода ToString()
        {
            return ($"Море: {this.Name}, является главным звеном, занимает {this.Precent}% системы");
        }



    }

}
