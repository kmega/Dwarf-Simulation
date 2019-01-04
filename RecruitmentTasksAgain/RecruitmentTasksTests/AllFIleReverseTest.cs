using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitmentTasksAgain;
using RecruitmentTasksAgain.Tools;
using System.Collections.Generic;

namespace RecruitmentTasksTests
{
    [TestClass]
    public class AllFileReverseTest
    {
        [TestMethod]
        public void ShouldReturnReverseText()
        {
            //given 
            AllFileStringInList file = new AllFileStringInList();
            List<string> testStr = file.teasStr;

            //when
            List<string> result = TextTools.ReverseListOfString(testStr);

            //then
            CollectionAssert.AreEqual(file.teasStrRev, result);
        }
    }
}
