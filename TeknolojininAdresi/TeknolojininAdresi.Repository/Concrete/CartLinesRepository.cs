using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Repository.EntityFramework;
using TeknolojininAdresi.DataAccess.Context;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Repository.Concrete
{
    public class CartLinesRepository : BaseRepository<CartLines>, ICartLinesRepository
    {
        public CartLinesRepository(TeknolojininAdresiContext context) : base(context)
        {

        }

        public void AddToCart(Carts cart, Products product, int quantity)
        {
            CartLines cartLine = cart.CartLines.FirstOrDefault(x => x.ProductsId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity += quantity; 
                Update(cartLine);
                return;
            }
            else
            {
                CartLines addCartLine = new CartLines()
                {
                    CartsId = cart.CartId,
                    ProductsId = product.ProductId,
                    Quantity = quantity,
                    UnitPrice = product.UnitPrice
                };
                Add(addCartLine);
            }
        }

        public void RemoveToCart(Carts cart, int productId)
        {
            Delete(cart.CartLines.FirstOrDefault(x => x.ProductsId == productId));          
        }

        public async Task<List<CartLines>> GetCartLinesList(Carts cart)
        {
            return await Set().Include(x=> x.Products).Where(x=> x.CartsId == cart.CartId).ToListAsync();
        }
    }
}
