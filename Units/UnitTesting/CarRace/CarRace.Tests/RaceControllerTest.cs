using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(RaceController))]
public class RaceControllerTest
{
    private RaceController _raceController;

    [TestInitialize]
    public void Setup()
    {
        var track = ComposeTrack();
        var cars = CreateRaceCars();
        _raceController = new RaceController(track, cars);
    }

    private static Track ComposeTrack()
    {
        var trackComposer = new TrackComposer();
        var sectionInformation = new[]{ (300, 250), (500, 300), (50, 40), (70, 120), (100, 300), (30, 100), (100, 300), (40, 150), (700, 200), (120, 150) };
        trackComposer.ComposeFrom(sectionInformation);
        return trackComposer.Track;
    }

    private static RaceCar[] CreateRaceCars()
    {
        const int numberOfCars = 10;
        var cars = new RaceCar[numberOfCars];
        for (var i = 0; i < 10; i++)
        {
            var newCar = new Car(i + 1);
            cars[i] = new RaceCar(newCar);
        }

        return cars;
    }
    
    [TestMethod]
    public void ItShouldPlaceCarsAtRaceTrackStart_GivenConstructed()
    {
        var raceStatus = _raceController.RaceStatusSortedBy(RaceStatusSortOrder.Rank);
        var trackStartSection = _raceController.Track.StartSection;
        var firstCarPosition = raceStatus[0].Position;
        Assert.AreEqual(trackStartSection, firstCarPosition.Section);
        Assert.AreEqual(0, firstCarPosition.PositionInSection);
    }


    [TestMethod]
    [Ignore]
    public void ItShouldMoveTheCar_GivenTheCarDoesKeepSpeedLimits()
    {
        
    }
}