using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface ICartsService
    {
        Task<Carts> GetCart(int userId);
        void OffCart(int cartsId);
    }
}
