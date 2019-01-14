using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Burger(Meet meet, Cheeseness cheeseness, List<AddonType> addons)
        {
            Meet = meet;
            Cheeseness = cheeseness;
            Addons = addons;
        }

        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
    }
}