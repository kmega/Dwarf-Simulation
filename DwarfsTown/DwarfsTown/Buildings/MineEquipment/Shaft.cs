using System.Collections.Generic;

namespace DwarfsTown
{
    public class Shaft
    {
        public bool isExist { get; set; }
        public List<Dwarf> dwarfs { get; set; }

        public Shaft()
        {
            dwarfs = new List<Dwarf>();
            isExist = true;
        }
    }
}