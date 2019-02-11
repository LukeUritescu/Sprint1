using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP2;
namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class UnitTestAirplane
    {
        Airplane ap;
        [TestMethod]
        public void TestAirPlaneAabout()
        {
            //Arrange
            ap = new Airplane();
            //Act
            string originalAirplaneAboutString = ap.About();
            ap.StartEngine();
            string engineStartAirPlaneString = ap.About();
            ap.StopEngine();
            string engineStopAirPlaneString = ap.About();
            //Assert
            Assert.AreEqual(originalAirplaneAboutString, engineStopAirPlaneString);
            Assert.AreNotEqual(originalAirplaneAboutString, engineStartAirPlaneString);
        }

        [TestMethod]
        public void TestAirPlaneConstructor()
        {
            //Arrange
            ap = new Airplane();
            //Act
            //Assert
            Assert.AreEqual(0, ap.CurrentAltitude);
            Assert.AreEqual(41000, ap.MaxAltitude);
            Assert.AreEqual(false, ap.IsFlying);
        }

        [TestMethod]
        public void TestAirPlaneFlyDownWhileEngineOff()
        {

        }

        [TestMethod]
        public void TestAirPlaneFlyDownWhileEngineOn()
        {

        }

        [TestMethod]
        public void TestAirPlaneFlyUpWhileEngineOff()
        {

        }

        [TestMethod]
        public void TestAirPlaneFlyUpWhileEngineOn()
        {

        }

        [TestMethod]
        public void TestAirPlaneGetEngineString()
        {

        }

        [TestMethod]
        public void TestAirPlaneStartEngine()
        {

        }

        [TestMethod]
        public void TestAirPlaneStopEngine()
        {

        }

        [TestMethod]
        public void TestAirPlaneTakeOff()
        {

        }
    }
}
