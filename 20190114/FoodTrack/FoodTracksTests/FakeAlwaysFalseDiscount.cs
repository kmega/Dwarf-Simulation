using FoodTracks.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracksTests
{
    class FakeAlwaysFalseDiscount : IRandomDiscount
    {
        public bool DrawDiscount()
        {
            return false;
        }
    }
}
