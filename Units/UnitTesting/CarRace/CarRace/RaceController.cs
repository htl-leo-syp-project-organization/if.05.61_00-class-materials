namespace CarRace;

public enum RaceStatusSortOrder {Number, Rank}

public class RaceController
{
    private readonly RaceCar[] _cars;
    public RaceController(Track track, RaceCar[] cars)
    {
        _cars = cars;
        Track = track;
        foreach (var car in _cars)
        {
            car.PlaceAtBeginningOf(Track);
        }
    }
    public Track Track { get; }

    public RaceCarInfo[] RaceStatusSortedBy(RaceStatusSortOrder sortOrder)
    {
        return _cars.Select(car => car.RaceCarInfo).ToArray();
    }
}