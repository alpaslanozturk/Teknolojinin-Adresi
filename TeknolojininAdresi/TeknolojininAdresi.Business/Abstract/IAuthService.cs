using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface IAuthService
    {
        Task<Users> Register(Users user, string password);
        Task<Users> Login(string userName, string password);
        Task<bool> UserExists(string userName);
        Task<Users> GetUser(int userId);
    }
}
