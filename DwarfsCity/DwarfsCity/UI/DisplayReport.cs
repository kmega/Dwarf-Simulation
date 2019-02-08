using DwarfsCity.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.UI
{
    public class DisplayReport
    {
        public void Display(List<string> logs)
        {
            foreach (string log in logs)
            {
                Console.WriteLine(log);
            }

        }
    }
}
