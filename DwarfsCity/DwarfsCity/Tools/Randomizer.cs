﻿using DwarfsCity.DwarfContener.DwarfEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DwarfsCity.Tools
{
    public class Randomizer
    {
        public static int GetChanceRatio(int min = 1,int max = 100)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        public static bool IsDwarfBorn()
        {
            if (GetChanceRatio() == 5)
                return true;
            else
                return false;
        }

        public static decimal ValueOfItem(Item item)
        {
            int valueIncrease = GetChanceRatio(0,10);

            switch(item)
            {
                case Item.Mithril:
                    return 15 + valueIncrease;
                case Item.Gold:
                    return 10 + valueIncrease;
                case Item.Silver:
                    return 5 + valueIncrease;
                case Item.DirtyGold:
                    valueIncrease = GetChanceRatio(0, 9);
                    return 1 + valueIncrease;
            }

            return -1;
        }

        public static Item ItemDigged()
        {
            int probability = GetChanceRatio();

            if (Enumerable.Range(1, 5).Contains(probability))
                return Item.Mithril;
            else if (Enumerable.Range(5, 20).Contains(probability))
                return Item.Gold;
            else if (Enumerable.Range(20, 55).Contains(probability))
                return Item.Silver;
            else 
                return Item.DirtyGold;

        }

        public static int CountsOfDigging()
        {
            return GetChanceRatio(1, 3);
        }


    }
}
