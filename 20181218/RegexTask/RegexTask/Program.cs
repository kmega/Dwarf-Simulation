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
        public static List<string> _data = new List<string>();
        public static string _file_txt;
        public static string _name_create_file = "Results.txt";
        public static string _karty_postaci_url = "../../../../cybermagic/karty-postaci/";
        static void Main(string[] args)
        {

            //ReadFile(url) -> string(text from file)
            ReadFile file = new ReadFile();

            _file_txt = file.Return_file(_karty_postaci_url+"1807-fryderyk-komciur.md");

            //Text Parser(text from file) -> string(Time, Full name)
            TextParser Parser = new TextParser();

            _data.Add(Parser.ExtractProfileName(_file_txt) + " był budowany " + Parser.ExtractTimeToCreate(_file_txt));
            Console.WriteLine(_data[0]);
           
            //Whole creating time(url) -> string time
            Whole_creating_time whole_time = new Whole_creating_time();

            _data.Add(whole_time.creating_time(_karty_postaci_url));
            Console.WriteLine(_data[1]);

            //Create file -> Results.txt
            Create_file recorder = new Create_file();

            recorder.save_file(_name_create_file, _data);


            Console.ReadKey();
        }
    }
}
