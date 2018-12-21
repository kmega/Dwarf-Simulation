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
            NowyKlient("Pawel", Kolor.Czarny, RozmiarSpodni.XL);
            NowyKlient("Urszula", Kolor.Niebieski, RozmiarSpodni.L);
            NowyKlient("Mariola", Kolor.Szary, RozmiarSpodni.S);
            NowyKlient("Mietek", Kolor.Czarny, RozmiarSpodni.L);

            Console.ReadLine();
        }

        public static void NowyKlient(string imie, Kolor kolor, RozmiarSpodni rozmiar)
        {
            Klient klient = new Klient
            {
                Imie = imie,
                KolorSpodni = kolor,
                RozmiarSpodni = rozmiar
            };

            klient.PrzymierzSpodnie();
            klient.KupTowaryZKoszyka();
        }
    }
}

//klasa klient
//marcin.balda@gmail.com