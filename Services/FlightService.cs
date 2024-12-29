using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Services
{
    public class FlightService : IFlight
    {
        private readonly DB _db;
        public FlightService(DB db) {
            _db = db;
        }

        public async Task<Flight> addFlightAccount(FlightAccountDTO dto)
        {
            var flight = await _db.Flights
               .Where(t => t.flightNo.ToLower() == dto.flightNo.ToLower())
               .Include(p => p.Account)
               .FirstOrDefaultAsync();
            if (flight == null)
                return null;

            var account = await _db.Accounts.FindAsync(dto.accId);
            if (account == null)
                return null;
            flight?.Account?.Add(account);
            await _db.SaveChangesAsync();
            return flight;
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
