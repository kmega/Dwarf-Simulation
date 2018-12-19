using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class Return_txt
    {

        public List<string> txt_in_files(List<string> files_name, string url)
        {
            ReadFile file_data = new ReadFile();
            List<string> txt_in_all_files = new List<string>();

            foreach (string s in files_name)
            {
                txt_in_all_files.Add(file_data.Return_file(url + s));
            }
            return txt_in_all_files;
        }
    }
}
