using Domen.Enums;
using Domen.Models;

namespace Services.Interfaces;

public interface IScheldule
{
    IEnumerable<Scheldule> GetSchelduleList();
    Scheldule GetScheldule (EnumsWeek day);
    Task Create(Scheldule item);
    Task Update(Scheldule item);
    Task Delete(EnumsWeek day);
    Task Save();
}
