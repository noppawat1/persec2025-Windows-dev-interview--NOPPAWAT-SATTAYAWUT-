using NUnit.Framework;
using System.Collections.Generic;
using Test3;  // Namespace ของฟอร์มคุณ

namespace UnitTests3
{
    [TestFixture]
    public class Form1Tests
    {
        [Test]
        public void Autocomplete_ReturnsCorrectResults()
        {
            // Arrange
            string search = "th";
            string[] items = new[] { "TH19", "SG20", "TH2", "SG10", "TH10", "SG2" };
            int maxResult = 3;

            // Act
            List<string> result = Form1.Autocomplete(search, items, maxResult);

            // Assert
            var expected = new List<string> { "TH10", "TH19", "TH2" };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Autocomplete_ReturnsEmptyList_WhenNoMatch()
        {
            // Arrange
            string search = "zz";
            string[] items = new[] { "TH19", "SG20", "TH2" };
            int maxResult = 5;

            // Act
            List<string> result = Form1.Autocomplete(search, items, maxResult);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Autocomplete_RespectsMaxResultLimit()
        {
            // Arrange
            string search = "sg";
            string[] items = new[] { "SG1", "SG2", "SG3", "SG4" };
            int maxResult = 2;

            // Act
            List<string> result = Form1.Autocomplete(search, items, maxResult);

            // Assert
            Assert.That(result.Count, Is.EqualTo(maxResult));
            Assert.That(result, Is.EqualTo(new List<string> { "SG1", "SG2" }));
        }

        [Test]
        public void Autocomplete_CleansBracketsFromItems()
        {
            // Arrange
            string search = "th";
            string[] items = new[] { "[TH19]", "SG20", "[TH2]" };
            int maxResult = 5;

            // Act
            List<string> result = Form1.Autocomplete(search, items, maxResult);

            // Assert
            var expected = new List<string> { "TH19", "TH2" };
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
