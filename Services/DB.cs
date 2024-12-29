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

        public DbSet<UpdatedVersion> UpdatedVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
          .HasOne(d => d.DocumentDetail)
          .WithOne(dd => dd.Document)
          .HasForeignKey<DocumentDetail>(dd => dd.DocId);

            // Explicitly configure the relationship between Document and Flight
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Flight)
                .WithMany(f => f.Document)
                .HasForeignKey(d => d.flightNo)  // Define the foreign key to the Flight entity
                .HasPrincipalKey(f => f.flightNo);  // Define the principal key (primary key) of the Flight entity


        }
    }
}
