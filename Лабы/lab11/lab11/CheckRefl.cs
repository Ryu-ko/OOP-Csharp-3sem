using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
     public class CheckRefl : ISample, IComparable<CheckRefl>
     {
        public int? someint;
        public string? somestr;

        public CheckRefl()
        {

        }
        public CheckRefl( string strparam, int intparam )
        {
            someint = intparam;
            somestr = strparam;
        }
        private CheckRefl( string str )
        {
            somestr = str;
        }

        public int CompareTo( CheckRefl? other )
        {
            return (somestr.CompareTo(other.somestr));
        }

        public int RandNum()
        {
            return (int)someint * RandNum();
        }

        public void StrMod( string a )
        {
            somestr += a;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("321123");
        }
        public override string ToString()
        {
            return "Экземпляр CheckRefl: " + somestr + ", " + Convert.ToString(someint);
        }
        public string VoidWrite( string a )
        {
            return ("12#!#" + a + "oekjiru");
        }
    }
}
