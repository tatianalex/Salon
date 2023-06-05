using Domen.Models;

namespace Services.Interfaces;

public interface ICategoryService
{
    Task GetCategoryServiceList();
    CategoryService GetCategoryServiceService(int id);
    Task Create(CategoryService item);
    Task Update(CategoryService item);
    Task Delete(int id);
    Task Save();
}
