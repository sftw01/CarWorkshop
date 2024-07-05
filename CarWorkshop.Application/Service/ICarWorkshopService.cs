namespace CarWorkshop.Application.Service;

public interface ICarWorkshopService
{
    Task Create(Domain.Entities.CarWorkshop carWorkshop);
}