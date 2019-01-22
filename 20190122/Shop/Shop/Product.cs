using System;

namespace Shop
{
    public class Product
    {
        public Product(ProductType type, string name)
        {
            Type = type;
            Name = name;
        }

        public ProductType Type { get; set; }
        public string Name { get; set; }

    }
}
