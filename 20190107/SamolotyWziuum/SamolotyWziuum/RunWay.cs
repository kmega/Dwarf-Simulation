using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamolotyWziuum
{
    public class RunWay
    {
        public bool available { get; set; }
        public int numberRunWay { get; set; }
        public RunWay(int runway)
        {
            available = true;
            numberRunWay = runway;
        }
    }
}
