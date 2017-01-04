using System;
using DevStore.Domain.Interfaces;
using DevStore.Domain;

namespace DevStore.Application
{
    public class UserApplication : Singleton<User>
    {
        private IUserRepository userRepository;

        private UserApplication(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public ResponseObject RegisterNewUser(string name)
        {

            try
            {
                User user = new User(name);
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
