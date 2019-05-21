using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Repository;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Repository.Abstract
{
    public interface ICartLinesRepository : IBaseRepository<CartLines>
    {
        void AddToCart(Carts cart, Products product, int quantity);
        void RemoveToCart(Carts cart, int productId);
        Task<List<CartLines>> GetCartLinesList(Carts cart);
    }
}
