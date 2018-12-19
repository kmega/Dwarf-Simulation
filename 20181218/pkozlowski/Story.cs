using System.IO;

namespace pkozlowski
{
    class Story
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string stuffWithMagda { get; set; }

        public Story(string filepath)
        {
            FilePath = filepath;
            takeStory();
            checkMagda();
        }

        private void takeStory()
        {
            var content = File.ReadAllText(FilePath);
            TextParser textParser = new TextParser();
            Title = textParser.ExtractStories(content);
        }

        private void checkMagda()
        {
            var content = File.ReadAllText(FilePath);
            TextParser textParser = new TextParser();
            stuffWithMagda = textParser.ExtractStuffWithMagda(content);
        }
    }
}
