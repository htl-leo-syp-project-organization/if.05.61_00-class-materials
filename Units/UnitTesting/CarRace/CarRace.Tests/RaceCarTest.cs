using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(RaceCar))]
public class RaceCarTest
{

    [TestMethod]
    public void ItShouldPublishPropertyGearFromCar_GivenCarsGearIsChanged()
    {
        var car = new Car(50);
        var raceCar = new RaceCar(car);
        
        car.Gear = 5;
        
        Assert.AreEqual(raceCar.Gear, 5);
    }


    [TestMethod]
    public void ItShouldTakeOverGearToCar_GivenGearIsChanged()
    {
        var car = new Car(50);
        var raceCar = new RaceCar(car);

        raceCar.Gear = 2;
        
        Assert.AreEqual(car.Gear, 2);
    }

    [TestMethod]
    public void ItShouldTakeOverSpeedFromCar_GivenCarIsAccelerated()
    {
        var car = new Car(50);
        var raceCar = new RaceCar(car);
        raceCar.Gear = 3;
        
        car.Accelerate();
        
        Assert.AreEqual(car.Speed, raceCar.Speed);
    }

    [TestMethod]
    public void ItShouldAccelerateCar_GivenAccelerateIsCalled()
    {
        var car = new Car(50);
        var raceCar = new RaceCar(car);
        raceCar.Gear = 1;
        
        raceCar.Accelerate();
        
        Assert.IsTrue(raceCar.Speed > 0);
        Assert.AreEqual(car.Speed, raceCar.Speed);
    }

    [TestMethod]
    public void ItShouldProvideCarsSectionAndPositionLocked()
    {
        var car = new Car(50);
        var section = new Section(100, 30);
        car.CurrentPosition = new Position(section.Locked(), 10);
        var raceCar = new RaceCar(car);
        
        var raceCarsPosition = raceCar.CurrentPosition;
        
        Assert.AreEqual(section.Locked(), raceCarsPosition.Section);
        Assert.AreEqual(10, raceCarsPosition.PositionInSection);
    }
}