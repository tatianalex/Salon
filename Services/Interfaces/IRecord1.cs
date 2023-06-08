using Domen.Models;

namespace Services.Interfaces;

public interface IRecord1
{
    Task <List<Record?>>GetRecordList(DateTime date);
    Task GetHoursList(DateTime date);
    Task<Record> GetRecord(int id);
    Task Create(Record item);
    Task Update(Record item);
    Task Delete(int id);
    Task Save();
}