
using System;


namespace Domen.Models
{

    public class MailTokenDTO
    {
        public long Id { get; set; }

        public Guid Key { get; set; }

        public DateTime DateExpire { get; set; }

       

        public long UserId { get; set; }
    }
}
    