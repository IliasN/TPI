/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoundStreamTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(SecondesToMMSS(92), "1:32");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(SecondesToMMSS(120), "2:00");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(SecondesToMMSS(0), "0:00");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(SecondesToMMSS(3), "0:03");
        }

        private string SecondesToMMSS(int pSec)
        {
            int minutes = pSec / 60;
            int secondes = pSec - ((pSec / 60) * 60);
            if (secondes < 10)
                return string.Format("{0}:{1}", minutes.ToString(), "0" + secondes.ToString());
            return string.Format("{0}:{1}", minutes.ToString(), secondes.ToString());
        }
    }
}
