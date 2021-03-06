﻿namespace DwarfSimulation
{
    class FatherBuyStrategy : IBuy
    {
        public void Buy(Shop shop, decimal wallet)
        {
            decimal money = wallet * 0.5m;

            shop.SellFood();
            shop.AcquirePayment(money);
        }

        public decimal UpdateWallet(decimal wallet)
        {
            return wallet * 0.5M;
        }
    }
}
