using Domen.Models;

namespace Services.Interfaces;

public interface IMaterial
{
    Task GetMaterialList();
    Material GetMaterial (int id);
    Task Create(Material item);
    Task Update(Material item);
    Task Delete(int id, Material? material);
    Task Save();
}
