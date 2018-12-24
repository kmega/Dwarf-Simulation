using System.IO;

namespace Task2
{
    public class FilesImporter
    {
        public string[] ImportAllFiles()
        {
            //macos return Directory.GetFiles("/Users/piotr/Desktop/Git/primary/20181218/" + "cybermagic/karty-postaci");
            return Directory.GetFiles(@"C:\Users\Piotr\Desktop\GitLab\primary\20181218\cybermagic\karty-postaci");

        }

    }
}
