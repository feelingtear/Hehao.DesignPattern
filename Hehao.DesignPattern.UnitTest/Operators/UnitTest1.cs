﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hehao.DesignPattern.Foundation.Operators;
using System.Collections.Generic;

namespace Hehao.DesignPattern.UnitTest.Operators
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SeasonTest()
        {
            Season season = new Season();
            Assert.AreEqual<string>(Season.Seasons[0], season);
            season++;
            season++;
            Assert.AreEqual<string>(Season.Seasons[2], season);
        }

        [TestMethod]
        public void ErrorEntityTest()
        {
            ErrorEntity entity = new ErrorEntity();
            entity += "hello";
            entity += 1;
            entity += 2;
            Assert.AreEqual<int>(1, entity.Messages.Count);
            Assert.AreEqual<int>(2, entity.Codes.Count);
        }

        [TestMethod]
        public void AdapteeTest()
        {
            Adaptee adaptee = new Adaptee();
            Target target = adaptee;
            //Assert.AreEqual<int>(adaptee.Code, target.Data);

            List<Target> targets = new List<Target>();
            targets.Add(adaptee);
            targets.Add(adaptee);

            Assert.AreEqual<int>(adaptee.Code, targets[1].Data);
        }
    }
}
