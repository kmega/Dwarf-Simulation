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
            string[] filePathsArrayDirPersonsCard =
                Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\karty-postaci"); //files path from directory karty postaci in array 

            string[] filePathsArrayDirStory =
                Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\opowiesci"); //files path from directory opowieści in array 

            List<string> filePathsListDirPersonsCard = filePathsArrayDirPersonsCard.ToList(); //files path from directory karty postaci in list
            List<string> filePathsListDirStory = filePathsArrayDirPersonsCard.ToList(); //files path from directory story in list
            #endregion



            //1. Plik  -- odczyt -> caly plik w stringu

            FileSupporter file_to_read = new FileSupporter();

            List<string> FilesStrPersonsCards = new List<string>();  // list of files form text in directory karty postaci in form of strings
            List<string> FilesStrDirOfStory = new List<string>();  // list of files form text in directory opowiesci in form of strings

            #region Task1
            string pathFryderykKomciur = filePathsListDirPersonsCard.FirstOrDefault(collection => collection.Contains("fryderyk-komciur"));
            string FileFryderykKomciurStr = file_to_read.Read_File(pathFryderykKomciur);
            #endregion

            CreateListOfFilesContainsText(filePathsArrayDirPersonsCard, file_to_read, FilesStrPersonsCards); // lists contains texts of files from directory karty postaci TASK 3

            CreateListOfFilesContainsText(filePathsArrayDirStory, file_to_read, FilesStrDirOfStory); // lists contains texts of files from directory opowieści TASk 4



            //2. Przesyłam odczytany plik do parsera i otrzymuje efekt w zależności od zadania
            // FryderykKomciurFileStr -- filtr(regex methods) --> string howLongWasBuild fryderyk

            //Task 1 2 PARSER
            TextParser WhatsTimeToCreated = new TextParser();
            //Task 3 PARSER
            TextParser WhatsName = new TextParser();
            //Task 4 PARSER
            TextParser MagdaPatirilParser = new TextParser();

            //GiveListFilesWhoContainsMagdaPatiril -- > Lista plików zawierających magdę patiril // TASK 4
            List<string> FilesWhoContainsMagdaPatiril = new List<string>();
            GiveListFilesWhoContainsMagdaPatiril(FilesStrDirOfStory, FilesWhoContainsMagdaPatiril, MagdaPatirilParser);

            //GiveOnlyTitleFilesWithMagdaPatiril -- > List 
            List<string> OnlyTitleFilesWithMagdaPatirilList = new List<string>();
            GiveOnlyTitleFilesWithMagdaPatiril(OnlyTitleFilesWithMagdaPatirilList, FilesWhoContainsMagdaPatiril, MagdaPatirilParser);

            #region Task2

            int TimeToCreateAllFilesInMinutes = 0;
            // GiveTimeToCreateAllFilesInMinutes -- > Czas potrzebny do zbudowania wszystkich plików

            TimeToCreateAllFilesInMinutes = GiveTImeToCreatedAllFilesInMinutes(FilesStrPersonsCards, WhatsTimeToCreated, TimeToCreateAllFilesInMinutes);

            // Console.WriteLine(TimeToCreateAllFilesInMinutes);
            TimeSpan span;
            string Hours, Minutes, result2;
            MakeResultTask2(TimeToCreateAllFilesInMinutes, out Hours, out Minutes, out result2);

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

            int numbersOfFilesWithoutBuildTIme = GiveHowManyFilesHaveNotBuildTIme(filePathsListDirPersonsCard, WhatsTimeToCreated, WhatsName, file_to_read);
            // Console.WriteLine(numbersOfFilesWithoutBuildTIme);
            //5. Liczy średni czas tworzenia plików
            // Liczba plików nie zawierających czasu -- liczy średni czas --> średni czas
            int averangeTimeOfBuildInMinutes = GIveAverageTimeOfBuildFIles(numbersOfFilesWithoutBuildTIme, filePathsListDirPersonsCard, TimeToCreateAllFilesInMinutes);

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

        private static void GiveOnlyTitleFilesWithMagdaPatiril(List<string> filesWhoContainsMagdaPatiril, List<string> filesWhoContainsMagdaPatiril1, TextParser magdaPatirilParser)
        {
           
        }

        private static void GiveListFilesWhoContainsMagdaPatiril(List<string> filesStrDirOfStory, List<string> ContainsMariaKomciurList, TextParser MagdaPatirilParser)
        {
            int i = 0;
            string ReadenFile;
            foreach (var file in filesStrDirOfStory)
            {
                ReadenFile = MagdaPatirilParser.ExtractMagdaPatril(file);

                if (ReadenFile == "Magda Patiril")
                {
                    ContainsMariaKomciurList.Add(ReadenFile);
                    Console.WriteLine(ContainsMariaKomciurList[i]);
                    i++;
                }

                else continue;
                
            }
        }

        private static void MakeResultTask2(int TimeToCreateAllFilesInMinutes, out string Hours, out string Minutes, out string result2)
        {
            TimeSpan span = TimeSpan.FromMinutes(TimeToCreateAllFilesInMinutes);
            Hours = span.ToString(@"hh");
            Minutes = span.ToString(@"mm");
            result2 = $"Wszystkie postacie do tej pory budowane były {Hours} godzin {Minutes} minut";
        }

        private static int GiveTImeToCreatedAllFilesInMinutes(List<string> FilesStrPersonsCards, TextParser WhatsTimeToCreated, int TimeToCreateAllFilesInMinutes)
        {
            foreach (var file in FilesStrPersonsCards)
            {
                string actuallyTimeNeedToCreated = WhatsTimeToCreated.ExtractTimeToCreate(file);
                // Console.WriteLine(actuallyTimeNeedToCreated);
                if (actuallyTimeNeedToCreated == "") continue;
                else
                {
                    TimeToCreateAllFilesInMinutes += int.Parse(actuallyTimeNeedToCreated);
                }
            }

            return TimeToCreateAllFilesInMinutes;
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
