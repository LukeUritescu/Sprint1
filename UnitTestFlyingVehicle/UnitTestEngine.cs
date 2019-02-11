using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP2;
namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class UnitTestEngine
    {
        Engine e;
        [TestMethod]
        public void TestEngineStartingAndStopping()
        {
            //Arrange
            e = new Engine();
            //Act
            bool originalEngineState = e.IsStarted;
            e.Start();
            bool EngineStateOn = e.IsStarted;
            e.Stop();
            bool EngineStateOff = e.IsStarted;
            //Assert
            Assert.AreEqual(EngineStateOn, true);
            Assert.AreEqual(originalEngineState, false);
            Assert.AreEqual(EngineStateOff, false);
        }

        [TestMethod]
        public void TestEngineAbout()
        {
            //Arrange
            e = new Engine();
            //Act
            string originalEngineStateString = e.About();
            e.Start();    
            string EngineStateOnString = e.About();
            e.Stop();
            string EngineStateOffString = e.About();
            //Assert
            Assert.AreNotEqual(EngineStateOnString, originalEngineStateString);
            Assert.AreEqual(EngineStateOffString, originalEngineStateString);
        }
       


    }
}
