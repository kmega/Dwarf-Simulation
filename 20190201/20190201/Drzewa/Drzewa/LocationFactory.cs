using System;
using System.Collections.Generic;
using System.Text;

namespace Drzewa
{
    public class LocationFactory
    {

        public Location CreateLocation (string record, string[] recordslist, int recordindex)
        {
            Location location = new Location();
            int depth = CreateDepth(record);
            location.Depth = depth;
            location.Name = record.TrimStart(' ');
            location.Path = CreatePath(recordslist, recordindex, depth, record);
            return location;
        }


        private string CreatePath(string[] recordslist, int recordindex, int recorddepth, string record)
        {
            int checkingParentsIterator = 1;
            string path="";
            
            for (int i = recordindex - 1; i >= 0; i--)
            {
                int checkedRecordIndex = 0;
                for (int j = 0; j < recordslist[i].Length; j++)
                {
                    if (!(Char.IsLetter(recordslist[i].ToCharArray()[j])))
                    {
                        checkedRecordIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (checkedRecordIndex == recorddepth - checkingParentsIterator)
                {
                    path = recordslist[i].TrimStart(' ') + "|" + path;
                    checkingParentsIterator++;
                }
            }
           return path += record.TrimStart(' ') + '|';
        }



        private int CreateDepth(string record)
        {
           int depth = 0;
            for (int i = 0; i < record.Length; i++)
                if (!(Char.IsLetter(record.ToCharArray()[i])))
                {
                    depth++;
                }
                else
                {
                    break;
                }
            return depth;
        }
    }
}
