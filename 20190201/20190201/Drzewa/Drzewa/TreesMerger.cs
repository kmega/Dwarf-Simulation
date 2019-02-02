using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drzewa
{
    public class TreesMerger
    {

        public List<Location> MergeTree(string input, List<Location> mainTree)
        {
            LocationFactory factory = new LocationFactory();
            string[] recordstab = input.Split('|');
            for (int i = 0; i < recordstab.Length; i++)
            {
                Location record = factory.CreateLocation(recordstab[i], recordstab, i);
                if (mainTree.Count == 0)
                {
                    mainTree.Add(record);
                }

                else
                {

                        if (!(mainTree.Exists(k => (k.Name == record.Name) && (k.Path == record.Path))))
                        {
                            mainTree.Add(record);
                        }
                }
            }
           return mainTree = mainTree.OrderBy(i => i.Path).ToList();
        }
    }

}
