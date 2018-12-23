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

            personCreator.SavePersonToFile(Persons.Where(x => x.Name == "").FirstOrDefault());



            Console.WriteLine("Hello World!");

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
