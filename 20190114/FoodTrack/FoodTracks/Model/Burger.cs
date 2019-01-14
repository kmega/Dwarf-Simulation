using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Burger(Meet meet, Cheeseness cheeseness, List<AddonType> addonTypes)
        {
            Meet = meet;
            Cheeseness = cheeseness;
            Addons = addonTypes;
        }

        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
    }
}