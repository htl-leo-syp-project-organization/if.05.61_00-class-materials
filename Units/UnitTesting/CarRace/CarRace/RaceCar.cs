namespace CarRace;

public class RaceCar
{
    private readonly Car _car;
    public RaceCar(Car car)
    {
        _car = car;
    }

    public int Number => _car.Number;
    public int Gear
    {
        get => _car.Gear;
        set => _car.Gear = value;
    }

    public int Speed => _car.Speed;
    public Car.Position CurrentPosition => _car.CurrentPosition;
    public RaceCarInfo RaceCarInfo => new RaceCarInfo(this);

    public void Accelerate()
    {
        _car.Accelerate();
    }

    public void PlaceAtBeginningOf(Track track)
    {
        var startPosition = new Car.Position(track.StartSection, 0);
        _car.CurrentPosition = startPosition;
    }
}

public readonly struct RaceCarInfo
{
    private readonly RaceCar _car;
    public RaceCarInfo(RaceCar car)
    {
        _car = car;
    }
    
    public int Number => _car.Number;
    public Car.Position Position => _car.CurrentPosition;
}