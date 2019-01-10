using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odziezowy.domena
{
    class Sklep
    {

        private List<Towar> Koszyk;
        //Drzewo <- programowanie
        //Dicionary
        //HashSet
        //Zapisywanie do kolekcji
        //Typ Internal
        // pola i modyfikatory dostepu

        //typ generyczny
        public Sklep() //konstruktor
        {
            RozpakujTowary();
        }

        private void RozpakujTowary() //typ Void nic nie zwraca
        {
            RozpakujButy();
            RozpakujSpodnie();
        }

        private void RozpakujSpodnie()
        {
            SpodnieWSklepie.Add(new Spodnie(
                50,
                Enums.Kolor.Czerwony, 
                Enums.TypSpodni.Jeansy, 
                Enums.RozmiarSpodni.XL));

            SpodnieWSklepie.Add(new Spodnie(
                60,
                Enums.Kolor.Biały,
                Enums.TypSpodni.Rurki,
                Enums.RozmiarSpodni.XL));


            SpodnieWSklepie.Add(new Spodnie(
                25,
                Enums.Kolor.Niebieski,
                Enums.TypSpodni.Robocze,
                Enums.RozmiarSpodni.XL));
        }

        private void RozpakujButy()
        {
            
        }

        public List<Buty> ButyWSklepie { get;  private set; }
        public List<Spodnie> SpodnieWSklepie { get; private set; }

        //Wprowadzic zmiennie do tej metody i poprawic 
        public void PrzymierzSpodnie()
        {
            for (int i = 0; i < SpodnieWSklepie.Count; i++)
            {
                if (SpodnieWSklepie[i].RozmiarSpodni == Enums.RozmiarSpodni.M;)
                {
                    Koszyk.Add(SpodnieWSklepie[i]);
                }
            }
        }
    }
}
