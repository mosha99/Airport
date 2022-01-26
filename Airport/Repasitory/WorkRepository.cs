namespace Airport.Repasitory
{
    public class WorkRepository : IWorkRepository
    {
        AirplantContext context;

        public WorkRepository(AirplantContext inMemoryContext)
        {
            context = inMemoryContext;

        }
        public async Task Add(Work work)
        {
            await context.Works.AddAsync(work);
            await context.SaveChangesAsync();
        }
        public async Task<List<Work>> Next()
        {
            var work = context.Works.Where(x => x.cheack != true);
            foreach (var item in work)
            {
                item.cheack = true;
            }
            await context.SaveChangesAsync();

            return await work.ToListAsync();
        }

    }
    public class WorksetRepository
    {
        public async Task<List<Work>> Next(AirplantContext context)
        {
            var work = context.Works.Where(x => x.cheack != true);
            foreach (var item in work)
            {
                item.cheack = true;
            }
            await context.SaveChangesAsync();

            return await work.ToListAsync();
        }

    }
}
