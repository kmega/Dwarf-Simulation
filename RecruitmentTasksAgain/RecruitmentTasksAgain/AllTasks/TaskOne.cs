using RecruitmentTasksAgain.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTasksAgain
{
    class TaskOne
    {
        
        List<string> AllFIleDesc = new List<string>();
        
        List<string> AllFIleReverse = new List<string>();

        public void Run()
        {
            //Wczytaj plik herbat -> List<string> AllFIleDesc
            AllFIleDesc = FileSupporter.ReadTeasToList();

            //Obróć recordy stringu -> List<string> AllFIleReverse
            AllFIleReverse = TextTools.ReverseListOfString(AllFIleDesc);

            //Zapisz AllFileReverse do result1.txt
            FileSupporter.SaveDataToFile();
        }
              
    }
}
