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
        [Test]
        public void CementaryReceivesDeadWorkers_ShouldDeleteWorkingGroupClass()
        {
            // Given
            Dwarf[] workingDwarves = new Dwarf[5];
            WorkingGroup workingGroups = new WorkingGroup(workingDwarves);

            //when
            Cementary.ReceiveDeadWorkers(workingGroups);
           // Logger.GetInstance().AddLog("Group is dead");

            //then
            Assert.AreEqual(5,Cementary._deadDwarves);
            Assert.AreEqual("Group has died in fatal accident", Logger.GetInstance().GetLogs()[0]);

        }
    }
}
