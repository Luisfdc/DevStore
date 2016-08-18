using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevStore.Domain;
using DevStore.Infra.DataContexts;

namespace Business
{
    public class Messages : Singleton<Messages>
    {
        private Messages()
        { }

        public ResponseObject NewMessageFromUser(string text, int id)
        {
            using (var db = new DevStoreDataContexts())
            {
                try
                {
                    var message = new Message(text, id);
                    db.Message.Add(message);
                    db.SaveChanges();
                    return new ResponseObject(true, "Message inserida com sucesso!", message);
                }
                catch (Exception)
                {
                    return new ResponseObject(false, "Erro ao tentar salvar Message!");
                }
            }
        }

        public List<Message> GetRecentMessages()
        {
            using (var db = new DevStoreDataContexts())
            {
                return db.Message.Include("User")
                    .OrderByDescending(a => a.CreateDate)
                    .Take(50).ToList()
                    .OrderBy(a => a.CreateDate)
                    .ToList();
            }
        }
    }
}
