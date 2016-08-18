using System;
using DevStore.Domain.Interfaces;

namespace DevStore.Application
{
    public class User : Singleton<User>
    {
        private IUserRepository userRepository;

        private User(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public ResponseObject RegisterNewUser(string name)
        {

            try
            {
                Domain.User user = new Domain.User(name);
                userRepository.Add(user);
                return new ResponseObject(true, "Usuário inserido com sucesso!", user);
            }
            catch (Exception)
            {
                return new ResponseObject(false, "Erro ao tentar salvar usuário!");
            }


        }
    }
}
