using System;

namespace Task2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //0. Import Regexow -> brutal force lub sposob zolwia
            //TextParser TortoiseBlackBox = new TextParser();
            //Regex Time = new Regex(@"\((\d\d) min.*\)");

            //1. Import wszystkich plikow txt w tej klasie jest tez blackBox
            FilesImporter filesImporter = new FilesImporter();
            string[] Collection = filesImporter.ImportAllFiles();

            //2. Na tekscie znalezc regexy dla czasu i go zsumowac
            BlackBoxSumator blackBoxSumator = new BlackBoxSumator();
            int  TotalTime = blackBoxSumator.AddingUpToSum(Collection);

            //3. Obliczyc ilosc minut i wysiwetlic
            FinalTimeResult finalTimeResult = new FinalTimeResult();
            finalTimeResult.DisplaySums(TotalTime);

            //4. Zapisac wynik w pliku
            FileWriter fileWriter = new FileWriter();
            fileWriter.WrtieToFile(TotalTime);
        }
    }
}
