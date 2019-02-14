using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Shop
    {
        int _soldFood;

        int _soldAlcohol;

        decimal _moneyEarned;

        internal void AcquirePayment(decimal money)
        {
            _moneyEarned += money;
        }

        internal void SellFood()
        {
            _soldFood += 1;
        }

        internal void SellAlcohol()
        {
            _soldAlcohol += 1;
        }

        internal int SoldFoodValue()
        {
            return _soldFood;
        }

        internal int SoldAcoholValue()
        {
            return _soldAlcohol;
        }

        internal decimal SaleValue()
        {
            return _moneyEarned;
        }

        internal void ServeEveryone(List<Dwarf> listOfDwarves)
        {
            foreach (var dwarf in listOfDwarves)
            {
                dwarf.BuyAtShop(this);
            }
        }
    }
}
