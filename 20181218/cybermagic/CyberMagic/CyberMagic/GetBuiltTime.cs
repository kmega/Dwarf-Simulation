using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    public class GetBuiltTime
    {

        public List<int> alltime(List<string> files)
        {
            List<int> alltimelist = new List<int>();

            foreach (var item in files)
            {
                string time;
                time = (new TextParser().ExtractTimeToCreate(item));
                if (time == "")
                {
                    continue;
                }
                else
                {
                    alltimelist.Add (Int32.Parse(time));
                    
                }

               
            }
            
            return alltimelist;
        }

        public int averageTime(List<int> alltimelist)
        {
            int average = 0;
            average = alltimelist.Sum() / alltimelist.Count;
            return average;
        }
    }
}
