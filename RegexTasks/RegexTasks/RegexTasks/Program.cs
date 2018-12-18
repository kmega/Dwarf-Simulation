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
            // Folder ze ścieżkami -- twórz ścieżki --> tablica ścieżek

            string[] filePaths =
                Directory.GetFiles(@"..\\..\\..\\..\\..\\20181218\\cybermagic\\karty-postaci");
            Console.WriteLine(filePaths[0]);

            //1. Plik  -- odczyt -> string calyplik
            FileSupporter file_to_read = new FileSupporter();
            string FryderyKomciurFileStr = file_to_read.Read_File(@"..\..\..\..\..\cybermagic\karty-postaci\1807-fryderyk-komciur.md");

            List<string> files = new List<string>();

            foreach (var item in filePaths)
            {
                files.Add(file_to_read.Read_File(item));
            }


            //2. FryderykKomciurFileStr -- filtr(regex methods) --> string howLongWasBuild fryderyk

            TextParser TimeToCreate = new TextParser();
            string HowLongWasBuildFryderykKomciur = TimeToCreate.ExtractTimeToCreate(FryderyKomciurFileStr);

            string result1 = "Fryderyk Komciur był budowany " + HowLongWasBuildFryderykKomciur + " minuty";

            //3. HowLongWasBuildFryderykKomciur -- zapis do pliku --> Result1.txt

            FileSupporter file_to_save = new FileSupporter();
            file_to_save.SaveToFIle(result1);

            

            Console.ReadKey();
        }
    }
}
