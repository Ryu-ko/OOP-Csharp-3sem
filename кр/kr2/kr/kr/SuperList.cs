using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    internal class SuperList<T> : List<int>//не так надо обьявить List<T> list; внутри класса и там уже это обработать
    {  
        
        
        public bool Find( T item )
        {
            if (Contains(Convert.ToInt32(item)))
            {
                return true;
            }
            else {
                
                throw new ArgumentException();
            }   
           return false;
  
        }


    }
}
