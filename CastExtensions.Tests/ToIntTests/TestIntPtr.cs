using System;
using CastExtensions.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastExtensions.Tests.ToIntTests
{
    [TestClass]
    public class TestIntPtr
    {
        [TestMethod]
        public void IntPtrStringTest()
        {
            string inputTooBig = ((ulong)long.MaxValue + (ulong)1).ToString();
            Assert.AreEqual<IntPtr>(inputTooBig.ToIntPtr(), IntPtr.Zero);
            string inputmax = long.MaxValue.ToString();
            Assert.AreEqual<IntPtr>(inputmax.ToIntPtr(), IntPtr.Zero);
            string input1 = "1";
            Assert.AreEqual<IntPtr>(input1.ToIntPtr(), new IntPtr(1));
            string input0 = "0";
            Assert.AreEqual<IntPtr>(input0.ToIntPtr(), IntPtr.Zero);
            string inputn1 = "-1";
            Assert.AreEqual<IntPtr>(inputn1.ToIntPtr(), new IntPtr(-1));
            string inputmin = long.MinValue.ToString();
            Assert.AreEqual<IntPtr>(inputmin.ToIntPtr(), IntPtr.Zero);
            string inputTooSmall = long.MinValue.ToString().Substring(0, long.MinValue.ToString().Length - 1) + "9"; // have to do something special here.
            Assert.AreEqual<IntPtr>(inputTooSmall.ToIntPtr(), IntPtr.Zero);
        }

        [TestMethod]
        public void IntPtrTTest()
        {
            object obj = new object();
            Assert.AreEqual<IntPtr>(obj.ToIntPtr(), IntPtr.Zero);
            object dynObj = new { Param1 = "test", Param2 = 1, Param3 = new object() };
            Assert.AreEqual<IntPtr>(dynObj.ToIntPtr(), IntPtr.Zero);
            Action action = () => { };
            Assert.AreEqual<IntPtr>(action.ToIntPtr(), IntPtr.Zero);
        }
    }
}
