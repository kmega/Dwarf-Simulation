using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;

namespace MiningSimulatorByKPMM.DwarfsTypes.BuyStrategies
{
    internal class BuyFoodAction : IBuyAction
    {
        public Product Perform(BankAccount bankAccount)
        {
            var quantity = bankAccount.LastInput / 2.0m;
            bankAccount.Withdraw(quantity);
            bankAccount.CalculateOverallAccount();
            return new Product(E_ProductsType.Food, quantity);
        }
    }
}
