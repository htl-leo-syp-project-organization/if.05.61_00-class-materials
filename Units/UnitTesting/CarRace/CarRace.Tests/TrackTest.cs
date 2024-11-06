using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(Track))]
public class TrackTest
{

    [TestMethod]
    public void ItShouldHoldTheStartSection_GivenOneSectionIsAdded()
    {
        var track = new Track();
        var someSection = new Section();
        
        track.Add(someSection);
        
        Assert.AreEqual(someSection.Locked(), track.StartSection);
    }

    [TestMethod]
    public void ItShouldProvideTheLengthOfTheSection_GivenOneSectionIsAdded()
    {
        var track = new Track();
        var someSection = new Section();
        
        track.Add(someSection);
        
        Assert.AreEqual(someSection.Length, track.Length);
    }

    [TestMethod]
    public void ItShouldProvideTheLengthOfBothSections_GivenTwoSectionsAreAdded()
    {
        var track = new Track();
        var someSection1 = new Section(100, 150);
        var someSection2 = new Section(200, 200);
        
        track.Add(someSection1);
        track.Add(someSection2);
        
        Assert.AreEqual(someSection1.Length + someSection2.Length, track.Length);
    }
}