namespace Airport.Worker;

public interface IWorker
{
    //protected IWorkerList WorkerList { set; get; }
    protected Task WorkerList_OnAdd(object? sender, EventArgs e);
    public Task StartWork();
}

