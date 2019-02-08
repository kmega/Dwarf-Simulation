using System;
using System.Linq;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Restaurant
{
    internal class Restaurant
    {
        int Rations;
        int FoodEated;
        List<Dwarf> HungryDwarfs;

        public Restaurant(List<Dwarf> hungryDwarfs)
        {
            Rations = 200;
            HungryDwarfs = hungryDwarfs;
        }

        public void FeedDwarfs()
        {
            List<Dwarf> AliveHungryDwarfs = HungryDwarfs.Where(dwarf => dwarf.IsAlive()).ToList();
            AliveHungryDwarfs.ForEach(dwarf =>
            {
                dwarf.Eat();
                Rations--;
                FoodEated++;
            });

            if (IsRationsBelow10())
                SendPidgeonForFood();
        }

        public int RationsLeft()
        {
            return Rations;
        }

        public int RationsEated()
        {
            return FoodEated;
        }

        private bool IsRationsBelow10()
        {
            return Rations < 10 ? true : false;
        }

        private void SendPidgeonForFood()
        {
            Console.WriteLine("Restaurant order 30 more food rations");
            Rations += 30;
        }
    }
}
