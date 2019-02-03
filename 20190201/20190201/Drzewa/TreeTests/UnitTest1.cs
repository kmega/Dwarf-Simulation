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
				"1. �wiat",
				"    1. Primus",
				"        1. Astoria",
				"            1. Szczeliniec",
				"                1. Powiat Pustogorski",
				"                    1. Pustogor",
				"                        1. Gabinet Pi�knotki",
				"                    1. Zacz�stwo",
				"                        1. Cyberszko�a",
				"                        1. Osiedle Ptasie",
				"                    1. Trz�sawisko Zjawosztup",
				"                        1. G�odna Ziemia"
			};
			TreeFactory rf = new TreeFactory();

			//when
			var RecordListTest = rf.CreateTreeOfRecords(drzewo1);
			Record expected = new Record("G�odna Ziemia", "�wiat|Primus|Astoria|Szczeliniec|Powiat Pustogorski|Trz�sawisko Zjawosztup|", 24);
			//then
			Assert.AreEqual(RecordListTest[11]._path, expected._path);
		}
		[Test]
		public void ShouldBe12Records()
		{
			//given
			List<string> drzewo1 = new List<string>()
			{
				"1. �wiat",
				"    1. Primus",
				"        1. Astoria",
				"            1. Szczeliniec",
				"                1. Powiat Pustogorski",
				"                    1. Pustogor",
				"                        1. Gabinet Pi�knotki",
				"                    1. Zacz�stwo",
				"                        1. Cyberszko�a",
				"                        1. Osiedle Ptasie",
				"                    1. Trz�sawisko Zjawosztup",
				"                        1. G�odna Ziemia"
			};
			TreeFactory rf = new TreeFactory();

			//when
			var RecordListTest = rf.CreateTreeOfRecords(drzewo1);
			//then
			Assert.AreEqual(RecordListTest.Count, 12);
		}
	}
}