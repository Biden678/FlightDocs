using FlightDocs.DTOs;
using FlightDocs.Models;

namespace FlightDocs.Repositories
{
    public interface IFlight
    {
        Task<Flight> addFlight(FlightDTO dto);

        Task<Flight> addFlightAccount(FlightAccountDTO dto);
    }
}
