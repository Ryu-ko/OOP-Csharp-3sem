using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{

    public delegate void RenameEventHandler( string name );
    public delegate void NewPropertyEventHandler( string name );
    public delegate void VersionEventHandler( double ver );


    internal class Programmer // с событиями Переименовать и Новое свойство.
    {
        private string name;

        public Programmer ( string name )//конструктор
        {
            this.name = name;
        }

        public event RenameEventHandler Rename;
        public event NewPropertyEventHandler NewProperty;
        public event VersionEventHandler Version;

        //методы на проверку работы евентов

        public void CommandNewProp( string n )
        {
            NewProperty.Invoke(n); // вызывает метод в том потоке, где он был создан
            Console.WriteLine("\n-- Вызвано событие изменения свойств --");

        }
        public void CommandRenameOperation( string n )
        {
            Rename.Invoke(n);
            Console.WriteLine("\n-- Вызвано событие Rename --");
        }
        public void CommandSetVersion( double v )
        {
            Version.Invoke(v);
            Console.WriteLine("\n--  Вызвано событие изменения версии --");
        }



    }
}
