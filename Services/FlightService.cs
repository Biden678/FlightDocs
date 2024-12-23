using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;

namespace FlightDocs.Services
{
    public class FlightService : IFlight
    {
        private readonly DB _db;
        public FlightService(DB db) {
            _db = db;
        }
        public async Task<Flight> addFlight(FlightDTO dto)
        {
            var Flight = new Flight
            {
                flightNo = dto.flightNo,
                pointOfLoading = dto.pointOfLoading,
                pointOfUnloading = dto.pointOfUnloading,
                departureDate = dto.departureDate,
            };
            await _db.Flights.AddAsync(Flight);
           await _db.SaveChangesAsync();
            return Flight ;
        }
    }
}
