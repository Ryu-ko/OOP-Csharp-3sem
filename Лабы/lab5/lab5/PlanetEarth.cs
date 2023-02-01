using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class PlanetEarth //класс-Контейнер 
    {
        public int kolvo = 0;
        public List<Continent> cntnr;

        public PlanetEarth()  //конструктор
        {
            cntnr=new List<Continent>();
            kolvo++;
        }

        public List<Continent> List //свойство 
        {
            get => cntnr;
            set {
                if (value is List<Continent>)
                {
                    cntnr = value;
                }
            
            }
        }

        //методы для добавления и удаления объектов в список, метод для вывода списка на консол

        public void Add( object value )
        {
            if (value is Continent thenn)
            { 
                cntnr.Add( thenn ); 
            }
        }

        public void Remove( object value )
        {
            if (value is Continent thenn)
            {
                cntnr.Remove(thenn);
                kolvo--;
            }
        }

        public void Print()
        {
            foreach (var elem in cntnr)
            {
                switch (elem)
                {
                    case Sea:
                        Console.WriteLine($"Название моря: {elem.Name}");
                        break;
                    case Island:
                        Console.WriteLine($"Название острова: {elem.Name}");
                        break;
                    case Government:
                        Console.WriteLine($"Название государства: {elem.Name}");
                        break;
                    default:
                        Console.WriteLine($"Континет : {elem.Name}");
                        break;
                }
            }
        }



    }
}
