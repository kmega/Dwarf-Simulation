using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VivaRegex;

namespace RegEx
{
    public class Task1
    {
        public string textKomciur;
        public string komciurResult;

        public Task1(string path)
        {
            textKomciur = GetText(path);
            komciurResult = KomciurResult(GetName(textKomciur), GetTime(textKomciur));
        }

        public string GetText(string path)
        {
            ReadFile rf = new ReadFile();
            textKomciur = rf.ReadSingleFile(path);
            return textKomciur;
        }

        public string GetName(string text)
        {
            TextParser tp = new TextParser();
            string name = tp.ExtractProfileName(text);
            return name;
        }

        public string GetTime(string text)
        {
            TextParser tp = new TextParser();
            string time = tp.ExtractTimeToCreate(text);
            return time;
        }

        public string KomciurResult(string name, string time)
        {
            string result = $"{name} byl budowany {time} minuty";
            return result;
        }
    }
}
