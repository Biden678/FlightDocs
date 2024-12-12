using FlightDocs.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Services
{
    public class DB : DbContext
    {
        public DB(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Group>  Groups { get; set; }
    }
}
