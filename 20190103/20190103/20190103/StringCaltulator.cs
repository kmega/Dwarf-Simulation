using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190103
{
    public class StringCaltulator
    {
        List<int> negativeNumbers = new List<int>();
        public int Add(string number)
        {
            int sum = 0;
            if (number == "")
            {
                sum = 0;
            }
            else
            {
                string[] firstLine = number.Split(new string[] { "//", "\n" }, StringSplitOptions.None);
                string delimiter = firstLine[1];
                string splitter = delimiter.Replace("[", "").Replace("]", "");
                string[] splittedNumber = number.Split(new char[] { ',', '.', '\n', '/'});

                if (firstLine[0] == "")
                {
                    sum = SplitByDelimiter(firstLine, splitter);
                }
                else
                {
                    sum = SplitWithoutDelimier(splittedNumber);
                }
            }
            CheckForNegatives(negativeNumbers);
            if (sum == 0)
            {
                sum = ManyDilimitersAllowed(number);
            }
            return sum;

        }

        private int ManyDilimitersAllowed(string number)
        {
            if(number == "")
            { return 0; }

            int sum = 0;
            string[] firstLine = number.Split(new string[] { "//", "\n" }, StringSplitOptions.None);
            string delimiter = firstLine[1];
            string splitter = delimiter.Replace("[", ",").Replace("]", ",");
            string[] splittersMany = splitter.Split(',');
            string[] splittedNumber = number.Split(new char[] { ',', '.', '\n', '/' });

            sum = SplitByMultiDelimiter(firstLine, splittersMany);

            return sum;
        }

        private int SplitByMultiDelimiter(string[] firstLine, string[] splittersMany)
        {
            int sum = 0;
            for (int i = 2; i < firstLine.Length; i++)
            {
                for(int y =0; y<splittersMany.Length; y++)
                {
                    foreach (var s in firstLine[i].Split(new string[] { splittersMany[y] }, StringSplitOptions.None))
                    {
                        int.TryParse(s, out int n);
                        if (n > 1000) { continue; }
                        sum += n;
                        if (n < 0) { negativeNumbers.Add(n); }

                    }
                }
                
            }
            return sum;
        }

        private int SplitWithoutDelimier(string[] splittedNumber)
        {
            int sum = 0;

            foreach (string s in splittedNumber)
            {
                int.TryParse(s, out int n);
                if(n > 1000) { continue; }
             
                sum += n;
                if (n < 0) { negativeNumbers.Add(n); }

            }

            return sum;
        }

        private int SplitByDelimiter(string[] firstLine, string splitter)
        {

            int sum = 0;
            for (int i = 2; i < firstLine.Length; i++)
            {
                foreach (var s in firstLine[i].Split(new string[] { splitter }, StringSplitOptions.None))
                {
                    int.TryParse(s, out int n);
                    if(n > 1000) { continue; }
                    sum += n;
                    if (n < 0) { negativeNumbers.Add(n); }

                }
            }
            return sum;
        }

        public void CheckForNegatives(List<int> negativeNumbers)
        {
            if (negativeNumbers.Count == 1)
            {
                throw new Exception(String.Format("negatives not allowed: {0}", negativeNumbers[0]));
            }
            else if (negativeNumbers.Count > 1)
            {
                throw new Exception(String.Format("negatives not allowed: {0}", negativeNumbers.ToString()));
            }
        }

    }
}
