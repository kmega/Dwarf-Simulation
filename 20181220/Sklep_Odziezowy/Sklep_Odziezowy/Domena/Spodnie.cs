using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_Odziezowy.Enums;

namespace Sklep_Odziezowy.Domena
{
    class Spodnie : Towar
    {
        public Spodnie(decimal cena, Kolor kolor, Typ_Spodni typ_spodni, Rozmiar_Spodni rozmiar_spodni)
        {

            if (WalidujDane(cena))
            {
                Cena = cena;
                Kolor = kolor;
                Typ = typ_spodni;
                Rozmiar = rozmiar_spodni;

                uzywane = false;
            }
            
         }
        private bool uzywane;
        public Typ_Spodni Typ { get; private set; }
        public Fason_Spodni Fason { get; private set; }
        public Kolor Kolor { get; private set; }
        public Rozmiar_Spodni Rozmiar { get; private set; }
        public decimal Cena { get; private set; }


       private bool WalidujDane(decimal cena)
        {
            return cena >= 0;
        }
    }
}
