

using Microsoft.AspNetCore.Identity;

namespace Airport.Worker;
public class Worker// : IWorker
{

    public bool stop = true;

    
    IServiceProvider serviceProvider;
    public Worker(IServiceProvider _serviceProvider)
    {
        serviceProvider = _serviceProvider;
        Worker_OnAdd += new EventHandler(async (sender, e) => await WorkerList_OnAdd(sender, e));
        LW = new List<Work>();
    }

    public static event EventHandler Worker_OnAdd;
    public void runt()
    {
        Worker_OnAdd.Invoke(null, EventArgs.Empty);
    }

    public List<Work> LW { get; set; }
    int x = 1;
    public async Task WorkerList_OnAdd(object? sender, EventArgs e)
    {
        if (stop) await StartWork();
    }

    public async Task StartWork()
    {
        var context = serviceProvider.GetRequiredService<AirplantContext>();
        var _workerRip = new WorksetRepository();
        var _queueRepasitory = new QueueRepasitory(context);

        if (!stop) return;
        stop = false;
        try
        {
            int d = 0;

            var Listw = await _workerRip.Next(context);

            while (true)
            {
                foreach (var w in Listw)
                {
                    if (w.TypeOfWork == WorkType.Add)
                    {
                        int Id = w.FlightsId ?? 0;
                        int result = await _queueRepasitory.AddPassengerToFlight(w.Pasengerid, Id);
                        if (result == -1)
                        {
                            Console.WriteLine("End Capacity");
                        }
                        else
                        {
                            Console.WriteLine($"passanger {w.Pasengerid} add to fly {w.FlightsId}  -{result}");

                        }
                    }
                }
                Listw = await _workerRip.Next(context);
                if (Listw.Count() == 0)
                {
                    stop = true;
                    break;
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

