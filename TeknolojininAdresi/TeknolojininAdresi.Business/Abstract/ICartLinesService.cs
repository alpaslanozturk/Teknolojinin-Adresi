using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface ICartLinesService
    {
        void AddToCart(Carts cart, Products product, int quantity);
        void RemoveToCart(Carts cart, int productId);
        Task<List<CartLines>> GetCartLinesList(Carts cart);
    }
}
