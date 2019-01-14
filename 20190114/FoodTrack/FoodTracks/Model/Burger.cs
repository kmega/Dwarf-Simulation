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
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Cheeseness = Cheeseness.None;
            Meet = Meet.CreateMeet();
        }

        public Burger(CheeseburgerMaker cheeseburger)
        {
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet(6);
            Cheeseness = Cheeseness.Single;
        }

        public Burger(DoubleCheeseburgerMaker doubleCheeseburger)
        {
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet(6);
            Cheeseness = Cheeseness.Double;
        }

        public Burger(VegeBurgerMaker vegeBurger)
        {
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.Single;
        }

        public Burger(EnglishBurgerMaker englishBurger)
        {
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet(11);
            Cheeseness = Cheeseness.Single;
            Addons.Add(AddonType.Halapenio);
            Addons.Add(AddonType.Egg);
        }

    }
}