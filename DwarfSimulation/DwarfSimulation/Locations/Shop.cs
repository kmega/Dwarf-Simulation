using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Shop
    {
        int SoldFood { get; set; }

        int SoldAlcohol { get; set; }

        decimal MoneyEarned { get; set; }

        internal void AcquirePayment(decimal money)
        {
            MoneyEarned += money;
        }

        internal void SellFood()
        {
            SoldFood += 1;
        }

        internal void SellAlcohol()
        {
            SoldAlcohol += 1;
        }

        internal int SoldFoodValue()
        {
            return SoldFood;
        }
    
        internal int SoldAcoholValue()
        {
            return SoldAlcohol;
        }

        internal decimal SaleValue()
        {
            return MoneyEarned;
        }
      
    }
}
