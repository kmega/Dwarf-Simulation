using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace CyberMagic
{
    public class BuildAllCharactersTime
    {
        public string BuildAllCharacters()
        {
            string url = @"../../../karty-postaci/";
            string textfile;
            int buildTime = 0;
            TextParser parser = new TextParser();
            foreach (string file in Directory.EnumerateFiles(url, "*.md"))
            {
                textfile = File.ReadAllText(file);
                buildTime += Convert.ToInt32(parser.ExtractTimeToCreate(textfile));
            }
            return "" + buildTime.ToString();
        }


    }
}
