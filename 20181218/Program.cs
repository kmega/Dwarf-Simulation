using System;
using System.IO;
using System.Collections.Generic;
using VivaRegex;
using System.Text;
using System.Timers;

namespace regexy
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "1807-fryderyk-komciur.md";
            string sourceDirectory = "cybermagic/karty-postaci/";

            TextParser textParser = new TextParser();

             // ZAD 1   
            string resultfile_1 = "result-1.txt";
            string stringToFileResult_1;
            string contentOneFile = getContentOneFile(sourceFile);
            string contentOneFileName = textParser.ExtractProfileName(contentOneFile);
            string contentOneFileTime = textParser.ExtractTimeToCreate(contentOneFile);
            stringToFileResult_1 = string.Format("{0}, był budowany {1} minuty", contentOneFileName, contentOneFileTime);
            File.WriteAllText(resultfile_1, stringToFileResult_1);
            
            // ZAD 2
            string resultfile_2 = "result-2.txt";
            string stringToFileResult_2;
            List<string> listOfFieles = new List<string>(getContentAllFiles(sourceDirectory));
            string sumOfAllMinutes = createSumOfTime(listOfFieles).ToString();
            int minutesInt = int.Parse(sumOfAllMinutes);
            decimal minutesDecimal = decimal.Parse(sumOfAllMinutes);
                   
            stringToFileResult_2 = string.Format("Wszystkie postacie do tej pory budowane były {0} godzin {1} minuty",
                                                    minutesInt/60, minutesDecimal%60);
            File.WriteAllText(resultfile_2, stringToFileResult_2);

            // ZAD 3
            string resultfile_3 = "result-3.txt";
            string stringToFileResult_3_1;
            string stringToFileResult_3_2;
            List<string> charactersWithoutTime = new List<string>(getContentAllFiles(sourceDirectory));
            List<string> countWithoutEmptyLines = new List<string>(extractCharactersWithoutTime(charactersWithoutTime));
            
            string numberOfminutes = extractCharactersWithoutTime(charactersWithoutTime).Count.ToString();
            
            int countPersonWithoutTime = 0;
            foreach(string i in countWithoutEmptyLines)
            {
                if (i != string.Empty)
                {
                    countPersonWithoutTime ++;
                }
            }
                        
            int numbOfminutes = int.Parse(numberOfminutes);
            int avgTime = minutesInt/numbOfminutes;

            //save to file characters without given time
            System.IO.File.AppendAllLines(resultfile_3, extractCharactersWithoutTime(charactersWithoutTime));
            stringToFileResult_3_1 = string.Format("średni czas budowania postaci z podanym czasem wynosi: {0} minut",
                                                 avgTime.ToString());
            File.AppendAllText(resultfile_3, stringToFileResult_3_1 + Environment.NewLine);

            //average time of building character without given time
            int avgTimeWithoutGivenTime = countPersonWithoutTime * avgTime;
            var timeSpan = TimeSpan.FromMinutes(avgTimeWithoutGivenTime);
            int hh = timeSpan.Hours;
            int mm = timeSpan.Minutes;

            stringToFileResult_3_2 = string.Format("Postacie bez podanego czasu najpewniej były budowane {0} godzin i {1} minut",
                                 hh, mm);
            File.AppendAllText(resultfile_3, stringToFileResult_3_2 + Environment.NewLine);
        
        }

        // -------- METHODS ---------------------

        // extract characters without time
        public static List<string> extractCharactersWithoutTime(List<string> getContentAllFiles)
        {
            TextParser textParser = new TextParser();
            List<string> extCharactersWithoutTime = new List<string>();
            foreach(string i in getContentAllFiles)
            {
                string a = File.ReadAllText(i);
                string b = textParser.ExtractTimeToCreate(a);
                string c = textParser.ExtractProfileName(a);
                if (b == string.Empty)
                {
                    extCharactersWithoutTime.Add(c);
                }
            }
            return extCharactersWithoutTime;
        }

        // create sum of time
        public static int createSumOfTime(List<string> listOfFieles)
        {
            TextParser textParser = new TextParser();
            int a;
            int sumOfAllMinutes = 0;
            
            foreach (string i in listOfFieles)
            {
                string b = File.ReadAllText(i);
                string c = textParser.ExtractTimeToCreate(b);
                Int32.TryParse(c, out a);
                sumOfAllMinutes += a;
            }
            return sumOfAllMinutes;
        } 

        // get files from directory
        public static List<string> getContentAllFiles(string sourceDirectory)
        {
            List<string> listOfFieles = new List<string>(Directory.GetFiles (sourceDirectory, "*.md"));
            List<string> contentOfAllFiles = new List<string>();
            foreach(string i in listOfFieles)
            {
                string a = File.ReadAllText(i);
                
                contentOfAllFiles.Add(i);
            }
            return contentOfAllFiles;
        }
        
        // get content from one file
        public static string getContentOneFile(string sourceFile)
        {
            string contentOfOneFile = File.ReadAllText(sourceFile);
            return contentOfOneFile;
        }

         
    }
}
