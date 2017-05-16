using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation.Index;

namespace Hehao.DesignPattern.UnitTest.Index
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSingleCollection()
        {
            SingleColumnCollection c = new SingleColumnCollection();

            Assert.AreEqual<string>("china", c[0]);
            Assert.AreEqual<int>(2, c["ch"].Length);
            Assert.AreEqual<string>("china", c["ch"][0]);
        }

        [TestMethod]
        public void TestMutiCollection()
        {
            Assert.AreEqual("joe", MutiColumnCollection.Data.Tables[0].Rows[0]["name"]);
            Assert.AreEqual("female", MutiColumnCollection.Data.Tables[0].Rows[1][1]);
        }

        [TestMethod]
        public void FindStaff()
        {
            Staff staff = new Staff();
            Employee employee = staff["John", "Doe"];
            string expected = "Vice President";
            Assert.AreEqual<String>(expected, employee.Title);
        }
    }
}
