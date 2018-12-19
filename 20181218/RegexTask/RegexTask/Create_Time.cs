using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class Create_Time
    {
        public TimeSpan creating_time(List<string> txt_in_all_files)
        {
            TextParser Parser = new TextParser();
            TimeSpan creating_time_for_all = TimeSpan.FromTicks(0); ;

            foreach (string txt in txt_in_all_files)
            {
                string min = Parser.ExtractTimeToCreate(txt);
                if (min != "")
                {
                    int minutes = Int32.Parse(min);
                    creating_time_for_all += TimeSpan.FromMinutes(minutes);
                }
            }

            return creating_time_for_all;
        }
    }
}
