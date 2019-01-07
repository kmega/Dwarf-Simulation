using System.IO;

namespace Tea_Data
{
    internal class FileIO
    {
        internal string[] TeaData()
        {
            string[] text = File.ReadAllLines(".../.../.../tea-data.txt");
            return text;
        }


        internal void Results(string message, int input)
        {
            string content = File.ReadAllText(".../.../.../result-" + input + ".txt");
            if (content != message)
            {
                File.WriteAllText(".../.../.../result-" + input + ".txt", message);
            }
        }
    }
}