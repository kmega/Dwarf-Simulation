using DwarfMineSimulator;
using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Shaft
    {
        public bool IsAvailable { get; private set; }
        public Shaft()
        {
            IsAvailable = true;
        }
        public void PerformAction(WorkingGroup workingGroup)
        {
            foreach (Dwarf dwarf in workingGroup.Workers)
            {
                dwarf.Work(this);
                if (IsAvailable == false)
                {
                    Cementary.ReceiveDeadWorkers(workingGroup);
                    break;
                }
            }
        }

        public List<Material> PerformDigging()
        {
            List<Material> diggedMaterials = new List<Material>();
            RandomizerThorins randomizer = new RandomizerThorins();
            int numberOfHits = randomizer.ReturnRandomNumber(1, 3);
            for(int i =0;i<numberOfHits;i++)
            {
                int numberInDiggingRange = randomizer.ReturnRandomNumber(1, 100);
                diggedMaterials.Add(randomizer.WhatDidYouDigOut(numberInDiggingRange));
            }
            return diggedMaterials;
        }

        public void Explode()
        {
            IsAvailable = false;
        }
        public void RepairShaft() => IsAvailable = true;
    }
}