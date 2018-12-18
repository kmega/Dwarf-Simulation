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
            //1. Plik Fryderyk Komciur -- odczyt -> string FryderykKomciur
            FileSupporter file_to_read = new FileSupporter();
            string FryderyKomciurFileStr = file_to_read.Read_File();


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
