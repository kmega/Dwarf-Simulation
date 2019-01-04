using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTasksAgain.Tools
{
    
    public class Tea
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Temperature { get; private set; }
        public string Time { get; private set; }
        public string SpecialAtr { get; private set; }

        public Tea(string OneLineOfFile)
        {
            string[] SplittedTea = OneLineOfFile.Split(',');

            Name = SplittedTea[0];
            Type = SplittedTea[1];
            Temperature = SplittedTea[2];
            Time = SplittedTea[3];
            SpecialAtr = SplittedTea[4];
        }
    }
}
