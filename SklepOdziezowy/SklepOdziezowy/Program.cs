using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Domena;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep();
            sklep.PrzymierzSpodnie(RozmiarSpodni.XL);

            Console.ReadLine();
        }
    }
}
