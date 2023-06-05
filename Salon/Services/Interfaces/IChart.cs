using Domen.Models;

namespace Services.Interfaces;

public interface IChart
{
    Task GetChartList();
    Chart GetChart(int id);
    Task Create(Chart item);
    Task Update(Chart item);
    Task Delete(int id);
    Task Save();
}
