using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    class Simulation
    {
        List<Dwarf> _dwarves = new List<Dwarf>();
        List<Shaft> _shafts = new List<Shaft>();
        Raport _raport = new Raport();

        //location
        Hospital _hospital = new Hospital(new Randomizer());
        Graveyard _graveyard = new Graveyard();
        DiningRoom _diningRoom = new DiningRoom();

        internal void Start()
        {
            Prepare();
            for (int i = 0; i < 30; i++)
            {
                if(!Day(i)) break;
            }
            _raport.Display();
        }

        internal bool Day(int dayNumber)
        {
            //Hospital
            if (dayNumber != 0)
            { _dwarves = _hospital.BornDwarf(_dwarves, _raport); }


            //Mines
            //Guild

            //Graveyard
            _dwarves = _graveyard.DeleteDeadDwarfFromList(_dwarves, _raport);
            if (!_graveyard.AnybodyLives(_dwarves)) return false;

            //DinningRoom
            if (!_diningRoom.CanEat(_dwarves, _raport)) return false;
            _diningRoom.DwarfsEat(_dwarves, _raport);


            //Shop


            return true;
        }

        internal void Prepare()
        {
            PrepareSimulation prepare = new PrepareSimulation();

            _dwarves = prepare.PrepareDwarves(10);
            _shafts = prepare.PrepareShafts(2);
        }
    }
}
