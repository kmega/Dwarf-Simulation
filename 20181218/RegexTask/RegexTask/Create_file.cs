using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegexTask
{
    class Create_file
    {
        public void save_file(string url, List<string> data)
        {
            File.WriteAllLines(url, data);

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
