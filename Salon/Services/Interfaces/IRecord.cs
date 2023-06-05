using Domen.Models;

namespace Services.Interfaces;

public interface IRecord
{
    Task GetRecordList();
    Record GetRecord(int id);
    Task Create(Record item);
    Task Update(Record item);
    Task Delete(int id);
    Task Save();
}