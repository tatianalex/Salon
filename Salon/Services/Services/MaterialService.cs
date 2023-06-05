using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

public class MaterialService : IMaterial
{
    private readonly AplicationContext _db;

    public MaterialService(AplicationContext db)
    {
        _db = db;
    }


    public Task GetMaterialList()
    {
        throw new NotImplementedException();
    }

    public Material GetMaterial(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Create(Material item)
    {
        await _db.AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public Task Update(Material item)
    {
        _db.Update(item);
        return Task.CompletedTask;
    }

    public async Task Delete(int id, Material? material)
    {

        material = await _db.Materials.FirstOrDefaultAsync(x => x != null && x.Id == id);
        if (material is null)

            throw new TirException("Material is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Materials.Remove(material);
        await _db.SaveChangesAsync();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}

   

   
    

