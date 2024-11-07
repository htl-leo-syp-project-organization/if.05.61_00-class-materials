using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(TrackComposer))]
public class TrackComposerTest
{

    [TestMethod]
    public void ItShouldCreateASection_GivenOneSectionsLengthAndSpeedAsArray()
    {
        var composer = new TrackComposer();
        var sectionInformation = new[] { (300, 250) };
        
        composer.ComposeFrom(sectionInformation);
        var track = composer.Track;

        Assert.AreEqual(sectionInformation[0].Item1, track.StartSection?.Length);
        Assert.AreEqual(sectionInformation[0].Item2, track.StartSection?.MaxSpeed);
    }
    
    [TestMethod]
    public void ItShouldCreateTwoSections_GivenTwoSectionLengthsAndSpeedsAsArray()
    {
        var composer = new TrackComposer();
        var sectionInformation = new[]{ (300, 250), (500, 300) };
        
        composer.ComposeFrom(sectionInformation);
        var track = composer.Track;
        var section1 = track.StartSection;
        var section2 = section1?.NextSection;
        
        Assert.AreEqual(sectionInformation[0].Item1, section1?.Length);
        Assert.AreEqual(sectionInformation[0].Item2, section1?.MaxSpeed);
        
        Assert.AreEqual(sectionInformation[1].Item1, section2?.Length);
        Assert.AreEqual(sectionInformation[1].Item2, section2?.MaxSpeed);
    }

    [TestMethod]
    public void ItShouldLeaveTheTrackOpen_GivenNoCloseIsRequired()
    {
        
        var composer = new TrackComposer();
        var sectionInformation = new[] { (300, 250), (500, 300), (50, 100), (800, 360) };
        
        composer.ComposeFrom(sectionInformation);
        var lastSection = composer.Track.StartSection?.NextSection?.NextSection?.NextSection;
        
        Assert.IsNull(composer.Track.StartSection!.PreviousSection);
        Assert.IsNull(lastSection?.NextSection);
    }
    
    [TestMethod]
    public void ItShouldConnectFirstAndLastSection_GivenCloseIsRequired()
    {
        var composer = new TrackComposer();
        var sectionInformation = new[] { (300, 250), (500, 300) };
        
        composer.ComposeFrom(sectionInformation, true);
        var startSection = composer.Track.StartSection;
        var endSection = startSection?.NextSection;
        
        Assert.AreEqual(startSection?.PreviousSection, endSection);
        Assert.AreEqual(endSection?.NextSection, startSection);
    }
}