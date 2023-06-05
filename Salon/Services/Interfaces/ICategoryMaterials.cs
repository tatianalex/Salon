using Domen.Models;

namespace Services.Interfaces;

public interface ICategoryMaterials
{
    Task GetCategoryMaterialsList();
    CategoryMaterials GetCategoryMaterials(int id);
    Task Create(CategoryMaterials item);
    Task Update(CategoryMaterials item);
    Task Delete(long id);
    Task Save();
}
