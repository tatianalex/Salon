using AutoMapper;
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


   
    public Task<List<Material?>> GetMaterialList()
    {
        
        return _db.Materials.ToListAsync();
    }

    public async Task<Material> GetMaterial(int id)
    {
        Material material = await _db.Materials.FirstOrDefaultAsync(x => x.Id == id);
        return material;
    }

    public async Task Create(MaterialDTO item)
    { var config = new MapperConfiguration(cfg =>
           cfg.CreateMap<MaterialDTO, Material>()
        );
        var mapper = new Mapper(config);
        var material = mapper.Map<MaterialDTO, Material>(item);
        await _db.AddAsync(material);
        await _db.SaveChangesAsync();
    }

    public async Task Update(MaterialDTO item)
    {var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<MaterialDTO, Material>()
        );
        var mapper = new Mapper(config);
        var material = mapper.Map<MaterialDTO, Material>(item);
        _db.Update(material);
        await _db.SaveChangesAsync();
    }

    

    public async Task Delete(int id)
    {

       var material = await _db.Materials.FirstOrDefaultAsync(x => x != null && x.Id == id);
        if (material is null)

            throw new SalonException("Material is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Materials.Remove(material);
        await _db.SaveChangesAsync();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}

   

   
    

