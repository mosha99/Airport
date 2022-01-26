using System.IO;

namespace Airport.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    IReadRepasitory _readRepasitory;
    ISimpelWrite _simpelWrite;
    protected Worker.Worker wr;
    IWorkRepository _workerRip;
    public HomeController(
        ILogger<HomeController> logger,
        Worker.Worker worker,
        IReadRepasitory readRepasitory,
        ISimpelWrite simpelWrite,
        IWorkRepository workerRip
        )
    {
        _workerRip = workerRip;
        wr = worker;
        _readRepasitory = readRepasitory;
        _simpelWrite = simpelWrite;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        await _simpelWrite.AddPasenger(new Pasenger() {Name="moein" , IsDeleted=false , UpdateDate=DateTime.Now , CreatDate=DateTime.Now });
        return View();
    }

    public async Task Privacy(int q, int r)
    {
        Work w = new Work() { ConnectionId = "2", FlightsId = q, Pasengerid = r };
        await _workerRip.Add(w);
        //wr.runt();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
