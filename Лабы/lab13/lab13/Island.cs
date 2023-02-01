
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
    public class Island : Government
    {
        [NonSerialized]
        public int pageNum;
        public Island( string name, int humanity, string head, string vallet ) : base(name, humanity, head, vallet)
        {
            this.name = name;
            this.humanity = humanity;
            this.head = head;
            this.vallet= vallet;
        }
        public Island() { }

    }


}
