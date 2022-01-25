namespace Airport.Models;

#nullable disable

public class AirPort
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string CityName { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public ICollection<Flights> InputFlights { get; set; }
    public ICollection<Flights> OutputFlights { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime CreatDate { get; set; }
    public DateTime UpdateDate { get; set; }
}

