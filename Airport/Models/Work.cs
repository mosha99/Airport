namespace Airport.Models;
#nullable disable

public class Work
{
    public int Pasengerid { get; set; }
    public WorkType TypeOfWork { get; set; }
    public int? FlightsId { get; set; }
    public string ConnectionId { get; set; }
}

public enum WorkType
{
    Add,
    Edit,
    delet,
}