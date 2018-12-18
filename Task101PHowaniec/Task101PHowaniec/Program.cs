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
            public Ksiazka() { }
            public Ksiazka(string name, rodzaj type, bool czyprzeczytana)
            {
                this.nazwa = name;
                this.rodzaj = type;
                this.przeczytana = czyprzeczytana;
            }
            public string nazwa { get; set; }
            public rodzaj rodzaj { get; set; }
            public bool przeczytana { get; set; }

            public bool CzytanieKsiazki()
            {
                Console.WriteLine("Czytana ksiazka {0}", nazwa);
                przeczytana = true;
                return przeczytana;
            }

        }

        public class Biblioteka
        {
            public List<Ksiazka> KsiazkiFantasy = new List<Ksiazka>();
            public List<Ksiazka> KsiazkiFantasyPrzeczytane = new List<Ksiazka>();
            public Biblioteka()
            {
                KsiazkiFantasy.Add(new Ksiazka("Harry Potter 1", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("Harry Potter 2", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("Harry Potter 3", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("LOTR", rodzaj.fantasy, false));
                KsiazkiFantasy.Add(new Ksiazka("Matrix", rodzaj.fantasy, false));
            }

            public Ksiazka FirstUnreadFantasyBook()
            {
                Ksiazka pierwszaNieprzeczytanaKsiazka = new Ksiazka();  
                foreach(var book in KsiazkiFantasy)
                {
                    if(book.przeczytana == false)
                    {
                        pierwszaNieprzeczytanaKsiazka = book;
                        break;
                    }
                }
                return pierwszaNieprzeczytanaKsiazka;
            }
        }

        public static void OdlozPrzeczytanaKsiazke(Ksiazka ksiazka, List<Ksiazka> KsiazkiPrzeczytane)
        {
            if(ksiazka.CzytanieKsiazki())
            {
                KsiazkiPrzeczytane.Add(ksiazka);
                Console.WriteLine("Odkladanie przeczytaj ksiazki {0} na polke przeczytanych ksiazek {1}", ksiazka.nazwa, ksiazka.rodzaj);
            } 
        }

        static void Main(string[] args)
        {
            // biblioteka -> filtr -> ksiazki fantasy
            // ksiazki fantasy -> filtr -> k.f. nieprzeczytane
            // kfnp -> wybierz ksiazke -> ksiazka
            // (ksiazka 3h) -> czytam -> ksiazki przeczytane
            // (k.przeczytane, pula ksiazek fantasy) -> wsadz ksiazke -> -o-

            Biblioteka Bibl = new Biblioteka();

            Ksiazka ks = Bibl.FirstUnreadFantasyBook();
           // ks.CzytanieKsiazki();
            OdlozPrzeczytanaKsiazke(ks, Bibl.KsiazkiFantasyPrzeczytane);
            
        }
    }
}
