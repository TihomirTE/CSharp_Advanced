using System;
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
            string phoneNumber = "088835345643";
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
            //Arrange
            Mock<ICall> call = new Mock<ICall>();
            Mock<ICall> call2 = new Mock<ICall>();
            //DateTime dt = DateTime.Now;
            //call.Setup(c => c.Time).Returns(dt);
            //call.Setup(c => c.Duration).Returns(30);
            call.Setup(c => c.PhoneNumber).Returns("08");

            var gsm = new Mock<GSM>();

            //Act
            gsm.Object.AddCall(call2.Object);

            //Assert
            Assert.AreEqual(call2.Object, gsm.Object.callHistory[0]);


        }

        [TestMethod]
        public void CalculateTotalPrice_ShouldCalculateCorrectly()
        {
            var gsm = new Mock<GSM>();
            gsm.Verify(x => x.CalculateTotalPrice());

        }
    }
}
