using Domen.Models;

namespace Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryService>> GetCategoryServiceList();
    CategoryService GetCategoryServiceService(int id);
    Task Create(CategoryService item);
    Task Update(CategoryService item);
    Task Delete(int id);
    Task Save();
}
