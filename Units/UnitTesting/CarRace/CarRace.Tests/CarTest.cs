using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(Car))]
public class CarTest
{
    [TestMethod]
    public void ItShouldHaveTheNumberAssignedOnConstruction_GivenConstructed()
    {
        const int someNumber = 15;
        
        var car = new Car(someNumber);
        
        Assert.AreEqual(15, car.Number);
    }
    [TestMethod]
    public void ItShouldHaveNoSpeed_GivenConstructed()
    {
        int someNumber = 8;
        var car = new Car(someNumber);
        Assert.AreEqual(0, car.Speed);
    }

    [TestMethod]
    public void ItShouldHaveAnInitialPosition_GivenConstructed()
    {
        var car = new Car(9);
        
        Assert.IsNull(car.CurrentPosition.Section);
        Assert.AreEqual(0, car.CurrentPosition.PositionInSection);
    }
    
    [TestMethod]
    public void ItShouldBeAtGear0_GivenConstructed()
    {
        int someNumber = 1;
        var car = new Car(someNumber);
        Assert.AreEqual(0, car.Gear);
    }

    [TestMethod]
    public void ItShouldThrowAnException_GivenSelectedGearIsNegative()
    {
        var car = new Car(5);
        
        var exception = Assert.ThrowsException<ArgumentException>(() => car.Gear = -1);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Gear must be between 0 and 6.", exception.Message);
    }

    [TestMethod]
    public void ItShouldThrowAnException_GivenSelectedGearIsGreaterThan6()
    {
        var car = new Car(3);
        
        var exception = Assert.ThrowsException<ArgumentException>(() => car.Gear = 7);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Gear must be between 0 and 6.", exception.Message);
    }
    private class FakeDice: IDice
    {
        public FakeDice(int value) {_dots = value;}

        private readonly int _dots;
        public int Dots { get; private set; }
        
        public bool WasRolled { get; private set; }
        public void Roll()
        {
            WasRolled = true;
            Dots = _dots;
        }
    }
    
    [TestMethod]
    public void ItShouldHaveASpeedOf250_GivenGear5AndDice5()
    {
        var dice = new FakeDice(5);
        var car = new Car(3, dice);
        car.Gear = 5;
        car.Accelerate();
        
        Assert.AreEqual(250, car.Speed);
    }


    [TestMethod]
    public void ItShouldRollTheDice_GivenAccelerateIsCalled()
    {
        var dice = new FakeDice(5);
        var car = new Car(25, dice);
        
        car.Accelerate();

        Assert.IsTrue(dice.WasRolled);
    }

    [TestMethod]
    public void ItShouldProvideACarInfo_GivenCarInfoIsCalled()
    {
        var car = new Car(25);
        var section = new Section(10, 10);
        car.CurrentPosition = new Position(
            section.Locked(), 
            0);
        Assert.AreEqual(car.CurrentPosition.Section, section.Locked());
        Assert.AreEqual(car.CurrentPosition.PositionInSection, 0);
    }
}