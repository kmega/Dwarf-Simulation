using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; }
        public Cheeseness Cheeseness { get; }
        public List<AddonType> Addons { get; set; }
        public string Name;

        public Burger()
        {
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Cheeseness = Cheeseness.None;
            Meet = Meet.CreateMeet();
        }

        public Burger(CheeseburgerMaker cheeseburger)
        {
            Name = "Cheeseburger";
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet(6);
            Cheeseness = Cheeseness.Single;
        }

        public Burger(DoubleCheeseburgerMaker doubleCheeseburger)
        {
            Name = "DoubleCheeseburger";
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet(6);
            Cheeseness = Cheeseness.Double;
        }

        public Burger(VegeBurgerMaker vegeBurger)
        {
            Name = "VegeBurger";
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.Single;
        }

        public Burger(EnglishBurgerMaker englishBurger)
        {
            Name = "EnglishBurger";
            Addons = new List<AddonType>();
            Addons.Add(AddonType.None);
            Meet = Meet.CreateMeet(11);
            Cheeseness = Cheeseness.Single;
            Addons.Add(AddonType.Halapenio);
            Addons.Add(AddonType.Egg);
        }

    }
}