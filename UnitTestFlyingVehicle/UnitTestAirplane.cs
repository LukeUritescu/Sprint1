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
            ///Goal here is to see what occurs what happens when the engine is off. It should not be able to descend
            //Arrange
            ap = new Airplane();
            //Act
            int originalAltitude = ap.CurrentAltitude;
            ap.FlyDown();
            int afterAltitude = ap.CurrentAltitude;


            //Assert
            Assert.AreEqual(0, originalAltitude); //This is to make sure originalAltitude is 0ft
            Assert.AreEqual(afterAltitude, originalAltitude);
        }

        [TestMethod]
        public void TestAirPlaneFlyDownWhileEngineOn()
        {
            //Goal here is to make sure:
            ///1. the plane while the engine is on, won't be able to go lower than 0 feet which is whhat thhe current altitude is.
            ///2. The plane will fly up 1000ft and then descend 1000ft to make sure it descends properly.
            //Arrange
            ap = new Airplane();

            //Act
            int originalAltitude = ap.CurrentAltitude;
            ap.StartEngine();
            ap.TakeOff();
            ap.FlyDown();//by default is 1000ft
            int attemptToFlyDownWhenOnTheGround = ap.CurrentAltitude;
            //now will fly up 1000ft
            ap.FlyUp();
            int flownUpFeet = ap.CurrentAltitude; //use to compare with finalDescent to make sure they aren't equal
            ap.FlyDown();
            int finalDescent = ap.CurrentAltitude; //final descent should be back at 0 ft. and should not equal flownUpFeet

            //Assert
            Assert.AreEqual(1000, flownUpFeet); //This to make sure flyUp hasn't risen up the plane
            Assert.AreEqual(0, originalAltitude); //This is to make sure originalAltitude is 0ft
            Assert.AreEqual(attemptToFlyDownWhenOnTheGround, originalAltitude); //This is to make sure the plane can't go lower than 0 feet which is the originalAltitude
            Assert.AreNotEqual(finalDescent, flownUpFeet); //This is to make sure the plane has gone up and the valuue is not 0ft
            Assert.AreEqual(finalDescent, originalAltitude); //This is to make sure the flyDown method works properly because it was at 1000ft(due to flyUP()), and is not at 0ft

        }

        [TestMethod]
        public void TestAirPlaneFlyUpWhileEngineOff()
        {
            //Arrange
            ap = new Airplane();
            //Act
            int originalAltitude = ap.CurrentAltitude;
            ap.FlyUp();
            int afterAltitude = ap.CurrentAltitude;
            //Assert
            Assert.AreEqual(afterAltitude, originalAltitude); //This is to see if the afterAltitude is equal to the originalAltitude while the engine off
            Assert.AreNotEqual(1000, afterAltitude); //This to make sure flyUp hasn't risen up the plane
            Assert.AreEqual(0, originalAltitude); //This is to make sure originalAltitude is 0ft
        }

        [TestMethod]
        public void TestAirPlaneFlyUpWhileEngineOn()
        {
            //Arrange
            ap = new Airplane();
            //Act
            int originalAltitude = ap.CurrentAltitude;
            ap.StartEngine();
            ap.TakeOff();
            ap.FlyUp();
            int afterFlyingUpDefault = ap.CurrentAltitude;
            ///Attempt To flyy up higher than max altitude
            ap.FlyUp(42000); //this should not work becaause desired altitude is (1,000 + 42,000)43,000 ft which is higher than maxAltitude
            int attemptToFlyUpPastMaxAltitude = ap.CurrentAltitude;
            ap.FlyUp(40000); //this should reachh 41000ft the max altitude
            int reachMaxAltitude = ap.CurrentAltitude; //plane should reach 41,000 ft reaching maxAltitude

            //Assert
            Assert.AreEqual(0, originalAltitude); //To make sure the altitude is 0
            Assert.AreEqual(1000, afterFlyingUpDefault); //To make sure flying up went up precisely 1000ft
            Assert.AreNotEqual(afterFlyingUpDefault, originalAltitude); //to make sure the plane flew up
            ///Attempt To flyy up higher than max altitude
            Assert.AreNotEqual(43000, attemptToFlyUpPastMaxAltitude);
            Assert.AreEqual(attemptToFlyUpPastMaxAltitude, afterFlyingUpDefault); //plane should not have ascended past the defauult flyUp method 
            ///Reaching max Altitude
            Assert.AreEqual(41000, reachMaxAltitude);
            Assert.AreNotEqual(originalAltitude, reachMaxAltitude);
        }

        [TestMethod]
        public void TestAirPlaneGetEngineString()
        {
            //Arrange
            ap = new Airplane();
            //Act
            string originalGetEngineString = ap.getEngineStartedString();
            ap.StartEngine();
            string engineTurnOnEngineString = ap.getEngineStartedString();
            ap.StopEngine();
            string engineTurnOffEngineString = ap.getEngineStartedString();
            //Assert
            Assert.AreEqual(originalGetEngineString, engineTurnOffEngineString);
            Assert.AreEqual("Engine is started", engineTurnOnEngineString);
            Assert.AreEqual("Engine not started", engineTurnOffEngineString);
        }

        [TestMethod]
        public void TestAirPlaneStartEngine()
        {
            //Arrange
            ap = new Airplane();
            //Act
            bool defaultEngineState = ap.Engine.IsStarted;
            ap.StartEngine();
            bool afterEngineStart = ap.Engine.IsStarted;
            //Assert
            Assert.AreEqual(false, defaultEngineState);
            Assert.AreEqual(true, afterEngineStart);
        }

        [TestMethod]
        public void TestAirPlaneStopEngine()
        {
            //Arrange
            ap = new Airplane();
            //Act
            bool defaultEngineState = ap.Engine.IsStarted;
            ap.StartEngine();
            bool testEngineOn = ap.Engine.IsStarted;
            ap.StopEngine();
            bool afterEngineStopped = ap.Engine.IsStarted;
            //Assert
            Assert.AreEqual(false, defaultEngineState);
            Assert.AreEqual(true, testEngineOn);
            Assert.AreEqual(afterEngineStopped, defaultEngineState);
        }

        [TestMethod]
        public void TestAirPlaneTakeOff()
        {
            //Arrange
            ap = new Airplane();
            //Act
            string defaultTakeOffString = ap.TakeOff();
            bool defaultFlyingState = ap.IsFlying;
            ap.StartEngine();
            string afterEngineStart = ap.TakeOff();
            bool afterFlyingState = ap.IsFlying;
            //Assert
            Assert.AreEqual("This engine can't fly until the engine is started", defaultTakeOffString);
            Assert.AreEqual(false, defaultFlyingState);
            Assert.AreEqual("This engine has started", afterEngineStart);
            Assert.AreEqual(true, afterFlyingState);
        }
    }
}
