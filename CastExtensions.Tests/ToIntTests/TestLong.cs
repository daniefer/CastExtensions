using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CastExtensions;
using CastExtensions.Classes;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestLong
    {
        [TestMethod]
        public void LongStringTest()
        {
            string inputTooBig = ((ulong)long.MaxValue + (ulong)1).ToString();
            Assert.AreEqual<long>(inputTooBig.ToLong(), 0);
            string inputmax = long.MaxValue.ToString();
            Assert.AreEqual<long>(inputmax.ToLong(), long.MaxValue);
            string input1 = "1";
            Assert.AreEqual<long>(input1.ToLong(), 1);
            string input0 = "0";
            Assert.AreEqual<long>(input0.ToLong(), 0);
            string inputn1 = "-1";
            Assert.AreEqual<long>(inputn1.ToLong(), -1);
            string inputmin = long.MinValue.ToString();
            Assert.AreEqual<long>(inputmin.ToLong(), long.MinValue);
            string inputTooSmall = long.MinValue.ToString().Substring(0, long.MinValue.ToString().Length - 1) + "9"; // have to do something special for this
            Assert.AreEqual<long>(inputTooSmall.ToLong(), 0);
        }

        [TestMethod]
        public void LongTTest()
        {
            object obj = new object();
            Assert.AreEqual<long>(obj.ToLong(), 0);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<long>(dynObj.ToLong(), 0);
            Action action = () => { };
            Assert.AreEqual<long>(action.ToLong(), 0);
        }
    }
}
