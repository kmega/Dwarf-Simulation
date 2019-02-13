using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Displayer
    {
        public static void DisplayInformationAfterOneDay(List<string> _newsPaper)
        {
            foreach (var page in _newsPaper)
            {
                Console.WriteLine(page);
            }           
        }
    }
}
