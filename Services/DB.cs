using FlightDocs.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Services
{
    public class DB : DbContext
    {
        public DB(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Group>  Groups { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<DocumentDetail> DocumentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()

        .HasOne(d => d.DocumentDetail)  // Document là bên chủ
        .WithOne(dd => dd.Document)    // DocumentDetail là bên phụ thuộc
        .HasForeignKey<DocumentDetail>(dd => dd.DocId); // Khóa ngoại là DocId trong DocumentDetail
        }
    }
}
