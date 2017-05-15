using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation;
using System.Collections.Generic;

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
        [TestMethod()]
        public void InvokeListTest()
        {
            string message = string.Empty;
            InvokeList list = new InvokeList();
            list.Invoke();
            Assert.AreEqual<string>("hello,world", list[0] + list[1] + list[2]);
        }

        [TestMethod()]
        public void OverloadableDelegateInvokerTest()
        {
            int result = 10;
            int expected = result;
            OverloadableDelegateInvoker invoker = new OverloadableDelegateInvoker();
            IDictionary<string, int> data = new Dictionary<string, int>();
            invoker.Memo(1, 2, data);

            Assert.AreEqual<int>(1 + 2, data["A"]);
            Assert.AreEqual<int>(1 - 2, data["S"]);
            Assert.AreEqual<int>(1 * 2, data["M"]);
        }

        /// <summary>
        /// 反射方法创建对象，工厂模式
        /// </summary>
        [TestClass()]
        public class RawGenericFactoryTest
        {
            interface IProduct
            {
            }
            class ConcreteProduct:IProduct
            {

            }
            [TestMethod]
            public void Test()
            {
                string typeName = typeof(ConcreteProduct).AssemblyQualifiedName;
                IProduct product = RawGenericFactory.Create<IProduct>(typeName);

                Assert.AreEqual<string>(typeName, product.GetType().AssemblyQualifiedName);
            }
        }
    }
}
