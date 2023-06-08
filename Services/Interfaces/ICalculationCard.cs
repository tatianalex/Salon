using Domen.Models;

namespace Services.Interfaces;

public interface ICalculationCard
{
    Task<List<CalculationCard>> GetCalculationList();
    CalculationCard GetCalculationCard(int id);
    Task Create(CalculationCard item);
    Task Update(CalculationCard item);
    Task Delete(int id);
    Task Save();
}
