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
            List<Dwarf> dwarves = new List<Dwarf>();
            dwarves.Add(new Dwarf(DwarfType.Bomber, null, new BomberWorkingStrategy()));
            dwarves.Add(new Dwarf(DwarfType.Father, null, new StandardWorkingStrategy()));
            dwarves.Add(new Dwarf(DwarfType.Lazy, null, new StandardWorkingStrategy()));
            dwarves.Add(new Dwarf(DwarfType.Single, null, new StandardWorkingStrategy()));
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
            dwarves.Add(new Dwarf(DwarfType.Father, null, new StandardWorkingStrategy()));
            dwarves.Add(new Dwarf(DwarfType.Lazy, null, new StandardWorkingStrategy()));
            dwarves.Add(new Dwarf(DwarfType.Single, null, new StandardWorkingStrategy()));
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
