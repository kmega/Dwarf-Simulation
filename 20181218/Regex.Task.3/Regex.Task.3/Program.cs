using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //1. Import wszystkich plikow txt w tej klasie jest tez blackBox -> string[] collection
            FilesImporter filesImporter = new FilesImporter();
            string dirPath = "/Users/piotr/Desktop/Git/primary/20181218/cybermagic/karty-postaci";
            string[] Collection = filesImporter.ImportAllFiles(dirPath);

            //2. kolekcja -> kolekcja ignore template
            BlackBoxSumator blackBoxSumator = new BlackBoxSumator();
            List<string> NewCollection = blackBoxSumator.IgnoreTemplate(Collection);

            //3. kolekcja contentow tych plikow 
            List<string> OpenedContent = blackBoxSumator.OpenFiles(NewCollection);

            //4. List contents -> List contents with time
            List<string> ContentsWithTime = blackBoxSumator.GetTimes(OpenedContent);

            //5. ContentsWithTime -> obliczyc sredni czas tworzenia
            double sumTime = blackBoxSumator.getSumTime(ContentsWithTime);
            int count = blackBoxSumator.getCountTime(ContentsWithTime);
            double avgTime = blackBoxSumator.getAvgTime(sumTime, count);

            //6. OpenedContent, avgTime -> wyswietl zakladajac
            blackBoxSumator.DisplayAssume(avgTime, sumTime);
            ////4. Zapisac wynik w pliku
            //FileWriter fileWriter = new FileWriter();
            //fileWriter.WrtieToFile(TotalTime);
        }


    }


}
