using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ReverseTextInputByLines_TwoLines_Task1Part()
        {
            //given
            CorealateTasks.TextReverser reverse = new CorealateTasks.TextReverser();
            string[] input = { "1,2,3","4,5,6" };

            string[] result = reverse.ReverseInput(input);

            Assert.AreEqual("4,5,6", result[0]);
            Assert.AreEqual("1,2,3", result[1]);
        }

        [Test]
        public void ReverseTextInputByLines_EmptyInput_Task1Part()
        {
            //given
            CorealateTasks.TextReverser reverse = new CorealateTasks.TextReverser();
            string[] input = { "" };

            string[] result = reverse.ReverseInput(input);

            Assert.AreEqual("", result[0]);
            
        }

        [Test]
        public void ReverseTextInputByLines_OneLine_Task1Part()
        {
            //given
            CorealateTasks.TextReverser reverse = new CorealateTasks.TextReverser();
            string[] input = { "1,2,3" };

            string[] result = reverse.ReverseInput(input);

            Assert.AreEqual("1,2,3", result[0]);

        }
    }
}