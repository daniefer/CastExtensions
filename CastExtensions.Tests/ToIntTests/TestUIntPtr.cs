using System;
using CastExtensions.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestUIntPtr
    {
        [TestMethod]
        public void UIntPtrStringTest()
        {
            string inputTooBig = ulong.MaxValue.ToString().Substring(0, ulong.MaxValue.ToString().Length - 1) + "6"; // have to do something special here.
            Assert.AreEqual<UIntPtr>(inputTooBig.ToUIntPtr(), UIntPtr.Zero);
            string inputmax = long.MaxValue.ToString();
            Assert.AreEqual<UIntPtr>(inputmax.ToUIntPtr(), UIntPtr.Zero);
            string input1 = "1";
            Assert.AreEqual<UIntPtr>(input1.ToUIntPtr(), new UIntPtr(1));
            string input0 = "0";
            Assert.AreEqual<UIntPtr>(input0.ToUIntPtr(), UIntPtr.Zero);
            string inputn1 = "-1";
            Assert.AreEqual<UIntPtr>(inputn1.ToUIntPtr(), UIntPtr.Zero);
        }

        [TestMethod]
        public void UIntPtrTTest()
        {
            object obj = new object();
            Assert.AreEqual<UIntPtr>(obj.ToUIntPtr(), UIntPtr.Zero);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<UIntPtr>(dynObj.ToUIntPtr(), UIntPtr.Zero);
            Action action = () => { };
            Assert.AreEqual<UIntPtr>(action.ToUIntPtr(), UIntPtr.Zero);
        }
    }
}
