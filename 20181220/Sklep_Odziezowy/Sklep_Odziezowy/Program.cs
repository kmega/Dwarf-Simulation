using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_Odziezowy.Domena;
using Sklep_Odziezowy.Enums;

namespace Sklep_Odziezowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep();

            sklep.Przymierz_Spodnie(Rozmiar_Spodni.M);
            sklep.KupTowaryZKoszyka();

        }
    }
}
