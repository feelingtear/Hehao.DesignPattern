using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation.Attributes;

namespace Hehao.DesignPattern.UnitTest.Attributes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IAttributedBuilder builder = new AttributedBuilder();
            Director director = new Director();
            director.BuildUp(builder);
            Assert.AreEqual<String>("a", builder.Log[0]);
            Assert.AreEqual<string>("b", builder.Log[1]);
            Assert.AreEqual<String>("c", builder.Log[2]);
        }
    }
}
