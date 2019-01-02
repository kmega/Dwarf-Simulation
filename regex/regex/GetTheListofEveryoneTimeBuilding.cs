using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace regex
{
    public class GetTheListofEveryoneTimeBuilding
    {
        public List<string> pathesOfFiles;
        public List<string> timesforEveryone;
        public TextParser textOperation;
  

        public GetTheListofEveryoneTimeBuilding(List<string> putthelistofpathes, List<string> getthelistoftimeslist, List<int> IntListPersonsWhoHaveNoTime)
        {
            TextParser textOperation = new TextParser();
            List<string> GetTheListOfTimes = new List<string>(putthelistofpathes);
            {

                string filepath, time;
                for (int i = 0; i < putthelistofpathes.Count; i++)
                {
                    filepath = putthelistofpathes[i];
                    using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        time = textOperation.ExtractTimeToCreate(File.ReadAllText(filepath));
                        if (time != "")
                        {
                            getthelistoftimeslist.Add(time); //lista czasów wszystkich
                        }
                        else
                        {
                            IntListPersonsWhoHaveNoTime.Add(i);
                        }
                    }

                }
                //getthelistoftimeslist.RemoveAll(s => s == string.Empty); //usun puste pola

                var intList = getthelistoftimeslist.Select(s => Convert.ToInt32(s)).ToList();
                
            }
           

        }
            
        //public GetTheListofEveryoneTimeBuilding(List<string> putthelistofpathes, List<int> getthelistoftimeslist)
        //{
        //    TextParser textOperation = new TextParser();
        //    List<string> GetTheListOfTimes = new List<string>(putthelistofpathes);
        //    {

        //        string filepath, time;
        //        for (int i = 0; i < putthelistofpathes.Count; i++)
        //        {
        //            filepath = putthelistofpathes[i];
        //            using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //            {
        //                time = textOperation.ExtractTimeToCreate(File.ReadAllText(filepath));
        //                if (time != "")
        //                {
        //                    getthelistoftimeslist.Add(time); //lista czasów wszystkich
        //                }
        //            }

        //        }
        //        getthelistoftimeslist.RemoveAll(s => s == string.Empty); //usun puste pola

        //        var intList = getthelistoftimeslist.Select(s => Convert.ToInt32(s)).ToList();

        //    }
        //}
    }
}