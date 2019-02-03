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
	}
}