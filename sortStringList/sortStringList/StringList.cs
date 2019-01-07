using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace sortStringList
{
    public class StringList
    {
        public string SortStringList(string beforeSort)
        {
            var stringList = beforeSort.Split(',');

            Regex letter = new Regex("^[a-zA-Z]$");
            Regex number = new Regex("^[0-9]*$");

            var oddLettersList = stringList
                .Where((c, i) => i % 2 == 0)
                .Where(s => letter.Match(s).Success)
                .OrderBy(s => s)
                .ToList();

            var evenLettersList = stringList
                .Where((c, i) => i % 2 != 0)
                .Where(s => letter.Match(s).Success)
                .OrderBy(s => s)
                .ToList();

            var numberList = stringList
                .Where(s => int.TryParse(s, out int result))
                .Select(s => int.Parse(s))
                .OrderBy(s => s)
                .Select(s => s.ToString())
                .ToList();

            List<string> resultString = new List<string>();

            resultString.AddRange(oddLettersList);
            resultString.AddRange(numberList);
            resultString.AddRange(evenLettersList);

            return string.Join(",", resultString);
        }
    }
}
