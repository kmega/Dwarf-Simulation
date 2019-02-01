using Mergee_tree;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void T01ReadFile()
        {
            SaveTreeListAndWrite write = new SaveTreeListAndWrite();
            var test = write.Write();
            TreeSort treeSort = new TreeSort();
            var test2 = treeSort.sort(test);
            Assert.Pass();
        }
    }
}