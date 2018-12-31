using System;
using System.IO;
using System.Collections.Generic;
using VivaRegex;
using System.Text;
using System.Timers;

namespace Methods
{
    public class MethodsToTasks
    {
                
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
                //string a = File.ReadAllText(i);
                contentOfAllFiles.Add(i);
            }
            return contentOfAllFiles;
        }

        // get content files form Opowiesci
        public static List<string> getContentFilesFromOpowiesci(string sourceDirectoryOpowiesci)
        {
            List<string> listFilesFromOpowiesci = new List<string>(Directory.GetFiles(sourceDirectoryOpowiesci, "*.md"));
            List<string> contentFilesFromOpowiesci = new List<string>();
            foreach(string i in listFilesFromOpowiesci)
            {
               // string a = File.ReadAllText(i);
                contentFilesFromOpowiesci.Add(i);
            }
            return contentFilesFromOpowiesci;
        }
        
        // get content from one file
        public static string getContentOneFile(string sourceFile)
        {
            string contentOfOneFile = File.ReadAllText(sourceFile);
            return contentOfOneFile;
        }
    }
}