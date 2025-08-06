using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Test6;

namespace UnitTests6
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

        [Test]
        public void Tribonacci_WithLessThan3StartValues_FillsWithZeros()
        {
            var start = new List<int> { 1 };
            int n = 5;
            var expected = new List<int> { 1, 0, 0, 1, 1 }; // 1,0,0, then 1+0+0=1, then 0+0+1=1

            var actual = form.Tribonacci(start, n);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Tribonacci_WithExact3StartValuesAndNLessThanCount_ReturnsFirstN()
        {
            var start = new List<int> { 1, 2, 3 };
            int n = 2;
            var expected = new List<int> { 1, 2 };

            var actual = form.Tribonacci(start, n);
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Tribonacci_With3StartValuesAndNMoreThanCount_ComputesCorrectly()
        {
            var start = new List<int> { 1, 1, 1 };
            int n = 6;
            var expected = new List<int> { 1, 1, 1, 3, 5, 9 };
            // 4th = 1+1+1=3
            // 5th = 1+1+3=5
            // 6th = 1+3+5=9

            var actual = form.Tribonacci(start, n);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Tribonacci_WithEmptyStartList_FillsZeros()
        {
            var start = new List<int>();
            int n = 4;
            var expected = new List<int> { 0, 0, 0, 0 };

            var actual = form.Tribonacci(start, n);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Tribonacci_WithStartListMoreThan3_UsesOnlyFirst3()
        {
            // Your code doesn't explicitly limit start to 3 in Tribonacci method,
            // but button click handler limits to 3 max. 
            // Here testing Tribonacci method alone with 4 values.
            var start = new List<int> { 1, 2, 3, 4 };
            int n = 6;
            var expected = new List<int> { 1, 2, 3, 4, 9, 16 };
            // Next values calculated as:
            // 5th = 4 + 3 + 2 = 9
            // 6th = 9 + 4 + 3 = 16

            var actual = form.Tribonacci(start, n);

            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}
