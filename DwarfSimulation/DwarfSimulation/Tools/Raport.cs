using System;
namespace DwarfSimulation
{
    internal class Raport
    {
        internal int TotalBorn { get; set; } = 0;
        internal int LazyBorn { get; set; } = 0;
        internal int FatherBorn { get; set; } = 0;
        internal int SingleBorn { get; set; } = 0;
        internal int SuiciderBorn { get; set; } = 0;

        internal int MithrilMined { get; set; } = 0;
        internal int GoldMined { get; set; } = 0;
        internal int SilverMined { get; set; } = 0;
        internal int TaintedGoldMined { get; set; } = 0;

        internal int DeathCount { get; set; } = 0;

        internal decimal TaxedMoney { get; set; } = 0.0m;
        internal decimal TotalMoneyEarned { get; set; } = 0.0m;

        internal int FoodEaten { get; set; } = 0;
        internal int FoodInDiningRoom { get; set; } = 200;

        internal int FoodBought { get; set; } = 0;
        internal int AlcoholBought { get; set; } = 0;
        internal decimal ShopEarned { get; set; } = 0.0m;

        internal void Display()
        {
            Console.WriteLine("\n ### Raport ###");
            Console.WriteLine("\n HOSPITAL");
            Console.WriteLine("Total born " + TotalBorn);
            Console.WriteLine("Lazy born " + LazyBorn);
            Console.WriteLine("Father born " + FatherBorn);
            Console.WriteLine("Single born " + SingleBorn);
            Console.WriteLine("Suicider born " + SuiciderBorn);
            Console.WriteLine("\n MINE");
            Console.WriteLine("Mithril mined " + MithrilMined);
            Console.WriteLine("Gold mined " + GoldMined);
            Console.WriteLine("Silver mined " + SilverMined);
            Console.WriteLine("Tainted gold mined " + TaintedGoldMined);
            Console.WriteLine("\n GRAVEYARD");
            Console.WriteLine("Dead count " + DeathCount);
            Console.WriteLine("\n GUILD");
            Console.WriteLine("Total money earned " + Decimal.Round(TotalMoneyEarned,2));
            Console.WriteLine("\n DINNING ROOM");
            Console.WriteLine("Food eaten " + FoodEaten);
            Console.WriteLine("Food in dinning room "+ FoodInDiningRoom);
            Console.WriteLine("\n SHOP");
            Console.WriteLine("Food bought " + FoodBought);
            Console.WriteLine("Alcohol bought " + AlcoholBought);
            Console.WriteLine("Shop earned " + Decimal.Round(ShopEarned,2));

        }
    }
}
