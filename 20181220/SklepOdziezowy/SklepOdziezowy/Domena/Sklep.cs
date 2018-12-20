using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Sklep
    {

        private List<Towar> koszyk = new List<Towar>();
        private decimal doZaplaty = 0;

        public Sklep()
        {
            RozpakujTowar();
        }

        private void RozpakujTowar()
        {
            RozpakujButy();
            RozpakujSpodnie();
            RozpakujKurtki();
        }

        private void RozpakujKurtki()
        {
            throw new NotImplementedException();
        }

        private void RozpakujSpodnie()
        {
            SpodnieWSklepie.Add(new Spodnie(
                50, Enums.Kolor.Czarny, Enums.Rozmiar.S, Enums.TypSpodni.Wojskowe));
            SpodnieWSklepie.AddRange(
                new[]
                {
                    new Spodnie(
                    50, Enums.Kolor.Czarny, Enums.Rozmiar.S,Enums.TypSpodni.Dżinsy),
                    new Spodnie(
                    60, Enums.Kolor.Moro, Enums.Rozmiar.XS,Enums.TypSpodni.Robocze),
                    new Spodnie(
                    70, Enums.Kolor.Pomarańczowy, Enums.Rozmiar.L,Enums.TypSpodni.Sztruksy),
                    new Spodnie(
                    80, Enums.Kolor.Szary, Enums.Rozmiar.XXXL,Enums.TypSpodni.Dresy),
                    new Spodnie(
                    90, Enums.Kolor.Biały, Enums.Rozmiar.XXS,Enums.TypSpodni.Garniturowe),
                    new Spodnie(
                    100, Enums.Kolor.Oktaryna, Enums.Rozmiar.M,Enums.TypSpodni.Garniturowe),
                    });
        }
        

        private void RozpakujButy()
        {
            throw new NotImplementedException();
        }

        private List<Buty> ButyWSklepie { get;  set; }
       private  List<Kurtki> KurtkiWSklepie { get;  set; }
        private List<Spodnie> SpodnieWSklepie { get;  set; }

        public void PrzymierzSpodnie( Rozmiar rozmiarklienta)
        {
            foreach (Spodnie spodnie in SpodnieWSklepie)
            {
                if (spodnie.Rozmiar == rozmiarklienta)
                {
                    koszyk.Add(spodnie);
                    doZaplaty += spodnie.Cena;
                }
            }
            }

        public void KupTowaryZKoszyka()
        {
            Console.WriteLine("Musisz zapłacić: {0} PLN", doZaplaty);
        }


        }



    }

