using System.Collections.Generic;

namespace FoodTracks.Model
{
    public class CheeseburgerMaker : IBurgerMaker
    {
        public Burger Make()
        {
          
            int cookingTime = 5;
            return new Burger(cookingTime);
        }
    }
}