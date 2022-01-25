namespace Airport.Models;
#nullable disable

public class Flighpass
{
    public int Id { get; set; }
    public Flights Flight { get; set; }
    public Pasenger Pasenger { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime CreatDate { get; set; }

}

