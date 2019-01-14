using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks.Model
{
    public class DiscountManager : IRandomDiscount
    {
        public bool DrawDiscount()
        {
            Random rand = new Random();
            int result = rand.Next(0,2);
            if(result>0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
