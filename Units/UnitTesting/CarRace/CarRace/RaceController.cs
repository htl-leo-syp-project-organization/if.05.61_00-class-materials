namespace CarRace;

public enum RaceStatusSortOrder {Number, Rank}

public class RaceController
{
    private readonly Car[] _cars;
    public RaceController(Track track, Car[] cars)
    {
        _cars = cars;
        Track = track;
//        _cars.Select(car => car.CurrentPosition.Section = Track.StartSection);
    }
    public Track Track { get; }

    public CarInfo[] RaceStatusSortedBy(RaceStatusSortOrder sortOrder)
    {
        return _cars.Select(car => car.CarInfo()).ToArray();
    }
}