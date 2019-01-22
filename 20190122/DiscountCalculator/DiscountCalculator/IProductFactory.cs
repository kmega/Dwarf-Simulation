using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public interface IProductFactory
    {
        Product CreateProduct(string name, string type, double price);
    }
}
