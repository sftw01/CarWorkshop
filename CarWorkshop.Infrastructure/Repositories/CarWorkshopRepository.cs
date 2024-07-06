using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Interfaces;

using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Repositories
{
    //implement interface ICarWorkshopRepository
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbContext.Add(carWorkshop);        //add carWorkshop entity to db context
            await _dbContext.SaveChangesAsync();        //save changes
        }
    }
}
