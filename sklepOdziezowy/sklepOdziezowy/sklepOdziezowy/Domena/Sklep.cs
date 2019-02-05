using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sklepOdziezowy.Domena;
using sklepOdziezowy.Enums;

namespace sklepOdziezowy.Domena
{
    class Sklep
    {
        private List<Towar> koszyk;
        private decimal doZaplaty = 0;
        
        public Sklep()
        {
            RozpakujTowary();
        }

        private void RozpakujTowary()
        {
            RozpakujButy();
            RozpakujSpodnie();
            
        }

        private void RozpakujSpodnie()
        {
            SpodnieWSklepie.Add(new Spodnie(50, Kolory.Czarny, TypySpodni.Sztruks, Rozmiar.L, FasonySpodni.Regular));
            SpodnieWSklepie.Add(new Spodnie(550, Kolory.Czarny, TypySpodni.Garniturowe, Rozmiar.L, FasonySpodni.Slim));
            SpodnieWSklepie.Add(new Spodnie(150, Kolory.Czarny, TypySpodni.Ocieplane, Rozmiar.L, FasonySpodni.Regular));
            SpodnieWSklepie.Add(new Spodnie(100, Kolory.Czarny, TypySpodni.Jeans, Rozmiar.L, FasonySpodni.Slim));
        }

        private void RozpakujButy()
        {
            
        }

        public void PrzymierzSpodnie(Rozmiar rozmiarKlienta)
        {
            foreach (var spodnie in SpodnieWSklepie)
            { 
                if (spodnie.Rozmiar == rozmiarKlienta)
                {
                    koszyk.Add(spodnie);
                    doZaplaty += spodnie.Cena;
                }
            }
        }

        public void KupTowaryZkoszyka()
        {
            if (koszyk.Any())
            {
               Console.WriteLine($"Musisz zapłacić {doZaplaty} PLN");
                Console.ReadKey();
            }
            
        }

        List<Buty> ButyWSklepie { get; set; }
        List<Spodnie> SpodnieWSklepie { get; set; }
    }
}
