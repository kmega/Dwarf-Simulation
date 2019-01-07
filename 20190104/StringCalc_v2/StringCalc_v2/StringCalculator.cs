using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalc_v2
{
    public class StringCalculator
    {
        List<int> negativeNumbers = new List<int>();

        public int Add(string number)
        {
            int sum = 0;

            if (number == "")
            { sum = 0; }

            else
            {
                sum = SimpleSplitter(number);

                if (sum == 0)
                {
                    sum = MultiDelimiter(number);
                }

                if (sum == 0)
                {
                    sum = ChosenDelimiterSupport(number);
                }
            }

            return sum;
        }

        public int SimpleSplitter(string number)
        {
            int sum = 0;
            string[] splitted = number.Split(',');

            foreach (var s in splitted)
            {
                int n = 0;
                Int32.TryParse(s, out n);
                sum += n;
                if (n < 0)
                {
                    this.negativeNumbers.Add(n);
                }
            }

            CheckForNegatives();

            return sum;
        }

        public int MultiDelimiter(string number)
        {
            int sum = 0;
            string[] splitted = number.Split(new char[] { ',',';', '\n'});

            foreach (var s in splitted)
            {
                int n = 0;
                Int32.TryParse(s, out n);
                sum += n;
                if (n < 0)
                {
                    this.negativeNumbers.Add(n);
                }
            }

            CheckForNegatives();

            return sum;
        }

        public int ChosenDelimiterSupport(string number)
        {
            int sum = 0;
            string[] firstLine = number.Split(new string[] { "//","\n" }, StringSplitOptions.None);
            string splitter = firstLine[1].Replace("[", "").Replace("]", "");

            for (int i = 2; i < firstLine.Length; i++)
            {
                foreach (string s in firstLine[i].Split(new string[] { splitter, "," }, StringSplitOptions.None))
                {
                    int n = 0;
                    Int32.TryParse(s, out n);
                    sum += n;
                    if(n<0)
                    {
                        this.negativeNumbers.Add(n);
                    }
                }
            }

            CheckForNegatives();

            return sum;
        }

        public void CheckForNegatives()
        {
            if(this.negativeNumbers.Count == 1)
            {
                string negatives = this.negativeNumbers.ToString();
                throw new Exception(String.Format("negatives not allowed: {0}", negatives));
            }
            else if ( this.negativeNumbers.Count >1)
            {
                string negatives = this.negativeNumbers.ToString();
                throw new Exception(String.Format("negatives not allowed: {0}", negatives));
            }
            else
            { }
        }
        
    }
}
