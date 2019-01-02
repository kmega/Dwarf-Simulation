using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AllTasksInOne
{
    public class Task6
    {
        public void Main()
        {
            //folderpath -> string[] sciezki
            string folderPath = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\opowiesci";
            string[] storyPaths = GetPaths(folderPath);
            //sciezki -> otwarte pliki
            List<string> openedStories = GetValuesOfFiles(storyPaths);

            //otwarte pliki -> zaslugi
            List<string> meritsOfStories = GetMerits(openedStories);

            //imie dla porownan
            string nameKalinaRomistrz = GetKalinaName(meritsOfStories);

            //zaslugi -> lista postaci ktore spotkala Kalina
            List<string> Characters = GetCharactersFromMerits(meritsOfStories, nameKalinaRomistrz);

            DisplayAndSaveResult(Characters);

        }

        private static void DisplayAndSaveResult(List<string> Characters)
        {
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\AllTasksInOne\AllTasksInOne\Results\Result6.txt");

            var q = from x in Characters
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };

            Console.WriteLine("Kalina Rotmistrz spotkała następujące postacie:");
            streamWriter.WriteLine("Kalina Rotmistrz spotkała następujące postacie:");

            Console.WriteLine();
            streamWriter.WriteLine("");

            foreach (var x in q)
            {
                if (x.Value != " Kalina Rotmistrz:")
                {
                    Console.WriteLine("{0} {1} razy",x.Value, x.Count);
                    streamWriter.WriteLine("{0} {1} razy", x.Value, x.Count);
                }
            }

            streamWriter.Close();
        }

        private List<string> GetCharactersFromMerits(List<string> meritsOfStories, string nameKalinaRomistrz)
        {
            List<string> returnList = new List<string>();
            TextParser textParser = new TextParser();

            foreach (string merit in meritsOfStories)
            {
                if(merit.Contains("Kalina Rotmistrz"))
                {
                    MatchCollection matches = Regex.Matches(merit, @"^* (\w+ \w+):", RegexOptions.Multiline);

                    foreach (object match in matches)
                    {
                        string tempMatch = match.ToString();
                        returnList.Add(tempMatch);
                    }
                }
            }

            return returnList;
        }

        private string GetKalinaName(List<string> meritsOfStories)
        {
            TextParser textParser = new TextParser();
            string returnName = null;

            foreach (string merit in meritsOfStories)
            {
                returnName = textParser.ExtractCharactersOfMerits(merit).Replace(':', '\0');
                if(returnName == "Kalina Rotmistrz")
                {
                    break;
                }
            }
            return returnName;
        }

        private List<string> GetMerits(List<string> openedStories)
        {
            List<string> returnList = new List<string>();
            TextParser textParser = new TextParser();

            foreach (string story in openedStories)
            {
                string tempMerit = textParser.ExtractMerit(story);
                if(tempMerit != string.Empty)
                {
                    returnList.Add(tempMerit);
                }
            }
            return returnList;
        }

        private List<string> GetValuesOfFiles(string[] storyPaths)
        {
            List<string> returnList = new List<string>();

            foreach (string path in storyPaths)
            {
                string tempValue = File.ReadAllText(path);
                returnList.Add(tempValue);
            }
            return returnList;
        }

        private string[] GetPaths(string folderPath)
        {
            return Directory.GetFiles(folderPath);
        }
    }
}