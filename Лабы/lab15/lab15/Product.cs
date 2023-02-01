using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    internal class Product
    {
        public string Name { get; set; }
        public uint Price { get; set; }

        public Product( string name,
                       uint price )
        {
            Name = name;
            Price = price;
        }

        public Product()
        {
            Name = String.Empty;
            Price = 0;
        }

        public override string ToString() => $"Имя: {Name}, Цена: {Price}";
    }
}
