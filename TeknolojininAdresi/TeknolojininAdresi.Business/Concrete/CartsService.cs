using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class CartsService : ICartsService
    {
        private ICartsRepository _repCart;

        public CartsService(ICartsRepository repCart)
        {
            _repCart = repCart;
        }

        public async Task<Carts> GetCart(int userId)
        {
            return await _repCart.GetCart(userId);
        }

        public void OffCart(int cartsId)
        {
            Carts cart = _repCart.Find(cartsId);
            cart.IsMain = false;
            _repCart.Update(cart);
        }
    }
}
