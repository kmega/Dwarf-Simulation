using System.Collections.Generic;
using System.Linq;
using System;

namespace pkozlowski
{
    class Task3
    {
        public static void run(string resultFile)
        {
            CharacterVault characterVault = new CharacterVault(@"cybermagic/karty-postaci", "*.md");
                List<string> exportString = new List<string>();
                List<KeyValuePair<string, int>> timeList = new List<KeyValuePair<string, int>>();
                
                timeList.Add(new KeyValuePair<string, int>(
                        "avgTimeForNonEmptyBuildTimeChars",
                        characterVault.charactersAvgBuildTime(
                            characterVault.Characters.Where(x => x.BuildTime != "").ToList())
                    ));

                exportString.Add("Postacie, które nie mają podanego czasu to:");

                characterVault.Characters.Where(x => x.BuildTime == "").ToList()
                    .ForEach(x => {
                        exportString.Add(x.Name);
                    });

                int avgBuildTimeForEmptyChar = characterVault.Characters.Where(x => x.BuildTime == "").Count();

                exportString.Add(string.Format("Średni czas budowania postaci to: {0} minut. ",
                    timeList.FirstOrDefault(x => x.Key == "avgTimeForNonEmptyBuildTimeChars").Value));

                TimeSpan timeSpan = TimeSpan.FromMinutes(
                    timeList.FirstOrDefault(x => x.Key == "avgTimeForNonEmptyBuildTimeChars").Value);

                // If I bet that empty ones have average build time the same as non empty ones, then I get same average build time
                exportString.Add(string.Format("Wszystkie postacie do tej pory budowne były {0} godzin {1} minut.", 
                    timeSpan.Hours, timeSpan.Minutes));

                characterVault.resultToFile(resultFile, exportString);
        }
    }
}