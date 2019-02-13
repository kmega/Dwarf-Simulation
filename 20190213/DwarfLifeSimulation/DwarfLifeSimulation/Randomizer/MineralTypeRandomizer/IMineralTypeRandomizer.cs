using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralTypeRandomizer
{
    public interface IMineralTypeRandomizer : IRandomizer
    {
        MineralType WhatHaveBeenDig(int? randomNumber = null);
    }
}