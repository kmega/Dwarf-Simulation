using NUnit.Framework;
using Drzewa;
using System.Collections.Generic;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestingCreatingRecordsWithPath()
		{
			//given
			List<string> drzewo1 = new List<string>()
			{
				"1. Œwiat",
				"    1. Primus",
				"        1. Astoria",
				"            1. Szczeliniec",
				"                1. Powiat Pustogorski",
				"                    1. Pustogor",
				"                        1. Gabinet Piêknotki",
				"                    1. Zaczêstwo",
				"                        1. Cyberszko³a",
				"                        1. Osiedle Ptasie",
				"                    1. Trzêsawisko Zjawosztup",
				"                        1. G³odna Ziemia"
			};
			TreeFactory rf = new TreeFactory();

			//when
			var RecordListTest = rf.CreateTreeOfRecords(drzewo1);
			Record expected = new Record("G³odna Ziemia", "Œwiat|Primus|Astoria|Szczeliniec|Powiat Pustogorski|Trzêsawisko Zjawosztup|", 24);
			//then
			Assert.AreEqual(RecordListTest[11]._path, expected._path);
		}
		[Test]
		public void ShouldBe12Records()
		{
			//given
			List<string> drzewo1 = new List<string>()
			{
				"1. Œwiat",
				"    1. Primus",
				"        1. Astoria",
				"            1. Szczeliniec",
				"                1. Powiat Pustogorski",
				"                    1. Pustogor",
				"                        1. Gabinet Piêknotki",
				"                    1. Zaczêstwo",
				"                        1. Cyberszko³a",
				"                        1. Osiedle Ptasie",
				"                    1. Trzêsawisko Zjawosztup",
				"                        1. G³odna Ziemia"
			};
			TreeFactory rf = new TreeFactory();

			//when
			var RecordListTest = rf.CreateTreeOfRecords(drzewo1);
			//then
			Assert.AreEqual(RecordListTest.Count, 12);
		}

		[Test]
		public void DepthShouldBe10()
		{
			//given
			List<string> drzewo1 = new List<string>()
			{
				"          1. NazwaTestowa"
			};
			//when
			List<Record> TestRecordList = new TreeFactory().CreateTreeOfRecords(drzewo1);
			int resultDepth = TestRecordList[0]._depth;
			//then
			Assert.AreEqual(10, resultDepth);
		}

		[Test]
		public void Merging2simpleTreesAfterMergeTree1ShouldHave3Records()
		{
			//given
			List<string> drzewo1 = new List<string>()
			{
				"1. SwiatTestowy",
				"    1. KontynentTestowy"
			};
			List<string> drzewo2 = new List<string>()
			{
				"1. SwiatTestowy",
				"    1. KontynentTestowy",
				"        1. MiastoTestowe"
			};
			TreeFactory rf = new TreeFactory();
			List<Record> tree1 = rf.CreateTreeOfRecords(drzewo1);
			List<Record> tree2 = rf.CreateTreeOfRecords(drzewo2);

			//when
			tree1 = new MergingTree().MergeTwoTrees(tree1, tree2);
			int result = tree1.Count;
			//then
			Assert.AreEqual(3, result);
		}
	}
}