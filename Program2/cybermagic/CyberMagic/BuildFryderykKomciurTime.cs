using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberMagic
{
    public class BuildFryderykKomciurTime
    {
        public string BuildFryderykKomciur()
        {
            string filetxt;
            string url = @"../../../karty-postaci/1807-fryderyk-komciur.md";

            StringReturner returner = new StringReturner();
            filetxt = returner.FileText(url);

            TextParser parser = new TextParser();
            string result = "Fryderyk Komciur był budowany " + parser.ExtractTimeToCreate(filetxt) + " minuty";

            return result;
        }
    }
}
