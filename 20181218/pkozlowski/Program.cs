using System.Collections.Generic;
using System.Linq;

namespace pkozlowski
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterVault characterVault = new CharacterVault(@"cybermagic/karty-postaci", "*.md");
            int builtTime = characterVault.charactersBuildTime(characterVault.Characters);
            characterVault.resultToFile(
                characterVault.Characters.Where(x => x.BuildTime == "").ToList(), 
                "wynik.txt");
            int averageBuildTime = characterVault.charactersBuildTime(
                characterVault.Characters.Where(x => x.BuildTime != "").ToList()
                );

            //characterVault.exportBuildTimeToFile("wynik.txt");
        }
    }
}
