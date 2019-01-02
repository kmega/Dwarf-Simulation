using System;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            else if (numbers.Length > 1)
            {
                int result = 0;
                numbers = numbers.Replace(",", " ").Replace("\n", " ");
                for (int i = 0; i < numbers.Split(' ').Length; i++)
                {
                    result += Convert.ToInt32(numbers.Split(' ')[i]);
                }
                return result;
            }
            else
            {
                return Convert.ToInt32(numbers);
            }
        }
    }
}
