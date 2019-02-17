using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany;

namespace ThorinsCompanyTests
{
    public class ShaftTests
    {
        Bank bank = new Bank();

        [Test]
        public void ShouldWorkingGroupDieWhenGroupContainsBomberDwarf()
        {
            // given
            List<Dwarf> dwarves = new Hospital().CreateDwarves(4);
            Dwarf dwarfBomber = DwarfFactory.CreateDwarf(DwarfType.Bomber);
            dwarves.Add(dwarfBomber);
            
            WorkingGroup workingGroup = new WorkingGroup(dwarves.ToArray());
            Shaft shaft = new Shaft();

            // when
            shaft.PerformAction(workingGroup);

            //then
            foreach(Dwarf dwarf in workingGroup.Workers)
            {
                Assert.AreEqual(false, dwarf.GetLifeStatus());
            }
        }



        [Test]
        public void ShouldWorkingGroupDigWhenGroupNotContainsBomberDwarf()
        {
            // given
            List<Dwarf> dwarves = new List<Dwarf>();
            dwarves.Add(DwarfFactory.CreateDwarf(DwarfType.Father));
            dwarves.Add(DwarfFactory.CreateDwarf(DwarfType.Lazy));
            dwarves.Add(DwarfFactory.CreateDwarf(DwarfType.Single));
            dwarves.Add(DwarfFactory.CreateDwarf(DwarfType.Father));
            WorkingGroup workingGroup = new WorkingGroup(dwarves.ToArray());
            Shaft shaft = new Shaft();

            // when
            shaft.PerformAction(workingGroup);

            //then
            foreach (Dwarf dwarf in workingGroup.Workers)
            {
                Assert.AreEqual(true, dwarf.GetLifeStatus());
                Assert.IsTrue(dwarf.ShowDiggedMaterials().Count > 0);
            }
        }

    }
}
