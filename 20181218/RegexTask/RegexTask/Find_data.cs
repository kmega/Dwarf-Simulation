using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexTask
{
    class Find_data
    {
        public string regex(string file, string regex)
        {
            string value="";
            Regex rx = new Regex(regex,
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Match match = rx.Match(file);
            if (match.Success)
            {
                value += (match.Value);
            }

            return value;
        }
}
}
