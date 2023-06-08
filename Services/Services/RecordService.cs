using System.Linq;
using Domen;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Interfaces;

namespace Services.Services;

    public class RecordService : IRecord
    {
       
        
        private readonly AplicationContext _db;
    
        public RecordService(AplicationContext db)
        {
            _db = db;
        }
        


public Task<List<Record?>> GetRecordList(DateTime date)
{
    return _db.Records.Where(r=>r.Chart.Date==date ).ToListAsync();
}

public Task<List<DateTime?>> GetHoursList(DateTime date)
{
    throw new NotImplementedException();
}

/*public  List<DateTime> GetHoursList(DateTime date)
{
    Chart chart = _db.Charts.FirstOrDefaultAsync(x => x.Date == date);
    var records = _db.Records.Where(r => r.Chart.Date == date).ToList();
    List<DateTime> hours = new List<DateTime>();

    DateTime t = chart.Start;
    while (t <= chart.Finish)
    {
        int fg = 0;

        if (records != null)
            foreach (Record record in records)
            {
                if (record.Start.Hour == t.Hour)
                    fg = 1;
            }

        if (fg == 0)
            hours.Add(t);
        t = t.AddHours(1);

    }

    return hours;
}*/

public async Task<Record> GetRecord(int id)
{
    Record record = await _db.Records.FirstOrDefaultAsync(x => x.Id == id);
    return record;
}

public async Task Create(Record item)
{
    await _db.AddAsync(item);
    await _db.SaveChangesAsync();
}

public async Task Update(Record item)
{
    _db.Update(item);
    await _db.SaveChangesAsync();
}

public async Task Delete(int id)
{
    var  record = await _db.Records.FirstOrDefaultAsync(x => x != null && x.Id == id);
    if (record is null)
    
        throw new SalonException("Record is not exists!", EnumErrorCode.EntityIsNotFound);
    
    _db.Records.Remove(record);
    await _db.SaveChangesAsync();
}

public Task Save()
{
    throw new NotImplementedException();
}
    }

