using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Service
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}
