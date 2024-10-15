namespace CarRace;

public class Car
{
    private readonly IDice _dice;
    private int _gear;

    public Car() : this(new DefaultDice())
    {
    }
    public Car(IDice dice)
    {
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

    public void Accellerate()
    {
        _dice.Roll();
        Speed = _dice.Dots * Gear * 10;
    }
}

class DefaultDice : IDice
{
    readonly Random _random = new Random();
    public int Dots { get; private set; }
    
    public void Roll()
    {
        Dots = _random.Next(6) + 1;
    }
}