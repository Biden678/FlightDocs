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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DocumentTypePermission>()
            //    .HasKey(dtp => dtp.Id);

            //modelBuilder.Entity<DocumentTypePermission>()
            //    .HasOne(dtp => dtp.DocumentType)
            //    .WithMany(dt => dt.DocumentTypePermission)
            //    .HasForeignKey(dtp => dtp.DocumentTypeId);

            //modelBuilder.Entity<DocumentTypePermission>()
            //    .HasOne(dtp => dtp.Permission)
            //    .WithMany(p => p.DocumentTypePermission)
            //    .HasForeignKey(dtp => dtp.PermissionId);
            //base.OnModelCreating(modelBuilder);
            //
            modelBuilder.Entity<FlightAssignment>()
               .HasKey(dtp => dtp.Id);

            modelBuilder.Entity<FlightAssignment>()
                .HasOne(dtp => dtp.Flight)
                .WithMany(dt => dt.FlightAssignment)
                .HasForeignKey(dtp => dtp.flightNo);

            modelBuilder.Entity<FlightAssignment>()
                .HasOne(dtp => dtp.Account)
                .WithMany(p => p.FlightAssignment)
                .HasForeignKey(dtp => dtp.accountId);
            base.OnModelCreating(modelBuilder);

        }
    }
}
