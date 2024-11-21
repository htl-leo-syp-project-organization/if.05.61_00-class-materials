namespace CarRace;

public class RaceCar
{
    private Car _car;
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
    public Position CurrentPosition { get => _car.CurrentPosition; }

    public void Accelerate()
    {
        _car.Accelerate();
    }
}