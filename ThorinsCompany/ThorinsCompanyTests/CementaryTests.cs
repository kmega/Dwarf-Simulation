using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany;
using ThorinsCompany.Raports;

namespace ThorinsCompanyTests
{
    class CementaryTests
    {
        Bank _bank = new Bank();

        [Test]
        public void CementaryReceivesDeadWorkers_ChangesStatusIsAliveToFalseAndLoggsMessageAndAddsThemToDeadList()
        {
            // Given
            Dwarf[] workingDwarves = new Hospital().CreateDwarves(5).ToArray();
            WorkingGroup workingGroups = new WorkingGroup(workingDwarves);

            //when
            Cementary.ReceiveDeadWorkers(workingGroups);

            //then
            foreach (var dwarf in workingDwarves)
            {
                Assert.IsFalse(dwarf.GetLifeStatus());
            }

            Assert.AreEqual(5,Cementary._deadDwarves);

        }

        [Test]
        public void FuneralOnCementary_DeadWarvesAreRemovedFromListOfAllDwarves()
        {
            // Given
            List<Dwarf> dwarves = new Hospital().CreateDwarves(5);
            Dwarf[] workingDwarves = dwarves.ToArray();
            WorkingGroup workingGroups = new WorkingGroup(workingDwarves);

            //when
            Cementary.ReceiveDeadWorkers(workingGroups);
            Cementary.Funeral(dwarves);

            //then
            foreach (var dwarf in dwarves)
            {
                Assert.IsTrue(dwarf.GetLifeStatus());
            }

            Assert.AreEqual(0, dwarves.Count);

        }
    }
}
