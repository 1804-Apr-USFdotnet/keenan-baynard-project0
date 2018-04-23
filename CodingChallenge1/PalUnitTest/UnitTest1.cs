using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge1;

namespace PalUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PalUnitTes1()
        {
            string TestString = "racecar";
            bool expected = true;

            bool actual = Pal.Check(TestString);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PalUnitTest2()
        {
            string TestString = "never odd, or even";
            bool expected = true;

            bool actual = Pal.Check(TestString);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PalUnitTes3()
        {
            string TestString = "RacecAr";
            bool expected = true;

            bool actual = Pal.Check(TestString);

            Assert.AreEqual(expected, actual);
        }
    }
}
