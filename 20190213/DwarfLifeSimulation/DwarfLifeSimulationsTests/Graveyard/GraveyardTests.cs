using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Locations.Graveyards;
using DwarfLifeSimulation.Enums;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DwarfLifeSimulationsTests.GraveyardTests
{
    internal class GraveyardTests
    {
        private List<IDwarf> dwarves;
        private Mine mine;
        private List<IWork> workers;
        private Graveyard graveyard;

        [SetUp]
        public void Setup()
        {
            dwarves = new List<IDwarf>() 
            {
                new DwarfFactory().Create(DwarfType.Father),
                new DwarfFactory().Create(DwarfType.Father),
                new DwarfFactory().Create(DwarfType.Father),
                new DwarfFactory().Create(DwarfType.Single),
                new DwarfFactory().Create(DwarfType.Single),
                new DwarfFactory().Create(DwarfType.Single),
                new DwarfFactory().Create(DwarfType.Sluggard),
                new DwarfFactory().Create(DwarfType.Sluggard),
                new DwarfFactory().Create(DwarfType.Sluggard),
                new DwarfFactory().Create(DwarfType.Suicide)
            };
        }
        
        [Test]
        public void T100_ShouldBe5DeadDwarvesBurriedInGraveyard()
        {
            //given
            mine = new Mine();
            graveyard = new Graveyard();
            workers = new List<IWork>();
            dwarves.ForEach(d => workers.Add(d));

            //when
            mine.Work(workers);
            graveyard.BuryDeadDwarves(dwarves);
            
            //then
            Assert.AreEqual(graveyard.DeadDwarvesAmount, 5);
        }
    }
}
