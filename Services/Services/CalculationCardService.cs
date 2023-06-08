using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

    public class CalculationCardService : ICalculationCard
    {
        private readonly AplicationContext _db;
    
        public CalculationCardService(AplicationContext db)
        {
            _db = db;
        }
    
        

        public Task<List<CalculationCard>> GetCalculationCardList()
        {
            return _db.CalculationCards.ToListAsync();
        }

        public Task<List<CalculationCard>> GetCalculationList()
        {
            throw new NotImplementedException();
        }

        public CalculationCard GetCalculationCard(int id)
        {
            throw new NotImplementedException();
        }


        public async Task Create (CalculationCard item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }
    
        public async Task Update(CalculationCard item)
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
            
    
            var  calculationCard = await _db.CalculationCards.FirstOrDefaultAsync(x => x != null && x.Id == id);
            if (calculationCard is null)
    
                throw new SalonException("CalculationCard is not exists!", EnumErrorCode.EntityIsNotFound);
    
            _db.CalculationCards.Remove(calculationCard);
            await _db.SaveChangesAsync();
        }
    
        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
    