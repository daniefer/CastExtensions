using System;
using CastExtensions.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestUshort
    {
        [TestMethod]
        public void UshortStringTest()
        {
            string inputTooBig = ((int)ushort.MaxValue + (int)1).ToString();
            Assert.AreEqual<ushort>(inputTooBig.ToUShort(), 0);
            string inputmax = ushort.MaxValue.ToString();
            Assert.AreEqual<ushort>(inputmax.ToUShort(), ushort.MaxValue);
            string input1 = "1";
            Assert.AreEqual<ushort>(input1.ToUShort(), 1);
            string input0 = "0";
            Assert.AreEqual<ushort>(input0.ToUShort(), 0);
            string inputn1 = "-1";
            Assert.AreEqual<ushort>(inputn1.ToUShort(), 0);
        }

        [TestMethod]
        public void UshortTTest()
        {
            object obj = new object();
            Assert.AreEqual<ushort>(obj.ToUShort(), 0);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<ushort>(dynObj.ToUShort(), 0);
            Action action = () => { };
            Assert.AreEqual<ushort>(action.ToUShort(), 0);
        }
    }
}
