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
            TextParser Parser1 = new TextParser();
            ReadFile file_data = new ReadFile();
            TimeSpan creating_time_for_all;
            string file;

            creating_time_for_all = TimeSpan.FromTicks(0);
            Console.WriteLine(creating_time_for_all);

            foreach (string s in Directory.GetFiles(url, "*.md").Select(Path.GetFileName))
            {
                file = file_data.Return_file(url + s);
                string min = Parser1.ExtractTimeToCreate(file);
                if (min != "")
                {
                    int minutes = Int32.Parse(min);
                    creating_time_for_all += TimeSpan.FromMinutes(minutes);
                }
            }

            Console.WriteLine(creating_time_for_all);
            Console.ReadKey();

            return creating_time_for_all.ToString();

        }
    }
}
