namespace CarRace;

public class Track
{
    private Section? _startSection;
    private Section? _endSection;
    public LockedSection? StartSection => _startSection?.Locked();

    public int Length
    {
        get
        {
            var currentSection = _startSection;
            var length = 0;
            while (currentSection != null && currentSection != _endSection)
            {
                length += currentSection.Length;
                currentSection = currentSection.NextSection;
            }
            return length + _endSection?.Length ?? 0;
        }
    }
    
    public void Add(Section section)
    {
        if (_startSection == null)
        {
            _startSection = section;
        }
        else
        {
            section.ConnectMeAfter(_endSection!);
        }

        _endSection = section;
    }

    public void Close()
    {
        if (_startSection != null) _endSection?.ConnectMeBefore(_startSection);
    }
}