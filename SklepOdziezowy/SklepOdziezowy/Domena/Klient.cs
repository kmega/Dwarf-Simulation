using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Enums;
using SklepOdziezowy.Domena;

namespace SklepOdziezowy.Domena
{
    class Klient
    {
        public string Imie { get; set; }
        public RozmiarSpodni RozmiarSpodni { get; set; }
        public Kolor KolorSpodni { get; set; }

        Sklep sklep = new Sklep();
        
        public List<Spodnie> PobierzListeSpodni()
        {
            List<Spodnie> SpodnieWSklepie = sklep.PobierzListeSpodni();
            return SpodnieWSklepie;
        }

        public void PrzymierzSpodnie()
        {
            foreach (Spodnie spodnie in PobierzListeSpodni())
            {
                if (spodnie.Rozmiar == RozmiarSpodni && spodnie.Kolor == KolorSpodni)
                {
                    sklep.Koszyk.Add(spodnie);
                    sklep.DoZaplaty += spodnie.Cena;
                }
            }
        }

        public void KupTowaryZKoszyka()
        {
            if (sklep.Koszyk.Any())
            {
                sklep.WyswietlKoszyk();
                Console.WriteLine($"{Imie}, za zakupy placisz lacznie: {sklep.DoZaplaty} PLN");
            }
        }
    }
}
