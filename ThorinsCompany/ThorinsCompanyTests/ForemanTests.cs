using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ThorinsCompany;

namespace ThorinsCompanyTests
{

    public class ForemanTests
    {
        [Test]
        public void ShouldForemanDivideDwarvesIntoGroupsOfFive([Range(0, 1000)]int dwarfs)
        {
            // Given
            new Bank();
            Hospital hospital = new Hospital();
            List<Dwarf> dwarves = hospital.CreateDwarves(dwarfs);
            int groupsExpected = dwarves.Count / 5;
            if (dwarves.Count % 5 != 0) groupsExpected++;
            Mine mine = new Mine();
            Foreman master = mine.Master;

            // When
            List<WorkingGroup> workingGroups = master.DivideDwarvesIntoWorkingGroups(dwarves);

            // Then
            int groupActual = workingGroups.Count;
            Assert.AreEqual(groupsExpected, groupActual);

        }
    }
}
