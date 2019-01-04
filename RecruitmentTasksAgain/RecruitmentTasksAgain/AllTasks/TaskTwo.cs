using RecruitmentTasksAgain.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTasksAgain
{
    class TaskTwo
    {
        public void Run()
        {
            //Read file and return list of string file -> List<string> teaFile;
            List<string> teaFile = FileSupporter.ReadTeasToList();

            //Remove first line and second line
            teaFile.RemoveRange(0, 2);

            //Generate new objects file who will contain type, name tea etc.
            List<Tea> teas = new List<Tea>();
            FileSupporter.GenerateListOfTeas(teaFile, teas);
                      
        }
        
    }
}
