using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevStore.Infra.DataContexts;

namespace Business
{
    public class User : Singleton<User>
    {
        private User()
        {
        }

        public ResponseObject RegisterNewUser(string name)
        {
            using (var db = new DevStoreDataContexts())
            {
                try
                {
                    var user = new DevStore.Domain.User(name);
                    db.User.Add(user);
                    db.SaveChanges();
                    return new ResponseObject(true,"Usuário inserido com sucesso!",user);
                }
                catch (Exception)
                {
                    return new ResponseObject(false, "Erro ao tentar salvar usuário!");
                }
            }

        }
    }
}
