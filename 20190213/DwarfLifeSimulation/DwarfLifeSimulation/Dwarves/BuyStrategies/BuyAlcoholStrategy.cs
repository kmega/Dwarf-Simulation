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
            //GetDailyIncomeFromBank(customerAccountId) -> decimal dailyIncome
            //Bank.Transfer(From customerAccountId To shopAccountId, decimal dailyIncome/2)
            return new Product()
            {
                ProductType = ProductType.Alcohol,
                Amount = 0.0m
            };
            //Amount = dailyIncome/2
        }
    }
}
