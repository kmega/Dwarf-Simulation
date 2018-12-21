using System.Collections.Generic;

namespace Task4
{
    partial class MainClass
    {
        public static void Main(string[] args)
        {
            //FileImporter -> string[] ListOfPaths(folder path)
            string folderPath = @"/Users/piotr/Desktop/Git/primary/20181218/cybermagic/opowiesci";
            string[] PathsOfFiles = new FileImporter().ListOfPaths(folderPath);

            //PathsOfFiles -> List<string> ContentOfFiles
            List<string> ListWithContent = new FileOpener().OpenFileFromPath(PathsOfFiles);

            //ListWithContent -> List<string> ContentsWithMagdaPatril
            List<string> ContentsWithMagdaPatril = new RegexOperator().MagdaTitleExtractor(ListWithContent);

            //ContentsWithMagdaPatril -> string Name
            string magdaName = new RegexOperator().MagdaName(ListWithContent);
            magdaName = magdaName.Substring(0, 13);

            //Display output
            new Display().PresentOutput(magdaName, ContentsWithMagdaPatril);

        }
    }
}
