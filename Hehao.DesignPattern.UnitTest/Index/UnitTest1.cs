using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation.Index;
using Hehao.DesignPattern.Foundation.Iterators;
using System.Collections.Generic;

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

        [TestMethod]
        public void FindData()
        {
            float expected = 65.9f;
            DashBoard dashboard = new DashBoard();
            float actual = dashboard[
                delegate(float data)
                {
                    return data > 63f;
                }
            ];

            Assert.AreEqual<float>(expected, actual);

            expected = 56.7f;
            actual = dashboard[f => f < 63f && f > 56.5f];

            Assert.AreEqual<float>(expected, actual);
        }


        [TestMethod]
        public void CompositeIteratorTest()
        {
            Stack<ObjectWithName> stack = new Stack<ObjectWithName>();
            stack.Push(new ObjectWithName("2"));
            stack.Push(new ObjectWithName("1"));

            Queue<ObjectWithName> queue = new Queue<ObjectWithName>();
            queue.Enqueue(new ObjectWithName("3"));
            queue.Enqueue(new ObjectWithName("4"));

            ObjectWithName[] array = new ObjectWithName[3];
            array[0] = new ObjectWithName("5");
            array[1] = new ObjectWithName("6");
            array[2] = new ObjectWithName("7");

            BinaryTreeNode root = new BinaryTreeNode("8");
            root.Left = new BinaryTreeNode("9");
            root.Right = new BinaryTreeNode("10");
            root.Right.Left = new BinaryTreeNode("11");
            root.Right.Left.Left = new BinaryTreeNode("12");
            root.Right.Left.Right = new BinaryTreeNode("13");
            root.Right.Right = new BinaryTreeNode("14");
            root.Right.Right.Right = new BinaryTreeNode("15");
            root.Right.Right.Right.Right = new BinaryTreeNode("16");

            //合并所有对象
            CompositeIterator iterator = new CompositeIterator();
            iterator.Add(stack);
            iterator.Add(queue);
            iterator.Add(array);
            iterator.Add(root);

            int count = 0;
            foreach(ObjectWithName obj in iterator)
            {
                Assert.AreEqual<String>((++count).ToString(), obj.ToString());
            }


        }
    }
}
