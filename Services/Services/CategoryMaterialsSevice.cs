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


    public Task<List<CategoryMaterials>> GetCategoryMaterialsList()
    {
        return _db.CategoryMaterials.ToListAsync();
    }

    public async Task<CategoryMaterials> GetCategoryMaterials(int id)
    {
        CategoryMaterials categoryMaterials = await _db.CategoryMaterials.FirstOrDefaultAsync(x => x.Id == id);
        return categoryMaterials;
    }

    public async Task Create (string name, string description)
    {
        var categoryMaterial = new CategoryMaterials
        {
            Name = name, Description = description
        };
        await _db.AddAsync(categoryMaterial);
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

            throw new SalonException("Category Materials is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.CategoryMaterials.Remove(categoryMaterials);
        await _db.SaveChangesAsync();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}