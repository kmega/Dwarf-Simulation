using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

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

        // public void exportBuildTimeToFile(string filepath)
        // {
        //     int builtTime = charactersBuildTime();
        //     TimeSpan builTime = TimeSpan.FromMinutes(builtTime);
        //     var resultText = string.Format("Wszystkie postacie do tej pory budowne były {0} godzin i {1} minut.\n", builTime.Hours, builTime.Minutes);
        //     File.AppendAllText(filepath, resultText);
        // }

        public void resultToFile(List<Character> characterList, string filepath, string addText = "")
        {
            File.AppendAllText(filepath, "Postacie, które nie mają podanego czasu to: \n");
            characterList.ForEach(x => {
                File.AppendAllText(filepath, x.Name + "\n");
                }); 
        }

        public int charactersBuildTime(List<Character> characterList)
        {
            int builtTime = 
                Characters.Sum(x => {
                    int result;
                    int.TryParse(x.BuildTime, out result);
                    return result;
                    });
            return builtTime;
        }
    }
}
