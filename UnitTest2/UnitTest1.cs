using NUnit.Framework;
using Test2;

namespace UnitTests2
{
    [TestFixture]
    public class Form1Tests
    {
        [Test]
        public void CustomSort_SortsCorrectly()
        {
            // Arrange
            string[] input = new[] { "TH19", "SG20", "TH2", "SG10", "TH10", "SG2" };
            string[] expected = new[] { "SG2", "SG10", "SG20", "TH2", "TH10", "TH19" };

            // Act
            string[] result = Form1.CustomSort(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        public void CustomSort_EmptyArray_ReturnsEmpty()
        {
            // Arrange
            string[] input = new string[] { };

            // Act
            string[] result = Form1.CustomSort(input);

            // Assert
            Assert.That(result, Is.Empty);

        }

        [Test]
        public void ExtractNumber_ExtractsNumberCorrectly()
        {
            Assert.That(Form1.ExtractNumber("19"), Is.EqualTo(19));
            Assert.That(Form1.ExtractNumber(""), Is.EqualTo(0));
            Assert.That(Form1.ExtractNumber("123abc"), Is.EqualTo(123));
            Assert.That(Form1.ExtractNumber("45xyz"), Is.EqualTo(45));
            Assert.That(Form1.ExtractNumber("abc"), Is.EqualTo(0));

        }
    }
}
