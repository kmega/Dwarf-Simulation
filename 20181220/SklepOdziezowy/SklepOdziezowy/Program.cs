using System;

namespace SklepOdziezowy.Domena
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //1. nowa klasa buty -> nadanie wlasciwosci butom
            // zamkniety zbior wartosci -> enum -> dostep globalny, dlatego jest w osobnym pliku
            //duplikacja kodu -> WIELKI BLAD
            //namespace -> zasieg nazw
            Sklep Sklep = new Sklep();
            Sklep.PrzymierzSpodnie(RozmiarSpodni.M);
            Sklep.KupTowaryWSklepie();
        }
    }
}
