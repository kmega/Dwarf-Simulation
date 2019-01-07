using NUnit.Framework;


namespace Tests
{
    public class Tests
    {

        [Test]
        public void SortNiepNumbers()
        {
            //given
            SortArray.Sorter sort = new SortArray.Sorter();
            string[] arrayToSort = { "a", "b", "1", "7", "4", "9", "d", "14", "k", "a", "1", "2" };

            //act
            string[] result = sort.SortArray(arrayToSort);

            Assert.AreEqual("a", result[1]);
            Assert.AreEqual("d", result[result.Length-1]);
        }
    }
}