using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    internal static class Raport
    {
        internal static int LazyBorn {  get; set; } = 0;
        internal static int SingleBorn {  get; set; } = 0;
        internal static int FatherBorn {  get; set; } = 0;
        internal static int SuiciderBorn {  get; set; } = 0;
        internal static int TotalBorn {  get; set; } = 0;


        internal static int MithrilMinded {  get; set; } = 0;
        internal static int GoldMinded {  get; set; } = 0;
        internal static int SilverMinded {  get; set; } = 0;
        internal static int TaintedGoldMinded {  get; set; } = 0;

        internal static int DeathCount {  get; set; } = 0;

        internal static decimal TaxedMoney {  get; set; } = 0.0m;
        internal static decimal TotalMoneyEarned {  get; set; } = 0.0m;

        internal static int FoodEaten {  get; set; } = 0;
        internal static int FoodInDiningRoom {  get; set; } = 200;

        internal static int FoodBought {  get; set; } = 0;
        internal static int AlcoholBought { get; set; } = 0;
        internal static decimal ShopEarned { get; set; }


        internal static string[] EndGameStats()
        {
            string[] raport = new string[22];

            raport[0] = "### Simulation Raport ### \n";
            raport[1] = "### HOSPITAL ###  \n";
            raport[2] = "Fathers born: " + Raport.FatherBorn;
            raport[3] = "Singles born: " + Raport.SingleBorn;
            raport[4] = "Lazy born: " + Raport.LazyBorn;
            raport[5] = "Suiciders born: " + Raport.SuiciderBorn + "\n";
            raport[6] = "### Mines ### \n";
            raport[7] = "Mithrill mined: " + Raport.MithrilMinded.ToString();
            raport[8] = "Gold mined: " + Raport.GoldMinded.ToString();
            raport[9] = "Silver mined: " + Raport.SilverMinded;
            raport[10] = "Tainted gold mined: " + Raport.TaintedGoldMinded + "\n";
            raport[11] = "### GRAVEYARD ### \n";
            raport[12] = "Death count: " + Raport.DeathCount + "\n";
            raport[13] = "### GUILD ###\n";
            raport[14] = "Taxed money: " + Raport.TaxedMoney;
            raport[15] = "Total money earned: " + Raport.TotalMoneyEarned + "\n";
            raport[16] = "### DINING ROOM ### \n";
            raport[17] = "Food eaten: " + Raport.FoodEaten + "\n";
            raport[18] = "### SHOP ### \n";
            raport[19] = "Food bought: " + Raport.FoodBought;
            raport[20] = "Alcohol bought: " + Raport.AlcoholBought;
            raport[21] = "Shop earned: " + Raport.ShopEarned;


            return raport;
        }
    }
}
