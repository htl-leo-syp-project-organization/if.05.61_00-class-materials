using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(Track))]
public class TrackTest
{

    [TestMethod]
    public void ItShouldHoldTheStartSection_GivenOneTrackIsAdded()
    {
        var track = new Track();

        var someSection = new Section();
        track.Add(someSection);
        
        Assert.AreEqual(someSection, track.StartSection);
    }
}