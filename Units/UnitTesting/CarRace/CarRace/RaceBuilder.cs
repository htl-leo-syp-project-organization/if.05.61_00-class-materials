namespace CarRace;

public class RaceBuilder
{
    private RaceController? _raceController;
    private Track? _track;
    private readonly List<Car> _cars = new List<Car>();
    public Track? Track {
        get => _track;
        set
        {
            // _track = value;
            // if (_cars.Count > 0)
            //     _raceController = new RaceController();
        }
      
    }
    public RaceController? RaceController => _raceController;

    public void AddCar(int number, string color)
    {
        // _cars.Add(new Car(number));
        // if (Track != null)
        //     _raceController = new RaceController();
    }
}