using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace pkozlowski
{
    class CharacterVault
    {
        public List<Character> Characters { get; set; }

        public CharacterVault()
        {
            Characters = new List<Character>();
        }

        public CharacterVault(string path, string searchPattern)
        {
            Characters = new List<Character>();
            foreach (var item in Directory.EnumerateFiles(path, searchPattern))
            {
                if (!item.Contains("template"))
                    Characters.Add(new Character(item));
            }
        }

        public void resultToFile(string filepath, List<string> content)
        {
            File.WriteAllLines(filepath, content);
        }

        public int charactersAvgBuildTime(List<Character> characterList)
        {
            int builtTime = 
                Characters.Sum(x => {
                    int result;
                    int.TryParse(x.BuildTime, out result);
                    return result;
                    });
            return builtTime / characterList.Count;
        }
    }
}
