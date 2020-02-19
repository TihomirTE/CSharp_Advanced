using System;
using _01.Defining_Classes_Part_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            string phoneNumber = "0899889988";
            Call call = new Call(duration, time, phoneNumber);

            GSM gsm = new GSM("S7", "Samsung");

            // Act
            gsm.AddCall(call);

            // Assert
            Assert.AreEqual(call, gsm.callHistory[0]);
        }
    }
}
