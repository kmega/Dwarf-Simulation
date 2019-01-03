using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaRegex;

namespace CyberMagicWithTests.Tasks
{
   public class Task1
    {
        public string pathKomciur = @"C:\Users\esmic\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";

        public string GetKomciur()
        {
            TextParser tp = new TextParser();
            string komciur = File.ReadAllText(pathKomciur);
            string toWrite = tp.ExtractProfileName(komciur) + " był budowany "
                + tp.ExtractTimeToCreate(komciur) + " minuty";
            return toWrite;
        }

    }
}
