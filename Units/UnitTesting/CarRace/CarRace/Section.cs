namespace CarRace;

public class Section
{
    /// <summary>
    /// The length of the section in meters
    /// </summary>
    public int Length { get; set; } = 100;
    
    /// <summary>
    /// The maximum speed possible for the section in km/h
    /// </summary>
    public int MaxSpeed { get; set; } = 150;
    public Section? NextSection { get; private set; }
    public Section? PreviousSection { get; private set; }

    public Section()
    {
        
    }
    public Section(int[] lengthAndSpeed)
    {
        Length = lengthAndSpeed[0];
        MaxSpeed = lengthAndSpeed[1];
    }

    public Section((int, int) sectionInformation)
    :this(sectionInformation.Item1, sectionInformation.Item2)
    {
    }
    public Section(int length, int maxSpeed) { Length = length; MaxSpeed = maxSpeed; }

    public void ConnectMeAfter(Section previousSection)
    {
        PreviousSection = previousSection;
        NextSection = previousSection.NextSection;
        previousSection.NextSection = this;
        if (NextSection != null)
            NextSection.PreviousSection = this;
    }

    public void ConnectMeBefore(Section nextSection)
    {
        NextSection = nextSection;
        PreviousSection = nextSection.PreviousSection;
        nextSection.PreviousSection = this;
        if (PreviousSection != null)
            PreviousSection.NextSection = this;
    }

    public LockedSection Locked()
    {
        return new LockedSection(this);
    }
}

public record LockedSection(Section Section)
{
    public int Length => Section.Length;
    public int MaxSpeed => Section.MaxSpeed;
    public LockedSection? NextSection => Section.NextSection?.Locked();
    public LockedSection? PreviousSection => Section.PreviousSection?.Locked();
}

