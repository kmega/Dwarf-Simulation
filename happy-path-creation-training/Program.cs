using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace happy_path_creation_training
{
    class Program
    {
        static void Main(string[] args)
        {
            //Directory <ReadAllFilenames> string[]
            string path = @"C:\Programming\C#Projects\Corealate\20181218\cybermagic\karty-postaci\";

            string[] fileNames = FileOperations.ReadAllFileNamesFromDirectory(path);

            string[] stringFiles = FileOperations.ConvertAllFilesToString(fileNames);

            //string[] <ReadAllBuildTime> string[]
            

            //string[] <SumAllBuildTime> string
            





            //*które postacie NIE mają podanej ilości czasu budowania - zapisz ich identyfikatory(imię i nazwisko)
            //*wylicz średni czas budowania postaci z tych które miały podany czas budowania
            //* ZIGNORUJ PLIK TEMPLATE(1807 - _template.md) -on świadomie jest pusty
            //* załóż, że te postacie(bez podanego czasu) były budowane tak samo szybko jak średni czas
            //*napisz ile najpewniej zajął czas budowania postaci
            //Zapisz do pliku(poniżej poprzedniego rekordu):







        }

        private static void ExtractAllBuildTime()
        {
            //Directory <ReadAllFilenames> string[]
            string path = @"C:\Programming\C#Projects\Corealate\20181218\cybermagic\karty-postaci\";

            string[] fileNames = FileOperations.ReadAllFileNamesFromDirectory(path);

            string[] stringFiles = FileOperations.ConvertAllFilesToString(fileNames);

            //string[] <ReadAllBuildTime> string[]
            string[] buildTimes = FileOperations.ExtractBuildTimesFromFile(stringFiles);

            //string[] <SumAllBuildTime> string
            string stringOutput = FileOperations.CreateStringToSave2(buildTimes);

            //string <SaveToFile> File
            string outputPath = @"zad2.txt";
            FileOperations.SaveToFile(outputPath, stringOutput);
        }









        private static void ExtractNameAndBuildTime()
        {
            //File <ReadFile to string> string
            string path = @"1807-fryderyk-komciur.md";
            string fileString = FileOperations.ConvertFileToString(path);
            // string <extract regex> string
            string extractedParam1 = TextParser.ExtractProfileName(fileString);
            string extractedParam2 = TextParser.ExtractTimeToCreate(fileString);
            // string <build output string> string
            string stringOutput = FileOperations.CreateStringToSave(extractedParam1, extractedParam2);
            // string <save to file> File
            string outputPath = @"fk-out.txt";
            FileOperations.SaveToFile(outputPath, stringOutput);
        }
    }


}
