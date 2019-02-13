using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Locations.Bank;
using DwarfLifeSimulation.Locations.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.BuyStrategies
{
    public class BuyAlcoholStrategy : IBuyStrategy
    {
        public Product Buy(int customerAccountId, int shopAccountId)
        {
            var bank = Bank.Instance;
            var dailyIncome = bank.GetDailyIncome(customerAccountId);
            var howMuchISpent = dailyIncome / 2.0m;           
            bank.Transfer(customerAccountId, shopAccountId, howMuchISpent);
            return new Product()
            {
                _productType = ProductType.Alcohol,
                _amount = howMuchISpent
            };
        }
    }
}
