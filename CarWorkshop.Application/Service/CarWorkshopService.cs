using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Service
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
           var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);

            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);
        }

        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var CarWorkshops = await _carWorkshopRepository.GetAll();

            var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(CarWorkshops);      //map CarWorkshops list to CarWorkshopDtos list

            return dtos;
        }
    }
}
