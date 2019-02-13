using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Raport
    {
       internal int LazyBorn { get; set; } = 0;
       internal int FathersBorn { get; set; } = 0;
       internal int SingleBorn { get; set; } = 0;
       
       internal int MithrilMined { get; set; } = 0;
       internal int GoldMined { get; set; } = 0;
       internal int SilverMined { get; set; } = 0;
       internal int TaintedGold { get; set; } = 0;
       
       internal int DeathCount { get; set; } = 0;
       
       internal decimal TaxedMoney { get; set; } = 0.0m;
       internal decimal TotalMoneyEarned { get; set; } = 0.0m;
       
       internal int FoodEaten { get; set; } = 0;
       internal int FoodInDiningRoom { get; set; } = 200;
       
       internal int FoodBought { get; set; } = 0;
       internal int AlcoholBought { get; set; } = 0;
       internal decimal ShopEarned { get; set; } = 0.0m;


    }
}
