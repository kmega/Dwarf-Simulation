using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTasks
{
    class Tasks
    {
        public List<string> personsWithoutBuildTime = new List<string>();

        public void TaskOne()
        {
            string[] filePathsArrayDirPersonsCard =
                   Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\karty-postaci"); //files path from directory karty postaci in array 
            List<string> filePathsListDirPersonsCard = filePathsArrayDirPersonsCard.ToList(); //files path from directory karty postaci in list
            FileSupporter file_to_read = new FileSupporter();
            FileSupporter file_to_save = new FileSupporter();


            TextParser WhatsTimeToCreated = new TextParser();

            #region Task1 ReadFile
            string FileFryderykKomciurStr = ChangeFileToReadableStr(filePathsListDirPersonsCard, file_to_read);
            #endregion

            #region Task1
            string HowLongWasBuildFryderykKomciur =
                WhatsTimeToCreated.ExtractTimeToCreate(FileFryderykKomciurStr);


            string result1 = "Fryderyk Komciur był budowany " + HowLongWasBuildFryderykKomciur + " minuty";
            #endregion Task1

            #region Task1

            file_to_save.SaveToFIle(result1, "Result1", false);

            #endregion


        }

        public void TaskTwo()
        {
            string[] filePathsArrayDirPersonsCard =
                  Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\karty-postaci"); //files path from directory karty postaci in array 
            List<string> filePathsListDirPersonsCard = filePathsArrayDirPersonsCard.ToList(); //files path from directory karty postaci in list

            FileSupporter file_to_read = new FileSupporter();
            FileSupporter file_to_save = new FileSupporter();


            TextParser WhatsTimeToCreated = new TextParser();
            List<string> FilesStrPersonsCards = new List<string>();  // list of files form text in directory karty postaci in form of strings
            List<string> FilesStrDirOfStory = new List<string>();  // list of files form text in directory opowiesci in form of strings

            CreateListOfFilesContainsText(filePathsArrayDirPersonsCard, file_to_read, FilesStrPersonsCards);

            #region Task2

            int TimeToCreateAllFilesInMinutes = 0;
            // GiveTimeToCreateAllFilesInMinutes -- > Czas potrzebny do zbudowania wszystkich plików

            TimeToCreateAllFilesInMinutes = GiveTImeToCreatedAllFilesInMinutes(FilesStrPersonsCards, WhatsTimeToCreated, TimeToCreateAllFilesInMinutes);

            // Console.WriteLine(TimeToCreateAllFilesInMinutes);
            TextParser WhatsName = new TextParser();

            int numbersOfFilesWithoutBuildTIme = GiveHowManyFilesHaveNotBuildTIme(filePathsListDirPersonsCard, WhatsTimeToCreated, WhatsName, file_to_read);


            int averangeTimeOfBuildInMinutes = GIveAverageTimeOfBuildFIles(numbersOfFilesWithoutBuildTIme, filePathsListDirPersonsCard, TimeToCreateAllFilesInMinutes);

            


            TimeSpan span;
            string Hours, Minutes, result2;

            int actualyTimeNeedToBuildAllFiles =
                TimeToCreateAllFilesInMinutes + (averangeTimeOfBuildInMinutes * personsWithoutBuildTime.Count);

            span = TimeSpan.FromMinutes(actualyTimeNeedToBuildAllFiles);
            Hours = span.ToString(@"hh");
            Minutes = span.ToString(@"mm");



            MakeResultTask2(TimeToCreateAllFilesInMinutes, out Hours, out Minutes, out result2);

            file_to_save.SaveToFIle(result2, "Result2", false);
            //Console.WriteLine("Wszystkie);
            #endregion          

        }

        public void TaskThree()
        {
            TextParser WhatsTimeToCreated = new TextParser();

            TextParser WhatsName = new TextParser();
            FileSupporter file_to_save = new FileSupporter();

            FileSupporter file_to_read = new FileSupporter();
            List<string> FilesStrPersonsCards = new List<string>();  // list of files form text in directory karty postaci in form of strings

            string[] filePathsArrayDirPersonsCard =
                  Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\karty-postaci"); //files path from directory karty postaci in array 
            List<string> filePathsListDirPersonsCard = filePathsArrayDirPersonsCard.ToList(); //files path from directory karty postaci in list

            CreateListOfFilesContainsText(filePathsArrayDirPersonsCard, file_to_read, FilesStrPersonsCards); // lists contains texts of files from directory karty postaci TASK 3

            #region Task3 
            string result3Title = "Postacie, które nie mają podanego czasu to: ";
            file_to_save.SaveToFIle(result3Title, "Result3", false);
            file_to_save.SaveToFIle("", "Result3", true);


            int TimeToCreateAllFilesInMinutes = 0;
            TimeToCreateAllFilesInMinutes = GiveTImeToCreatedAllFilesInMinutes(FilesStrPersonsCards, WhatsTimeToCreated, TimeToCreateAllFilesInMinutes);

            int numbersOfFilesWithoutBuildTIme = GiveHowManyFilesHaveNotBuildTIme(filePathsListDirPersonsCard, WhatsTimeToCreated, WhatsName, file_to_read);
            int averangeTimeOfBuildInMinutes = GIveAverageTimeOfBuildFIles(numbersOfFilesWithoutBuildTIme, filePathsListDirPersonsCard, TimeToCreateAllFilesInMinutes);


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




            TimeSpan span;
            string Hours, Minutes;
            span = TimeSpan.FromMinutes(actualyTimeNeedToBuildAllFiles);
            Hours = span.ToString(@"hh");
            Minutes = span.ToString(@"mm");
            #endregion
            string allTimeBuildText =
                $"Uwzględniając powyższe, postacie do tej pory budowane były najpewniej {Hours} godzin {Minutes} minut.";

            file_to_save.SaveToFIle(allTimeBuildText, "Result3", true);

            #endregion
        }

        public void TaskFour()
        {
            string[] filePathsArrayDirStory =
                           Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\opowiesci"); //files path from directory opowieści in array
            
            List<string> filePathsListDirStory = filePathsArrayDirStory.ToList(); //files path from directory story in list
            FileSupporter file_to_save = new FileSupporter();
            FileSupporter file_to_read = new FileSupporter();
            List<string> FilesStrDirOfStory = new List<string>();  // list of files form text in directory opowiesci in form of strings

            CreateListOfFilesContainsText(filePathsArrayDirStory, file_to_read, FilesStrDirOfStory); // lists contains texts of files from directory opowieści TASk 4

            TextParser MagdaPatirilParser = new TextParser();

            //GiveListFilesWhoContainsMagdaPatiril -- > Lista ścieżek plików zawierających magdę patiril // TASK 4
            List<string> FilesPathWhoContainsMagdaPatiril = new List<string>();
            GiveListFilesPathWhoContainsMagdaPatiril(FilesStrDirOfStory, filePathsArrayDirStory, FilesPathWhoContainsMagdaPatiril, MagdaPatirilParser);

            //GiveOnlyTitleFilesWithMagdaPatiril -- > List nazw opowieści w których jest magda patiril
            List<string> OnlyTitleFilesWithMagdaPatirilList = new List<string>();
            GiveOnlyTitleFilesWithMagdaPatiril(OnlyTitleFilesWithMagdaPatirilList, FilesPathWhoContainsMagdaPatiril, file_to_read, MagdaPatirilParser);

            #region Task4
            string result4Title = "Magda Patiril występowała w następujących Opowieściach:  ";
            file_to_save.SaveToFIle(result4Title, "Result4", false);
            file_to_save.SaveToFIle("", "Result4", true);

            foreach (var story in OnlyTitleFilesWithMagdaPatirilList)
            {
                file_to_save.SaveToFIle(story, "Result4", true);
            }
            #endregion

        }

        public void TaskSix()
        {
            List<string> AllFilesPathsWithKalinaRotmistrz = new List<string>();
            //1.Stwórz listę plików gdzie występuje Kalina Rotmistrz -> AllFilesPathsWithKalinaRotmistrz
            MakeListFilesOfPathsWithKalinaRotmistrz(AllFilesPathsWithKalinaRotmistrz);

            Dictionary<string, int> WhoWasActingAndHowManyTimes = new Dictionary<string, int>();
            //2.Stwórz słownik osób z którymi występowała Kalina Rotmistrz, każda osoba posiada ilość wystąpień -> WhoWasActingAndHowManyTimes
            MakeDictPersonsWhoWasActingWithKalina(AllFilesPathsWithKalinaRotmistrz, WhoWasActingAndHowManyTimes);
            
            //3.Zapisz do pliku rezulat 6 kto występował z Kaliną Rotmistrz i ile razy
            SaveResultatTaskSixToFile(WhoWasActingAndHowManyTimes);

        }

        private void SaveResultatTaskSixToFile(Dictionary<string, int> whoWasActingAndHowManyTimes)
        {
            FileSupporter file_to_save = new FileSupporter();

            string titleResult = "Kalina Rotmistrz spotkała następujące postacie: ";
            file_to_save.SaveToFIle(titleResult, "Result6", false);
            file_to_save.SaveToFIle("", "Result6", true);

            foreach (var person in whoWasActingAndHowManyTimes)
            {
                string person_to_save = person.Key + ": " + person.Value;
                file_to_save.SaveToFIle(person_to_save, "Result6", true);
            }
        }

        private void MakeDictPersonsWhoWasActingWithKalina(List<string> allFilesPathsWithKalinaRotmistrz, Dictionary<string, int> whoWasActingAndHowManyTimes)
        {
            //2.Sprawdź z jakimi postaciami występowała Kalina Rotmistrz i ile razy
            CheckWithWhomKalinaRotmistrzWasActingAndHowManyTimes
                (allFilesPathsWithKalinaRotmistrz, whoWasActingAndHowManyTimes);
        }

        private void CheckWithWhomKalinaRotmistrzWasActingAndHowManyTimes(List<string> allFilesPathsWithKalinaRotmistrz, Dictionary<string, int> whoWasActingAndHowManyTimes)
        {
            List<string> PersonsWhoActWithKalina = new List<string>();
            string contain_file;
            foreach (var file in allFilesPathsWithKalinaRotmistrz)
            {
                //Daj zawartość pierwszego pliku w którym jest Kalina --> string contains
                contain_file = GiveFileContain(file);
                //Dodaj osoby występujące z Kaliną Rotmistrz do Listy osób występujących z Kaliną
                AddPersonsFromOneFileActingWithKalinaToList(PersonsWhoActWithKalina, contain_file);
                
            }
            //Usuwa wystąpienia kaliny rotmistrz z listy
            RebuildListDeletingKalina(PersonsWhoActWithKalina);

            
            
            //Dodaj osobę do słownika (Nazwa osoby oraz ilość wystąpień)
            AddPersonsFromOneFileActingWithKalinaToDict(whoWasActingAndHowManyTimes, PersonsWhoActWithKalina);
        }
       

        private void RebuildListDeletingKalina(List<string> personsWhoActWithKalina)
        {
            //Usuwaj Kalinę Rotmistrz, dopóki występuje w liście
            while(personsWhoActWithKalina.Contains("Kalina Rotmistrz"))
            {
                personsWhoActWithKalina.Remove("Kalina Rotmistrz");
            }
            
        }

        private void AddPersonsFromOneFileActingWithKalinaToDict(Dictionary<string,int> whoWasActingAndHowManyTimes, List<string> PersonsWhoActWithKalina)
        {
            //Pogrupuj listę po osobach
            GroupListByPersonAndAddToDict(PersonsWhoActWithKalina, whoWasActingAndHowManyTimes);               
        }

        private void GroupListByPersonAndAddToDict(List<string> personsWhoActWithKalina, Dictionary<string, int> whoWasActingAndHowManyTimes)
        {
            var group = personsWhoActWithKalina.GroupBy(x => x);
            foreach (var person in group)
            {
                whoWasActingAndHowManyTimes.Add(person.Key, person.Count());
            }
        }


        private void AddPersonsFromOneFileActingWithKalinaToList(List<string> personsWhoActWithKalina, string file_contain)
        {
            TextParser KalinaParser = new TextParser();
            //Daj string z sekcji zasługi
            string stuffFromZaslugi;
            stuffFromZaslugi = KalinaParser.ExtractStuffFromZaslugi(file_contain);
            //Daj liste osób z sekcji zasługi
            KalinaParser.ExtractPersonsActingWithKalina(stuffFromZaslugi, personsWhoActWithKalina);           
        }

        private void MakeListFilesOfPathsWithKalinaRotmistrz(List<string> AllFilesPathsWithKalinaRotmistrz)
        {
            string[] allPathsFilesFromOpowiesciArray =
                           Directory.GetFiles(@"..\..\..\..\20181218\cybermagic\opowiesci");
            List<string> allPathsFilesFromOpowiesciList = allPathsFilesFromOpowiesciArray.ToList();

            //Szukaj pliku gdzie jest kalina rotmistrz dopóki istnieją pliki
            foreach (var file in allPathsFilesFromOpowiesciList)
            {
                //Dodaj plik gdzie jest kalina rotmistrz do listy plików gdzie jest kalina rotmistrz
                AddPathOfFileToList(file, AllFilesPathsWithKalinaRotmistrz);
                                
            }
            
        }

        private void AddPathOfFileToList(string file, List<string> allFilesPathsWithKalinaRotmistrz)
        {
            //Znajdź plik gdzie jest kalina rotmistrz
            SearchFileWithKalinaRotmistrz(file, allFilesPathsWithKalinaRotmistrz);           
        }

        private void SearchFileWithKalinaRotmistrz(string file, List<string> allFilesPathsWithKalinaRotmistrz)
        {
            //Otworz plik -> treść otwartego pliku
            string file_contain = GiveFileContain(file);
            //Sprawdź czy występuje Kalina Rotmistrz --> true,false
            //Jeśli true dodaj znaleziony plik do listy allFilesPathsWithKalinaRotmistrz
            if (CheckDoesKalinaExist(file_contain)) allFilesPathsWithKalinaRotmistrz.Add(file);
        }

        private bool CheckDoesKalinaExist(string file_contain)
        {
            TextParser Kalina = new TextParser();
            if (Kalina.CheckingExistOfKalina(file_contain).Any()) return true;

            else return false;
        }

        private string GiveFileContain(string file)
        {
            FileSupporter file_to_read = new FileSupporter();
            return file_to_read.Read_File(file);
        }

        private static void GiveOnlyTitleFilesWithMagdaPatiril(List<string> OnlyTitleFilesWithMagdaPatirilList, List<string> filesWhoContainsMagdaPatiril, FileSupporter file, TextParser magdaPatirilParser)
        {
            List<string> tempStringFile = new List<string>();
            int i = 0;

            foreach (var item in filesWhoContainsMagdaPatiril)
            {
                tempStringFile.Add(file.Read_File(item));
                OnlyTitleFilesWithMagdaPatirilList.Add(magdaPatirilParser.ExtractTitleOfStory(tempStringFile[i]));
                i++;
            }
        }

        private static void GiveListFilesPathWhoContainsMagdaPatiril(List<string> filesStrDirOfStory, string[] filePathsArrayDirStory, List<string> FilesPathWhoContainsMagdaPatiril, TextParser MagdaPatirilParser)
        {
            int i = 0;
            string ReadenFile;
            foreach (var file in filesStrDirOfStory)
            {
                ReadenFile = MagdaPatirilParser.ExtractStuffWithMagda(file);
                if (ReadenFile.Contains("Magda Patiril"))
                {
                    FilesPathWhoContainsMagdaPatiril.Add(filePathsArrayDirStory[i]);
                }
                i++;
            }
        }

        void CreateListOfFilesContainsText(string[] filePathsArray, FileSupporter file_to_read, List<string> FilesStr)
        {
            foreach (var item in filePathsArray)
            {
                FilesStr.Add(file_to_read.Read_File(item));
            }
        }

        string ChangeFileToReadableStr(List<string> _filePathsListDirPersonsCard, FileSupporter _file_to_read)
        {
            string pathFryderykKomciur = _filePathsListDirPersonsCard.FirstOrDefault(collection => collection.Contains("fryderyk-komciur"));
            string _FileFryderykKomciurStr = _file_to_read.Read_File(pathFryderykKomciur);
            return _FileFryderykKomciurStr;
        }

        void MakeResultTask2(int _TimeToCreateAllFilesInMinutes, out string _Hours, out string _Minutes, out string _result2)
        {
            TimeSpan _span = TimeSpan.FromMinutes(_TimeToCreateAllFilesInMinutes);
            _Hours = _span.ToString(@"hh");
            _Minutes = _span.ToString(@"mm");
            _result2 = $"Wszystkie postacie do tej pory budowane były {_Hours} godzin {_Minutes} minut";
        }

        int GiveTImeToCreatedAllFilesInMinutes(List<string> _FilesStrPersonsCards, TextParser _WhatsTimeToCreated, int _TimeToCreateAllFilesInMinutes)
        {
            foreach (var file in _FilesStrPersonsCards)
            {
                string actuallyTimeNeedToCreated = _WhatsTimeToCreated.ExtractTimeToCreate(file);
                // Console.WriteLine(actuallyTimeNeedToCreated);
                if (actuallyTimeNeedToCreated == "") continue;
                else
                {
                    _TimeToCreateAllFilesInMinutes += int.Parse(actuallyTimeNeedToCreated);
                }
            }

            return _TimeToCreateAllFilesInMinutes;
        }

        int GIveAverageTimeOfBuildFIles(int _numbersOfFilesWithoutBuildTIme, List<string> filePathsList, int _TimeToCreateAllFilesInMinutes)
        {

            double average = (double)_TimeToCreateAllFilesInMinutes / ((double)(filePathsList.Count - 1) - (double)_numbersOfFilesWithoutBuildTIme);
            //Console.WriteLine("average float: " + average);

            return (int)Math.Round(average);
        }

        int GiveHowManyFilesHaveNotBuildTIme(List<string> filePathsList, TextParser _WhatsTimeToCreated, TextParser _WhatsName, FileSupporter _file_to_read)
        {
            int numbers = 0;
            string fileInFormOfText;

            foreach (var file in filePathsList)
            {
                if (file.Contains("template")) continue;
                else
                {
                    fileInFormOfText = _file_to_read.Read_File(file);

                    if (_WhatsTimeToCreated.ExtractTimeToCreate(fileInFormOfText) == "")
                    {
                        //Console.WriteLine(WhatsName.ExtractProfileName(fileInFormOfText));
                        BuildListPersonsWhoDoesNotHaveBuildTime(_WhatsName.ExtractProfileName(fileInFormOfText));
                        numbers++;
                    }

                }
            }

            return numbers;
        }

        void BuildListPersonsWhoDoesNotHaveBuildTime(string profileName)
        {
            personsWithoutBuildTime.Add(profileName);
        }

    }
}
