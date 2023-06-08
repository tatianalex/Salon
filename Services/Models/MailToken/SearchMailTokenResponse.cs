using Services.Pagination;

namespace Services.Models.MailToken;

public interface SearchMailTokenResponse: IPaginationResponse<MailTokenShortModel>
{
    public Page Page { get; set; } = new  Page();

    public long Count { get; set; }

    public IReadOnlyCollection<MailTokenShortModel> Items { get; set; }  
}
