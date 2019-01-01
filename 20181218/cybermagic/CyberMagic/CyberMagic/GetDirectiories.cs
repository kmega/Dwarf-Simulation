using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
   public  class GetDirectiories

    {

       private string[] CardsDirectories;
       private string[] StoriesDirectories;

      public  GetDirectiories(string pathCads, string pathStories)
        {
            CardsDirectories = Directory.GetFiles(pathCads);
            StoriesDirectories = Directory.GetFiles(pathStories);

        }

        public List<string> ModifyCardcharList (List <string> charFromCardslist)
        {
            for (int i= 0; i < charFromCardslist.Count;i++)
            {
                foreach (var item in CardsDirectories)
                {
                    string temp = File.ReadAllText(item);
                    if (charFromCardslist[i] == new TextParser().ExtractProfileName(temp))
                    {
                        charFromCardslist[i] += ", " + Path.GetFileName(item);
                        break;
                    }
                    
                }
            }


            return charFromCardslist;
        }

        public List<string> ModifyStoriescharList(List<string> charFromStoriesslist)
        {
            for (int i = 0; i < charFromStoriesslist.Count; i++)
            {
                string tempdirectories = "";
                foreach (var item in StoriesDirectories)
                {
                    string temp = File.ReadAllText(item);
                    temp = new TextParser().ExtractMerit(temp);
                    temp = new TextParser().ExtractCharacterFromMerit(temp);
                    string[] parts = temp.Split(',');
                    if (parts.Contains(charFromStoriesslist[i])) {

                        tempdirectories += ", " + Path.GetFileName(item);

                    }

                }
                charFromStoriesslist[i] +=  tempdirectories;
            }


            return charFromStoriesslist;
        }




    }
    
    }

