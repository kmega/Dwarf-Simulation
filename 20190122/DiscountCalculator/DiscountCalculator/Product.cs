using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public class Product : IProduct
    {
        public string ProductType { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, string type, double price)
        {
            Name = name;
            ProductType = type;
            Price = price;
        }
    }
}
