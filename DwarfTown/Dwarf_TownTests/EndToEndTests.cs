using Dwarf_Town;
using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations;
using Dwarf_Town.Locations.Guild;
using Dwarf_Town.Locations.Guild.OreValue;
using Dwarf_Town.Locations.Mine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_TownTests
{
    public class EndToEndTests
    {


        [Test]
        public void OneDwarSingleWorkFor10DaysAndBroughtOutGoldWorth10 ()
        {
            //given
            Mock<IChance> chanceForDwarfBorn = new Mock<IChance>();
            chanceForDwarfBorn.Setup(i => i.GenerateChance(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            Mock<IBroughtOutOreChance> chanceForOre = new Mock<IBroughtOutOreChance>();
            chanceForOre.Setup(i => i.GetTheOre(It.IsAny<int>())).Returns(MineralType.Gold);
            Mock<IOreValue> oreValue = new Mock<IOreValue>();
            oreValue.Setup(i => i.GenerateOreValue()).Returns(10);
            Mock<IOutputWriter> presenter = new Mock<IOutputWriter>();
            Guild guild = new Guild(
                new Dictionary<MineralType, IOreValue>() { { MineralType.Gold, oreValue.Object } },
                new Dictionary<MineralType, decimal>() { { MineralType.Gold, 0 } },
                presenter.Object
                );
            Dwarf dwarf = new Dwarf(DwarfType.FATHER);
            Mock<IWork> workingDwarf = new Mock<IWork>();
            workingDwarf.Setup(i => i.Dig()).Returns(1);
            workingDwarf.Setup(i => i.GenerateChance(It.IsAny<int>(), It.IsAny<int>())).Returns(20);
            workingDwarf.Setup(i => i.HideToBackpack(It.IsAny<MineralType>())).Callback((MineralType ore) =>
            {
                dwarf.BackPack.AddOre(ore);
            });
            workingDwarf.Setup(i => i.ShowWhatYouBroughtOut()).Returns(dwarf.BackPack.ShowBackpack());
            dwarf._work = workingDwarf.Object;
            SimulationStartConditions startConditions = new SimulationStartConditions();
            startConditions.Canteen = new Canteen(200);
            startConditions.Presenter = presenter.Object;
            startConditions.Dwarves = new List<Dwarf>() { dwarf };
            startConditions.Guild = guild;
            startConditions.Hospital = new Hospital(chanceForDwarfBorn.Object);
            startConditions.MaxDay = 10;
            startConditions.Mine = new Mine(1,
                new Dictionary<MineralType, int>() { { MineralType.Gold, 0 } },
                chanceForOre.Object, presenter.Object);
            startConditions.Shop = new Shop();
            startConditions.DwarvesBornFirstDay = 0;
            SimulationStart simulation = new SimulationStart(startConditions);

            //when
            simulation.Start();

            //then
            Assert.IsTrue(guild.ShowTresure() == 25);
            Assert.IsTrue(guild.ShowGuildRegister()[0] == 100);
            Assert.IsTrue(dwarf.Wallet.OverallCash == 37.50m);
            presenter.Verify(i => i.WriteLine("\nSimulation end because all simulation days passed"));
            presenter.Verify(i => i.WriteLine("*************"));
            presenter.Verify(i => i.WriteLine($"Dwarves died: 0"));
            presenter.Verify(i => i.WriteLine("\nMining results (Quantity/Overall value):"));
            presenter.Verify(i => i.WriteLine($"Gold: 10/100 gp"));
            presenter.Verify(i => i.WriteLine("\nShop results:"));
            presenter.Verify(i => i.WriteLine($"Alcohol: 0"));
            presenter.Verify(i => i.WriteLine($"Food: 37,50"));
            presenter.Verify(i => i.WriteLine($"\nIn Canteen left 190 food rations"));
            presenter.Verify(i => i.WriteLine("\nTresure results:"));
            presenter.Verify(i => i.WriteLine($"Guild gathered 25,00 gp"));
            presenter.Verify(i => i.WriteLine($"Shop gathered 37,50 gp"));
            presenter.Verify(i => i.WriteLine($"Dwarf gathered 37,50 gp"));
            presenter.Verify(i => i.WriteLine("*************"));



        }
        [Test]
        public void SimulationEndAfterSuicideKillAllDwarvesAtFirstDay()
        {
            //given
            Mock<IOutputWriter> presenter = new Mock<IOutputWriter>();
            Mock<IChance> chanceForDwarfBorn = new Mock<IChance>();
            chanceForDwarfBorn.Setup(i => i.GenerateChance(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            SimulationStartConditions startConditions = new SimulationStartConditions();
            startConditions.Canteen = new Canteen(200);
            startConditions.Presenter = presenter.Object;
            startConditions.Dwarves = new List<Dwarf>();
            startConditions.Dwarves.Add(new Dwarf(DwarfType.SUICIDE));
                for(int i=0;i<4; i++)
            {
                startConditions.Dwarves.Add(new Dwarf(DwarfType.FATHER));
            }
            startConditions.Hospital = new Hospital(chanceForDwarfBorn.Object);
            startConditions.MaxDay = 10;
            startConditions.Mine = MineFactory.CreateStandardMine(presenter.Object);
            startConditions.DwarvesBornFirstDay = 0;
            startConditions.Guild = GuildFactory.CreateStandardGuild(presenter.Object);
            startConditions.Shop = new Shop();
            startConditions.Canteen = new Canteen(200);
            SimulationStart simulation = new SimulationStart(startConditions);
            Assert.IsTrue(simulation.Dwarves.Count == 5);

            //when
            simulation.Start();

            //then
            Assert.IsTrue(simulation.Dwarves.Count == 0);
            Assert.IsTrue(Cementary.GraveyardStats == 5);
            Assert.IsTrue(simulation.ActualDay == 1);
            presenter.Verify(i => i.WriteLine("Shaft destroyed."));
            presenter.Verify(i => i.WriteLine("\nCasualties in mine: 5"));
            simulation.Presenter.WriteLine("\nSimulation end because all dwarves died");

        }





    }
}
