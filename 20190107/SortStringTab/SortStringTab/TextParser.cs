using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStringTab
{
    public class TextParser
    {
        public List<string> ParseInput (string input)
        {
            string[] tempstring = input.Split(',');
            List<string> listofstrings = tempstring.ToList();
            return listofstrings;

        }
    

    }
}
