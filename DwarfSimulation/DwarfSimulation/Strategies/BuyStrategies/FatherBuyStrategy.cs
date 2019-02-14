using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    class FatherBuyStrategy : IBuy
    {
        public void Buy(Shop shop, decimal wallet)
        {
            decimal money = wallet * 0.5m;

            shop.SellFood();
            shop.AcquirePayment(money);
        }
    }
}
