using DwarfsCity.DwarfContener;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Cementary
    {
        List<Dwarf> _deadDwarfs = new List<Dwarf>();
        public void BurryDeadDwarfs(List<Dwarf> deadDwarfs)
        {
            foreach (var dwarf in deadDwarfs)
            {
                _deadDwarfs.Add(dwarf);
            }
            deadDwarfs.Clear();

            //give report it the shape of log/logger 
        }
    }
}