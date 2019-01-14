using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }

        public Burger(Meet meet, Cheeseness cheeseness, AddonType addons)
        {
            Addons = new List<AddonType>();
            Meet = meet;
            Cheeseness = cheeseness;
            Addons.Add(addons);
        }

        public Burger(Meet meet, AddonType addons)
        {
            Addons = new List<AddonType>();
            Meet = meet;
            Addons.Add(addons);
        }

        public Burger(Meet meet, Cheeseness cheeseness, List<AddonType> addons)
        {
            Addons = new List<AddonType>();
            Meet = meet;
            Cheeseness = cheeseness;
            Addons = addons;
        }

    }
}