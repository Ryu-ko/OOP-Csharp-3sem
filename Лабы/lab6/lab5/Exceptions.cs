using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class HumanityExceprtion : Exception //базовый класс всех типов исключений в C#
    {
        public HumanityExceprtion( string message ) : base(message) { }
    }

    internal class WaterException : ArgumentException
    {
        public WaterException( string message ) : base(message) { }
    }

    internal class NameException : NullReferenceException
    {
        public NameException( string message ) : base(message)
        {
        }
    }
}
