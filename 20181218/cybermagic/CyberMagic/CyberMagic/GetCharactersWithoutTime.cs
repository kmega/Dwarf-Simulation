using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
   public  class GetCharactersWithoutTime
    {

        public  List<string> charactersWithoutTime(List<string> files)
        {
            List<string> charswithouttime = new List<string>();
            charswithouttime.Add("Postaci bez czasu budowania\n");
            

            foreach (var item in files)
            {

                if (new TextParser().ExtractTimeToCreate(item) == "" && !(new TextParser().ExtractProfileName(item) == ""))
                {
                    charswithouttime.Add( new TextParser().ExtractProfileName(item));
                    
                }

            }
            
            return charswithouttime;
        }

        
    }
}
