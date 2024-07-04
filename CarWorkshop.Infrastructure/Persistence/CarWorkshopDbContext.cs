using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Persistence
{
    internal class CarWorkshopDbContext : DbContext
    {
        public DbSet<CarWorkshop.Domain.Entities.CarWorkshop> CarWorkshops { get; set; }    // DbSet for CarWorkshop entity - used to query and save instances of CarWorkshop entity


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   //
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarWorkshopDb;Trusted_Connection=True;");
        }
        
        //ponizsza metoda słuzy do polaczenia z contactDetails, contactDetails nie jest zadna tabela nowa ale nalezy do tabeli Workshop
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.CarWorkshop>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
