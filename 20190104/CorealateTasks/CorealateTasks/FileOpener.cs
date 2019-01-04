using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CorealateTasks
{
    class FileOpenerAndSaver
    {
        public static string[] GetContentFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public static void SaveToPath(string[] toSave, string path)
        {
            File.AppendAllLines(path, toSave);
        }
    }
}
