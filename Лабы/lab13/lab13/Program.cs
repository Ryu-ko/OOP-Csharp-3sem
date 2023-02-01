using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace lab13
{
    class Program
    {
        static void Main( string[] args )
        {
            Island isl1 = new Island("Япония ", 125440000, " Фумио Кисида ", "иена ");
            Island isl2 = new Island("Сингапур ", 5453600, " Тони Тан Кен Ям ", "Сингапурский доллар ");
            Island isl3 = new Island("Куба ", 11008112, " Рауль Кастро ", "Кубинское песо ");
            Island isl4 = new Island("Исландия ", 364000, " Гуни Торласиус Йоханнессон ", "Исландская крона ");
            Island isl5 = new Island("Ямайка ", 2930050, " Эндрю Холнесс ", "Ямайский доллар ");


            // ----- сериализация ------

            CustomSerializer<Island>.Serialize(isl1, SERIALIZETYPE.XML, @"F:\.Уник\2 курс\ООП С#\Лабы\lab13");
            CustomSerializer<Island>.Serialize(isl1, SERIALIZETYPE.JSON, @"F:\.Уник\2 курс\ООП С#\Лабы\lab13");
            CustomSerializer<Island>.Serialize(isl1, SERIALIZETYPE.Binary, @"F:\.Уник\2 курс\ООП С#\Лабы\lab13");
            //CustomSerializer<Island>.Serialize(isl1, SERIALIZETYPE.SOAP, @"F:\.Уник\2 курс\ООП С#\Лабы\lab13");


            // ----- десериализация ------

            var xmlIsl = CustomSerializer<Island>.Deserialize(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\lab13.Island.xml");
            var jsonIsl = CustomSerializer<Island>.Deserialize(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\lab13.Island.json");
            var binIsl = CustomSerializer<Island>.Deserialize(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\lab13.Island.bin");
            //var soapIsl = CustomSerializer<Island>.Deserialize(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13.Island.soap");


            //----- 2.  Коллекция объектов, сериализация/десирализация, сохранение в файл

            List<Island> islList = new List<Island>() {isl1, isl2, isl3, isl4 };

            CustomSerializer<Island>.Serialize(islList, SERIALIZETYPE.XML, @"F:\.Уник\2 курс\ООП С#\Лабы\lab13");
            CustomSerializer<Island>.Serialize(islList, SERIALIZETYPE.JSON, @"F:\.Уник\2 курс\ООП С#\Лабы\lab13");

            var xmlList= CustomSerializer<Island>.DeserializeToList(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\System.Collections.Generic.List`1[lab13.Island].xml");
            var jsonList = CustomSerializer<Island>.DeserializeToList(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\System.Collections.Generic.List`1[lab13.Island].json");


            //----- 3. XPath представляет язык запросов в XML. Он позволяет выбирать элементы, соответствующие определенному селектору.

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\System.Collections.Generic.List`1[lab13.Island].xml");
            var xroot = xmlDocument.DocumentElement;

            var selectNodes = xroot.SelectNodes("*");

            foreach (var item in selectNodes)
            {
                Console.WriteLine((item as XmlNode).InnerText);
            }

            Console.WriteLine("\n\n");

            var namesNodes = xroot.SelectNodes("Island[name='Япония ']");

            foreach (var item in namesNodes)
            {
                Console.WriteLine((item as XmlNode).InnerText);
            }


            //----- 4.  LINQ to XML

            Console.WriteLine("\nLINQ to XML:");

            XDocument xdoc = new XDocument();
                    
                    //первый эл
            XElement island = new XElement("island"); 

            XAttribute isl_name_atr = new XAttribute("name", "Япония");

            XElement bs_humanity_elem = new XElement("humanity", "125440000");
            XElement bs_head_elem = new XElement("head", "Фумио Кисида");

            island.Add(isl_name_atr);            //заполняем аттрибутом и элем-ми
            island.Add(bs_humanity_elem);
            island.Add(bs_head_elem);

                    //второй эл
            XElement island2 = new XElement("island");    

            XAttribute isl2_name_atr = new XAttribute("name", "Сингапур");

            XElement bs2_humanity_elem = new XElement("humanity", "5453600");
            XElement bs2_head_elem = new XElement("head", "Тони Тан Кен Ям");

            island2.Add(isl2_name_atr);          //заполняем аттрибутом и элем-ми
            island2.Add(bs2_humanity_elem);
            island2.Add(bs2_head_elem);

                    //третий эл
            XElement island3 = new XElement("island");    

            XAttribute isl3_name_atr = new XAttribute("name", "Куба");

            XElement bs3_humanity_elem = new XElement("humanity", "11008112");
            XElement bs3_head_elem = new XElement("head", "Рауль Кастро");

            island3.Add(isl3_name_atr);          //заполняем аттрибутом и элем-ми
            island3.Add(bs3_humanity_elem);
            island3.Add(bs3_head_elem);


            XElement root = new XElement("root");   //корневой элемент
            root.Add(island);
            root.Add(island2);
            root.Add(island3);
            xdoc.Add(root);
            xdoc.Save(@"F:\.Уник\2 курс\ООП С#\Лабы\lab13\Island_4.xml");
            //сохраняем в файл


            /* функциональное создание
             * XDocument xdoc = new XDocument( new XElement ("Islands",

                                                  new XElement("island", 
                                                      new XAttribute("title","Japan"),

                                                      new XElement("humanity", "125440000"),
                                                      new XElement("head", "Фумио Кисида")
                                                              ),

                                                   new XElement("island",
                                                      new XAttribute("title", "Cuba"),

                                                      new XElement("humanity", "11008112"),
                                                      new XElement("head", "Рауль Кастро")
                                                              )
                                                   )
                                                ); //создаем новый хмл док c инфой
              xdoc.Save("IslandLinq.xml");
           */


            // ------ запросы ----------

            Console.WriteLine("Запрос 1: по правителю(Фумио Кисида)"); //1-й запрос

            var items = xdoc.Element("root").Elements("island")
                                .Where(p => p.Element("head").Value == "Фумио Кисида")
                                .Select(p => p);

            foreach (var item in items)
            {
                Console.WriteLine(item.Attribute("name").Value + " - " + item.Element("head").Value);
            }

            Console.WriteLine();


            Console.WriteLine("Запрос 2: по названию");
            var coun = xdoc.Element("root").Elements("island")
                .Where(p => p.Attribute("name").Value == "Сингапур")
                .Select(p => p);
            foreach (var c in coun)
            {
                Console.WriteLine(c.Attribute("name").Value + " - " + c.Element("head").Value);
            }


        }
    }
}