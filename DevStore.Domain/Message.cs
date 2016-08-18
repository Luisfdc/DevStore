using System.ComponentModel.DataAnnotations.Schema;
using DevStore.Domain.Base;

namespace DevStore.Domain
{
    public class Message: ModelBase
    {
        public Message()
        {    
        }

        public Message(string text, int userId)
        {
            Texto = text;
            UserId = userId;
        }

        public string Texto { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
