using System;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            //folder -> var paths to files
            string folderPath = @"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\opowiesci"; //WINDOWS
            string[] pathsOfFiles = new PathExtractor().ExtractPathsToFile(folderPath);

            //paths to files -> string[] OpenedFiles
            List<string> OpenedFiles = new ContentExtractor().ExtractContent(pathsOfFiles);

            //OpenedFiles -> List<string> zaslugi
            List<string> temp = new Zasluga().Wyciag(OpenedFiles);

            Console.ReadKey();
        }
    }

    class Zasluga
    {
        public List<string> Wyciag(List<string> openedFiles)
        {
            List<string> tempList = new List<string>();
            TextParser textParser = new TextParser();
            foreach (string item in openedFiles)
            {
                string temp1 = textParser.ExtractZaslugi(item);
                if(temp1 != String.Empty)
                {
                    tempList.Add(temp1);
                }
            }
            return tempList;
        }
    }
}
