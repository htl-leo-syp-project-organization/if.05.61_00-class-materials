namespace CarRace;

public class Car
{
    private readonly IDice _dice;
    private int _gear;

    public Car(int number) : this(number, new DefaultDice())
    {
    }
    public Car(int number, IDice dice)
    {
        Number = number;
        _dice = dice;
    }
    public int Speed { get; private set; }

    public int Gear
    {
        get => _gear;

        set
        {
            if (value is < 0 or > 6) throw new ArgumentException("Gear must be between 0 and 6.");
            _gear = value;
        }
    }

    public int Number { get; private set; }
    
    public Position CurrentPosition { get;  set; }
    
    public void Accelerate()
    {
        _dice.Roll();
        Speed = _dice.Dots * Gear * 10;
    }

    public CarInfo CarInfo()
    {
        return new CarInfo(this);
    }
}

internal class DefaultDice : IDice
{
    readonly Random _random = new Random();
    public int Dots { get; private set; }
    
    public void Roll()
    {
        Dots = _random.Next(6) + 1;
    }
}

public struct Position
{
    public Position(LockedSection section, int positionInSection)
    {
        Section = section;
        PositionInSection = positionInSection;
    }
    public LockedSection Section { get; }
    public int PositionInSection { get; }
}

public readonly struct CarInfo
{
    private readonly Car _car;
    public int Number { get => _car.Number; }
    public Position Position => _car.CurrentPosition;

    public CarInfo(Car car)
    {
        _car = car;
    }
}