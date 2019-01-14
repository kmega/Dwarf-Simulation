using System;
using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class Burger
    {
        public Meet Meet { get; set; }
        public Cheeseness Cheeseness { get; set; }
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
            Addons = new List<AddonType>() { AddonType.None };
        }
        public Burger(int cookingtime,int a)
        {
            
            Meet = Meet.CreateMeet(cookingtime);
            Cheeseness = Cheeseness.Double;
            Addons = new List<AddonType>() { AddonType.None };
           
        }
        public Burger(int cookingtime, int a, int b)
        {
            Meet = Meet.CreateMeet();
            Cheeseness = Cheeseness.Single;
            Addons = new List<AddonType>() { AddonType.None };
           
        }
        public Burger(int cookingtime, int a,int b, int c)
        {
            Meet = Meet.CreateMeet(cookingtime);
            Cheeseness = Cheeseness.Single;
            Addons = new List<AddonType>() { AddonType.Egg, AddonType.Halapenio };
            
        }

// meettype, cheesenes addons - odwolania

    }





}
