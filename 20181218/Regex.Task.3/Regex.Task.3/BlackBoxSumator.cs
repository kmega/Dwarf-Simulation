using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    class BlackBoxSumator
    {
        TextParser textParser = new TextParser();

        public List<string> IgnoreTemplate(string[] collection)
        {
            List<string> ReturnList = new List<string>();

            foreach (string item in collection)
            {
                if (!item.Contains("template"))
                {
                    ReturnList.Add(item);
                }
            }
            return ReturnList;
        }

        public List<string> GetTimes(List<string> NewCollection)
        {
            List<string> ReturnList = new List<string>();
            foreach (string content in NewCollection)
            {
                string temp = textParser.ExtractTimeToCreate(content);
                if (temp != "")
                {
                    ReturnList.Add(content);
                }
            }
            return ReturnList;
        }

        public List<string> OpenFiles(List<string> NewCollection)
        {
            List<string> ReturnOpenedContents = new List<string>();
            foreach (string path in NewCollection)
            {
                string tempOpenedFile = File.ReadAllText(path);
                ReturnOpenedContents.Add(tempOpenedFile);
            }
            return ReturnOpenedContents;
        }

        public double getAvgTime(double sumTime, int count)
        {
            return sumTime / count;
        }

        public int getCountTime(List<string> ContentsWithTime)
        {
            int count = 0;
            foreach (string content in ContentsWithTime)
            {
                count++;
            }
            return count;
        }

        public void DisplayAssume(double avgTime, double sumTime)
        {
            TimeSpan totalTimeSpan = TimeSpan.FromMinutes(sumTime);
            TimeSpan avgTimeSpan = TimeSpan.FromMinutes(avgTime);

            Console.WriteLine("Średni czas budowania postaci to: {0} minut.",avgTimeSpan.Minutes);
            Console.WriteLine("Uwzględniając powyższe, postacie do tej pory budowane " +
                              "były najpewniej {0} godzin {1} minut.", totalTimeSpan.Hours, totalTimeSpan.Minutes);
        }

        public double getSumTime(List<string> ContentsWithTime)
        {
            double sum=0;
            foreach (string content in ContentsWithTime)
            {
                string temp = textParser.ExtractTimeToCreate(content);
                sum += Convert.ToDouble(temp);
            }
            return sum;
        }
    }
}
