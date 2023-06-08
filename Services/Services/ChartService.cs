using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;
        public class ChartService :IChart
        {
            private readonly AplicationContext _db;
        
            public ChartService(AplicationContext db)
            {
                _db = db;
            }
        
        
            public Task GetChartList()
            {
                throw new NotImplementedException();
            }
        
            public Chart GetChart (DateTime date)
            {
                throw new NotImplementedException();
            }

            public async Task Create(DateTime datebegin, DateTime dateend)
            {
                DateTime start = datebegin;
                
                while (start <=dateend)
                {
                    var  schedule = await _db.Scheldules.FirstOrDefaultAsync(x => x != null && x.Day == start.DayOfWeek);
                    var chart = new Chart
                    {
                        Date= start,
                        Start =schedule.Start,
                        Finish = schedule.Finish,
                      };
                    Delete(start);
                    await _db.AddAsync(chart);
                    start = start.AddDays(1);

                }
                await _db.SaveChangesAsync();
                
                
            }

            public async Task Create (Chart item)
            {
                await _db.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        
            public async Task Update(Chart item)
            {
              
                _db.Update(item);
                await _db.SaveChangesAsync();
            }
    
            public async Task Delete(DateTime date)
            {
                var  chart = await _db.Charts.FirstOrDefaultAsync(x => x != null && x.Date == date);
                if (chart is null)
        
                    throw new SalonException("Chart is not exists!", EnumErrorCode.EntityIsNotFound);
        
                _db.Charts.Remove(chart);
                await _db.SaveChangesAsync();
            }

            public Task Save()
            {
                throw new NotImplementedException();
            }

          
}
