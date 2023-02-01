using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public struct GvmntInhabitant //равительство в населенном пункте
    {
        public string Profession = "Структура";
        public int Revenue;
        bool Happiness;
        string GvName;

        public GvmntInhabitant(string profession, int revenue, bool happiness, string gvname )
        {
            Profession = profession;
            Revenue = revenue;
            Happiness = happiness;
            GvName = gvname;
        }
        public static int sample()
        {
            return 1;
        }

    }
}
