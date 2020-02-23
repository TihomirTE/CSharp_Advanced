using System;
using System.Collections.Generic;
using _01.Defining_Classes_Part_1;
using _01.Defining_Classes_Part_1.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gsm.Tests
{
    [TestClass]
    public class GsmTests
    {
        [TestMethod]
        public void AddCall_ShouldAddCorrectCall()
        {
            // Arrange
            long duration = 20;
            DateTime time = DateTime.Now;
            string phoneNumber = "088888888";
            Call call = new Call(duration, time, phoneNumber);

            GSM gsm = new GSM("S7", "Samsung");

            // Act
            gsm.AddCall(call);

            // Assert
            Assert.AreEqual(call, gsm.callHistory[0]);
        }

        [TestMethod]
        public void AddCall_ShouldAddCorrectCallUsingMoq()
        {
            // Arrange
            Mock<ICall> call = new Mock<ICall>();
            Mock<ICall> call2 = new Mock<ICall>();
            // DateTime dt = DateTime.Now;
            //call.Setup(c => c.Time).Returns(dt);
            //call.Setup(c => c.Duration).Returns(30);
            call.Setup(c => c.PhoneNumber).Returns("089");

            var gsm = new Mock<GSM>();

            // Act
            gsm.Object.AddCall(call.Object);

            // Assert
            Assert.AreEqual(call.Object, gsm.Object.callHistory[0]);
        }

        [TestMethod]
        public void CalculateTotalPrice_ShouldCallDurationOnce()
        {
            // Arrange
            var call = new Mock<ICall>();
            call.Setup(c => c.Duration).Returns(180);
            var gsm = new Mock<GSM>();
            //var gsm = new GSM();
            gsm.Object.callHistory.Add(call.Object);
            double? expectedResult = 1.11;

            // Act
            double? gsmResult = gsm.Object.CalculateTotalPrice();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), gsmResult.ToString());
        }
    }
}
