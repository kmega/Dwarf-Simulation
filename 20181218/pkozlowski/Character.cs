using System.IO;

namespace pkozlowski
{
    class Character
    {
        public string Name { get; set; }
        public string BuildTime { get; set; }
        public string filePath { get; set; }

        public Character(string filepath)
        {
            filePath = filepath;
            takeProfileName();
            takeTimeToCreate();
        }

        private void takeProfileName()
        {
            var content = File.ReadAllText(filePath);
            TextParser textParser = new TextParser();
            Name = textParser.ExtractProfileName(content);
        }

        private void takeTimeToCreate()
        {
            var content = File.ReadAllText(filePath);
            TextParser textParser = new TextParser();
            BuildTime = textParser.ExtractTimeToCreate(content);
        }
    }
}
