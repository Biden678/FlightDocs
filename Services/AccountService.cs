using FlightDocs.DTOs;
using FlightDocs.Models;
using FlightDocs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Services
{
    public class AccountService : IAccount
    {
        private readonly DB _db;
        private readonly IConfiguration _configuration;
        public AccountService(DB db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public async Task<Account> AddAccount(AccountDTO dto)
        {
            dto.Id = Guid.NewGuid();
            dto.Password = HashedPassword(dto.Password);
            var checkGroup = await _db.Groups.AnyAsync(g => g.Id == dto.groupId);
            if (!checkGroup)
            {
                throw new Exception("Id Groups is not exist");
            }
            var newAccount = new Account
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password,
                groupId = dto.groupId
            };
            await _db.Accounts.AddAsync(newAccount);
            await _db.SaveChangesAsync();
           return newAccount;
        }
        public static string HashedPassword(string password) { 
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
     

        public async Task<IEnumerable<Account>> getAllAcount()
        {
            var account = await _db.Accounts.Include(g=>g.Group).ToListAsync();
            return account;
        }

        public string Login(LoginDTO dto)
        {
            var account = Authenticate(dto);
            if (account != null)
            {
                return TokenService.GenerateJSONWebToken(_configuration, account);
                 
            }
            else
            {
                return null;
            }
        }
        private Account Authenticate(LoginDTO dto)
        {
            var currentAccount = _db.Accounts.FirstOrDefault
                (x => x.Email.ToLower() == dto.Email.ToLower());
            if (currentAccount != null)
            {
                var checkPass = VerifiedPassword(dto.Password, currentAccount.Password);
                if (checkPass) {
                    return currentAccount;
                }
                return null;
            }
            return null;
        }
        public static bool VerifiedPassword(string enterPassword, string storeHash)
        {
            return BCrypt.Net.BCrypt.Verify(enterPassword, storeHash);
        }
    }
}
