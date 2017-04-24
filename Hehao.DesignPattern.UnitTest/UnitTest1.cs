using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation;

namespace Hehao.DesignPattern.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AsyncInvoker asyncInvoke = new AsyncInvoker();
            System.Threading.Thread.Sleep(3000);

            Assert.AreEqual<string>("method", asyncInvoke.Ouput[0]);
            Assert.AreEqual<string>("fast", asyncInvoke.Ouput[1]);
            Assert.AreEqual<string>("slow", asyncInvoke.Ouput[2]);
        }
    }
}
