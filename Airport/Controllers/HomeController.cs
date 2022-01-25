using System.IO;

namespace Airport.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    IReadRepasitory _readRepasitory;
    ISimpelWrite _simpelWrite;
    protected IWorker wr;
    protected IWorkerList wrl;
    public HomeController(
        ILogger<HomeController> logger,
        //IWorkerList workerList,
        IWorker worker,
        IReadRepasitory readRepasitory,
        ISimpelWrite simpelWrite
        )
    {
        //wrl = workerList;
        wr = worker;
        _readRepasitory = readRepasitory;
        _simpelWrite = simpelWrite;

        _logger = logger;
    }

    public int Index()
    {
        return WorkerList.works.Count();
    }

    public async Task Privacy( int q,int r)
    {
        Work w = new Work() {ConnectionId="2" ,FlightsId =q , Pasengerid = r };
        //wrl.works.Add(w);
        WorkerList.works.Add(w);
        Console.WriteLine(WorkerList.works.Count());
       // int x =  wrl.AddWork(w);
       // Console.WriteLine(x);
       // return x;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
