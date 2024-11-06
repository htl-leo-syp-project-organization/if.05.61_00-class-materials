namespace CarRace;

public class Track
{
    private Section? _startSection;
    public LockedSection? StartSection => _startSection?.Locked();
    public int Length { get => StartSection?.Length ?? 0; }

    public void Add(Section section)
    {
        _startSection = section;
    }
}