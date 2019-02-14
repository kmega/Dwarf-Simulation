using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Shop
    {
        int _soldFood = 0;

        int _soldAlcohol = 0;

        decimal _moneyEarned = 0.0M;

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

        internal void Display()
        {
            List<string> shopDailyStats = new List<string>();
            Outputer outputer = new Outputer();
            shopDailyStats.Add("");
            shopDailyStats.Add("### Shop ###");
            shopDailyStats.Add($"Food sold: {_soldFood}.");
            shopDailyStats.Add($"Alcohol sold: {_soldAlcohol}.");
            shopDailyStats.Add($"Shop earn: {_moneyEarned} $.");
            outputer.Display(shopDailyStats);
        }

        internal void UpdateSimulationRaport(Raport raport)
        {
            raport.AlcoholBought += _soldAlcohol;
            raport.FoodBought += _soldFood;
            raport.ShopEarned += _moneyEarned;
        }
    }
}
