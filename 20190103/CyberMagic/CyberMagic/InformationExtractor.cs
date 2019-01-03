using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagic
{
    public static class InformationExtractor
    {
        public static string ExtractSingleName(string file)
        {
            var textParser = new TextParser();
            var name = textParser.ExtractProfileName(file);
            return name;
        }

        public static int ExtractSingleTime(string file)
        {
            var textParser = new TextParser();
            return Int32.Parse(textParser.ExtractTimeToCreate(file));
        }
    }
}
