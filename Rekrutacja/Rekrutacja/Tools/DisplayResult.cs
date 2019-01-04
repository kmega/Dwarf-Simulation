using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    public class DisplayResult
    {
        public void Display(string[] filetext)
        {
            foreach (var item in filetext)
            {
                Console.WriteLine(item);
            }
        }
    }
}
