using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{ 
    internal interface GenerInterf <T>  // обобщенный интерфейс с операциями добавить, удалить, просмотреть.
    {
        void Add( T value );
        void Delete();
        void Show();
    }
}
