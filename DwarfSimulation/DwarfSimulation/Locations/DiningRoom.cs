using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfSimulation
{
    internal class DiningRoom
    {
        internal void DwarfsEat(List<Dwarf> dwarves, Raport raport)
        {
            int foodConsumed = dwarves.Where(dwarf => dwarf.Wallet > 0).Count();
            int lazyDwarfWithoutMoney = dwarves.Where(dwarf => dwarf.Wallet == 0).Count();
            raport.FoodEaten += foodConsumed;
            raport.FoodInDiningRoom -= foodConsumed;
            Display(OrderFood(raport), foodConsumed, lazyDwarfWithoutMoney, raport);
        }

        internal void Display(bool orderdFood, int foodConsumed, int lazyDwarfWithoutMoney, Raport raport)
        {
            List<string> output = new List<string>();
            Outputer outputer = new Outputer();
            output.Add("");
            output.Add("### Dining Room ###");
            output.Add("Dwarfs Eats " + foodConsumed + " meals");
            output.Add("Hungry dwarfs " + lazyDwarfWithoutMoney);
            output.Add("Food in dining room Food " + raport.FoodInDiningRoom);
            if (orderdFood) output.Add("Food ordered");
            outputer.Display(output);
        }

        internal bool OrderFood(Raport raport)
        {
            if (raport.FoodInDiningRoom < 10)
            {
                raport.FoodInDiningRoom += 30;
                return true;
            }
            return false;
        }

        internal bool CanEat(List<Dwarf> dwarves, Raport raport)
        {
            int foodConsumed = dwarves.Where(dwarf => dwarf.Wallet > 0).Count();
            return (raport.FoodInDiningRoom > foodConsumed);
        }
    }
}
