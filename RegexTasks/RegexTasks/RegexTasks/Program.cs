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
            FileReader file1 = new FileReader();
            string FryderyKomciurFileStr = file1.Read_File();


            //2. FryderykKomciurFileStr -- filtr(regex methods) --> string howLongWasBuild fryderyk

            TextParser TimeToCreate = new TextParser();
            string HowLongWasBuildFryderykKomciur = TimeToCreate.ExtractTimeToCreate(FryderyKomciurFileStr);

            Console.WriteLine($"Fryderyk Komciur był budowany {HowLongWasBuildFryderykKomciur} minuty");

            Console.ReadKey();
        }
    }
}
