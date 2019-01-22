using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountApp
{
    public interface IPriceProduct
    {
        decimal Price(string type);
    }
}
