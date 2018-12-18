using System;
using System.Text.RegularExpressions;
using System.IO;



namespace lab20181218
{
    class Program
    {
        static void Main(string[] args)
        {
            //Regex regex = new Regex(@"\s/Content/([a-zA-Z0-9\-]+?)\.aspx");
            Regex regex = new Regex(@"\((\d\d) min.*\)\");
            //\((\d\d) min.*\)
            using (StreamReader reader = new StreamReader(@"happy-path-creation-training.md"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        string v = match.Groups[1].Value;
                        Console.WriteLine(line);
                        Console.WriteLine("..." +v);
                    }
                }
            }
            
        }
    }
}
