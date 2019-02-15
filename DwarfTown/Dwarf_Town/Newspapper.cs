using System.Collections.Generic;

namespace Dwarf_Town
{
    public class Newspapper
    {
        public Newspapper()
        {
            Message = new List<string>();
        }

        public List<string> Message { get; set; }
    }
}