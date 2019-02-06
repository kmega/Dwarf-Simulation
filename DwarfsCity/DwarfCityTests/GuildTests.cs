using System;
using System.Collections.Generic;
using System.Text;
using DwarfsCity;
using DwarfsCity.DwarfContener;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DwarfCityTests
{
    [TestClass]
    public class GuildTests
    {
        [TestMethod]
        public void SpendMoneyFromGuild()
        {
            //given
            City city = new City();
            Guild guild = new Guild();
            Hospital hospital = new Hospital();
            hospital.InitialiseBasicNumberOfDwarfs(city.GetDwarfs(), 10);

            foreach (var dwarf in city.GetDwarfs())
            {
                dwarf.Backpack.Moneys = 10;
            }

            //when,then
            guild.GetMoneyFromDwarfs(city.GetDwarfs());
            guild.SpendGiuldMoney(100);

            Assert.AreEqual(0, guild.GetGuildMoney());

            //when, then
            bool canSpendMoney = guild.SpendGiuldMoney(1);

            Assert.IsTrue(canSpendMoney == false);


        }
    }
}
