using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class PlanetEarthController
    {
        // класс-Контроллер, который управляет объектом-Контейнером и реализовать в нем запросы
        
        // все государства на заданном континенте
        //подсчитать количество морей
        //вывести острова по алфавиту

        private int goal;

        public void ShowG( PlanetEarth planet, Continent continent )
        {
            string res = " | ";
            foreach (var el in planet.List.Where(el => el is Government))
            {
                if (((Government)el).Cont == continent.Name)
                {
                    res += Convert.ToString(el.Name) + " | ";
                }
            }
            Console.WriteLine("Государства, находящиеся на континенте " + continent.Name + ":\n" + res);
        }

        public void NOSeas( PlanetEarth planet )
        {
            goal = 0;
            foreach (var el in planet.List.Where(el => el is Sea))
            {
                goal++;

            }

            Console.WriteLine("Количество морей = " + goal);
        }


        public void IslAlphabet( PlanetEarth planet )
        {
            Island[] islands = new Island[10];
            int i = 0;
            Island temp = new Island();
            foreach (var el in planet.List.Where(el => el is Island))
            {
                islands[i] = (Island)el;
                i++;
            }
            for (int a = 0; a < i - 1; a++)
            {
                for (int c = 0; c < i - 1; c++)
                {
                    if (islands[c].Name.CompareTo(islands[c + 1].Name) > 0)
                    {
                        temp = islands[c];
                        islands[c] = islands[c + 1];
                        islands[c + 1] = temp;
                    }

                }
            }
            Console.WriteLine("Острова в алфавитном порядке");
            for (int o = 0; o < 10; o++)
            {
                Console.WriteLine(islands[o]);
            }
        }

    }
}
