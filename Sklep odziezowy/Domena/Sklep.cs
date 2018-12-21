using Sklep_odziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_odziezowy.Domena
{
    class Sklep

    {
        private List<Towar> koszyk;

        public Sklep()
        {
            RozpakujTowary();
        }

        public void RozpakujTowary()
        {
            RozpakujButy();
            RozpakujSpodnie();
        }

        private void RozpakujSpodnie()
        {
            SpodnieWSklepie.AddRange(new[] { new Spodnie(50, Kolor.BLACK, TypSpodni.DRESY, RozmiarSpodni.L), new Spodnie(150, Kolor.GRAY, TypSpodni.DZINSY, RozmiarSpodni.XL),
            new Spodnie(25, Kolor.GREEN, TypSpodni.GARNITUROWE, RozmiarSpodni.L), new Spodnie(300, Kolor.RED, TypSpodni.LNIANE, RozmiarSpodni.S)});
        }

        private void RozpakujButy()
        {
            throw new NotImplementedException();
        }

        public List<Buty> ButyWSklepie { get; private set; }
        public List<Spodnie> SpodnieWSklepie { get; private set; }

        public void PrzymierzSpodnie(RozmiarSpodni rozmiarKlienta)
        {
            for (int i = 0; i < SpodnieWSklepie.Count; i++)
            {
                if (SpodnieWSklepie[i].Rozmiar == rozmiarKlienta)
                {
                koszyk.Add(SpodnieWSklepie[i]);
                }
            }
        }
    }
}
