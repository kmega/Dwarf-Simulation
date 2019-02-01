using System;
using System.Collections.Generic;
using System.Text;

namespace TreeMerging
{
    public static class RecordFactory
    {
        public static List<LocationRecord> CreateRecords(List<string> tree)
        {
            List<LocationRecord> locationRecords = new List<LocationRecord>();
            for(int i = 0; i < tree.Count; i++)
            {
                int depth = tree[i].IndexOf('1');
                var content = tree[i].Substring(depth + 2).Trim();
                string path = "";
                if(i!=0)
                {
                    for(int z = 1; z <= i; z++)
                    {
                        if(tree[i].IndexOf('1') > tree[i-z].IndexOf('1'))
                        {
                            path = locationRecords[i - z].Path +"|"+ locationRecords[i-z].Content;
                            break;
                        }
                    }
                }
                locationRecords.Add(new LocationRecord(depth, path, content));
            }
            return locationRecords;
        }
    }
}
