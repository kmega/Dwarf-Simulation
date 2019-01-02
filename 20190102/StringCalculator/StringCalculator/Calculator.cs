using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            
            
            String[] pattern = new String[] { @",",};           
            //String[] stringnumbersarray = Regex.Split(numbers, "[,\n]");
            String[] stringnumbersarray = numbers.Split(new char[] { ',', '\n' });
            
            int[] intnumbersarray = Array.ConvertAll(stringnumbersarray, s => int.Parse(s));            
            int result = 0;
            foreach (int number in intnumbersarray)
                result = result + number;

            return result;

        }
    }
}
