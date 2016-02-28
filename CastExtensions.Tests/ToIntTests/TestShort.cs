using System;
using CastExtensions.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestShort
    {
        [TestMethod]
        public void ShortStringTest()
        {
            string inputTooBig = (short.MaxValue + 1).ToString();
            Assert.AreEqual<short>(inputTooBig.ToShort(), 0);
            string inputmax = short.MaxValue.ToString();
            Assert.AreEqual<short>(inputmax.ToShort(), short.MaxValue);
            string input1 = "1";
            Assert.AreEqual<short>(input1.ToShort(), 1);
            string input0 = "0";
            Assert.AreEqual<short>(input0.ToShort(), 0);
            string inputn1 = "-1";
            Assert.AreEqual<short>(inputn1.ToShort(), -1);
            string inputmin = short.MinValue.ToString();
            Assert.AreEqual<short>(inputmin.ToShort(), short.MinValue);
            string inputTooSmall = (short.MinValue - 1).ToString();
            Assert.AreEqual<short>(inputTooSmall.ToShort(), 0);
        }

        [TestMethod]
        public void ShortTTest()
        {
            object obj = new object();
            Assert.AreEqual<short>(obj.ToShort(), 0);
            object dynObj = new {Param1 = "test", Param2 = 1, Param3 = new object()};
            Assert.AreEqual<short>(dynObj.ToShort(), 0);
            Action action = () => { };
            Assert.AreEqual<int>(action.ToShort(), 0);
        }
    }
}
