using System;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                numbers = "0";
            }
            int result = Convert.ToInt32(numbers);
            return result;
        }
    }
}
