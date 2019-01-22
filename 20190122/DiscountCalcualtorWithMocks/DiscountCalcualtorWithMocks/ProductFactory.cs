using System;
namespace DiscountCalcualtorWithMocks
{
    public class ProductFactory
    {
        public Product CreateSingleProduct(string type, decimal price)
        {
            return new Product(type, price);
        }
    }
}
