using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public interface IProduct
    {
        string ProductType {get;set;}
        string Name { get; set; }
        double Price { get; set; }

    }
}
