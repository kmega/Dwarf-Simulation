using System.IO;
using Tales.Persons;

namespace Tales
{
    class PersonCreator
    {

        public TextParser TextParser { get; set; }
        public PersonCreator(TextParser textParser)
        {
            TextParser = textParser;
        }

        public Person CreatePersonFromFile(string file)
        {
            int time;
            var person = File.ReadAllText(file);

            int.TryParse(TextParser.ExtractTimeToCreate(person), out time);
            string name = TextParser.ExtractProfileName(person);

            return new Person() { Name = name, CreationTime = time };
        }

        public void SavePersonToFile(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}