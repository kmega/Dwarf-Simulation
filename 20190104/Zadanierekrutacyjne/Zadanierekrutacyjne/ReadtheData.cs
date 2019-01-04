using System;
using System.Collections.Generic;
using System.IO;

namespace Zadanierekrutacyjne
{

    public class ReadtheData
    {
        public List<string> Reader(string path)
        {
            List<string> Teadata = new List<string> { };
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                
                while ((line= sr.ReadLine()) != null)
                {
                    Teadata.Add(line);
                }
            }
            return Teadata;
        }
    }
}