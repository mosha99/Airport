namespace Airport.Models;

#nullable disable

public class Flights
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public AirPort StartLocation { get; set; }
    public AirPort EndLocation { get; set; }
    [MaxLength]
    public string Discription { get; set; }
    public Airplans Airplan { get; set; }
    public ICollection<Flighpass> PasengerList { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatDate { get; set; }
    public DateTime UpdateDate { get; set; }
}

