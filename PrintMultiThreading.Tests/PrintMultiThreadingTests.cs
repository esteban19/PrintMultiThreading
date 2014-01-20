using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintMultiThreading;

namespace PrintMultiThreading.Tests
{
    [TestClass]
    public class PrintMultiThreadingTests
    {
        [TestMethod]
        public void Sum_AddingASequenceOfNumbers_ShouldReturnSummationOfThem()
        {
            Printer p = new Printer();
            int expected = 11;
            int result = p.Sum(10, 1);
            Assert.AreEqual(expected, result);
        }
    }
}
