using System.IO;
using System.Linq;
using System.Text;

namespace pkozlowski
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterVault characterVault = new CharacterVault();
            //characterVault.Characters.Add(new Character(@"cybermagic/karty-postaci/1807-fryderyk-komciur.md"));
            foreach (var item in Directory.EnumerateFiles(@"cybermagic/karty-postaci", "*.md"))
            {
                characterVault.Characters.Add(new Character(item));
            }

            var result = characterVault.Characters.Where(x => x.Name == "Fryderyk Komciur").Single();
            var resultText = result.Name + " był budowny " + result.BuildTime + " minuty.";
            File.WriteAllText("wynik.txt", resultText);
        }
    }
}
