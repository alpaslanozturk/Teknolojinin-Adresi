using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Repository;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Repository.Abstract
{
    public interface ICartsRepository : IBaseRepository<Carts>
    {
        Task<Carts> GetCart(int userId);
    }
}
