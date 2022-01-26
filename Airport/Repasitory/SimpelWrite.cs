namespace Airport.Repasitory
{
    public class SimpelWrite : ISimpelWrite
    {


        AirplantContext _DataBase;

        public SimpelWrite(AirplantContext DataBase)
        {
            _DataBase = DataBase;
        
        }


        public async Task AddAirPlant(Airplans airplans)
        {
            _DataBase.Airplans.Add(airplans);
            await _DataBase.SaveChangesAsync();

        }

        public async Task AddAirport(AirPort airPort)
        {
            _DataBase.AirPorts.Add(airPort);
            await _DataBase.SaveChangesAsync();

        }

        public async Task AddFlight(int startlocId, int endlocId, int AirplaneId, Flights flight)
        {
            var startloc = _DataBase.AirPorts.FirstOrDefault(x => x.Id == startlocId);
            var endloc = _DataBase.AirPorts.FirstOrDefault(x => x.Id == endlocId);
            var Airplane = _DataBase.Airplans.FirstOrDefault(x => x.Id == AirplaneId);
            if (startloc == null || endloc == null || Airplane == null) throw new Exception("404");

            flight.StartLocation = startloc;
            flight.EndLocation = endloc;
            flight.Airplan = Airplane;

            Flights flights = flight;

            _DataBase.Flights.Add(flights);
            await _DataBase.SaveChangesAsync();

        }

        public async Task AddPasenger(Pasenger pasenger)
        {
            try
            {
                _DataBase.Pasengers.Add(pasenger);
                await _DataBase.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }



        public async Task DeleteAirPlant(int airplantId)
        {
            var AirPlant = _DataBase.Airplans.FirstOrDefault(x => x.Id == airplantId);
            if (AirPlant == null) throw new Exception("404");
            AirPlant.IsDeleted = true;
            await _DataBase.SaveChangesAsync();
        }

        public async Task DeleteAirport(int airportId)
        {
            var AirPort = _DataBase.AirPorts.FirstOrDefault(x => x.Id == airportId);
            if (AirPort == null) throw new Exception("404");
            AirPort.IsDeleted = true;
            await _DataBase.SaveChangesAsync();
        }

        public async Task DeleteFlight(int flightId)
        {
            var Flight = _DataBase.Flights.FirstOrDefault(x => x.Id == flightId);
            if (Flight == null) throw new Exception("404");
            Flight.IsDeleted = true;
            await _DataBase.SaveChangesAsync();
        }

        public async Task DeletePasenger(int pasengerId)
        {
            var Pasenger = _DataBase.Flights.FirstOrDefault(x => x.Id == pasengerId);
            if (Pasenger == null) throw new Exception("404");
            Pasenger.IsDeleted = true;
            await _DataBase.SaveChangesAsync();
        }



        public async Task EditAirPlant(Airplans airplans)
        {
            var AirPlant = _DataBase.Airplans.FirstOrDefault(x => x.Id == airplans.Id);
            if (AirPlant == null) throw new Exception("404");

            foreach (var item in typeof(Airplans).GetProperties())
            {
                if (item.Name.ToLower() == "id") continue;
                item.SetValue(AirPlant, item.GetValue(airplans));
            }

            await _DataBase.SaveChangesAsync();
        }

        public async Task EditAirport(AirPort airPort)
        {
            var AirPort = _DataBase.AirPorts.FirstOrDefault(x => x.Id == airPort.Id);
            if (AirPort == null) throw new Exception("404");

            foreach (var item in typeof(AirPort).GetProperties())
            {
                if (item.Name.ToLower() == "id") continue;
                item.SetValue(AirPort, item.GetValue(airPort));
            }

            await _DataBase.SaveChangesAsync();
        }

        public async Task EditFlight(Flights flights)
        {
            var Flights = _DataBase.AirPorts.FirstOrDefault(x => x.Id == flights.Id);
            if (Flights == null) throw new Exception("404");

            foreach (var item in typeof(Flights).GetProperties())
            {
                if (item.Name.ToLower() == "id") continue;
                item.SetValue(Flights, item.GetValue(flights));
            }

            await _DataBase.SaveChangesAsync();
        }

        public async Task EditPasenger(Pasenger pasenger)
        {
            var Pasenger = _DataBase.AirPorts.FirstOrDefault(x => x.Id == pasenger.Id);
            if (Pasenger == null) throw new Exception("404");

            foreach (var item in typeof(Flights).GetProperties())
            {
                if (item.Name.ToLower() == "id") continue;
                item.SetValue(Pasenger, item.GetValue(pasenger));
            }

            await _DataBase.SaveChangesAsync();
        }

        public async Task EnterToAirPlane(Pasenger pasenger, Flights flights, bool success)
        {
            FlightsInfo flightsInfo = new FlightsInfo();

            flightsInfo.pasenger = _DataBase.Pasengers.FirstOrDefault(x => x.Id == pasenger.Id);
            flightsInfo.Flight = _DataBase.Flights.FirstOrDefault(x => x.Id == flights.Id);

            if (flightsInfo.Flight == null) throw new Exception("404");
            if (flightsInfo.pasenger == null) throw new Exception("404");

            flightsInfo.date = DateTime.Now;

            _DataBase.FlightsInfo.Add(flightsInfo);

            await _DataBase.SaveChangesAsync();
        }

    }
}
