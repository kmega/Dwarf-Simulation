using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
        public Burger()
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.None;
            Addons = new List<AddonType>() {AddonType.None};
        }

        public Burger(int cookingTime)
        {
            Meet = Meet.CreateMeet(cookingTime);
            Cheeseness = Cheeseness.Single;
            Addons = new List<AddonType>() {AddonType.None};
        }

        public Burger(int cookingTime, int a)
        {
            Meet = Meet.CreateMeet(cookingTime);
            Cheeseness = Cheeseness.Double;
            Addons = new List<AddonType>() { AddonType.None};
        }
        public Burger(int cookingTime, int a, int b)
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.Single;
            Addons = new List<AddonType>() { AddonType.None};
        }
        public Burger(int cookingTime, int a, int b, int c)
        {
            Meet = Meet.CreateMeet(cookingTime);
            Addons = new List<AddonType>() { AddonType.Halapenio, AddonType.Egg};
            Cheeseness = Cheeseness.Single;
        }
    }
}