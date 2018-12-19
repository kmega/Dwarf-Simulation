using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class List_people
    {
        public List<Person> with_or_without_time(List<string> txt_in_files, bool with_time)
        {

            TextParser Parser = new TextParser();
            List<Person> person_without_time = new List<Person>();

            foreach (string txt in txt_in_files)
            {
                string min = Parser.ExtractTimeToCreate(txt);
                if (with_time)
                {
                    if (min != "")
                    {
                        string name = Parser.ExtractProfileName(txt);
                        if (name != "")
                        {
                            person_without_time.Add(new Person() { name = name });
                        }
                    }
                }
                else {
                    if (min == "")
                    {
                        string name = Parser.ExtractProfileName(txt);
                        if (name != "")
                        {
                            person_without_time.Add(new Person() { name = name });
                        }
                    }
                }
                
            }
            return person_without_time;
        }

    }
}
