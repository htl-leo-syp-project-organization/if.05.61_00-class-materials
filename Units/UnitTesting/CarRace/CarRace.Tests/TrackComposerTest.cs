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
    [Ignore]
    public void ItShouldConnectTwoSectionsInACircle_GivenTwoSections()
    {
        var composer = new TrackComposer();
        int[,] sectionInformation = { { 300, 250 }, { 500, 300 } };
        
        composer.AddTracks(sectionInformation);
        var startSection = composer.GetSection(0);
        var endSection = composer.GetSection(1);
        
        Assert.AreEqual(startSection.NextSection, endSection);
        Assert.AreEqual(startSection.PreviousSection, endSection);
        Assert.AreEqual(endSection.NextSection, startSection);
        Assert.AreEqual(endSection.PreviousSection, startSection);
    }


    [TestMethod]
    [Ignore]
    public void ItShouldCreateAllSectionsAndConnectThem_GivenMoreSection()
    {
        var composer = new TrackComposer();
        int[,] sectionInformation = { { 300, 250 }, { 500, 300 }, {50, 40}, {70, 120} };
        
        composer.AddTracks(sectionInformation);
        
        Assert.AreEqual(composer.GetSection(0).NextSection, composer.GetSection(1));
        Assert.AreEqual(composer.GetSection(0).PreviousSection, composer.GetSection(3));
        
        Assert.AreEqual(composer.GetSection(1).NextSection, composer.GetSection(2));
        Assert.AreEqual(composer.GetSection(1).PreviousSection, composer.GetSection(0));
        
        Assert.AreEqual(composer.GetSection(2).NextSection, composer.GetSection(3));
        Assert.AreEqual(composer.GetSection(2).PreviousSection, composer.GetSection(1));
        
        Assert.AreEqual(composer.GetSection(3).NextSection, composer.GetSection(0));
        Assert.AreEqual(composer.GetSection(3).PreviousSection, composer.GetSection(2));
    }
}