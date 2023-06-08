using Services.Pagination;

namespace Services.Models.MailToken;

public class GetMailTokenRequest:IPaginationRequest
{ 
    public long? UserId { get; set; } = null;

    public Page Page { get; set; } = new Page();   
}