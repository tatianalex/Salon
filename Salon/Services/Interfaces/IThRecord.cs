using Domen.Models;

namespace Services.Interfaces;

public interface IThRecord
{
    Task GetThRecordList();
    ThRecord GetThRecord(int id);
    Task Create(ThRecord item);
    Task Update(ThRecord item);
    Task Delete(int id);
    Task Save();
}
