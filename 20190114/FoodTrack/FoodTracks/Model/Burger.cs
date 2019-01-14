using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
    }
}