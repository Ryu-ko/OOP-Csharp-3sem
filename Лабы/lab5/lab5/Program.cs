using lab5;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab5
{
     class Program
    {
        static void Main( string[] args )
        {
            Water salted = new Water(1234, "солёная");
          
            GvmntInhabitant inh1 = new GvmntInhabitant("asd", 3600, true, "Норвегия");

            Water presnaya = new Water(4567, "пресная");

            Sea sea = new Sea("Саргассово море", 12, presnaya);
            Sea sea2 = new Sea("Красное море", 15, salted);

            Island island = new Island("Сицилия", "Италия", 6000000);
            Island island1 = new Island("Гренландия", "Дания", 55592);

            Continent continent = new Continent("Евразия", 2000000000);

            Government government = new Government("Республика Беларусь", "Александр Лукашенко", "BYN", 9100000, "Евразия");

            government.belt = GeoBelt.medium;

            Government government1 = new Government("США", "Joe Biden", "USD", 330000000, "Северная Америка");
            Government government2 = new Government("Республика Польша", "Анджей Дуда", "PLN", 385000000, "Евразия");

            government2.belt = (GeoBelt)5;

            PlanetEarth planet = new PlanetEarth();
            planet.Add(government1);
            planet.Add(sea2);
            planet.Add(island);
            planet.Add(continent);
            planet.Add(island1);
            planet.Add(government);
            planet.Add(sea);
            planet.Add(government2);
            planet.Print();

            PlanetEarthController PController = new PlanetEarthController();
            Console.WriteLine();

            PController.NOSeas(planet);
            Console.WriteLine();

            PController.ShowG(planet, continent);

            Island island2 = new Island("Северный", "Новая Зеландия", 3000000);
            Island island3 = new Island("Санторини", "Греция", 15500);
            Island island4 = new Island("Бали", "Индонезия", 46028);

            planet.Remove(government);
            planet.Remove(government1);
            planet.Add(island2);
            planet.Add(island3);

            Console.WriteLine();

            PController.NOSeas(planet);

            Console.WriteLine();

            PController.ShowG(planet, continent);

            planet.Add(island4);

            Console.WriteLine();

            PController.IslAlphabet(planet);


        }
    }
}