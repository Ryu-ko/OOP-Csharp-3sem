using System;


namespace Program
{

    //Создать класс Airline: Пункт назначения, Номер рейса, Тип самолета, Время вылета, Дни недели.
    //Свойства и конструкторы должны обеспечивать проверку корректности.
    //Создать массив объектов.
     public partial class Airline //Частичные классы (partial classes) – конструкция, которая позволяет определить один класс в нескольких файлах.
    { //Для хранения данных в классе применяются поля - это переменные, определенные на уровне класса.
      
        public readonly int id;
        private string destination;//пункт назначения
        private uint flight_number; //номер рейса 6 цифр
        private const string airplane_type= "Boeing";//тип самолета  
        private string departure_time;//время вылета
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
        public string Airplane_Type { get => airplane_type;}
        public string Departure_time { get => departure_time; set => departure_time = value; }
        public string Weekday { get => weekday; set => weekday = value; }

        //Конструкторы
        public Airline() //конструктор буз параметров
        {
            destination = "Berlin";//пункт назначения
            flight_number = 323412; //номер рейса 6 цифр
            departure_time = "18:00";//время вылета
            weekday = "Saturday";
            id = GetHashCode();
        }

        //с параметрами
        public Airline( string destination, uint flight_Num, string airplane_Type, string departure_time, string weekday )
        {
            id = GetHashCode();
            Weekday = weekday;
            Flight_Num = flight_Num;
            this.destination = destination;//чтобы разграничить параметры и поля класса, к полям класса обращение идет через ключевое слово this.  
            this.weekday = weekday;
            this.departure_time = departure_time;
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
            Console.WriteLine($"Количесво созданых объектов в настоящий момент {numObj}");
            
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
            return  $"ID: {this.id}\n" +
                    $"Пункт назначения: {this.destination}\n" +
                    $"Номер рейса: {this.flight_number}\n" +
                    $"Тип самолета: {airplane_type}\n" +
                    $"Время вылета: {this.departure_time}\n" +
                    $"День недели: {this.weekday}\n";
        }

        public void Func( ref string  val1, out string val2 )
        {
            Console.WriteLine(val1);
            val2 = "Minsk"; // Обязательно
            Console.WriteLine(val2);
        }

    }
    class Class1
    {
        static void Main( string[] args )
        {

            Airline airline0 = new Airline();
            string dep1 = "Berlin",// ref, должно быть присвоено значение до вызова метода.
                dep2;
            airline0.Func(ref dep1, out dep2); //организовать вместо вызова по значению вызов по ссылке

            Airline airline1 = new Airline();
            Console.WriteLine("\nОбъект, созданный конструктором по умолчанию: ");

            Console.WriteLine( airline1.ToString());

            Console.WriteLine("Задайте количество Рейсов: ");
            int numOfAirL = int.Parse(Console.ReadLine());

            Airline[] DB_Airline = new Airline[numOfAirL];          //создаём массив классов с БД о пользователях
            DB_Airline[0]=new Airline("Минск", 123412, "18:00", "пон"," ");
            Console.WriteLine();

            for (int i = 1; i < numOfAirL; i++)
            {
                DB_Airline[i] = new Airline();

                Console.WriteLine("Введите пункт назначения: ");
                DB_Airline[i].Destination = Console.ReadLine();
                Console.WriteLine("Введите номер рейса (6 цифр): ");
                DB_Airline[i].Flight_Num = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Введите время вылета (прим. 15:30): ");
                DB_Airline[i].Departure_time = Console.ReadLine();
                Console.WriteLine("Введите день недели: ");
                DB_Airline[i].Weekday = Console.ReadLine();
                Console.WriteLine();
                
            }


            //a) список рейсов для заданного пункта назначения;
            Console.WriteLine();
            Console.WriteLine("Введите пункт назначения для вывода списка рейсов: "); 
            string checkDestination = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Список рейсов для пункта назначения {checkDestination}");
            for (int k = 0; k < numOfAirL; k++)
            {
                if (DB_Airline[k].Destination == checkDestination)
                {              
                    Console.WriteLine($"{DB_Airline[k].Flight_Num}\t{DB_Airline[k].Airplane_Type}\t  {DB_Airline[k].Departure_time} \t {DB_Airline[k].Weekday}"); 
                }
            }
            Console.WriteLine();


            //b) список рейсов для заданного дня недели;
            Console.WriteLine("Введите день недели для вывода списка рейсов: ");
            string checkWeekday = Console.ReadLine();
            Console.WriteLine();
            
            Console.WriteLine($"Список рейсов для дня недели {checkWeekday}");
            for (int k = 0; k < numOfAirL; k++)
            {
                if (DB_Airline[k].Weekday == checkWeekday)
                {
                    Console.WriteLine($"{DB_Airline[k].Destination}\t {DB_Airline[k].Flight_Num}\t{DB_Airline[k].Airplane_Type}\t  {DB_Airline[k].Departure_time}");
                }
            }




        }
    }
}