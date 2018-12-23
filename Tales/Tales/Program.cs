using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tales.cybermagic.Tales;
using Tales.Persons;

namespace Tales
{
    class Program
    {
        private static string PersonfolderPath = "cybermagic/karty-postaci/";
        private static string TalefolderPath = "cybermagic/opowiesci/";

        static void Main(string[] args)
        {
            List<Person> Persons = new List<Person>();
            List<Tale> Tales = new List<Tale>();
            var textParser = new TextParser();

            PersonCreator personCreator = new PersonCreator(textParser);
            TalesCreator talesCreator = new TalesCreator(textParser);

            ReadFiles(PersonfolderPath)
                .ForEach(x=> Persons
                    .Add(personCreator.CreatePersonFromFile(x)));


            //TASK 1 save fryderyk komciur to file
            personCreator.SavePersonToFile(Persons.Where(x => x.Name == "Fryderyk Komciur").FirstOrDefault());
            //TASK 2 save sum creation time of all persons and save to file
            string text = $"Wszystkie postacie budowane były przez: " +
                          $"{Persons.Sum(x => x.CreationTime)/60} godzin i " +
                          $"{Persons.Sum(x => x.CreationTime) % 60} minuty";
            File.WriteAllText(Environment.CurrentDirectory + "/allPersonsTimeBuild.txt"
                , text);



            Console.ReadLine();
        }

        static List<string> ReadFiles(string path)
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path, "*.md"))
            {
                if (!file.Contains("1807-_template.md"))
                {
                   files.Add(file);
                }

            }

            return files;

        }
    }
}
