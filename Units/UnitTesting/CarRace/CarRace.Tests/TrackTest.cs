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

        var totalTrackLength = someSection1.Length + someSection2.Length;
        Assert.AreEqual(totalTrackLength, track.Length);
    }

    [TestMethod]
    public void ItShouldConnectFirstAndLastSection_GivenCloseIsCalled()
    {
        var track = new Track();
        var someSection1 = new Section(100, 150);
        var someSection2 = new Section(200, 200);
        var someSection3 = new Section(300, 260);
        track.Add(someSection1);
        track.Add(someSection2);
        track.Add(someSection3);

        track.Close();
        
        var startSection = track.StartSection;
        var secondSection = startSection?.NextSection;
        var thirdSection = secondSection?.NextSection;
        
        Assert.AreEqual(secondSection, startSection?.NextSection);
        Assert.AreEqual(thirdSection, secondSection?.NextSection);
        Assert.AreEqual(startSection, thirdSection?.NextSection);
    }

    [TestMethod]
    public void ItShouldDoNothing_GivenCloseIsCalledOnAnEmptyTrack()
    {
        var track = new Track();
        track.Close();
        Assert.IsNull(track.StartSection);
    }

    [TestMethod]
    public void ItShouldConnectSectionToItself_GivenCloseIsCalledOnAOneSectionTrack()
    {
        var track = new Track();
        track.Add(new Section());
        
        track.Close();
        var section = track.StartSection;
        
        Assert.AreEqual(section, section?.NextSection);
        Assert.AreEqual(section, section?.PreviousSection);
    }

    [TestMethod]
    public void ItShouldProvideACorrectLength_GivenTrackIsClosed()
    {
        var track = new Track();
        var someSection1 = new Section(100, 150);
        var someSection2 = new Section(200, 200);
        var someSection3 = new Section(300, 260);
        track.Add(someSection1);
        track.Add(someSection2);
        track.Add(someSection3);
        
        track.Close();
        var totalTrackLength = someSection1.Length + someSection2.Length + someSection3.Length;
        Assert.AreEqual(totalTrackLength, track.Length);
    }
}