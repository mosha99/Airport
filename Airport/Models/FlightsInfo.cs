namespace Airport.Models;
#nullable disable

public class FlightsInfo
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public Pasenger pasenger { get; set; }
    public Flights Flight { get; set; }
    public bool ArrivedOnPlane { get; set; }
}

