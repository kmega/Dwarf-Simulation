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
                if (numbers.Contains(",") == true)
                {
                    numbers.Replace(",", " ");
                    Console.WriteLine(numbers);
                    numbers = numbers.Replace(",", " ");
                    for (int i = 0; i < numbers.Split(' ').Length; i++)
                    {
                        result += Convert.ToInt32(numbers.Split(' ')[i]);
                    }
                    return result;
                }
                else
                {
                    for (int i = 0; i < numbers.Split('\n').Length; i++)
                    {
                        result += Convert.ToInt32(numbers.Split('\n')[i]);
                    }
                    return result;
                }
            }
            else
            {
                return Convert.ToInt32(numbers);
            }
        }
    }
}
