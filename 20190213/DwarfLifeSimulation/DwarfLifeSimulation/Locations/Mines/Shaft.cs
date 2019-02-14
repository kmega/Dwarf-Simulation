using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Randomizer.MineralTypeRandomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Mines
{
    public class Shaft
    {
        private bool _isOccupied;

        public bool IsOccupied
        {
            get { return _isOccupied; }
            set { _isOccupied = value; }
        }
        private ShaftStatus _shaftStatus;

        public ShaftStatus ShaftStatus
        {
            get { return _shaftStatus; }
            set { _shaftStatus = value; }
        }

        private IMineralTypeRandomizer _mineralTypeRandomizer;        

        public Shaft()
        {
            _isOccupied = false;
            _shaftStatus = ShaftStatus.Working;
            _mineralTypeRandomizer = new MineralTypeGenerationStrategy();
        }

        public MineralType GenerateMineralType()
        {
            return _mineralTypeRandomizer.WhatHaveBeenDig();
        }

    }
}
