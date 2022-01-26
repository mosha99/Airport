namespace Airport.Repasitory
{
    public interface IWorkRepository
    {
        public Task Add(Work work);
        public Task<List<Work>> Next();

    }

}
