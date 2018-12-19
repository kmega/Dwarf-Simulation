using System.Collections.Generic;
using System.Linq;
using System;

namespace pkozlowski
{
    class Task4
    {
        public static void run(string resultFile)
        {
            StoryVault storyVault = new StoryVault(@"cybermagic/opowiesci", "*.md");
            List<string> exportString = new List<string>();

            exportString.Add(string.Format("Magda Patiril występowała w następujących Opowieściach:"));

            storyVault.Stories.Where(x => x.stuffWithMagda != "").ToList().
                ForEach(x => {
                    exportString.Add(x.Title);
                });

            exportString.Add("");

            storyVault.resultToFile(resultFile, exportString);
        }
    }
}