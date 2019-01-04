using RecruitmentTasksAgain.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTasksAgain
{
    public class FileSupporter
    {
        public static List<string> ReadTeasToList()
        {
            return File.ReadAllLines(@"tea-data.txt").ToList();
        }

        public static void SaveDataToFile()
        {
            throw new NotImplementedException();
        }

        public static void GenerateListOfTeas(List<string> FileStr, List<Tea> teas)
        {
            foreach (var tea in FileStr)
            {
                teas.Add(new Tea(tea));
            }
        }
    }
}
