using CarRace;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRace.Tests;

[TestClass]
[TestSubject(typeof(Section))]
public class SectionTest
{

    [TestMethod]
    public void ItShouldHaveADefaultLengthAndMaxSpeed_GivenConstructed()
    {
        var section = new Section();
        Assert.AreEqual(100, section.Length);
        Assert.AreEqual(150, section.MaxSpeed);
    }


    [TestMethod]
    public void ItShouldHaveTheGivenLengthAndMaxSpeed_GivenConstructedWithParameters()
    {
        const int someLength = 50;
        const int someSpeed = 100;
        var section = new Section(someLength, someSpeed);
        
        Assert.AreEqual(someLength, section.Length);
        Assert.AreEqual(someSpeed, section.MaxSpeed);
    }

    [TestMethod]
    public void ItShouldHaveTheGivenLengthAndMaxSpeed_GivenConstructedWithAnArray()
    {
        int[] lengthAndSpeed = new int[] { 800, 120 };

        var section = new Section(lengthAndSpeed);
        
        Assert.AreEqual(lengthAndSpeed[0], section.Length);
        Assert.AreEqual(lengthAndSpeed[1], section.MaxSpeed);
    }

    [TestMethod]
    public void ItShouldKnowItsNextSection_GivenConnectedBeforeAnotherSection()
    {
        var section1 = new Section();
        var section2 = new Section();
        
        section1.ConnectMeBefore(section2); // section 1 - section 2
        Assert.AreEqual(section2, section1.NextSection);
        Assert.AreEqual(section1, section2.PreviousSection);
    }


    [TestMethod]
    public void ItShouldKnowItsPreviousSection_GivenConnectedAfterAnotherSection()
    {
        var section1 = new Section();
        var section2 = new Section();
        
        section1.ConnectMeAfter(section2); // section2 - section1
        Assert.AreEqual(section2, section1.PreviousSection);
        Assert.AreEqual(section1, section2.NextSection);
    }
}