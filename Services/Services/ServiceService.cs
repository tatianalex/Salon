using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

public class ServiceService : IService
{
    private readonly AplicationContext _db;

    public ServiceService(AplicationContext db, Service service)
    {
        _db = db;
       
    }

    public Task<List<Service>> GetServiceList()
    {
        return _db.Services.ToListAsync();
    }

    async Task<Service> IService.GetService(int id)
    {
        Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
        return service;
    }

    async Task IService.Create(Service item)
    {
        await _db.AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Service item)
    {
        _db.Update(item);

    }


    public async Task Save()
    {

        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {


        var service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
        if (service is null)

            throw new SalonException("Service is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Services.Remove(service);
        await _db.SaveChangesAsync();
    }
}


  