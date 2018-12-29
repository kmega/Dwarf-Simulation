using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using regExApp;
using System.IO;

namespace regExApp.Domena
{
    class Tasks
    {
        public void UserDecisionReader()
        {
            Program.TextParser reader = new Program.TextParser();
            string userDecision = Console.ReadLine();
            int userDigit = Int32.Parse(reader.AnalyseUserImput(userDecision));

            switch (userDigit)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
            }
      
        }

        private void Task1()
        {
            
            string path = "1807-fryderyk-komciur.md";
            string file_Content = ReadFile(path);
        }

        private void Task2()
        {
            throw new NotImplementedException();
        }

        private void Task3()
        {
            throw new NotImplementedException();
        }

        private void Task4()
        {
            throw new NotImplementedException();
        }
    }
}
