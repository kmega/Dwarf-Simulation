using System.Collections.Generic;
using System.IO;

namespace Task4
{
    public class FileOpener
    {
        public List<string> OpenFileFromPath(string[] PathsOfFiles)
        {
            List<string> ListWithContentToReturn = new List<string>();

            foreach (string path in PathsOfFiles)
            {
                string temporaryOpenedFileToAddToList = File.ReadAllText(path);
                ListWithContentToReturn.Add(temporaryOpenedFileToAddToList);
            }
            return ListWithContentToReturn;
        }
    }
}
