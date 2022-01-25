namespace Airport.Models;

#nullable disable

public class Pasenger
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Flighpass> Flights { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatDate { get; set; }
    public DateTime UpdateDate { get; set; }
}

