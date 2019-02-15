using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System;

namespace Dwarf_Town.Strategy
{
    public class DiggWork : IWork
    {
        private Dwarf _dwarf;

        public DiggWork(Dwarf dwarf)
        {
            _dwarf = dwarf;
        }

        public void DeathSentence()
        {
            _dwarf.IsAlive = false;
        }

        public int Dig()
        {
            Random rand = new Random();
            int numberOfHits = rand.Next(1, 3);
            return numberOfHits;
        }

        public void HideToBackpack(MineralType ore)
        {
            _dwarf.BackPack.AddOre(ore);
        }

        public bool AskAboutLife()
        {
            return _dwarf.IsAlive;
        }

        public int GenerateChance(int lowerBound, int upperBound)
        {
            Random rand = new Random();
            int value = rand.Next(lowerBound, upperBound);
            return value;
        }
    }
}