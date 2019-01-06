using System.Linq;

namespace StringCalculator2
{
    public class StringCalc
    {

        public int Add1element(string value)
        {
            int result = 0;
            if (value == string.Empty)
            {
                result = 0;
            }
            else
            {
                result = int.Parse(value);
            }
            return result;
        }

        public int Add2elements(string value)
        {
            string[] numbers = value.Split(',');
            int result = 0;
            int[] myInts = numbers.Select(int.Parse).ToArray();
            foreach (int x in myInts)
            {
                result = result + x;
            }

            return result;
        }
        public int AddUnknowAmountOfElements(string value)
        {
            string[] numbers = value.Split(',');
            int result = 0;
            int[] myInts = numbers.Select(int.Parse).ToArray();
            foreach (int x in myInts)
            {
                result = result + x;
            }

            return result;
        }
        public int AddUnknowAmountOfElementsWithNewLine(string value)
        {
            char[] separator = new char[] {',', '\n' };
            string[] numbers = value.Split(separator);
            
            
            int result = 0;
            int[] myInts = numbers.Select(int.Parse).ToArray();
            foreach (int x in myInts)
            {
                result = result + x;
            }

            return result;
        }
        public int AddUnknowAmountOfElementsWithDiffrentSeparators(string value)
        {          
            var getNumbers = (from t in value
                              where char.IsDigit(t)
                              select t).ToArray();
            int result = 0;
            int[] Aint = getNumbers.Select(a => a - '0').ToArray();          
            foreach (int x in Aint)
            {
                result = result + x;
            }
            return result;
        }
        public int AddUnknowAmountOfElementsWithNegative(string value)
        {
            var getNumbers = (from t in value
                              where char.IsDigit(t)
                              select t).ToArray();
            int result = 0;
            int[] Aint = getNumbers.Select(a => a - '0').ToArray();
            foreach (int x in Aint)
            {
                result = result + x;
            }
            return result;
        }
        public int IgnoreMoreThan1000(string value)
        {
            char[] separator = new char[] { ',', '\n' };
            string[] numbers = value.Split(separator);
            int[] intnumbers = new int[] { };

            for (int i = 0; i < numbers.Length; i++)
            {
                var getNumbers = (from t in numbers[i]
                    where char.IsDigit(t)
                    select t).ToArray();
                numbers[i] = getNumbers.ToString();
                intnumbers = numbers[i].Select(a => a - '0').ToArray();
            }
           
            int result = 0;
            
            foreach (int x in intnumbers)
            {
                result = result + x;
            }
            return result;
        }

        
    }
}