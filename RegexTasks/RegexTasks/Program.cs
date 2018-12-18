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
        public static List<string> personsWithoutBuildTime = new List<string>();

        static void Main(string[] args)
        {
            

            //0. Stwórz ścieżki do plików
            // Folder ze ścieżkami -- twórz ścieżki --> Lista ścieżek

            #region Array and List of Path Files
            string[] filePathsArray =
                Directory.GetFiles(@"..\..\..\..\..\20181218\cybermagic\karty-postaci"); // path in array

            List<string> filePathsList = filePathsArray.ToList(); // paths in list
            #endregion

            

            //1. Plik  -- odczyt -> string caly plik

            FileSupporter file_to_read = new FileSupporter();

            List<string> FilesStr = new List<string>();  // list of files in strings

            #region Task1
            string pathFryderykKomciur = filePathsList.FirstOrDefault(collection => collection.Contains("fryderyk-komciur"));
            string FileFryderykKomciurStr = file_to_read.Read_File(pathFryderykKomciur);
            #endregion

            CreateListOfFilesContainsText(filePathsArray, file_to_read, FilesStr);


            //2. Przesyłam odczytany plik do parsera i otrzymuje efekt w zależności od zadania
            // FryderykKomciurFileStr -- filtr(regex methods) --> string howLongWasBuild fryderyk

            TextParser WhatsTimeToCreated = new TextParser();
            TextParser WhatsName = new TextParser();

            int TimeToCreateAllFilesInMinutes = 0;

            #region Task2


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

            file_to_save.SaveToFIle(result1, "Result1", false);

            #endregion

            #region Task2

            file_to_save.SaveToFIle(result2, "Result2", false);

            #endregion



            //4. Liczy ilość wystąpień plików nie zawierających czasu budowania
            // Lista ścieżek plików -- licz wystąpienia --> ilość wystąpień plików bez czasu budowania

            int numbersOfFilesWithoutBuildTIme = GiveHowManyFilesHaveNotBuildTIme(filePathsList, WhatsTimeToCreated, WhatsName, file_to_read);
            // Console.WriteLine(numbersOfFilesWithoutBuildTIme);
            //5. Liczy średni czas tworzenia plików
            // Liczba plików nie zawierających czasu -- liczy średni czas --> średni czas
            int averangeTimeOfBuildInMinutes = GIveAverageTimeOfBuildFIles(numbersOfFilesWithoutBuildTIme, filePathsList, TimeToCreateAllFilesInMinutes);
            //5 - END

            #region Task3 
            string result3Title = "Postacie, które nie mają podanego czasu to: ";
            file_to_save.SaveToFIle(result3Title, "Result3", false);
            file_to_save.SaveToFIle("", "Result3", true);

            foreach (var person in personsWithoutBuildTime)
            {
                file_to_save.SaveToFIle(person, "Result3", true);
            }

            string averangeText = $"Średni czas budowania postaci to: {averangeTimeOfBuildInMinutes} minut.";

            file_to_save.SaveToFIle("", "Result3", true);
            file_to_save.SaveToFIle(averangeText, "Result3", true);

            #region Task3 Calculate Actualy Build Time
            //Oblicza aktualny czas budowania plików uwzględniając nie podanych z góry czasów
            //aktualny czas budowania + (średni czas * liczba wystąpień)

            int actualyTimeNeedToBuildAllFiles =
                TimeToCreateAllFilesInMinutes + (averangeTimeOfBuildInMinutes * personsWithoutBuildTime.Count);

            span = TimeSpan.FromMinutes(actualyTimeNeedToBuildAllFiles);
            Hours = span.ToString(@"hh");
            Minutes = span.ToString(@"mm");
            #endregion
            string allTimeBuildText =
                $"Uwzględniając powyższe, postacie do tej pory budowane były najpewniej {Hours} godzin {Minutes} minut.";

            file_to_save.SaveToFIle(allTimeBuildText, "Result3", true);

            #endregion

            Console.ReadKey();
        }

        private static int GIveAverageTimeOfBuildFIles(int numbersOfFilesWithoutBuildTIme, List<string> filePathsList, int TimeToCreateAllFilesInMinutes)
        {

            double average = (double)TimeToCreateAllFilesInMinutes / ((double)(filePathsList.Count - 1) - (double)numbersOfFilesWithoutBuildTIme);
            //Console.WriteLine("average float: " + average);

            return (int)Math.Round(average);
        }

        private static int GiveHowManyFilesHaveNotBuildTIme(List<string> filePathsList, TextParser WhatsTimeToCreated, TextParser WhatsName, FileSupporter file_to_read)
        {
            int numbers = 0;
            string fileInFormOfText;

            foreach (var file in filePathsList)
            {
                if (file.Contains("template")) continue;
                else
                {
                    fileInFormOfText = file_to_read.Read_File(file);

                    if(WhatsTimeToCreated.ExtractTimeToCreate(fileInFormOfText) == "")
                    {
                        //Console.WriteLine(WhatsName.ExtractProfileName(fileInFormOfText));
                        BuildListPersonsWhoDoesNotHaveBuildTime(WhatsName.ExtractProfileName(fileInFormOfText));
                        numbers++;
                    }

                }
            }            

            return numbers;
        }

        private static void BuildListPersonsWhoDoesNotHaveBuildTime(string profileName)
        {
            Program.personsWithoutBuildTime.Add(profileName);
        }

        private static void CreateListOfFilesContainsText(string[] filePathsArray, FileSupporter file_to_read, List<string> FilesStr)
        {
            foreach (var item in filePathsArray)
            {
                FilesStr.Add(file_to_read.Read_File(item));
            }
        }
    }
}
