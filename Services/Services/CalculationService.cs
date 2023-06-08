using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

public class CalculationService : ICalculation
    {
        private readonly AplicationContext _db;
    
        public CalculationService(AplicationContext db)
        {
            _db = db;
        }
    
        public Task<List<Calculation>> GetCalculationList()
        {
            return _db.Calculations.ToListAsync();
        }
       
    
        public Calculation GetCalculation (int id)
        {
            throw new NotImplementedException();
        }
    
        public async Task Create (Calculation item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }
    
        public async Task Update(Calculation item)
        {
          
            _db.Update(item);
            await _db.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            
    
            var  calculation = await _db.Calculations.FirstOrDefaultAsync(x => x != null && x.Id == id);
            if (calculation is null)
    
                throw new SalonException("Calculation is not exists!", EnumErrorCode.EntityIsNotFound);
    
            _db.Calculations.Remove(calculation);
            await _db.SaveChangesAsync();
        }
    
        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
