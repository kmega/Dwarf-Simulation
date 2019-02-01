using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TreeMerging;

namespace TreeMergingTests
{
    class RecordCreatingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldBuildLocationRecordsFromSimpleTree()
        {
            //given:
            var tree = new FakeTreeData().GetSimpleTree();

            //When
            List<LocationRecord> result = RecordFactory.CreateRecords(tree); 
            //Then
            Assert.IsTrue(result[2].Depth == 8);
            Assert.IsTrue(result[2].Content == "Astoria, Asteroidy");
            Assert.IsTrue(result[2].Path == "|Świat|Primus");
            Assert.IsTrue(result.Count == 3);
        }
        [Test]
        public void ShouldBuildTreeWithAppropiatePathForPtasieOsiedleRecord()
        {
            //given:
            var tree = new FakeTreeData().GetComplexTree();

            //When
            List<LocationRecord> result = RecordFactory.CreateRecords(tree);
            //Then
            Assert.IsTrue(result[9].Depth == 24);
            Assert.IsTrue(result[9].Content == "Osiedle Ptasie");
            Assert.IsTrue(result[9].Path == "|Świat|Primus|Astoria|Szczeliniec|Powiat Pustogorski|Zaczęstwo");
            Assert.IsTrue(result.Count == 12);
        }
    }
}
