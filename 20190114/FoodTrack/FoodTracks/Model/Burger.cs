using System;
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

        public override bool Equals(object obj)
        {
            var burger = obj as Burger;
            return burger != null &&
                   EqualityComparer<Meet>.Default.Equals(Meet, burger.Meet) &&
                   Cheeseness == burger.Cheeseness &&
                   EqualityComparer<List<AddonType>>.Default.Equals(Addons, burger.Addons);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Meet, Cheeseness, Addons);
        }
    }
}