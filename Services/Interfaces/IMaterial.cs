using Domen.Models;

namespace Services.Interfaces;

public interface IMaterial
{
    Task<List<Material?>> GetMaterialList();
    Task<Material> GetMaterial(int id);
    Task Create(MaterialDTO item);
    Task Update(MaterialDTO item);
    Task Delete(int id);
    Task Save();
}
