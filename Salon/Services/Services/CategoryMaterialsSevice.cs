using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

public class CategoryMaterialsService : ICategoryMaterials
{
    private readonly AplicationContext _db;

    public CategoryMaterialsService(AplicationContext db)
    {
        _db = db;
    }


    public Task GetCategoryMaterialsList()
    {
        throw new NotImplementedException();
    }

    public CategoryMaterials GetCategoryMaterials (int id)
    {
        throw new NotImplementedException();
    }

    public async Task Create (CategoryMaterials item)
    {
        await _db.AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public async Task Update(CategoryMaterials item)
    {
      
        _db.Update(item);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        

        var  categoryMaterials = await _db.CategoryMaterials.FirstOrDefaultAsync(x => x != null && x.Id == id);
        if (categoryMaterials is null)

            throw new TirException("Category Materials is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.CategoryMaterials.Remove(categoryMaterials);
        await _db.SaveChangesAsync();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}