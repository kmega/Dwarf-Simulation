using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Guild;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SimulationTests.Guild_Tests
{
    public class GuildTests
    {

        [Test]
        public void TestDirtGoldReturnForOneDwarf()
        {
            //given
            Guild guild = new Guild();
            List<Dwarf> dwarves = new List<Dwarf>()
        {
            new Dwarf()
            {
               PersonalEquipment = new List<E_MineralsType> {E_MineralsType.DirtGold}
            }
        };

            //when
            guild.PaymentForDwars(dwarves);

            //then
            Assert.AreEqual(1.5m, dwarves[0].DailySalary);
            Assert.AreEqual(0.5m, guild.Account);
        }

        [Test]
        public void TestDirtGoldForTwoDwarves()
        {
            //given
            Guild guild = new Guild();
            List<Dwarf> dwarves = new List<Dwarf>()
        {
            new Dwarf()
            {
               PersonalEquipment = new List<E_MineralsType> {E_MineralsType.DirtGold}
            },
            new Dwarf()
            {
               PersonalEquipment = new List<E_MineralsType> {E_MineralsType.DirtGold}
            },

        };

            //when
            guild.PaymentForDwars(dwarves);

            //then
            Assert.AreEqual(1.5m, dwarves[0].DailySalary);
            Assert.AreEqual(1.5m, dwarves[1].DailySalary);
            Assert.AreEqual(1m, guild.Account);
        }

    }
}
