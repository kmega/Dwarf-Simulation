using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCalc
{
    public class ProductFactory
    {
        public Product CreateSingleProduct(decimal price, EProductType productType)
        {
            return new Product( price,  productType);
        }
    }
}
