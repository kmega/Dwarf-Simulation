using NUnit.Framework;
using ThorinsCompany;
using Moq;

namespace ThorinsCompanyTests
{
    class HospitalTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(1,1)]
        [TestCase(10, 10)]
        public void T01Hospital(int HowManyYouWantCreateDwarf, int countDwarvesList)
        {
            Hospital hospital = new Hospital();
            var dwarves = hospital.CreateDwarves(HowManyYouWantCreateDwarf);
            Assert.AreEqual(dwarves.Count, countDwarvesList);
        }
    }
}
