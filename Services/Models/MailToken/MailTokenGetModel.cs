using Services.Pagination;

namespace Services.Models.MailToken;

public class MailTokenGetModel: IPaginationRequest
{
    public string Search { get; set; } = string.Empty;

    public Page Page { get; set; } = new Page();  
}

