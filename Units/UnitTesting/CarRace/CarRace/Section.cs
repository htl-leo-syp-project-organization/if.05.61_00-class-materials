namespace CarRace;

public class Section
{
    public int Length { get; set; } = 10;
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
    public Section(int length, int maxSpeed) { Length = length; MaxSpeed = maxSpeed; }

    public void ConnectAfter(Section previousSection)
    {
        PreviousSection = previousSection;
        previousSection.NextSection = this;
    }

    public void ConnectBefore(Section nextSection)
    {
        NextSection = nextSection;
        nextSection.PreviousSection = this;
    }
}