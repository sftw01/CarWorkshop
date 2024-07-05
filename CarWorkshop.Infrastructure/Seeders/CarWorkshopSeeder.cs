using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            // Check if database is connected
            if (await _dbContext.Database.CanConnectAsync())
            {
                //if db is empty
                if (!_dbContext.CarWorkshops.Any())
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis ASO",
                        ContactDetails = new CarWorkshopContactDetails()
                        {
                            City = "Krakow",
                            PhoneNumber = "+48667445298",
                            PostalCode = "30-001",
                            Street = "Szewska 1"
                        }
                    };

                    mazdaAso.EncodeName();
                    _dbContext.CarWorkshops.Add(mazdaAso);

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
