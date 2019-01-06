using System;
using System.Collections.Generic;

namespace HappyPathsWithTests
{
    public class Methods
    {
        public string GetName(string path)
        {
            string openedFile = new FileOps().ReadSingleFile(path);
            return new TextParser().ExtractProfileName(openedFile);
        }

        public int GetTime(string path)
        {
            string openedFile = new FileOps().ReadSingleFile(path);
            return Convert.ToInt32(new TextParser().ExtractTimeToCreate(openedFile));
        }

        public int GetTimeFromOpenedFile(string openedFile)
        {
            Int32.TryParse(new TextParser().ExtractTimeToCreate(openedFile), out int time);
            return time;
        }

        public int GetSummaryTime(string path)
        {
            List<string> pathToFilesInFolder = new FileOps().ReadAllPathsToFilesInFolder(path);
            List<string> AllOpenedFilesFromFolder = new FileOps().ReadAllContent(pathToFilesInFolder);

            int summaryTime = 0;

            foreach (string singleOpenedFile in AllOpenedFilesFromFolder)
            {
                summaryTime += GetTimeFromOpenedFile(singleOpenedFile);
            }

            return summaryTime;
        }
    }
}
