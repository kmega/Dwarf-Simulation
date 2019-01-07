using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroplaneSymulation
{
    public class Planes
    {
        public List<int> plane_creator(int number_planes)
        {
            List<int> planes_list = new List<int>();

            for (int i = 0; i < number_planes; i++)
            {
                planes_list.Add(i);
            }
            return planes_list;
        }
        
    }
}
