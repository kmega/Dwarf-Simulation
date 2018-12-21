using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Shop
    {
        private List<Shoes> shoesList = new List<Shoes>();
        private List<Trousers> trousersList = new List<Trousers>();
        public List<Product> cart = new List<Product>();

        public Shop()
        {
            unzipProducts();
        }

        private void unzipProducts()
        {
            unzipShoes();
            unzipTrousers();
        }

        private void unzipTrousers()
        {
            trousersList.Add(new Trousers(TrousersType.Jeans, 100, FashionTrousers.Straight, Color.Black, Size.M));
            trousersList.Add(new Trousers(TrousersType.Dress, 150, FashionTrousers.Loose, Color.Blue, Size.L));
            trousersList.Add(new Trousers(TrousersType.Jeans, 200, FashionTrousers.Bootcut, Color.White, Size.M));
        }

        private void unzipShoes()
        {
            throw new NotImplementedException();
        }
    }
}
