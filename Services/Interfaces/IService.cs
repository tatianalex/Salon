using Domen.Models;

namespace Services.Interfaces;

public interface IService
{
    Task<List<Service>> GetServiceList();
    Task<Service> GetService(int id);
    Task Create(Service item);
    Task Update(Service item);
    Task Delete(int id);
    Task Save();
}
