using FoodTracks.Model;
using NUnit.Framework;

namespace Tests
{
    public class MeetTests
    { 
        [Test]
        public void T01_Creation_Of_None_Meet()
        {
            // Given
            // When
            var result = Meat.CreateMeet();
            // Then
            Assert.AreEqual(result.Type, MeatType.None);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void T02_Creation_Of_Rare_Meet(int time)
        {
            // Given
            // When
            var result = Meat.CreateMeet(time);
            // Then
            Assert.AreEqual(result.Type, MeatType.Rare);
        }

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void T03_Creation_Of_Medium_Meet(int time)
        {
            // Given
            // When
            var result = Meat.CreateMeet(time);
            // Then
            Assert.AreEqual(result.Type, MeatType.Medium);
        }

        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        public void T04_Creation_Of_Full_Meet(int time)
        {
            // Given
            // When
            var result = Meat.CreateMeet(time);
            // Then
            Assert.AreEqual(result.Type, MeatType.Full);
        }
    }
}