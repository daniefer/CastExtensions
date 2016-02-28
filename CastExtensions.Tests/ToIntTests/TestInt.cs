using System;
using CastExtensions.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CastExtensions;
using CastExtensions.Classes;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestInt
    {
        [TestMethod]
        public void IntStringTest()
        {
            string inputTooBig = ((long)int.MaxValue + (long)1).ToString();
            Assert.AreEqual<int>(inputTooBig.ToInt(), 0);
            string inputmax = int.MaxValue.ToString();
            Assert.AreEqual<int>(inputmax.ToInt(), int.MaxValue);
            string input1 = "1";
            Assert.AreEqual<int>(input1.ToInt(), 1);
            string input0 = "0";
            Assert.AreEqual<int>(input0.ToInt(), 0);
            string inputn1 = "-1";
            Assert.AreEqual<int>(inputn1.ToInt(), -1);
            string inputmin = int.MinValue.ToString();
            Assert.AreEqual<int>(inputmin.ToInt(), int.MinValue);
            string inputTooSmall = ((long)int.MinValue - (long)1).ToString();
            Assert.AreEqual<int>(inputTooSmall.ToInt(), 0);
        }

        [TestMethod]
        public void IntTTest()
        {
            object obj = new object();
            Assert.AreEqual<int>(obj.ToInt(), 0);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<int>(dynObj.ToInt(), 0);
            Action action = () => { };
            Assert.AreEqual<int>(action.ToInt(), 0);
            decimal dec = 22.3m;
            Assert.AreEqual<int>(dec.ToShort(), 22);
        }
    }
}
