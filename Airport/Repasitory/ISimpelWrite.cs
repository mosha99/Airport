namespace Airport.Repasitory
{
    public interface ISimpelWrite
    {
        public Task AddAirPlant(Airplans airplans);
        public Task EditAirPlant(Airplans airplans);
        public Task DeleteAirPlant(int airplantId);
        public Task AddFlight(int startlocId, int endlocId, int AirplaneId, Flights flight);
        public Task EditFlight(Flights flights);
        public Task DeleteFlight(int flightId);
        public Task AddAirport(AirPort airPort);
        public Task EditAirport(AirPort airPort);
        public Task DeleteAirport(int airportId);
        public Task AddPasenger(Pasenger pasenger);
        public Task EditPasenger(Pasenger pasenger);
        public Task DeletePasenger(int pasengerId);
    }
}
