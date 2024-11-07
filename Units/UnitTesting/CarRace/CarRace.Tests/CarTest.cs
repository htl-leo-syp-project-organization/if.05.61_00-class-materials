using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(Car))]
public class CarTest
{

    [TestMethod]
    public void ItShouldHaveNoSpeed_GivenConstructed()
    {
        var car = new Car();
        Assert.AreEqual(0, car.Speed);
    }


    [TestMethod]
    public void ItShouldBeAtGear0_GivenConstructed()
    {
        var car = new Car();
        Assert.AreEqual(0, car.Gear);
    }

    [TestMethod]
    public void ItShouldThrowAnException_GivenSelectedGearIsNegative()
    {
        var car = new Car();
        
        var exception = Assert.ThrowsException<ArgumentException>(() => car.Gear = -1);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Gear must be between 0 and 6.", exception.Message);
    }

    [TestMethod]
    public void ItShouldThrowAnException_GivenSelectedGearIsGreaterThan6()
    {
        var car = new Car();
        
        var exception = Assert.ThrowsException<ArgumentException>(() => car.Gear = 7);
        Assert.IsNotNull(exception);
        Assert.AreEqual("Gear must be between 0 and 6.", exception.Message);
    }
    private class FakeDice: IDice
    {
        public FakeDice(int value) {_dots = value;}

        private int _dots;
        public int Dots { get; private set; }
        
        public bool WasRolled { get; private set; } = false;
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
        var car = new Car(dice);
        car.Gear = 5;
        car.Accelerate();
        
        Assert.AreEqual(250, car.Speed);
    }


    [TestMethod]
    public void ItShouldRollTheDice_GivenAccelerateIsCalled()
    {
        var dice = new FakeDice(5);
        var car = new Car(dice);
        
        car.Accelerate();

        Assert.IsTrue(dice.WasRolled);
    }
}