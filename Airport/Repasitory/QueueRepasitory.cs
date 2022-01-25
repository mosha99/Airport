namespace Airport.Repasitory
{
    public class QueueRepasitory : IQueueRepasitory
    {
        AirplantContext _DataBase;

        public QueueRepasitory(AirplantContext DataBase)
        {
            _DataBase = DataBase;
        }
        public async Task<int> AddPassengerToFlight(int _pasenger, int _flights)
        {
            var Pasenger = _DataBase.Pasengers.FirstOrDefault(x => x.Id == _pasenger);
            if (Pasenger == null) throw new Exception("404");
            var Flight = _DataBase.Flights
                .Include(x=>x.Airplan)
                .Include(x => x.PasengerList)
                .FirstOrDefault(x => x.Id == _flights);
            if (Flight == null) throw new Exception("404");

            int Capacity = Flight.Airplan.Capacity;
            int passcount = _DataBase.Flighpasses
                .Where(x => x.Flight.Id == _flights && x.IsDeleted != true)
                .Include(x => x.Flight)
                .Include(x => x.Pasenger)
                .Count();

            if ((Capacity - passcount) < 1)
            {
                return -1;
            }

            Flighpass flighpass = new Flighpass()
            {
                IsDeleted =false,
                Flight = Flight,
                Pasenger = Pasenger,
                CreatDate = DateTime.Now,
            };

            Flight.PasengerList.Add(flighpass);
            await _DataBase.SaveChangesAsync();
            return passcount + 1;
        }

        public int DeletePassengerInFlight(Pasenger pasenger, Flights flights)
        {
            return -1;
        }
    }
}
