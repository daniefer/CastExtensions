using System;
using CastExtensions.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestUlong
    {
        [TestMethod]
        public void UlongStringTest()
        {
            string inputTooBig = ulong.MaxValue.ToString().Substring(0, ulong.MaxValue.ToString().Length - 1) + "6"; // have to do something special here.
            Assert.AreEqual<ulong>(inputTooBig.ToULong(), 0);
            string inputmax = ulong.MaxValue.ToString();
            Assert.AreEqual<ulong>(inputmax.ToULong(), ulong.MaxValue);
            string input1 = "1";
            Assert.AreEqual<ulong>(input1.ToULong(), 1);
            string input0 = "0";
            Assert.AreEqual<ulong>(input0.ToULong(), 0);
            string inputn1 = "-1";
            Assert.AreEqual<ulong>(inputn1.ToULong(), 0);
        }

        [TestMethod]
        public void UlongTTest()
        {
            object obj = new object();
            Assert.AreEqual<ulong>(obj.ToULong(), 0);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<ulong>(dynObj.ToULong(), 0);
            Action action = () => { };
            Assert.AreEqual<ulong>(action.ToULong(), 0);
        }
    }
}
