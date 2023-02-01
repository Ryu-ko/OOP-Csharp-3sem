
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;

namespace lab13
{
    [Serializable]
    public abstract class Government
    {
        public string name;
        public int humanity;
        public string head;
        public string vallet;

        public Government( string name, int humanity, string head, string vallet )
        {
            this.name = name;
            this.humanity = humanity;
            this.head = head;
            this.vallet = vallet;
        }

        public Government() { }

        public override string ToString() => GetType().Name;
        public override bool Equals( object obj ) => GetType().Name == obj.ToString();

    }
}
