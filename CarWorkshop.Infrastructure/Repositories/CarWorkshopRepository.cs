﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Interfaces;

using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Add(carWorkshop); //add carWorkshop entity to db context
            await _dbContext.SaveChangesAsync(); //save changes
        }

        //return carworkshop by name or null if not found
        public Task<Domain.Entities.CarWorkshop?> GetByName(string name)
            => _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
            => await _dbContext.CarWorkshops.ToListAsync();

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
            => await _dbContext.CarWorkshops.FirstAsync(c => c.EncodedName == encodedName);

        public Task Commit() => _dbContext.SaveChangesAsync();

        public async Task Delete(string encodedName)
        {
            var carWorkshopToRemove = _dbContext.CarWorkshops.FirstOrDefault(c => c.EncodedName == encodedName);
            if(carWorkshopToRemove is null)
            {
                new Exception("Brak warsztatu w bazie danych");
            }

            var result = _dbContext.Remove(carWorkshopToRemove);
            _dbContext.SaveChanges();
            Console.WriteLine("usunieto ");
        }

    }

}
