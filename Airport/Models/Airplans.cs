namespace Airport.Models;

#nullable disable

public class Airplans
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public ICollection<Flights> Flights { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatDate { get; set; }
    public DateTime UpdateDate { get; set; }

}

