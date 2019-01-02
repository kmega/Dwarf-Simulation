using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace regex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TextParser textOperation = new TextParser();
            GetTheListOfPathThatFiles getthelistofpathes = new GetTheListOfPathThatFiles();    
            
            List<string> PathesOfFiles = getthelistofpathes.ListOfPathThatFiles(@"C:\Users\lysia\OneDrive\Pulpit\cor2\Corealate_materiały\regexy\primary-develop\20181218\cybermagic\karty-postaci");
           
            List<string> TimesforEveryoneIntList = new List<string> { }; List<int> IntListPersonsWhoHaveNoTimeInFile = new List<int> { };
            GetTheListofEveryoneTimeBuilding getthelistoftimes = new GetTheListofEveryoneTimeBuilding(PathesOfFiles, TimesforEveryoneIntList, IntListPersonsWhoHaveNoTimeInFile); 
            
            List<string> PersonsforWhomWeDontKnowTime = new List<string> { };
            GetTheListOfEveryoneWhoHaveNOTATimeInFile listofpersons = new GetTheListOfEveryoneWhoHaveNOTATimeInFile(PathesOfFiles, IntListPersonsWhoHaveNoTimeInFile, PersonsforWhomWeDontKnowTime);
            int SumOfTimes = TimesforEveryoneIntList.Select(s => Convert.ToInt32(s)).ToList().Sum();
            int AverageOfTimeBuilding = SumOfTimes / (PathesOfFiles.Count - IntListPersonsWhoHaveNoTimeInFile.Count);
            int TheSumOfTimeOfBuildingEveryoneEvenPersonsWhoHaveNotTimeinFileButWeHaveAverage = (SumOfTimes + (AverageOfTimeBuilding * IntListPersonsWhoHaveNoTimeInFile.Count));
            //ZAPIS DO PLIKU 103
            using(StreamWriter sw = new StreamWriter(@"C:\Users\lysia\cUserslysia.ssh\primary\20181218\results.txt"))
            {
                sw.WriteLine("Task103");
                sw.WriteLine("Lista osób bez podanego czasu budowania:");
                foreach (string person in PersonsforWhomWeDontKnowTime)
                {
                    sw.WriteLine(person);
                }
                sw.WriteLine("Czas budowania postaci wyniósł: " + TheSumOfTimeOfBuildingEveryoneEvenPersonsWhoHaveNotTimeinFileButWeHaveAverage + " minut, czyli " +TheSumOfTimeOfBuildingEveryoneEvenPersonsWhoHaveNotTimeinFileButWeHaveAverage/60 + "h " + TheSumOfTimeOfBuildingEveryoneEvenPersonsWhoHaveNotTimeinFileButWeHaveAverage % 60 + "minut" );
            }
            Console.ReadKey();
          //TASK104


        }




        //    // suma czasow i liczba osob, ktore go maja
        //    TheSumOfTheTimesEveryoneTimeBuilding();
        //    // sredni czas budowania dla osob bez czasu
        //    TheAverageTimeOfBuildingForEveryoneWhoHaveNOTATimeInFile();
        //    TheSumOfEveryTimeInFile();
        //    // zapisz wyniki do pliku
        //    SaveTheDataToFile();
        //}

        //public static void GetTheListofEveryoneTimeBuilding()
        //{

        //    string filepath;
        //    for (int i = 0; i < PathesOfFiles.Count; i++)
        //    {
        //        filepath = PathesOfFiles[i];
        //        using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            time = textOperation.ExtractTimeToCreate(File.ReadAllText(filepath));
        //            timesofallfiles.Add(time); //lista czasów wszystkich
        //        }
        //    }
        //    timesofallfiles.RemoveAll(s => s == string.Empty); //usun puste pola

        //    var intList = timesofallfiles.Select(s => Convert.ToInt32(s)).ToList();
        //}







        //public static void Main(string[] args)
        //{
        //    //given directory 
        //    //get filenames (directory) = list of files


        //    TextParser textOperation = new TextParser();  

        //    List<string> timesofallfiles = new List<string> { };

        //    int[] timesofall = new int[] { };
        //    string time = "";


        //    string path = @"C:\Users\lysia\OneDrive\Pulpit\cor2\Corealate_materiały\regexy\primary-develop\20181218\cybermagic\karty-postaci";
        //        List<string> PathesOfFiles = Directory.GetFiles(path).ToList<string>(); // Lista ścieżek wszystkich



        //   string filepath;
        //    for (int i = 0; i < PathesOfFiles.Count; i++)
        //    {
        //        filepath = PathesOfFiles[i];
        //        using (FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //        {
        //            time = textOperation.ExtractTimeToCreate(File.ReadAllText(filepath));
        //            timesofallfiles.Add(time); //lista czasów wszystkich
        //        }
        //    }
        //    timesofallfiles.RemoveAll(s => s == string.Empty); //usun puste pola

        //    var intList = timesofallfiles.Select(s => Convert.ToInt32(s)).ToList();

        //    int sumoftimes = 0;
        //    for (int i = 0; i < timesofallfiles.Count; i++)
        //    {

        //         sumoftimes= sumoftimes+ intList[i];
        //    }
        //    Console.WriteLine(sumoftimes + "minut");
        //    int hours = sumoftimes / 60;
        //    int minutes = sumoftimes % 60;

        //    // ZAPISANIE DO PLIKU
        //    using (StreamWriter sw = new StreamWriter(@"C:\Users\lysia\OneDrive\Pulpit\cor2\Corealate_materiały\regexy\task2.txt"))
        //    {
        //        sw.WriteLine("Wszystkie postacie do tej pory budowane były " + hours + " godzin" + minutes + " minut");


        //    }
        //    Console.WriteLine("Wszystkie postacie do tej pory budowane były " + hours + " godzin " + minutes + " minut");
        //    Console.ReadKey();

        //}

        //public static void Komciuch(string[] args)
        //{
        //    //get fryderyk komciuch = string          
        //    string path = @"C:\Users\lysia\OneDrive\Pulpit\Corealate_materiały\regexy\primary-develop\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
        //    string text = "", title ="", time ="";
        //    using (FileStream fs = File.Open(path, FileMode.Open,FileAccess.Read,FileShare.Read))
        //    {
        //        text = File.ReadAllText(path);
        //    }

        //    // extract time/titile
        //    TextParser textOperation = new TextParser();        
        //    title = textOperation.ExtractProfileName(text);
        //    time = textOperation.ExtractTimeToCreate(text);

        //    //print name + time

            //using (StreamWriter sw = new StreamWriter(@"C:\Users\lysia\OneDrive\Pulpit\Corealate_materiały\regexy\primary-develop\20181218\czas-fryderyk-komciur.txt"))
            //{
            //    sw.WriteLine(title + " był budowany " + time + " minuty");


            //}
        //    Console.WriteLine(title + time);
        //    Console.ReadKey();
        //}



    }


}

