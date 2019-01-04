using System.Collections.Generic;
using System.IO;

namespace Zadanierekrutacyjne
{
    public class SaveTheData
    {
        public void Save(List<string> reversedata)
        {
            using (StreamWriter sw = new StreamWriter("result-1.txt"))
            {
                foreach (string element in reversedata)
                {
                    sw.WriteLine();
                }               
    
            }
        }
    }
}