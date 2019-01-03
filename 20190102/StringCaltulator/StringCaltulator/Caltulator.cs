using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCaltulator
{
    public class Caltulator
    {
        public int Add(string input)
        {
            int result = 0;
            //string[] parts = input.Split(new char[] {' ', '/', ';', ',', '.', ':', '\n' });
            string[] parts = Regex.Split(input, @"[^\d-]"); //regex dzieli po liczbach 
            foreach( var part in parts)
            {
                if(int.TryParse(part, out int n))
                {
                    result += Int32.Parse(part);
                } else
                {
                    continue;
                }
            }
            return result;
        }
    }
}
