using System.IO;

namespace Task2
{
    public class FilesImporter
    {
        public string[] ImportAllFiles()
        {
            return Directory.GetFiles("/Users/piotr/Desktop/Git/primary/20181218/" +
                                      "cybermagic/karty-postaci");
        }

    }
}
