namespace CarRace;

public class TrackComposer
{
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
}