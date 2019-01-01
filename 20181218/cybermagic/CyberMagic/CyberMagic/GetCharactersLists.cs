using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    public class GetCharactersLists
    {

        public List<string> CharactersFromCards = new List<string>();
      public  List<string> CharactersFromStories = new List<string>();
       public List<string> CharactersFromBoth = new List<string>();

        public GetCharactersLists (List<string> fileCards, List<string> fileStories)
        {

            CharactersFromCards = GetCharsFromCards(fileCards);
            CharactersFromStories = GetCharsFromStories(fileStories);
            CharactersFromBoth = GetCharsFromBoth();

        }


        private List<string> GetCharsFromCards(List<string> fileCards)
        {

            foreach (var item in fileCards)
            {


                string chrName = new TextParser().ExtractProfileName(item);

                if (!(chrName == "") && !(CharactersFromCards.Contains(chrName)))
                {
                    CharactersFromCards.Add(chrName);
                }
            }
            return CharactersFromCards;
        }

        private List<string> GetCharsFromStories(List<string> fileStories)
        {

            foreach (var item in fileStories)
            {
                string temp = new TextParser().ExtractMerit(item);
                temp = new TextParser().ExtractCharacterFromMerit(temp);
                string[] parts = temp.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {

                    if (!(CharactersFromStories.Contains(parts[i])))
                    {
                        CharactersFromStories.Add(parts[i]);
                    }

                }
            }
            return CharactersFromStories;

        }

        private List<string> GetCharsFromBoth()
        {
            foreach (var item in CharactersFromCards)
            {
                if (CharactersFromStories.Contains(item) && !(CharactersFromBoth.Contains(item)))
                {
                    CharactersFromBoth.Add(item);
                    
                    
                }

            }
            foreach (var item in CharactersFromBoth)
            {
                CharactersFromCards.Remove(item);
                CharactersFromStories.Remove(item);
            }
            return CharactersFromBoth;
        }
    }
}



