using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace pkozlowski
{
    class StoryVault
    {
        public List<Story> Stories { get; set; }

        public StoryVault()
        {
            Stories = new List<Story>();
        }

        public StoryVault(string path, string searchPattern)
        {
            Stories = new List<Story>();
            foreach (var item in Directory.EnumerateFiles(path, searchPattern))
            {
                Stories.Add(new Story(item));
            }
        }

        public void resultToFile(string filepath, List<string> content)
        {
            File.AppendAllLines(filepath, content);
        }
    }
}
