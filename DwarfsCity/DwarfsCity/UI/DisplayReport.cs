using DwarfsCity.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.UI
{
    public class DisplayReport
    {
        public void Display(Report reports)
        {
            foreach (string report in reports.GetReportsToDisplay())
            {
                Console.WriteLine(report);
                Console.WriteLine("-");
            }

            Console.WriteLine("==============");
        }
    }
}
