using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(RaceController))]
public class RaceControllerTest
{

    [TestMethod]
    [Ignore]
    public void ItShouldPlaceCarsAtRaceTrackStart_GivenCarsAreAddedToTheRace()
    {
        var trackComposer = new TrackComposer();
        var sectionInformation = new[]{ (300, 250), (500, 300), (50, 40), (70, 120), (100, 300), (30, 100), (100, 300), (40, 150), (700, 200), (120, 150) };
        trackComposer.ComposeFrom(sectionInformation);
        var track = trackComposer.Track;
        var raceController = new RaceController
        {
            track = track
        };
        
        var carNumber = raceController.AddCar(new Car());
        var position = raceController.GetPosition(carNumber);
        
        Assert.AreEqual(track.StartSection, position.Section);
        Assert.AreEqual(0, position.PositionInSection);
    }


    [TestMethod]
    public void ItShouldMoveTheCar_GivenTheCarDoesKeepSpeedLimits()
    {
        var trackComposer = new TrackComposer();
        var sectionInformation = new[]{ (300, 250), (500, 300), (50, 40), (70, 120), (100, 300), (30, 100), (100, 300), (40, 150), (700, 200), (120, 150) };
        trackComposer.ComposeFrom(sectionInformation);

        var raceController = new RaceController
        {
            track = trackComposer.Track
        };
        
    }
}