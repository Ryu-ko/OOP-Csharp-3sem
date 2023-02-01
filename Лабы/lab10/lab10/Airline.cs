using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public partial class Airline //Частичные классы (partial classes) – конструкция, которая позволяет определить один класс в нескольких файлах.
    { //Для хранения данных в классе применяются поля - это переменные, определенные на уровне класса.

        public readonly int id;
        private string destination;//пункт назначения
        private uint flight_number; //номер рейса 6 цифр
        private  string airplane_type ;//тип самолета  
        //private string departure_time;//время вылета
        private DateTime _TimeOfDep;
        private string weekday;//день недели


        //Cвойства

        public string Destination { get => destination; set => destination = value; }
        public uint Flight_Num
        {
            get => flight_number;
            set
            {
                if (value > 999999 && value < 100000)
                {
                    Console.WriteLine("Неверный номер рейса!");
                }
                else
                {
                    flight_number = value;
                }
            }
        }
        public string Airplane_Type { get => airplane_type; set => airplane_type = value; }
        //public string Departure_time { get => departure_time; set => departure_time = value; }
        public DateTime TimeOfDep
        {
            set { this._TimeOfDep = value; }
            get { return this._TimeOfDep; }
        }
        public string Weekday { get => weekday; set => weekday = value; }

        //Конструкторы
        public Airline() //конструктор буз параметров
        {
            destination = "Berlin";//пункт назначения
            flight_number = 323412; //номер рейса 6 цифр
            _TimeOfDep = new DateTime(2022, 12, 05, 07, 45, 00);
            weekday = "Saturday";
            id = GetHashCode();
        }

        //с параметрами
        public Airline( string destination, uint flight_Num, string airplane_Type, string weekday, DateTime TimeOfDep )
        {
            id = GetHashCode();
            Weekday = weekday;
            Flight_Num = flight_Num;
            this.destination = destination;//чтобы разграничить параметры и поля класса, к полям класса обращение идет через ключевое слово this.  
            this.weekday = weekday;
            _TimeOfDep = TimeOfDep;
            Airplane_Type = airplane_Type;
        }

        // закрытый
        //Закрытые конструкторы используются, чтобы не допустить
        //создания экземпляров класса при отсутствии полей или методов экземпляра

        private Airline( int id, string destination )
        {
            this.id = id;
            this.destination = destination;
        }
        // предотвращает создание объекта класса из-вне. Используется в синглтонах и фабриках.

        static int numObj;  //статическое поле, хранящее количество созданных объектов
        static void classInfo()   //статический метод вывода информации о классе
        {
            numObj = 0;
            Console.WriteLine($"\nКоличесво созданых объектов в настоящий момент {numObj}\n");

        }

        //Статический конструктор используется для инициализации
        //любых статических данных или для выполнения определенного действия,
        //которое требуется выполнить только один раз. 
        //для всех обьектов 1 раз и все видно что он сделал

        static Airline()
        {
            classInfo();
            Console.WriteLine("\nВаши данные:");
        }

        public override string ToString() // переопределение метода ToString Используется по умолчанию для получения имени объекта
        {
            return $"ID: {this.id}\n" +
                    $"Пункт назначения: {this.destination}\n" +
                    $"Номер рейса: {this.flight_number}\n" +
                    $"Тип самолета: {this.airplane_type}\n" +
                    $"Время вылета: {_TimeOfDep}\n" +
                    $"День недели: {this.weekday}\n";
        }

        public void Func( ref string val1, out string val2 )
        {
            Console.WriteLine(val1);
            val2 = "Minsk"; // Обязательно
            Console.WriteLine(val2);
        }

    }
}
