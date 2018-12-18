using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegexTask
{
    class Program
    {
        public static string file;
        public static string name_create_file = "Task1.txt";
        public static string karty_postaci_url = "../../../../cybermagic/karty-postaci/";
        public static string creating_time_for_all;
        static void Main(string[] args)
        {

            //Odczytanie pliku -> file
            ReadFile file1 = new ReadFile();
            file = file1.Return_file(karty_postaci_url+"1807-fryderyk-komciur.md");

            //Odpalenie regexa -> data from file
            Find_data find_data = new Find_data();

            string result = find_data.regex(file, @"(\w+ \w+)");

            result +=" był budowany " + find_data.regex(file, @"\((\d\d) min.*\)");
            Console.WriteLine(result);

            Create_file save = new Create_file();
            save.save_file(name_create_file, result);

            //uzycie obcego parsera
            TextParser Parser = new TextParser();
            Console.WriteLine(Parser.ExtractTimeToCreate(file));

            Whole_creating_time whole_time = new Whole_creating_time();
            creating_time_for_all = whole_time.creating_time(karty_postaci_url);

            save.save_file(name_create_file, creating_time_for_all);

            Console.ReadKey();
        }
    }
}
