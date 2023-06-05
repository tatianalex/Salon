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
        Service = service;
    }


    Task IService.GetServiceList()
    {
        throw new NotImplementedException();
    }

    Service IService.GetService (int id)
    {
        throw new NotImplementedException() ;
    }

    async Task IService.Create (Service item)
    {
        await _db.AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public Task Update(Service item)
    {
        _db.Update(item);
        return Task.CompletedTask;
    }

    public async Task Delete(int id, Service? service)
    {
        if (service == null) throw new ArgumentNullException(nameof(service));

        service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
        if (service is null)

            throw new TirException("Service is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Services.Remove(Service);
        await _db.SaveChangesAsync();
    }

    private Service Service { get; set; }

    public Task GetServiceList()
    {
        throw new NotImplementedException();
    }

    public Service GetService(int id)
    {
        throw new NotImplementedException();
    }

    public Task Create(Service item)
    {
        throw new NotImplementedException();
    }

    Task IService.Update(Service item)
    {
        throw new NotImplementedException();
    }

    Task IService.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task IService.Save()
    {
        throw new NotImplementedException();
    }
}

public class TirException : Exception
{
    public TirException(string materialIsNotExists, object entityIsNotFound)
    {
        throw new NotImplementedException();
    }
}