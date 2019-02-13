using DwarfsTown;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DwarfsTownTests
{
    [TestClass]
    public class HospitalTests
    {
        Dwarf dwarf;
        Hospital hospital = new Hospital();
        Randomizer randomizer;
        [TestMethod]
        public void IsBornFatherDwarf()
        {      
            Dwarf dwarf = hospital.BirthDwarf();
            //expected
            TypeEnum expected = TypeEnum.Father;
            //result           
            TypeEnum result = dwarf.Type;
            

            Assert.AreEqual(expected,result);
        }
       public void IsTenDwarfsBorn()
        {

        }
    }
}
