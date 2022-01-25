namespace Airport.Worker;
#nullable disable

public static class WorkerList 
{
    public static IList<Work> works { get; set; } = new List<Work>();
    public static Work Next()
    {
        if (works.Count == 0) return null;

        Work work = works[0];
        works.RemoveAt(0);
        return work;
    }
    static string  s = "";
    public static int count() { return works.Count; }

    public static event EventHandler OnAdd;
    public static int AddWork(Work work)
    {
        int count1 = works.Count;

        works.Add(work);
        int count2 = works.Count;

        if ((count1 + 1) != count2)
        {
            Console.WriteLine("error");
        }
        return works.Count();

        // OnAdd.Invoke(work, EventArgs.Empty);

    }

}

