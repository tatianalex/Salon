using Domen.Models;

namespace Services.Interfaces;

public interface ICalculation
{
    Task GetCalculationList();
    Calculation GetCalculation(int id);
    Task Create(Calculation item);
    Task Update(Calculation item);
    Task Delete(int id);
    Task Save();
}
