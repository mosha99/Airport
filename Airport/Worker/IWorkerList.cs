namespace Airport.Worker;

public interface IWorkerList
{
    public IList<Work> works { get; set; }
    public Work Next();
    public int count();

    public event EventHandler OnAdd;
    public int AddWork(Work work);
}

