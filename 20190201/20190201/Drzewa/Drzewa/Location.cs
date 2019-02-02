using System;

namespace Drzewa
{
    public class Location
    {

        public int Depth;
        public string Name;
        public string Path;

      


        public override string ToString()
        {
            string display = "";

            for (int i=0; i < Depth; i++)
            {
                display += "    ";
            }
            display += Name;
            return display;
        }

    }
}