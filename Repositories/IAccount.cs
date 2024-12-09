using FlightDocs.DTOs;
using FlightDocs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Repositories
{
    public interface IAccount
    {
        Task<Account> AddAccount(AccountDTO dto);
        Task<IEnumerable<Account>> getAllAcount();
        string ? Login(LoginDTO dto);
    }
}
