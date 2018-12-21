using System;
using System.Collections.Generic;
using SklepOdziezowy.Enum;

namespace SklepOdziezowy.Domena
{
    class Sklep
    {
        //wspolny interfejs
        //zly -> object
        private List<Towar> koszyk = new List<Towar>(); //polimorfizm here
        private decimal DoZaplaty = 0;

        public Sklep()
        {
            ButyWSklepie = new List<Buty>();
            SpodnieWSklepie = new List<Spodnie>();
            RozpakujTowary();
        }

        private void RozpakujTowary()
        {
            RozpakujButy();
            RozpakujSpodnie();
        }

        private void RozpakujSpodnie()
        {
            SpodnieWSklepie.Add(new Spodnie(50, Color.Black, RozmiarSpodni.L,
                                            FasonSpodni.Dopasowane));
            SpodnieWSklepie.AddRange(
                new[] {
                new Spodnie(70, Color.Green, RozmiarSpodni.S, FasonSpodni.Luzne),
                new Spodnie(170, Color.Red, RozmiarSpodni.XL, FasonSpodni.zDziurami),
                }
            );
        }

        private void RozpakujButy()
        {

        }

        public List<Buty> ButyWSklepie { get; private set; }
        public List<Spodnie> SpodnieWSklepie { get; private set; }

        public void PrzymierzSpodnie(RozmiarSpodni rozmiarSpodni)
        {
            foreach(Spodnie spodnie in SpodnieWSklepie)
            {
                if(spodnie.Rozmiar == rozmiarSpodni)
                {
                    koszyk.Add(spodnie);
                    DoZaplaty += spodnie.Cena;
                }
            }
        }

        public void KupTowaryWSklepie()
        {
            if(koszyk.Count > 0)
            {
                Console.WriteLine("Musisz zaplacic: {0} PLN", DoZaplaty);
            }
            else{
                Console.WriteLine("Nic nie pasuje");
            }
        }

    }
}
