using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevStore.Domain.Base;
using Newtonsoft.Json;

namespace DevStore.Domain
{
    public class User:ModelBase
    {
        private User()
        {
        }

        public User(string name)
        {
            Nome = name;
        }

        [MaxLength(100, ErrorMessage = "O nome do usuário exedeu a quantidade de caractéres")]
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<Message> Messages { get; set; }
    }
}
