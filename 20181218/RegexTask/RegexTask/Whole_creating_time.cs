using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class Whole_creating_time
    {

        public string creating_time(string url)
        {
            TextParser Parser = new TextParser();
            ReadFile file_data = new ReadFile();
            TimeSpan creating_time_for_all = TimeSpan.FromTicks(0); ;
            string file;


            foreach (string s in Directory.GetFiles(url, "*.md").Select(Path.GetFileName))
            {
                file = file_data.Return_file(url + s);
                string min = Parser.ExtractTimeToCreate(file);
                if (min != "")
                {
                    int minutes = Int32.Parse(min);
                    creating_time_for_all += TimeSpan.FromMinutes(minutes);
                }
            }


            return "Wszystkie postacie do tej pory budowane były " + creating_time_for_all.Hours.ToString() + " godzin " + creating_time_for_all.Minutes.ToString() + " minuty";


        }
    }
}
