using NUnit.Framework;
using ThorinsCompany;
using Moq;
using System.Collections.Generic;

namespace ThorinsCompanyTests
{
    class HospitalTest
    {
        [TestCase(1,1)]
        [TestCase(10, 10)]
        public void T01Hospital(int HowManyYouWantCreateDwarf, int countDwarvesList)
        {
            Hospital hospital = new Hospital();
            var dwarves = hospital.CreateDwarves(HowManyYouWantCreateDwarf);
            Assert.AreEqual(dwarves.Count, countDwarvesList);
        }

        [Test]
        public void T02Hospital()
        {
            Mock<IRamdomizerThorins> dwarfType = new Mock<IRamdomizerThorins>();
            dwarfType.Setup(m => m.WillHeBeBorn(1)).Returns(true);
        }
    }
}
