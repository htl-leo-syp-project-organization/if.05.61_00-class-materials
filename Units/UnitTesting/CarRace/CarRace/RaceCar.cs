namespace CarRace;

public class RaceCar
{
    private readonly Car _car;
    public RaceCar(Car car)
    {
        _car = car;
    }

    public int Gear
    {
        get => _car.Gear;
        set => _car.Gear = value;
    }

    public int Speed => _car.Speed;
    public Position CurrentPosition => _car.CurrentPosition;

    public void Accelerate()
    {
        _car.Accelerate();
    }

    public void PlaceAtBeginningOf(Track track)
    {
        var startPosition = new Position(track.StartSection, 0);
        _car.CurrentPosition = startPosition;
    }
}