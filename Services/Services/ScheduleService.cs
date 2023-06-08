using Domen;
using Domen.Enums;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services;

public class SchelduleService : IScheldule
{
    private readonly AplicationContext _db;

    public SchelduleService(AplicationContext db)
    {
        _db = db;
    }

    public IEnumerable<Scheldule> GetSchelduleList()
    {
        return _db.Scheldules.ToList();
    }

    
    public Scheldule GetScheldule(EnumsWeek day)
    {
        return _db.Scheldules.Find(day);
    }
 
    public async Task Create(Scheldule scheldule)
    {
        _db.Scheldules.Add(scheldule);
    }
 
    public async Task Update(Scheldule scheldule)
    {
        _db.Entry(scheldule).State = EntityState.Modified;
    }

    

    public async Task Delete(EnumsWeek day)
    {
        var scheldule = _db.Scheldules.Find(day);
        if (scheldule != null)
            _db.Scheldules.Remove(scheldule);
    }
 
    public async Task Save()
    {
        _db.SaveChangesAsync();
    }
 
    private bool disposed = false;
 
    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
        this.disposed = true;
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}


