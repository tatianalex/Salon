using Domen.Models;

namespace Services.Interfaces;

public interface IMailToken
{
    Task GetMailTokenList();
    MailToken GetMailToken(int id);
    Task Create(MailToken item);
    Task Update(MailToken item);
    Task Delete(int id);
    Task Save();
}
