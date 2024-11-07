namespace CarRace;

public class TrackComposer
{
    private readonly List<Section> _sections = new List<Section>();
    public Track Track { get; set; } = new Track();

    public void ComposeFrom((int, int)[] sectionInformation, bool closedTrackIsRequired = false)
    {
        AddSectionsToTrack(sectionInformation);
        CloseTrackIf(closedTrackIsRequired);
    }
    private void AddSectionsToTrack((int, int)[] sectionInformation)
    {
        foreach (var section in sectionInformation)
        {
            this.Track.Add(new Section(section));
        }
    }
    private void CloseTrackIf(bool closedTrackIsRequired)
    {
        if (closedTrackIsRequired)
        {
            Track.Close();
        }
    }
    public void AddTracks(int[,] sectionInformation)
    {
        var firstSection = AddFirstSection(sectionInformation);
        AddRemainingSections(sectionInformation, firstSection);
        LinkLastAndFirstSection();
    }

    private Section AddFirstSection(int[,] sectionInformation)
    {
        var firstSection = new Section(sectionInformation[0, 0], sectionInformation[0, 1]);
        firstSection.ConnectMeAfter(firstSection);
        _sections.Add(firstSection);
        return firstSection;
    }

    private void AddRemainingSections(int[,] sectionInformation, Section firstSection)
    {
        var previousSection = firstSection;
        for (var i = 1; i < sectionInformation.GetLength(0); i++)
        {
            previousSection = AddSection(sectionInformation, i, previousSection);
        }
    }

    private Section AddSection(int[,] sectionInformation, int i, Section previousSection)
    {
        var newSection = new Section(sectionInformation[i, 0], sectionInformation[i, 1]);
        newSection.ConnectMeAfter(previousSection);
        _sections.Add(newSection);
        previousSection = newSection;
        return previousSection;
    }
    
    private void LinkLastAndFirstSection()
    {
        var firstSection = _sections.First();
        var lastSection = _sections.Last();
        lastSection.ConnectMeBefore(firstSection);
    }

    public Section GetSection(int i)
    {
        return _sections[i];
    }
}