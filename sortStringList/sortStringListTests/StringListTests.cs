using NUnit.Framework;
using sortStringList;

namespace sortStringListTests
{
    [TestFixture]
    public class StringListTests
    {
        [TestCase("a,b,1,7,4,c,9,d,14,k,a,1,2", "a,a,1,1,2,4,7,9,14,b,c,d,k")]
        public void SortString(string beforeSort, string afterSort)
        {
            StringList st = new StringList();

            string result = st.SortStringList(beforeSort);

            Assert.AreEqual(afterSort, result);
        }
    }
}
