using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks.Model
{
    public class Meat
    {
        private readonly int _cookingTime;

        public static Meat CreateMeet()
        {
            return new Meat(MeatType.None);
        }

        public static Meat CreateMeet(int cookingTime)
        {
            if (cookingTime < 10 && cookingTime >= 5)
            {
                return new Meat(MeatType.Medium, cookingTime);
            }
            if (cookingTime >= 10)
            {
                return new Meat(MeatType.Full, cookingTime);
            }

            if (cookingTime > 0)
            {
                return new Meat(MeatType.Rare, cookingTime);
            }
            throw new ArgumentException();
        }
        private Meat(MeatType type, int cookingTime = 0)
        {
            _cookingTime = cookingTime;
            Type = type;
        }
        public MeatType Type { get;}
    }
}
