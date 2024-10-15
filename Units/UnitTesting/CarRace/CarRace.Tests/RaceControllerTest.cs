using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(RaceController))]
public class RaceControllerTest
{

    [TestMethod]
    public void ItShouldPlaceCarsAtRaceTrackStart_GivenCarsAreAddedToTheRace()
    {
        var trackComposer = new TrackComposer();
        int[,] sectionInformation = { { 300, 250 }, { 500, 300 }, { 50, 40 }, { 70, 120 }, {100, 300}, {30, 100}, {100, 300}, {40, 150}, {700, 200}, {120, 150} };
        trackComposer.AddTracks(sectionInformation);
        
        var raceController = new RaceController
        {
            raceTrackStart = trackComposer.GetSection(0)
        };
        var carNumber = raceController.AddCar(new Car());
        var position = raceController.GetPosition(carNumber);
        Assert.AreEqual(trackComposer.GetSection(0), position.Section);
        Assert.AreEqual(0, position.PositionInSection);
    }


    [TestMethod]
    public void ItShouldMoveTheCar_GivenTheCarDoesKeepSpeedLimits()
    {
        var trackComposer = new TrackComposer();
        int[,] sectionInformation = { { 300, 250 }, { 500, 300 }, { 50, 40 }, { 70, 120 }, {100, 300}, {30, 100}, {100, 300}, {40, 150}, {700, 200}, {120, 150} };
        trackComposer.AddTracks(sectionInformation);

        var raceController = new RaceController
        {
            raceTrackStart = trackComposer.GetSection(0)
        };
        
    }
}