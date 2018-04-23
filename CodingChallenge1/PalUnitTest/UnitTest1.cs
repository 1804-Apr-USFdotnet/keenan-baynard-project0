using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge1;

namespace PalUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PalUnitTest()
        {
            string TestString = "racecar";
            bool expected = true;

            bool actual = Pal.Check(TestString);

            Assert.AreEqual(expected, actual);
            
        }
    }
}
