namespace CarRace;

public class RaceController
{
    public Section raceTrackStart { get; set; }

    public int AddCar(Car car)
    {
        return 0;
    }

    public struct Position
    {
        public Position(Section section, int position)
        {
            Section = section;
            PositionInSection = position;
        }
        public Section Section { get; }
        public int PositionInSection { get; }
    }
    
    public Position GetPosition(int carNumber)
    {
        return new Position(raceTrackStart, 0);
    }
}