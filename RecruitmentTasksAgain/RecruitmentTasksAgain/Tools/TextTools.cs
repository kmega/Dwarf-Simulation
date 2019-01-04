using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTasksAgain.Tools
{
    public class TextTools
    {
        public static List<string> ReverseListOfString(List<string> allFileDesc)
        {
            allFileDesc.Reverse();
            return allFileDesc.ToList();
        }
    }
}
