using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Shop : IShop
    {
        public void PerformShopping(IShoppingStrategy shoppingStrategy)
        {
            shoppingStrategy.Buy();
        }
    }
}
