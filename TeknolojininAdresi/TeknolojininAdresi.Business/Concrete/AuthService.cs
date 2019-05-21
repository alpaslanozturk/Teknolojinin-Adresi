using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<Users> GetUser(int userId)
        {
            return await _repository.GetUser(userId);
        }

        public async Task<Users> Login(string userName, string password)
        {
            return await _repository.Login(userName, password);
        }

        public async Task<Users> Register(Users user, string password)
        {
            return await _repository.Register(user, password);
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _repository.UserExists(userName);
        }
    }
}
