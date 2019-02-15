using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Simulation
    {
        List<Dwarf> _dwarves = new List<Dwarf>();
        List<Shaft> _shafts = new List<Shaft>();
        Raport _raport = new Raport();

        internal void Start()
        {
            Prepare();
            for (int i = 0; i < 30; i++)
            {
                if (!Day(i)) break;
            }
            _raport.Display();
        }

        internal bool Day(int dayNumber)
        {
            Randomizer randomizer = new Randomizer();

            //Hospital
            Hospital hospital = new Hospital(randomizer);
            if (dayNumber != 0)
            { _dwarves = hospital.BornDwarf(_dwarves, _raport); }


            //Mines
            Mines mines = new Mines();
            mines.EnterMines(_dwarves, _shafts, _raport);
            //Guild
            Guild guild = new Guild(randomizer);
            guild.ExchangeDwarvesMineralsAndGiveThemMoney(_dwarves);
            guild.Display();
            guild.UpdateSimulationRaport(_raport);

            //Graveyard
            Graveyard graveyard = new Graveyard();
            _dwarves = graveyard.DeleteDeadDwarfFromList(_dwarves, _raport);
            if (!graveyard.AnybodyLives(_dwarves)) return false;

            //DinningRoom
            DiningRoom diningRoom = new DiningRoom();
            if (!diningRoom.CanEat(_dwarves, _raport)) return false;
            diningRoom.DwarfsEat(_dwarves, _raport);


            //Shop
            Shop shop = new Shop();
            shop.ServeEveryone(_dwarves);
            shop.Display();
            shop.UpdateSimulationRaport(_raport);

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
