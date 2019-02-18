using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP2;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class UnitTestToyPlane
    {
        ToyPlane tp;
        [TestMethod]
        public void TestToyPlaneAabout()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            string originalToyplaneAboutString = tp.About();
            tp.WindUp();
            tp.StartEngine();
            string engineStartToyPlaneString = tp.About();
            tp.StopEngine();
            tp.UnWind();
            string engineStopToyPlaneString = tp.About();
            //Assert
            Assert.AreEqual(originalToyplaneAboutString, engineStopToyPlaneString);
            Assert.AreNotEqual(originalToyplaneAboutString, engineStartToyPlaneString);
        }

        [TestMethod]
        public void TestAirPlaneConstructor()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            //Assert
            Assert.AreEqual(0, tp.CurrentAltitude);
            Assert.AreEqual(50, tp.MaxAltitude);
            Assert.AreEqual(false, tp.IsFlying);
            Assert.AreEqual(false, tp.IsWoundUp);
        }

        [TestMethod]
        public void TestAirPlaneFlyDownWhileEngineOff()
        {
            ///Goal here is to see what occurs what htppens when the engine is off. It should not be able to descend
            //Arrange
            tp = new ToyPlane();
            //Act
            int originalAltitude = tp.CurrentAltitude;
            tp.FlyDown();
            int afterAltitude = tp.CurrentAltitude;


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
            tp = new ToyPlane();

            //Act
            int originalAltitude = tp.CurrentAltitude;
            tp.WindUp();
            tp.StartEngine();
            tp.TakeOff();
            tp.FlyDown(50);//by default is 1000ft
            int attemptToFlyDownWhenOnTheGround = tp.CurrentAltitude;
            //now will fly up 50ft
            tp.FlyUp(50);
            int flownUpFeet = tp.CurrentAltitude; //use to compare with finalDescent to make sure they aren't equal
            tp.FlyDown(50);
            int finalDescent = tp.CurrentAltitude; //final descent should be back at 0 ft. and should not equal flownUpFeet

            //Assert
            Assert.AreEqual(50, flownUpFeet); //This to make sure flyUp hasn't risen up the plane
            Assert.AreEqual(0, originalAltitude); //This is to make sure originalAltitude is 0ft
            Assert.AreEqual(attemptToFlyDownWhenOnTheGround, originalAltitude); //This is to make sure the plane can't go lower than 0 feet which is the originalAltitude
            Assert.AreNotEqual(finalDescent, flownUpFeet); //This is to make sure the plane has gone up and the valuue is not 0ft
            Assert.AreEqual(finalDescent, originalAltitude); //This is to make sure the flyDown method works properly because it was at 1000ft(due to flyUP()), and is not at 0ft

        }

        [TestMethod]
        public void TestAirPlaneFlyUpWhileEngineOff()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            int originalAltitude = tp.CurrentAltitude;
            tp.FlyUp();
            int afterAltitude = tp.CurrentAltitude;
            //Assert
            Assert.AreEqual(afterAltitude, originalAltitude); //This is to see if the afterAltitude is equal to the originalAltitude while the engine off
            Assert.AreNotEqual(50, afterAltitude); //This to make sure flyUp hasn't risen up the plane
            Assert.AreEqual(0, originalAltitude); //This is to make sure originalAltitude is 0ft
        }

        [TestMethod]
        public void TestAirPlaneFlyUpWhileEngineOn()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            int originalAltitude = tp.CurrentAltitude;
            tp.WindUp();
            tp.StartEngine();
            tp.TakeOff();
            tp.FlyUp(10);
            int afterFlyingUpDefault = tp.CurrentAltitude;
            ///Attempt To flyy up higher than max altitude
            tp.FlyUp(42); //this should not work becaause desired altitude is (40 + 42)82 ft which is higher than maxAltitude
            int attemptToFlyUpPastMaxAltitude = tp.CurrentAltitude;
            tp.FlyUp(40); //this should reachh 41000ft the max altitude
            int reachMaxAltitude = tp.CurrentAltitude; //plane should reach 50 ft reaching maxAltitude

            //Assert
            Assert.AreEqual(0, originalAltitude); //To make sure the altitude is 0
            Assert.AreEqual(10, afterFlyingUpDefault); //To make sure flying up went up precisely 1000ft
            Assert.AreNotEqual(afterFlyingUpDefault, originalAltitude); //to make sure the plane flew up
            ///Attempt To flyy up higher than max altitude
            Assert.AreNotEqual(83, attemptToFlyUpPastMaxAltitude);
            Assert.AreEqual(attemptToFlyUpPastMaxAltitude, afterFlyingUpDefault); //plane should not have ascended past the defauult flyUp method 
            ///Reaching max Altitude
            Assert.AreEqual(50, reachMaxAltitude);
            Assert.AreNotEqual(originalAltitude, reachMaxAltitude);
        }

        [TestMethod]
        public void TestAirPlaneGetEngineString()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            string originalGetEngineString = tp.getEngineStartedString();
            tp.WindUp();
            tp.StartEngine();
            string engineTurnOnEngineString = tp.getEngineStartedString();
            tp.StopEngine();
            tp.UnWind();
            string engineTurnOffEngineString = tp.getEngineStartedString();
            //Assert
            Assert.AreEqual(originalGetEngineString, engineTurnOffEngineString);
            Assert.AreEqual("Engine is started", engineTurnOnEngineString);
            Assert.AreEqual("Engine not started", engineTurnOffEngineString);
        }

        [TestMethod]
        public void TestAirPlaneStartEngine()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            bool defaultEngineState = tp.Engine.IsStarted;
            tp.WindUp();
            tp.StartEngine();
            bool afterEngineStart = tp.Engine.IsStarted;
            //Assert
            Assert.AreEqual(false, defaultEngineState);
            Assert.AreEqual(true, afterEngineStart);
        }

        [TestMethod]
        public void TestAirPlaneStopEngine()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            bool defaultEngineState = tp.Engine.IsStarted;
            tp.WindUp();
            tp.StartEngine();
            bool testEngineOn = tp.Engine.IsStarted;
            tp.StopEngine();
            tp.UnWind();
            bool afterEngineStopped = tp.Engine.IsStarted;
            //Assert
            Assert.AreEqual(false, defaultEngineState);
            Assert.AreEqual(true, testEngineOn);
            Assert.AreEqual(afterEngineStopped, defaultEngineState);
        }

        [TestMethod]
        public void TestAirPlaneTakeOff()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            string defaultTakeOffString = tp.TakeOff();
            bool defaultFlyingState = tp.IsFlying;
            tp.WindUp();
            tp.StartEngine();
            string afterEngineStart = tp.TakeOff();
            bool afterFlyingState = tp.IsFlying;
            //Assert
            Assert.AreEqual("This engine can't fly until the engine is started", defaultTakeOffString);
            Assert.AreEqual(false, defaultFlyingState);
            Assert.AreEqual("This engine has started", afterEngineStart);
            Assert.AreEqual(true, afterFlyingState);
        }

        [TestMethod]
        public void TestToyPlaneWindUP()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            bool defaultWindUpState = tp.IsWoundUp;
            tp.WindUp();
            bool afterWindUPMethod = tp.IsWoundUp;
            //Assert
            Assert.AreEqual(false, defaultWindUpState);
            Assert.AreEqual(true, afterWindUPMethod);

        }

        [TestMethod]
        public void TestToyPlaneUnwind()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            bool defaultWindUpState = tp.IsWoundUp;
            tp.WindUp();
            bool afterWindUPMethod = tp.IsWoundUp;
            tp.UnWind();
            bool afterWindDown = tp.IsWoundUp;
            //Assert
            Assert.AreEqual(false, defaultWindUpState);
            Assert.AreEqual(true, afterWindUPMethod);
            Assert.AreEqual(afterWindDown, defaultWindUpState);

        }

        [TestMethod]
        public void TestToyPlaneGetWindUpString()
        {
            //Arrange
            tp = new ToyPlane();
            //Act
            string defaultToyPlaneWindUpString = tp.GetWindUpString();
            tp.WindUp();
            string afterWindUpString = tp.GetWindUpString();
            //Assert
            Assert.AreEqual("ToyPlane is wound up", afterWindUpString);
            Assert.AreEqual("ToyPlane not wound up", defaultToyPlaneWindUpString);

        }
    }
}

