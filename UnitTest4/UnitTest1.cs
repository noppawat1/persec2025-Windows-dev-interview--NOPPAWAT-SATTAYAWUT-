using NUnit.Framework;
using System;
using Test4;

namespace UnitTests4
{
    [TestFixture]
    public class Form1Tests
    {
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(9, ExpectedResult = "IX")]
        [TestCase(58, ExpectedResult = "LVIII")]
        [TestCase(1994, ExpectedResult = "MCMXCIV")]
        [TestCase(3999, ExpectedResult = "MMMCMXCIX")]
        public string IntToRoman_ValidInput_ReturnsCorrectRoman(int number)
        {
            return Form1.IntToRoman(number);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(4000)]
        public void IntToRoman_InvalidInput_ThrowsArgumentOutOfRangeException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Form1.IntToRoman(number));
        }

        [TestCase("I", ExpectedResult = 1)]
        [TestCase("IV", ExpectedResult = 4)]
        [TestCase("IX", ExpectedResult = 9)]
        [TestCase("LVIII", ExpectedResult = 58)]
        [TestCase("MCMXCIV", ExpectedResult = 1994)]
        [TestCase("MMMCMXCIX", ExpectedResult = 3999)]
        [TestCase("mcmxciv", ExpectedResult = 1994)]  // Lowercase input should work as well
        public int RomanToInt_ValidInput_ReturnsCorrectInteger(string roman)
        {
            return Form1.RomanToInt(roman);
        }

        [Test]
        public void RomanToInt_EmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Form1.RomanToInt(""));
        }

        [Test]
        public void RomanToInt_NullString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Form1.RomanToInt(null));
        }

    }
}
