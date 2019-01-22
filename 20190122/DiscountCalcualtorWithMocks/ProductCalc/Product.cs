using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCalc
{
    public class Product : IProduct
    {
        public Product(decimal price, EProductType productType)
        {
            Price = price;
            ProductType = productType;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public EProductType GetProductType()
        {
            return ProductType;
        }

        private decimal Price { get; set; }
        private EProductType ProductType{ get; set; }
    }

    public enum EProductType
    {
        Buty,
        Odziez
    }
}
