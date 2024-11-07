namespace CarRace;

public class RaceController
{
    public Track Track { get; set; }

    public int AddCar(Car car)
    {
        return 0;
    }

    public struct Position
    {
        public Position(LockedSection section, int position)
        {
            Section = section;
            PositionInSection = position;
        }
        public LockedSection Section { get; }
        public int PositionInSection { get; }
    }
    
    public Position GetPosition(int carNumber)
    {
        return new Position(Track.StartSection!, 0);
    }
}