using SklepOdziezowy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy.Domena
{
    class Shop
    {
        public Shop()
        {
            UnpackCargo();
        }

        List<Shoes> ShoesInShop { get; set; }
        List<Pants> PantsInShop { get; set; }
        private List<Cargo> Basket = new List<Cargo>();
        private decimal sumToPay = 0;

        private void UnpackCargo()
        {
            UnpackShoes();
            UnpackPants();
        }

        private void UnpackPants()
        {
            PantsInShop.AddRange(new[]
            {
                 new Pants(50, EuropeanSize.L, Colour.Gray, PantsType.Fabric, PantsStyling.Constricted),
                 new Pants(90, EuropeanSize.XL, Colour.Black, PantsType.Corduroy, PantsStyling.Straight),
                 new Pants(34, EuropeanSize.S, Colour.Red, PantsType.Fabric, PantsStyling.Fit),
                 new Pants(99, EuropeanSize.M, Colour.Blue, PantsType.Jeans, PantsStyling.Constricted),
                 new Pants(158, EuropeanSize.XS, Colour.White, PantsType.Working, PantsStyling.Fit),
                 new Pants(22, EuropeanSize.XXL, Colour.Blue, PantsType.Jeans, PantsStyling.Straight)
            }
            );
        }
        private void UnpackShoes()
        {
            ShoesInShop = new List<Shoes>();
        }
        public void TryPants(EuropeanSize clientSize)
        {
            foreach(var pants in PantsInShop)
            {
                if (pants.Size == clientSize)
                {
                    Basket.Add(pants);
                    sumToPay += pants.Price;
                }
            }           
        }
        public void BuyCargoFromBasket()
        {
            if(Basket.Any())
            {
                Console.WriteLine($"You need to pay: {sumToPay}");
            }
        }
    }
}

