using Dwarf_Town.Enums;

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