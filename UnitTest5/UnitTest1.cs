using NUnit.Framework;
using System;
using Test5;

namespace UnitTests5
{
    [TestFixture]
    public class Form1Tests
    {
        private Form1 form;

        [SetUp]
        public void Setup()
        {
            form = new Form1();
        }

        [TestCase(12345, ExpectedResult = 54321)]
        [TestCase(987654321, ExpectedResult = 987654321)]
        [TestCase(1002, ExpectedResult = 2100)]
        [TestCase(555, ExpectedResult = 555)]
        [TestCase(1, ExpectedResult = 1)]
        public int SortDigitsDesc_ValidInput_ReturnsSortedNumber(int input)
        {
            return form.SortDigitsDesc(input);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-123)]
        public void SortDigitsDesc_NonPositiveInput_ThrowsArgumentOutOfRangeException(int input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => form.SortDigitsDesc(input));
        }
    }
}
