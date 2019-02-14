using Dwarf_Town.Enums;
using Dwarf_Town.Models;

namespace Dwarf_Town.Interfaces
{
    public interface IWork : IChance
    {
        int Dig();
        void HideToBackpack(MineralType ore);
        void DeathSentence();
        bool AskAboutLife();
    }
}