using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace SortTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestcharacterNotEven()
        {
            int counter = 0;
            List<string> list = new List<string>();
            list.Add("a");
            Sort getSort = new Sort();
            var list1 = getSort.GetListNotEvenCharacter(list);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestcharacterEven()
        {
            int counter = 0;
            List<string> list = new List<string>();
            list.Add("b");
            for (int i = 0; i < list.Count; i++)
            {
                if (int.TryParse(list[i], out int value))
                {

                }
                else if (list[i][0] % 2 == 0)
                {
                    counter++;
                }
            }
            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void Testcharacternumber()
        {
            int counter = 0;
            List<string> list = new List<string>();
            list.Add("12");
            for (int i = 0; i < list.Count; i++)
            {
                if (int.TryParse(list[i], out int value))
                {
                    counter++;
                }
            }
            Assert.AreEqual(1, counter);
        }
    }
}
