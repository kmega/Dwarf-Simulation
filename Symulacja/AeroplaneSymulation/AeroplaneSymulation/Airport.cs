using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroplaneSymulation
{
    public class Airport
    {
        public List<bool> Airport_Places(int number_place)
        {
            List<bool> airpor_place = new List<bool>();

            for (int i = 0; i < number_place; i++)
            {
                airpor_place.Add(true);
            }
            return airpor_place;
        }
    }
}
