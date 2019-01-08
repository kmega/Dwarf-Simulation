using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
{
    public class Airstrip
    {
        public bool isFree = true;
        public static int id = 0;
        public Airstrip()
        {
            id++;
        }

        public override string ToString()
        {
            return "PAS ID: " + id;
        }
    }
}
