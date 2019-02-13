using System;
using System.Collections.Generic;
using Mine.Locations.Interfaces;

namespace Mine.Locations
{
    public sealed class Guild : IGuild
    {
        private static readonly Guild _instance = new Guild();

        public static Guild Instance
        {
            get
            {
                return _instance;
            }
        }
        public int ChangeOreToCoins(List<Ore> ores)
        {
            int coins = 0;

            Random rand = new Random();
            foreach (Ore ore in ores)
            {
                if (ore == Ore.Mithril)
                    coins+=rand.Next(15, 25);
                if (ore == Ore.Gold)
                    coins += rand.Next(10, 20);
                if (ore == Ore.Silver)
                    coins += rand.Next(5, 10);
                if (ore == Ore.DirtGold)
                    coins += 5;
            }

            return coins;
        }
    }
}
