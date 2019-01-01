using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    public class CharacterEncounterCounter
    {
        public string KalinaMeetList (List<string> stories)
        {
            Dictionary<string, int> charlist = new Dictionary<string, int>();
            string txt = "Kalina Rotmistrz spotkała następujące postacie:\n\n";
            


            foreach (var item in stories)
            {
                string temp = new TextParser().ExtractMerit(item);
                temp = new TextParser().ExtractCharacterFromMerit(temp);
                string[] parts = temp.Split(',');
                for (int i = 0; i < parts.Length; i++) {
                    if (parts[i]=="Kalina Rotmistrz")
                    {
                        continue;
                    }
                    else if (charlist.ContainsKey(parts[i]))
                    {
                        charlist[parts[i]] += 1;
                    }
                    else
                    {
                        charlist.Add(parts[i], 1);
                    }
                }
               
            }

            foreach (var item in charlist)
            {
                if (item.Value == 1)
                {
                    txt += item.Key + ": " + item.Value + " raz\n";
                }
                else
                    txt += item.Key + ": " + item.Value + " razy\n";
            }
            return txt;
        }
        

    }
}
