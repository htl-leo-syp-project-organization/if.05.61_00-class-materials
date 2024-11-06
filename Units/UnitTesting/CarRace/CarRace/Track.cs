namespace CarRace;

public class Track
{
    public Section? StartSection { get; private set; }
    public void Add(Section section)
    {
        StartSection = section;
    }
}