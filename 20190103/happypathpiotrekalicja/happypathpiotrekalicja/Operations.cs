using System;
using System.IO;

namespace happypathpiotrekalicja
{
    public class Operations
    {
        public string ReturnName(string komciurPath)
        {
            TextParser textParser = new TextParser();

            string content = File.ReadAllText(komciurPath);
            string name = textParser.ExtractProfileName(content);

            return name;
        }

        public int ReturnTime(string komciurPath)
        {
            TextParser textParser = new TextParser();

            string content = File.ReadAllText(komciurPath);
            int time = Convert.ToInt16(textParser.ExtractTimeToCreate(content));

            return time;
        }
    }
}