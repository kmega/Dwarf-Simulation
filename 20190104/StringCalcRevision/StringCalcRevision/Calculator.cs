using System;
using System.Collections.Generic;

namespace StringCalcRevision
{
    public class Calculator
    {
        public int Add(string value, string[] delimiter)
        {
            if (value == string.Empty)
                return 0;

            List<string> stringList = ReturnList(value, delimiter);

            return ExtractSum(stringList);
        }

        private List<string> ReturnList(string value, string[] delimiter)
        {
            List<string> stringList = new List<string>();

            foreach (string s in value.Split(delimiter, StringSplitOptions.None))
            {
                stringList.Add(s.Replace("abs", "").Replace("ff", "").Replace("\n", "").Replace("f", ""));
            }

            return stringList;
        }

        private int ExtractSum(List<string> stringList)
        {
            int result = 0;

            foreach (string s in stringList)
            {
                int.TryParse(s, out int intNumber);
                result += intNumber;
            }

            return result;
        }
    }
}
