using System;
using System.Collections.Generic;
using System.IO;

namespace Task6
{
    class ContentExtractor
    {
        public List<string> ExtractContent(string[] pathsOfFiles)
        {
            List<string> returnList = new List<string>();

            foreach (string path in pathsOfFiles)
            {
                string content = File.ReadAllText(path);
                returnList.Add(content);
            }
            return returnList;
        }
    }
}
