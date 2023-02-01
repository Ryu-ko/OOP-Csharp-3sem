using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class Dvlp
    {
        readonly int id;
        string fio;
        string company;

        public Dvlp(int id, string fio, string company )
        {
            this.id = id;
            this.fio = fio;
            this.company = company;
        }

        public void PrintVal()
        {
            Console.WriteLine($"iD: {id} \nФИО: {fio} \nНазвание компании: {company} ");
        }

    }
}
