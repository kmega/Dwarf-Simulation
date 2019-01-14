using System.Collections.Generic;
namespace FoodTracks.Model

{
    public class EnglishBurgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
			return new Burger(Meet.CreateMeet(13), Cheeseness.Single, 
				new List<AddonType>() { AddonType.Halapenio, AddonType.Egg }, 25);
		}
    }
}