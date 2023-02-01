using lab8;

namespace Lab8
{
    class Program
    {
        static void Main()
        {
            Programmer prog = new Programmer("Tani");
            PLanguage Csh = new PLanguage("C#",9.0f, "Полиморфизм", "Наследование", "Типизация");
            PLanguage SQL = new PLanguage("SQL", Math.Round(6.3f, 2), "Интерактивный", "Взаимодействие с БД");

            prog.Rename += Csh.OnRename; //событие Rename
            prog.NewProperty += Csh.OnDeleteProperty;
            prog.NewProperty += SQL.OnAddProperty;

            prog.CommandRenameOperation("Cpp");
            prog.CommandNewProp("Типизация");

            prog.NewProperty -= Csh.OnDeleteProperty;
            prog.NewProperty += Csh.OnAddProperty;

            prog.CommandNewProp("Взаимодействие с объектами");

            prog.Version += Csh.OnVersion;
            prog.CommandSetVersion(Math.Round(9.1f, 2));

            Console.WriteLine(Csh);
            Console.WriteLine(SQL);




            Func<string, string> func;
            Action<string> test2;
            Func<string, string> func2;
            Func<string, string> func3;
            Func<string, string> func4;


            func = str1 => {  //блочное лямбда-выражение(упрощенная запись анонимных методов) 
                char[] sign = { '.', ',', '!', '?', '-', ':', '+', '=' };

                for (int i = 0; i < str1.Length; i++)
                {
                    if (sign.Contains(str1[i]))
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                Console.WriteLine(str1);
                return str1;
            };

            test2 = delegate ( string str2 )   //анонимный метод
            {
                str2 += " DelegateAction";
                Console.WriteLine(str2);
            };

            func2 = str3 =>
            {
                str3 = str3.Replace(" ", "");
                Console.WriteLine(str3);
                return str3;
            };

            func3 = str4 =>
            {
                str4 = str4.ToUpper();
                Console.WriteLine(str4);
                return str4;
            };
            
            func4 = str5 =>
            {
                str5 = str5.ToLower();
                Console.WriteLine(str5);
                return str5;
            };



            string str = "one + five = seven";
            Console.WriteLine("\nСтрока в начале: " + str);
            Console.WriteLine("Преобразования: ");

            string s1, s2, s3;

            s1 = ForStrings.RemoveS(str, func); //удал знаков

            ForStrings.AddToString(s1, test2);//добавление строки

            s2 = ForStrings.RemoveSpaces(s1, func2);//удал пробелов

            s3 = ForStrings.Upper(s2, func3);

            ForStrings.Lower(s3, func4);


        }
    }
}