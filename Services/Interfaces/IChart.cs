using Domen.Models;

namespace Services.Interfaces;

public interface IChart
{
    Chart GetChart(DateTime date);
    Task Create(DateTime datebegin,DateTime dateend);
    Task Update(Chart item);
    Task Delete(DateTime date);
    Task Save();
}
