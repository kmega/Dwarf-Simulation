using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    class SingleBuyStrategy : IBuy
    {
        public void Buy(Shop shop, decimal wallet)
        {
            decimal money = wallet * 0.5m;
            
            shop.SellAlcohol();
            shop.AcquirePayment(money);
        }

        public decimal UpdateWallet(decimal wallet)
        {
            return wallet * 0.5M;
        }
    }
}
