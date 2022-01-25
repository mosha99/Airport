namespace Airport.Repasitory;

public interface IReadRepasitory
{
    public List<Pasenger> GetPasengers();
    public Pasenger GetPasengers(int Id);

    public List<Airplans> GetAirplans();
    public Airplans GetAirplans(int Id);

    public List<Flights> GetFlights();
    public Flights GetFlights(int Id);

    public List<AirPort> GetAirports();
    public AirPort GetAirports(int Id);

}

