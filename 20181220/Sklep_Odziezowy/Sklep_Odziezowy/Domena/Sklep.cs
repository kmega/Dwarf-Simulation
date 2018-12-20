using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sklep_Odziezowy.Enums;

namespace Sklep_Odziezowy.Domena
{
    class Sklep
    {
        private List<Towar> Koszyk = new List<Towar>();
        private decimal doZaplaty = 0;
        public Sklep()
        {
            Rozpakuj_Towary();
        }

        private void Rozpakuj_Towary()
        {
            Rozpakuj_Buty();
            Rozpakuj_Spodnie();
        }

        private void Rozpakuj_Spodnie()
        {
            Spodnie_W_Sklepie.Add(
                new Spodnie(
                    50, 
                    Kolor.Black, 
                    Typ_Spodni.
                    Do_Garnituru, 
                    Rozmiar_Spodni.L));
            Spodnie_W_Sklepie.AddRange(
                new[] {
                     new Spodnie(
                        60,
                        Kolor.Green,
                        Typ_Spodni.
                        Dresy,
                        Rozmiar_Spodni.S),

                     new Spodnie(
                        50,
                        Kolor.Black,
                        Typ_Spodni.
                        Do_Garnituru,
                        Rozmiar_Spodni.L),

                    new Spodnie(
                        150,
                        Kolor.White,
                        Typ_Spodni.
                        Do_Garnituru,
                        Rozmiar_Spodni.XL),
                });
        }

        private void Rozpakuj_Buty()
        {
        }

        public List<Buty> Buty_W_Sklepie { get; private set; }
        public List<Spodnie> Spodnie_W_Sklepie { get; private set; }

        public void Przymierz_Spodnie(Rozmiar_Spodni rozmiar_klienta)
        {
            foreach (var spodnie in Spodnie_W_Sklepie)
            {
                if (spodnie.Rozmiar == rozmiar_klienta)
                {
                    Koszyk.Add(spodnie);
                    doZaplaty += spodnie.Cena;
                }

            }
        }

        public void KupTowaryZKoszyka()
        {
            Console.WriteLine("Musisz zapłacić: " + doZaplaty);
        }
    }
}

