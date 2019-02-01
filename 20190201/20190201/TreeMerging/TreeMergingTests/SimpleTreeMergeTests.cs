using NUnit.Framework;
using System.Collections.Generic;
using TreeMerging;
using TreeMergingTests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldMergeFakeSimpleWithComplexTree()
        {
            //given
            var simpleTree = RecordFactory.CreateRecords(new FakeTreeData().GetSimpleTree());
            var complexTree = RecordFactory.CreateRecords(new FakeTreeData().GetComplexTree());

            //when
            List<LocationRecord> mergedTree = TreeMerger.MergeTwoTrees(simpleTree, complexTree);
            //then
            Assert.IsTrue(mergedTree.Count == 13);
            Assert.AreEqual(mergedTree[2], simpleTree[2]);
            Assert.AreEqual(mergedTree[10], complexTree[9]);
        }
        [Test]
        public void ShouldMergeListOf4Trees()
        {
            //given
            List<LocationRecord> tree1 = RecordFactory.CreateRecords(new FakeTreeData().GetSimpleTree());
            List<LocationRecord> tree2 = RecordFactory.CreateRecords(new FakeTreeData().GetComplexTree());
            List<LocationRecord> tree3 = RecordFactory.CreateRecords(new FakeTreeData().GetThirdTree());
            List<LocationRecord> tree4 = RecordFactory.CreateRecords(new FakeTreeData().GetFourthTree());
            List<List<LocationRecord>> trees = new List<List<LocationRecord>>()
            {
                tree1, tree2, tree3, tree4
            };
            //when
            List<LocationRecord> mergedTree = TreeMerger.MergeTrees(trees);
            //then
            Assert.IsTrue(mergedTree.Count == 18);
        }
    }
}