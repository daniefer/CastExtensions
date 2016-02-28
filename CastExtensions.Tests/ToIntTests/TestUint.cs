using System;
using CastExtensions.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestUint
    {
        [TestMethod]
        public void UintStringTest()
        {
            string inputTooBig = ((long)uint.MaxValue + (long)1).ToString();
            Assert.AreEqual<uint>(inputTooBig.ToUInt(), 0);
            string inputmax = uint.MaxValue.ToString();
            Assert.AreEqual<uint>(inputmax.ToUInt(), uint.MaxValue);
            string input1 = "1";
            Assert.AreEqual<uint>(input1.ToUInt(), 1);
            string input0 = "0";
            Assert.AreEqual<uint>(input0.ToUInt(), 0);
            string inputn1 = "-1";
            Assert.AreEqual<uint>(inputn1.ToUInt(), 0);
        }

        [TestMethod]
        public void UintTTest()
        {
            object obj = new object();
            Assert.AreEqual<uint>(obj.ToUInt(), 0);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<uint>(dynObj.ToUInt(), 0);
            Action action = () => { };
            Assert.AreEqual<uint>(action.ToUInt(), 0);
        }
    }
}
