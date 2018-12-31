using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using VivaRegex;
using Methods;

namespace regexy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Task: 1, 2, 3, 4");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                {
                    Task1();
                    break;
                }
                case 2:
                {
                    Task2();
                    break;
                }
                case 3:
                {
                    Task3();
                    break;
                }
                case 4:
                {
                    Task4();
                    break;
                }
            }
            
        }
            

             // ZAD 1 
        public static void Task1()
        {
            string sourceFile = "1807-fryderyk-komciur.md";  
            string resultfile_1 = "result-1.txt";
            string stringToFileResult_1;
            string contentOneFile = MethodsToTasks.getContentOneFile(sourceFile);
            string contentOneFileName = new TextParser().ExtractProfileName(contentOneFile);
            string contentOneFileTime = new TextParser().ExtractTimeToCreate(contentOneFile);
            stringToFileResult_1 = string.Format("{0}, był budowany {1} minuty", contentOneFileName, contentOneFileTime);
            File.WriteAllText(resultfile_1, stringToFileResult_1);
        }    
            // ZAD 2
        public static void Task2()
        {
            string sourceDirectory = "cybermagic/karty-postaci/";
            string resultfile_2 = "result-2.txt";
            string stringToFileResult_2;
            List<string> listOfFieles = new List<string>(MethodsToTasks.getContentAllFiles(sourceDirectory));
            string sumOfAllMinutes = MethodsToTasks.createSumOfTime(listOfFieles).ToString();
            int minutesInt = int.Parse(sumOfAllMinutes);
            decimal minutesDecimal = decimal.Parse(sumOfAllMinutes);
                   
            stringToFileResult_2 = string.Format("Wszystkie postacie do tej pory budowane były {0} godzin {1} minuty",
                                                    minutesInt/60, minutesDecimal%60);
            File.WriteAllText(resultfile_2, stringToFileResult_2);
        }
            // ZAD 3
        public static void Task3()
        {
            string sourceDirectory = "cybermagic/karty-postaci/";
            string resultfile_3 = "result-3.txt";
            string stringToFileResult_3_1;
            string stringToFileResult_3_2;
            List<string> charactersWithoutTime = new List<string>(MethodsToTasks.getContentAllFiles(sourceDirectory));
            List<string> countWithoutEmptyLines = new List<string>(MethodsToTasks.extractCharactersWithoutTime(charactersWithoutTime));
            
            string numberOfminutes = MethodsToTasks.extractCharactersWithoutTime(charactersWithoutTime).Count.ToString();
            
            int countPersonWithoutTime = 0;
            foreach(string i in countWithoutEmptyLines)
            {
                if (i != string.Empty)
                {
                    countPersonWithoutTime ++;
                }
            }
            //--------- dubel - do optymalizacji
            List<string> listOfFieles = new List<string>(MethodsToTasks.getContentAllFiles(sourceDirectory));
            string sumOfAllMinutes = MethodsToTasks.createSumOfTime(listOfFieles).ToString();
            int minutesInt = int.Parse(sumOfAllMinutes);

            int numbOfminutes = int.Parse(numberOfminutes);
            int avgTime = minutesInt/numbOfminutes;

            //save to file characters without given time
            System.IO.File.AppendAllLines(resultfile_3, MethodsToTasks.extractCharactersWithoutTime(charactersWithoutTime));
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
            // ZAD 4
        public static void Task4()
        {
            string stringToFileResult;
            TextParser textParser = new TextParser();
            string sourceDirectoryOpowiesci = "cybermagic/opowiesci/";
            string resultfile_4 = "result-4.txt";
            List<string> listOfFilesOpowiesci = new List<string>(MethodsToTasks.getContentFilesFromOpowiesci(sourceDirectoryOpowiesci));
                       
            string stories = "";
            foreach(var y in listOfFilesOpowiesci)
            {
                if(File.ReadAllText(y).Contains("Magda Patiril"))
                {
                   stories += textParser.ExtractStoryWithMagda(File.ReadAllText(y)) +"\n";
                }
            }
            string textTofile = string.Format("Magda Patiril występowała w nastepujących powieściach");
            stringToFileResult = string.Format("{0} ", stories);
            File.WriteAllText(resultfile_4, textTofile + "\n");
            File.AppendAllText(resultfile_4, stringToFileResult);
        }
            
        
    }
}
