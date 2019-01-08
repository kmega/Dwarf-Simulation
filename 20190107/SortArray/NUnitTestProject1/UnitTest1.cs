using NUnit.Framework;


namespace Tests
{
    public class Tests
    {

        [Test]
        public void SortFinal()
        {
            //given
            SortArray.Sorter sort = new SortArray.Sorter();
            string[] arrayToSort = { "a", "b", "1", "7", "4", "9", "d", "14", "k", "a", "1", "2" };

            //act
            string[] result = sort.SortArray(arrayToSort);

            Assert.AreEqual("a", result[1]);
            Assert.AreEqual("d", result[result.Length-1]);
        }

        [Test]
        public void SortEvenLetters()
        {
            //given
            SortArray.Sorter sort = new SortArray.Sorter();
            string[] arrayToSort = { "f","b","d" };

            //act
            string[] result = sort.SortEvenLetters(arrayToSort);

            Assert.AreEqual("b", result[0]);
            Assert.AreEqual("f", result[result.Length - 1]);
        }

        [Test]
        public void SortOddLetters()
        {
            //given
            SortArray.Sorter sort = new SortArray.Sorter();
            string[] arrayToSort = { "e", "c", "a" };

            //act
            string[] result = sort.SortOddLetters(arrayToSort);

            Assert.AreEqual("a", result[0]);
            Assert.AreEqual("e", result[result.Length - 1]);
        }
    }
}