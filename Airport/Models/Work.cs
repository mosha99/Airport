using System.ComponentModel.DataAnnotations;

namespace Airport.Models;
#nullable disable

public class Work
{
    public int Id { get; set; }
    public int Pasengerid { get; set; }
    public WorkType TypeOfWork { get; set; }
    public int? FlightsId { get; set; }
    public string ConnectionId { get; set; }
    public DateTime Date { set; get; }
    public bool Success { get; set; }

    public bool cheack { get; set; }
}

public enum WorkType
{
    Add,
    Edit,
    delet,
}