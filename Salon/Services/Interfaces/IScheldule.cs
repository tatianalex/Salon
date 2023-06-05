using Domen.Models;

namespace Services.Interfaces;

public interface IScheldule
{
    IEnumerable<Scheldule> GetSchelduleList();
    Scheldule GetScheldule (int id);
    Task Create(Scheldule item);
    Task Update(Scheldule item);
    Task Delete(int id);
    Task Save();
}
