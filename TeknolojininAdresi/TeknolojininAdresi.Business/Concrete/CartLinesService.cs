using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class CartLinesService : ICartLinesService
    {
        private ICartLinesRepository _repCartLines;

        public CartLinesService(ICartLinesRepository repCartLines)
        {
            _repCartLines = repCartLines;
        }

        public void AddToCart(Carts cart, Products product, int quantity)
        {
            _repCartLines.AddToCart(cart, product, quantity);
        }

        public async Task<List<CartLines>> GetCartLinesList(Carts cart)
        {
            return await _repCartLines.GetCartLinesList(cart);
        }

        public void RemoveToCart(Carts cart, int productId)
        {
            _repCartLines.RemoveToCart(cart, productId);
        }
    }
}
