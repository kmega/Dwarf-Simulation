using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class BlackBoxSumator
    {
        public int AddingUpToSum(string[] Collection)
        {
            TextParser TortoiseBlackBox = new TextParser();
            int TotalTime = 0;
            int IntNumber = 0;
            foreach (string item in Collection)
            {
                IEnumerable<string> TempOpenedFile = File.ReadLines(item);
                foreach (string TimeStringInFile in TempOpenedFile)
                {
                    string StringNumber = TortoiseBlackBox.ExtractTimeToCreate(TimeStringInFile);
                    if (StringNumber != string.Empty)
                    {
                        IntNumber = Convert.ToInt32(StringNumber);
                        TotalTime += IntNumber;
                    }
                    //Match match = Time.Match(TimeStringInFile);
                    //if (match.Success)
                    //{
                    //    //string TempTimeStringInFile = TimeStringInFile.Replace('(', '\0');
                    //    string TempTimeStringInFile = TimeStringInFile.Substring(1,2);
                    //    TotalTime += Convert.ToInt32(TempTimeStringInFile);
                    //    Console.WriteLine(TempTimeStringInFile);
                    //}
                }
            }
            return TotalTime;
        }
    }
}
