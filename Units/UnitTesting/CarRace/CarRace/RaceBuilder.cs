namespace CarRace;

public class RaceBuilder
{
    private Track? _track;
    private readonly List<RaceCar> _cars = new List<RaceCar>();
    public Track? Track {
        set => _track = value;
    }
    public RaceController? RaceController 
    {
        get
        {
            RaceController? raceController = null;
            if (_track != null && _cars.Count > 0)
            {
                raceController = new RaceController(_track, _cars.ToArray());
            }
            return raceController;
        }
    }

    public void AddCar(int number, string color)
    {
        var newCar = new Car(number);
        _cars.Add(new RaceCar(newCar));
    }
}