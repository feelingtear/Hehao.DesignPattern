using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation.Iterators;

namespace Hehao.DesignPattern.UnitTest.Iterators
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RawIterator()
        {
            int count = 0;
            RawIterator iterator = new RawIterator();
            foreach (int item in iterator)
            {
                Assert.AreEqual<int>(count++, item);
            }

            count = 1;
            foreach(int item in iterator.GetRange(1,3))
            {
                Assert.AreEqual<int>(count++, item);
            }

            string[] data = new string[] { "hello","world","!"};
            count = 0;
            foreach (string item in iterator.Greeting)
            {
                Assert.AreEqual<string>(data[count++], item);
            }

        }
    }
}
