using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();

            Task2();

            // Task 3


            // Wczytanie wszystkich tekstów postaci w folderze

            string directory = @"C:\Users\Lenovo\Desktop\primary\20181218\cybermagic\karty-postaci";
            string[] fileNames = FindAllFileNames(directory);
            //ścieżki plików => ignorowanie pliku template => ścieżki bez pliku template
            List<string> ListOfCharactersTexts = FindTextInAllFiles(fileNames);

            // karty postaci => zbuduj liste postaci => Lista postaci ze statami 
            List<Character> ListOfCharactersStats = BuildAllCharactersTimeProfile(ListOfCharactersTexts);


            // lista postaci ze statami => odfiltruj te bez czasu => Lista postaci bez czasu
            List<Character> ListOfCharacterWithoutTimes = SelectCharactersWithoutTime(ListOfCharactersStats);


            //lista postaci z filtrem czasu budowania => oblicz średni czas budowania postaci  =>średni czas budowania
            string averangeTimeCharactersWithTime = AverangeCharacterBuildTime(ListOfCharactersStats).ToString();

            // średni czas budowania postaci, lista postaci bez czasu, całkowity czas budowania postaci => wynik

            // WriteResult(---,ListOfCharacterWithoutTimes, averangeTimeCharactersWithTime);
            //WriteResult(); - do implementacji

            Console.ReadKey();
        }

        private static void WriteResult()
        {

            using (StreamWriter sw = File.AppendText(@"C:\Users\Lenovo\Desktop\primary\Tasks\result2.md"))
            {
                sw.WriteLine();
            }


        }

        private static double AverangeCharacterBuildTime(List<Character> listOfCharacter)
        {
            double sumOfTime = 0;
            double charactersNumber = 0;

            foreach (var item in listOfCharacter)
            {
                if (item.Time != "")
                {
                    sumOfTime += double.Parse(item.Time);
                    charactersNumber += 1;
                }
            }

            double ListOfCharactersWithoutTime = listOfCharacter.Count - charactersNumber;
            
            double averangeTime = sumOfTime / charactersNumber;

            

            foreach (var item in listOfCharacter)
            {
                if (item.Time == "")
                {
                    item.Time = averangeTime.ToString();
                }
            }
            sumOfTime = 0;
            charactersNumber = 0;

            foreach (var item in listOfCharacter)
            {
               
                    sumOfTime += double.Parse(item.Time);
                    charactersNumber += 1;
                
            }
            averangeTime = sumOfTime / charactersNumber;
            return averangeTime;

        }

        private static List<Character> SelectCharactersWithoutTime(List<Character> listOfCharacters)
        {
            List<Character> listOfCharacter = new List<Character>();
            foreach (var item in listOfCharacters)
            {
                if (item.Time == "")
                {
                    listOfCharacter.Add(item);
                }
            }
            return listOfCharacter;
        }

        private static List<Character> BuildAllCharactersTimeProfile(List<string> listOfCharactersText)
        {
            List<Character> ListOfCharactersProfileTimes = new List<Character>();

            foreach (var character in listOfCharactersText)
            {
                string time = FindTimeInSingleFile(character);
                string name = FindNameInSingleFile(character);
                ListOfCharactersProfileTimes.Add(new Character() { Time = time, Title = name });
            };
            return ListOfCharactersProfileTimes;


        }

        private static void Task2()
        {
            //Task 2

            //ścieżka folderu => wyznacz wszystkie ścieżki plików => ścieżki plików
            string directory = @"C:\Users\Lenovo\Desktop\primary\20181218\cybermagic\karty-postaci";
            string[] fileNames = FindAllFileNames(directory);

            // ścieżki plików => Wczytaj teksty plików => teksty w plikach

            List<string> TextInFiles = FindTextInAllFiles(fileNames);

            // lista tekstów plików => wyszukaj czasy   => czasy plików
            List<string> ListOfTimes = TimeInFiles(TextInFiles);

            // czasy plików => sumuj czasy => suma czasów
            int sumOfTimes = SumAllFileTimes(ListOfTimes);

            //suma czasów = >  konwersja czasu z minut na godziny
            string convertedTime = HoursMinutesTimeConverter(sumOfTimes);

            //Zapisz wynik

            WriteResult(convertedTime);
        }

        private static void WriteResult(string time)
        {
            string result = $"Wszystkie postacie do tej pory budowane były {time}";

            string path2 = @"C:\Users\Lenovo\Desktop\primary\Tasks\result2.md";
            File.WriteAllText(path2, result);
        }

        private static string HoursMinutesTimeConverter(int sumOfTimes)
        {
            TimeSpan time = TimeSpan.FromMinutes(sumOfTimes);
            string hours = time.Hours.ToString();
            string minutes = time.Minutes.ToString();
            string convertedTime = $"{hours} godzin i {minutes} minut";
            return convertedTime;


        }

        private static int SumAllFileTimes(List<string> listOfTimes)
        {
            int timer = 0;
            foreach (var time in listOfTimes)
            {
                if (time != "")
                {
                    timer += int.Parse(time);
                }

            }
            return timer;
        }

        private static List<string> TimeInFiles(List<string> filesTime)
        {
            List<string> FilesTime = new List<string>();

            foreach (var time in filesTime)
            {
                FilesTime.Add(FindTimeInSingleFile(time));

            }
            return FilesTime;
        }

        private static List<string> FindTextInAllFiles(string[] fileNames)
        {
            List<string> FilesText = new List<string>();


            foreach (var file in fileNames)
            {
                if (!file.Contains("template"))
                {
                    FilesText.Add(ReadSingleFile(file));
                }

            }
            return FilesText;


        }

        private static string[] FindAllFileNames(string directory)
        {

            string[] fileEntries = Directory.GetFiles(directory);
            return fileEntries;
        }

        private static void Task1()
        {
            // Task 1
            // dane wejściowe = > Wczytanie pliku = > tekst
            string path = @"C:\Users\Lenovo\Desktop\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string openFile = ReadSingleFile(path);


            //plik wejściowy => wyszukanie czasu => czas
            string fkTime = FindTimeInSingleFile(openFile);


            // plik wejściowy=> wyszukanie imienia = > imie
            string fkName = FindNameInSingleFile(openFile);


            // dane wyjściowe => zapisz do pliku => plik
            SaveResult(fkName, fkTime);
        }

        private static void SaveResult(string name, string time)
        {
            string result = $"{name} był budowany {time} minuty";

            string path2 = @"C:\Users\Lenovo\Desktop\primary\Tasks\result.md";
            File.WriteAllText(path2, result);
        }

        private static string FindTimeInSingleFile(string file)
        {
            TextParser textParser = new TextParser();
            string time = textParser.ExtractTimeToCreate(file);
            return time;
        }

        private static string FindNameInSingleFile(string file)
        {
            TextParser textParser = new TextParser();
            string name = textParser.ExtractProfileName(file);
            return name;
        }

        private static string ReadSingleFile(string path)
        {
            string openFile = File.ReadAllText(path);
            return openFile;
        }
    }
}
