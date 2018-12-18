using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            //0. Stwórz ścieżki do plików
            // Folder ze ścieżkami -- twórz ścieżki --> Lista ścieżek

            #region Array and List of Path Files
            string[] filePathsArray =
                Directory.GetFiles(@"..\..\..\..\..\20181218\cybermagic\karty-postaci"); // path in array

            List<string> filePathsList = filePathsArray.ToList(); // path in list
            #endregion

            //1. Plik  -- odczyt -> string calyplik

            FileSupporter file_to_read = new FileSupporter();

            List<string> FilesStr = new List<string>();  // list of files in strings

            #region Task1
            string pathFryderykKomciur = filePathsList.FirstOrDefault(collection => collection.Contains("fryderyk-komciur"));
            string FileFryderykKomciurStr = file_to_read.Read_File(pathFryderykKomciur);
            #endregion

            CreatedListOfFilesContainsText(filePathsArray, file_to_read, FilesStr);


            //2. Przesyłam odczytany plik do parsera i otrzymuje efekt w zależności od zadania
            // FryderykKomciurFileStr -- filtr(regex methods) --> string howLongWasBuild fryderyk

            TextParser WhatsTimeToCreated = new TextParser();

            #region Task2
            int TimeToCreateAllFilesInMinutes = 0;

            foreach (var file in FilesStr)
            {
                string actuallyTimeNeedToCreated = WhatsTimeToCreated.ExtractTimeToCreate(file);
               // Console.WriteLine(actuallyTimeNeedToCreated);
                if (actuallyTimeNeedToCreated == "") continue;
                else
                {
                    TimeToCreateAllFilesInMinutes += int.Parse(actuallyTimeNeedToCreated);
                }
            }
           // Console.WriteLine(TimeToCreateAllFilesInMinutes);
            TimeSpan span = TimeSpan.FromMinutes(TimeToCreateAllFilesInMinutes);
            string Hours = span.ToString(@"hh");
            string Minutes = span.ToString(@"mm");

            string result2 = $"Wszystkie postacie do tej pory budowane były {Hours} godzin {Minutes} minut";

            //Console.WriteLine("Wszystkie);
            #endregion

            #region Task1
            string HowLongWasBuildFryderykKomciur =
                WhatsTimeToCreated.ExtractTimeToCreate(FileFryderykKomciurStr);


            string result1 = "Fryderyk Komciur był budowany " + HowLongWasBuildFryderykKomciur + " minuty";
            #endregion Task1

            //3. Dane końcowe --> zapis do pliku --> rezultat

            FileSupporter file_to_save = new FileSupporter();

            #region Task1

            file_to_save.SaveToFIle(result1, "Result1");

            #endregion

            #region Task2

            file_to_save.SaveToFIle(result2, "Result2");

            #endregion

            Console.ReadKey();
        }

        private static void CreatedListOfFilesContainsText(string[] filePathsArray, FileSupporter file_to_read, List<string> FilesStr)
        {
            foreach (var item in filePathsArray)
            {
                FilesStr.Add(file_to_read.Read_File(item));
            }
        }
    }
}
