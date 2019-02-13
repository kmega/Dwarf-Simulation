using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal static class Raport
    {
       internal static int LazyBorn { get; set; } = 0;
       internal static int FathersBorn { get; set; } = 0;
       internal static int SingleBorn { get; set; } = 0;
       
       internal static int MithrilMined { get; set; } = 0;
       internal static int GoldMined { get; set; } = 0;
       internal static int SilverMined { get; set; } = 0;
       internal static int TaintedGold { get; set; } = 0;
       
       internal static int DeathCount { get; set; } = 0;
       
       internal static decimal TaxedMoney { get; set; } = 0.0m;
       internal static decimal TotalMoneyEarned { get; set; } = 0.0m;
       
       internal static int FoodEaten { get; set; } = 0;
       internal static int FoodInDiningRoom { get; set; } = 200;
       
       internal static int FoodBought { get; set; } = 0;
       internal static int AlcoholBought { get; set; } = 0;
       internal static decimal ShopEarned { get; set; } = 0.0m;


    }
}
