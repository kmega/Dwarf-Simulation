using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task101PHowaniec
{
    class Program
    {
        public enum rodzaj
        {
            fantasy
        }

        public class Ksiazka
        {
            public Ksiazka(string name, rodzaj type, bool czyprzeczytana)
            {
                this.nazwa = name;
                this.rodzaj = type;
                this.czyprzeczytana = czyprzeczytana;
            }
            public string nazwa { get; set; }
            public rodzaj rodzaj { get; set; }
            public bool czyprzeczytana { get; set; }

        }

        public class Biblioteka
        {
            List<Ksiazka> KsiazkiFantasy = new List<Ksiazka>();
            List<Ksiazka> KsiazkiFantasyNieprzeczytane = new List<Ksiazka>();
            List<Ksiazka> KsiazkiFantasyPrzeczytane = new List<Ksiazka>();
            public Biblioteka()
            {
                KsiazkiFantasy.Add(new Ksiazka("Harry Potter 1", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("Harry Potter 2", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("Harry Potter 3", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("LOTR", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("Matrix", rodzaj.fantasy, false));
            }

            internal Ksiazka FirstUnreadFantasyBook()
            {
                
                throw new NotImplementedException();
            }
        }

        public Ksiazka WybierzKsiazke(Ksiazka ksiazka)
        {

            return ksiazka;
        }

        public bool CzytanieKsiazki(Ksiazka ksiazka)
        {
            ksiazka.czyprzeczytana = true;
            return ksiazka.czyprzeczytana;
        }

        public void OdlozPrzeczytanaKsiazke(Ksiazka ksiazka, List<Ksiazka> KsiazkiFantasyPrzeczytane)
        {
            
        }

        static void Main(string[] args)
        {
            // biblioteka -> filtr -> ksiazki fantasy
            // ksiazki fantasy -> filtr -> k.f. nieprzeczytane
            // kfnp -> wybierz ksiazke -> ksiazka
            // (ksiazka 3h) -> czytam -> ksiazki przeczytane
            // (k.przeczytane, pula ksiazek fantasy) -> wsadz ksiazke -> 

            Biblioteka Bibl = new Biblioteka();

            Ksiazka ks = Bibl.FirstUnreadFantasyBook();
            

        }
    }
}
