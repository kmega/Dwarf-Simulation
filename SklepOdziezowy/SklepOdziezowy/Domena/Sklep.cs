using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    // domyslny typ dla klas to internal (czyli dostepny tylko w tym projekcie)
    class Sklep
    {
        private List<Towar> Koszyk = new List<Towar>();
        private decimal DoZaplaty = 0;

        public Sklep()
        {
            RozpakujTowary();
        }

        //zasada pojedynczej odpowiedzielnosci, jedna metoda odpowiada jednej czynnosci
        private void RozpakujTowary()
        {
            RozpakujSpodnie();
            RozpakujButy();
        }

        private void RozpakujButy()
        {
            ButyWSklepie.Add(new Buty());
        }

        private void RozpakujSpodnie()
        {
            SpodnieWSklepie.Add(new Spodnie(50, Kolor.Czarny, TypSpodni.Dzinsy, RozmiarSpodni.L));
            SpodnieWSklepie.Add(new Spodnie(175, Kolor.Niebieski, TypSpodni.Dzinsy, RozmiarSpodni.L));
            //AddRange dodaje wiele rzeczy(obiektow w tym przypadku) na raz
            SpodnieWSklepie.AddRange(new[] { new Spodnie(147, Kolor.Zielony, TypSpodni.Robocze, RozmiarSpodni.L),
                new Spodnie(450, Kolor.Czarny, TypSpodni.Garniturowe, RozmiarSpodni.L),
                new Spodnie(250, Kolor.Niebieski, TypSpodni.Dresy, RozmiarSpodni.XL),
                new Spodnie(250, Kolor.Bialy, TypSpodni.Garniturowe, RozmiarSpodni.XL) } );
        }

        // prywatny setter i publiczny getter, czyli tylko nasza klasa moze modyfikowac liste ale dostep jest publiczny
        public List<Buty> ButyWSklepie = new List<Buty>();
        public List<Spodnie> SpodnieWSklepie = new List<Spodnie>();
        List<Kurtki> KurtkiWSklepie { get; set; }
        //lista to typ generyczny czyli typ do przechowywania roznego rodzajow danych

        public void PrzymierzSpodnie(RozmiarSpodni rozmiarKlienta)
        {
            foreach(Spodnie spodnie in SpodnieWSklepie)
            {
                if(spodnie.Rozmiar == rozmiarKlienta)
                {
                    Koszyk.Add(spodnie);
                    DoZaplaty += spodnie.Cena;
                }
            }
        }

        public void KupTowaryZKoszyka()
        {
            if (Koszyk.Any())
            {
                Console.WriteLine($"Musisz zaplacic: {DoZaplaty} PLN");
            }
        }
    }
}
 