using NUnit.Framework;
using PersecTest;
using System.Reflection;

namespace UnitTest1
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

        [TestCase("()", true)]
        [TestCase("[]", true)]
        [TestCase("{}", true)]
        [TestCase("({[]})", true)]
        [TestCase("({[})", false)]
        [TestCase("(", false)]
        [TestCase(")", false)]
        [TestCase("[}", false)]
        [TestCase("{[()]}", true)]
        [TestCase("{[a]}", false)] // มีตัวอักษรที่ไม่ใช่วงเล็บ
        public void IsBalanced_ReturnsExpected(string input, bool expected)
        {
            var method = typeof(Form1).GetMethod("IsBalanced", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(method, Is.Not.Null, "ไม่พบเมธอด IsBalanced – โปรดตรวจสอบชื่อหรือ access modifier");


            bool result = (bool)method.Invoke(form, new object[] { input });

            Assert.That(result, Is.EqualTo(expected));

        }
    }
}
