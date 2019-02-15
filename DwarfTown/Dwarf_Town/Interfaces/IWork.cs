using Dwarf_Town.Enums;
using Dwarf_Town.Models;
using System.Collections.Generic;

namespace Dwarf_Town.Interfaces
{
    public interface IWork : IChance
    {
        int Dig();
        void HideToBackpack(MineralType ore);
        List<MineralType> ShowWhatYouBroughtOut();
        void DeathSentence();
       
    }
}