using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TeaPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<ListTeaClass> informatioAboutTea = new List<ListTeaClass>();
            // Read the file and display it line by line.  
            StreamReader file =
                new StreamReader(@"C:\Users\Lenovo\code\primary\TeaFast\tea-data.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(',');
                if (split.Length == 4)
                {
                    informatioAboutTea.Add(new ListTeaClass
                    {
                        teaName = split[0],
                        typeTea = split[1],
                        boilingpoint = split[2],
                        boilingTime = split[3]
                    });
                }
                else if (split.Length == 5)
                {
                    informatioAboutTea.Add(new ListTeaClass
                    {
                        teaName = split[0],
                        typeTea = split[1],
                        boilingpoint = split[2],
                        boilingTime = split[3],
                        specialProperties = split[4]
                    });
                }
                
                else if (split.Length == 1)
                {
                    informatioAboutTea.Add(new ListTeaClass
                    {
                        teaName = split[0]
                    });
                }
            }

            file.Close();
        }
    }
}
