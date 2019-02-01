using System;
using System.Collections.Generic;
using System.Text;

namespace Mergee_tree
{
    class ReadTree
    {
        public string[] read(string currentFile)
        {
            string[] info = new string[2];
            int information = currentFile.IndexOf("1. ");
            string name = currentFile.Trim();
            info[0] = information.ToString();
            info[1] = name;
            return info;
        }
    }
}
