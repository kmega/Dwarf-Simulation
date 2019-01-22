using System;
namespace DiscountCalcualtorWithMocks
{
    public class Product : IProduct
    {
        public string ProductType { get; set; }
        public decimal Price { get; set; }

        public Product(string productType, decimal price)
        {
            ProductType = productType;
            Price = price;
        }

        public string GetProductType()
        {
                return ProductType;
        }

        public decimal GetPrice()
        {
                return Price;
        }
    }
}
