using System;
using System.IO;
using System.Collections.Generic;
using VivaRegex;

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
            List<string> extractTime = new List<string>();
            foreach (string line in listOfFieles)
            {
                string a = File.ReadAllText(line);
                string b = textParser.ExtractTimeToCreate(a);
                if (b != string.Empty) 
                {
                    extractTime.Add(b);
                }
            }
            string resultfile_3 = "result-3.txt";
            string stringToFileResult_3;
            string numberOfminutes = extractTime.Count.ToString();
            int numbOfminutes = int.Parse(numberOfminutes);
            int avgTime = minutesInt/numbOfminutes;
            
            stringToFileResult_3 = string.Format("średni czas budowania postaci wynosi {0} minut",
                                                 avgTime.ToString());
            File.WriteAllText(resultfile_3, stringToFileResult_3);

            
        }

        // -------- METHODS ---------------------

        // extract time form all files
    /*    public static List<string> extractTimeFromAllFiles(List<string> getContentAllFiles)
        {
            TextParser textParser = new TextParser();
            List<string> extractTime = new List<string>();
            foreach(string i in getContentAllFiles)
            {
                string a = File.ReadAllText(i);
                string b = textParser.ExtractTimeToCreate(a);
                extractTime.Add(b);
            }
            return extractTime;
        }
    */
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
            List<string> listOfFieles = new List<string>(Directory.GetFiles(sourceDirectory, "*.md"));
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


