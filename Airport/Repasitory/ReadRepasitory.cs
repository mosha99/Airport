namespace Airport.Repasitory;
#nullable disable

public class ReadRepasitory : IReadRepasitory
{
    AirplantContext _DataBase;

    public ReadRepasitory(AirplantContext DataBase)
    {
        _DataBase = DataBase;

    }

    public List<Airplans> GetAirplans()
    {
        List<Airplans> List = _DataBase.Airplans
            .Where(x => x.IsDeleted != true)
            .Include(x => x.Flights)
            .AsNoTracking().ToList();
        return List;
    }

    public Airplans GetAirplans(int Id)
    {
        Airplans airplans = _DataBase.Airplans.AsNoTracking().FirstOrDefault(x => x.Id == Id & x.IsDeleted != true);
        return airplans;
    }

    public List<AirPort> GetAirports()
    {
        List<AirPort> airPorts = _DataBase.AirPorts
            .Where(x => x.IsDeleted != true)
            .Include(x => x.OutputFlights).ThenInclude(x => x.Airplan)
            .Include(x => x.InputFlights).ThenInclude(x => x.Airplan)
            .AsNoTracking().ToList();
        return airPorts;
    }

    public AirPort GetAirports(int Id)
    {
        AirPort airPort = _DataBase.AirPorts.AsNoTracking().FirstOrDefault(x => x.Id == Id & x.IsDeleted != true);
        return airPort;
    }

    public List<Flights> GetFlights()
    {
        List<Flights> flights = _DataBase.Flights
            .Where(x => x.IsDeleted != true)
            .Include(x => x.Airplan)
            .Include(x=>x.PasengerList)
            .Include(x => x.StartLocation)
            .Include(x => x.EndLocation)

            .AsNoTracking().ToList();
        return flights;
    }

    public Flights GetFlights(int Id)
    {
        Flights flights = _DataBase.Flights.AsNoTracking().FirstOrDefault(x => x.Id == Id & x.IsDeleted != true);
        return flights;
    }

    public List<Pasenger> GetPasengers()
    {
        List<Pasenger> pasengers = _DataBase.Pasengers.AsNoTracking().Where(x => x.IsDeleted != true).ToList();
        return pasengers;
    }

    public Pasenger GetPasengers(int Id)
    {
        Pasenger pasenger = _DataBase.Pasengers.AsNoTracking().FirstOrDefault(x => x.Id == Id & x.IsDeleted != true);
        return pasenger;
    }

}

