namespace Airport.Worker;
public class Worker : IWorker
{
    private readonly ILogger<Worker> _logger;
    public bool stop = true;

    protected IQueueRepasitory _queueRepasitory;

    public Worker(/*IWorkerList _WorkerList,*/ ILogger<Worker> logger, IQueueRepasitory queueRepasitory)
    {
        _logger = logger;
        _queueRepasitory = queueRepasitory;
       // WorkerList = _WorkerList;
        WorkerList.OnAdd += new EventHandler(async (sender, e) => await WorkerList_OnAdd(sender, e));
        LW = new List<Work>();
    }
    ///public IWorkerList WorkerList { set; get; }
    public List<Work> LW { get; set; }
    int x = 1;
    public async Task WorkerList_OnAdd(object? sender, EventArgs e)
    {
        Console.WriteLine(x);

        if (sender != null)
        {
            x++;
        }

        if (x == 1001)
        {
            Console.WriteLine("-" + WorkerList.count());
        }
        //if (stop) await StartWork();
    }

    public async Task StartWork()
    {
        if (!stop) return;
        stop = false;
        try
        {
            int d = 0;
            while (true)
            {
                Work w = WorkerList.Next();

                if (w == null)
                {
                    _logger.LogError("w is null");
                    continue;
                }
                LW.RemoveAt(0);
                Console.WriteLine(x);
                x++;
                if (w.TypeOfWork == WorkType.Add)
                {
                    int Id = w.FlightsId ?? 0;
                    int result = await _queueRepasitory.AddPassengerToFlight(w.Pasengerid, Id);
                    _logger.LogInformation(w.ConnectionId + '/' + result + "___ " + "***");
                }

            }
        }
        catch (Exception ex)
        {

            throw;
        }

        stop = true;
    }
}

