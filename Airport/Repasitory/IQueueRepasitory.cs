namespace Airport.Repasitory;

public interface IQueueRepasitory
{
    public Task<int> AddPassengerToFlight(int pasenger, int flights);
    public int DeletePassengerInFlight(Pasenger pasenger, Flights flights);
}

