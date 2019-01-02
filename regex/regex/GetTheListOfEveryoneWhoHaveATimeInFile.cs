using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace regex
{
    public class GetTheListOfEveryoneWhoHaveNOTATimeInFile
        
    {
        TextParser textOperation = new TextParser();
        // WZIAC PETLE ZE WSZYSTKIMI CZASAMI Z PUSTYMI POLAMI, TA Z CZASAMI, I WYPISAĆ KTORE ELEMENTY !!!!!
        public GetTheListOfEveryoneWhoHaveNOTATimeInFile(List<string> putthelistofpathes, List<int> numberofpersonsforwhomwedontknowtime, List <string> outlistofpersonswedontknowtime)
        {  
            for (int i = 0; i < putthelistofpathes.Count; i++)
            {
                if (numberofpersonsforwhomwedontknowtime.Contains(i))
                {                  
                    using (FileStream fs = File.Open(putthelistofpathes[i], FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        string name = textOperation.ExtractProfileName(File.ReadAllText(putthelistofpathes[i]));
                        outlistofpersonswedontknowtime.Add(name);  

                    }
                }
            }          

        }
    }
}