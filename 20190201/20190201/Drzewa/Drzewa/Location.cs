using System;

namespace Drzewa
{
    public class Location
    {

        public int depth;
        public string name;
        public string path;

        public Location(string record, string[] parse, int iterator)
        {
            depth = 0;
            for (int i = 0; i < record.Length; i++)
                if (!(Char.IsLetter(record.ToCharArray()[i])))
                {
                    depth++;
                }
                else
                {
                    break;
                }
            name = record.TrimStart(' ');

            Path(parse, iterator);

        }

        void Path(string[] parse, int iterator)
        {
            int itemdepth = 0;
            int pathiterator = 1;
            for (int i = iterator - 1; i >= 0; i--)
            {
                for (int j = 0; j < parse[i].Length; j++)
                {
                    if (!(Char.IsLetter(parse[i].ToCharArray()[j])))
                    {
                        itemdepth++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (itemdepth == depth - pathiterator)
                {
                    path = parse[i].TrimStart(' ') + "|" + path;
                    pathiterator++;
                    itemdepth = 0;
                }
                else
                {
                    itemdepth = 0;
                }
            }
            path += name + '|';
        }

        public override string ToString()
        {
            string display = "";

            for (int i=0; i < depth; i++)
            {
                display += "    ";
            }
            display += name;
            return display;
        }

    }
}