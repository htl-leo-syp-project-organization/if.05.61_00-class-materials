namespace CarRace;

public class Track
{
    public Section? StartSection { get; private set; }
    public int Length { get => StartSection?.Length ?? 0; }

    public void Add(Section section)
    {
        StartSection = section;
    }
}