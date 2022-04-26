using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace FirstIdent.Models
{
    public class User : IdentityUser
    {
        [InverseProperty("Sender")]
        public List<Message> MsgsSent { get; set; }
        [InverseProperty("Receiver")]
        public List<Message> MsgsRcvd { get; set; }
        public User()
        {
            MsgsRcvd = new List<Message>();
            MsgsSent = new List<Message>();
        }
    }
}