using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TreeMerge
{
    public class BranchBuilder
    {
        private static int depth;
        private static int record;
        private static string name;
        private static List<string> path = new List<string>();

        public static Branch Build(string branch, int _record)
        {
            depth = GiveDepth(branch);
            record = _record;
            name = GiveName(branch);

            return new Branch(depth, record, name);
        }

        private static string GiveName(string branch)
        {
            string _name = Regex.Replace(branch, @".*?1.", "");
            return _name;
        }

        private static int GiveDepth(string branch)
        {           
            int lengthTextBeforeSplit = branch.Length;
            int startIndex = branch.IndexOf('1');
            branch = branch.Remove(startIndex);

            return branch.Length/4;
        }

        public static void GivePath(List<Branch> branches)
        {
            
        }
    }
}