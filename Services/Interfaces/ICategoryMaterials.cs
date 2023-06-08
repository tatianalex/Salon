using Domen.Models;

namespace Services.Interfaces;

public interface ICategoryMaterials
{
    Task<List<CategoryMaterials>> GetCategoryMaterialsList();
    Task<CategoryMaterials> GetCategoryMaterials(int id);
    Task Create(string name, string description);
    Task Update(CategoryMaterials item);
    Task Delete(long id);
    Task Save();
}
