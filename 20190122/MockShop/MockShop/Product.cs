using System;

namespace MockShop
{
    public class Product
    {
        public Product(string name, ProductType productType)
        {
            Name = name;
            type = productType;
        }
        public string Name { get; set; }
        public ProductType type { get; set; }
    }
}