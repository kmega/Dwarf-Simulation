using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralTypeRandomizer
{
    public interface IMineralTypeRandomizer
    {
        MineralType WhatHaveBeenDig(int? randomNumber = null);
    }
}