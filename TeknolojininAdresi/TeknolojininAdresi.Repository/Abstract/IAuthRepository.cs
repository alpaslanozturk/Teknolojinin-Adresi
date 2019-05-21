using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Repository;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Repository.Abstract
{
    public interface IAuthRepository
    {
        Task<Users> Register(Users user, string password);
        Task<Users> Login(string userName, string password);
        Task<bool> UserExists(string userName);
        Task<Users> GetUser(int userId);
    }
}
