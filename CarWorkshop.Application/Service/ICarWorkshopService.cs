using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Service;

public interface ICarWorkshopService
{
    Task Create(CarWorkshopDto carWorkshop);
}