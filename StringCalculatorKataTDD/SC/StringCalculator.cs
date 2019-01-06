using System;
using System.Linq;


namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numbersStringArray = numbers.Replace('\n', ',').Split(',');

            if (numbersStringArray[0].StartsWith("//"))
            {
                var delimeters = numbersStringArray[0].Remove(0,2).Distinct();
                foreach (var delimeter in delimeters)
                {
                    numbersStringArray[1] = numbersStringArray[1].Replace(delimeter, ',');
                }
                numbersStringArray = numbersStringArray[1].Split(',');
            }

            var numbersArray = numbersStringArray.Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s));

            if (numbersArray.Any(p => p < 0))
            {
                throw new Exception($"Negatives not allowed {string.Join(" ", numbersArray.Where(p => p < 0))}");
            }

            var sum = numbersArray.Where(s => s <= 100).Sum();
            return sum;
        }
    }
}
