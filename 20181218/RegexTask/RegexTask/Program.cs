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
        public static List<string> _results = new List<string>();
        public static List<string> _txt_in_all_files = new List<string>();
        public static List<string> _files_name = new List<string>();
        public static List<string> _files_task3 = new List<string>();
        public static List<Person> _files_name_without_time= new List<Person>();
        public static List<Person> _files_name_with_time= new List<Person>();
        static TimeSpan _creating_time_for_all;
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

            _results.Add(Parser.ExtractProfileName(_file_txt) + " był budowany " + Parser.ExtractTimeToCreate(_file_txt));;

            //Retrun names in catalog(url) -> List <string> name_files
            Names_file_in_catalog names_files = new Names_file_in_catalog();

            _files_name = names_files.names(_karty_postaci_url);

            //Return all txt files(_names_files) -> List<string> txt_in_files
            Return_txt all_txt = new Return_txt();

            _txt_in_all_files = all_txt.txt_in_files(_files_name,_karty_postaci_url);

            //List<string> txt_in_files -> Create time(TimeSpan all time)
            Create_Time creating_Time = new Create_Time();

            _creating_time_for_all = creating_Time.creating_time(_txt_in_all_files);


            string result = "Wszystkie postacie do tej pory budowane były " + _creating_time_for_all.Hours.ToString();
             result += " godzin "+ _creating_time_for_all.Minutes.ToString() + " minut";
            _results.Add(result);

            //Retrun names in catalog(url) -> List <string> name_files
            _files_task3 = names_files.names(_karty_postaci_url);

            //List <string> name_files -> Remove template.md -> name_files
            Remove_sth_from_list_string remove = new Remove_sth_from_list_string();

            _files_task3 = remove.remover(_files_task3);


            //List<string> txt_in_files(without Remove 1807-_template.md) -> List<string> txt in files
            _txt_in_all_files = all_txt.txt_in_files(_files_task3, _karty_postaci_url);

            //List<string> txt in files -> List<Person> name and last name people without creating time
            List_people people = new List_people();

            _results.Add("Ludzie bez czasu tworzenia");

            _files_name_without_time = people.with_or_without_time(_txt_in_all_files, false);
            
            foreach (var item in _files_name_without_time)
            {
                _results.Add(item.name);
            }

            //List people with creating time(List<string> _txt_in_all_files) -> Number person with creating time (int number)
            _files_name_with_time = people.with_or_without_time(_txt_in_all_files, true);

            Average_time_of_creating time = new Average_time_of_creating();
            TimeSpan average_time_of_creating = time.average_time(_creating_time_for_all, _files_name_with_time.Count - 1);

            _results.Add("Średni czas budowania postaci to " + average_time_of_creating.Minutes.ToString() + " minut");

            TimeSpan new_time_for_all;
            Cout_new_creating_time cout_time = new Cout_new_creating_time();
            new_time_for_all = cout_time.Cout_new_time(_creating_time_for_all, average_time_of_creating, _files_name_with_time.Count -1);


            result = "Wszystkie postacie do tej pory budowane były " + new_time_for_all.Hours.ToString();
            result += " godzin " + new_time_for_all.Minutes.ToString() + " minut";
            _results.Add(result);


            //text from name files in catalog -> List<string> name_files from catalog
            

            //text


            //Create file -> Results.txt
            Create_file recorder = new Create_file();
            recorder.save_file(_name_create_file, _results);


            Console.ReadKey();
        }
    }
}
