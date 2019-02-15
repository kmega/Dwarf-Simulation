using Dwarf_Town;
using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations.Guild;
using Dwarf_Town.Locations.Mine;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dwarf_TownTests
{
    public class NewspaperTests
    {
        [Test]
        public void DwarfSellDirytGold()
        {
            //given
            Mock<IOutputWriter> presenter = new Mock<IOutputWriter>();
            Guild guild = GuildFactory.CreateStandardGuild(presenter.Object);
            Dwarf dwarf = new Dwarf(DwarfType.FATHER);
            dwarf.BackPack.AddOre(MineralType.DirtyGold);
            List<ISell> miners = new List<ISell>() { dwarf._sell };

            //when
            guild.PaymentForDwarves(miners);

            //then
            presenter.Verify(i => i.WriteLine("Dwarf exchange DirtyGold for 1,50 gp and guild take 0,50 gp provision"));
        }

        [Test]
        public void SuicideDestroyShaft()
        {
            //given
            Mock<IOutputWriter> presenter = new Mock<IOutputWriter>();
            Shaft shaft = new Shaft(presenter.Object);
            Dwarf dwarf = new Dwarf(DwarfType.SUICIDE);

            //when
            shaft.PerformWork(new List<IWork>() { dwarf._work });

            //given
            presenter.Verify(i => i.WriteLine("Shaft destroyed."));
        }

        [Test]
        public void DwarfBroughtOutGold()
        {
            //given
            Mock<IOutputWriter> presenter = new Mock<IOutputWriter>();
            Shaft shaft = new Shaft(presenter.Object);
            Mock<IWork> workingDwarf = new Mock<IWork>();
            workingDwarf.Setup(i => i.Dig()).Returns(1);
            workingDwarf.Setup(i => i.GenerateChance(It.IsAny<int>(), It.IsAny<int>())).Returns(20);

            //when
            shaft.PerformWork(new List<IWork>() { workingDwarf.Object });

            //then
            presenter.Verify(i => i.WriteLine("Dwarf brought out Gold."));
        }
    }
}