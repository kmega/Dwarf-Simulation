using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sklepOdziezowy.Domena;
using sklepOdziezowy.Enums;


namespace sklepOdziezowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep();

            sklep.PrzymierzSpodnie(Rozmiar.M);

        }
    }
}
