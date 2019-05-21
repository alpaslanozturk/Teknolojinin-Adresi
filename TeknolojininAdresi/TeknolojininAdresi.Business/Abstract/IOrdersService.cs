using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface IOrdersService
    {
        void CompleteOrder(int userId, int cartsId, Orders order);
    }
}
