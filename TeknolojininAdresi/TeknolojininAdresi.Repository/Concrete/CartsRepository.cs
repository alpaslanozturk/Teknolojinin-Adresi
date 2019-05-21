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
    public class CartsRepository : BaseRepository<Carts>, ICartsRepository
    {
        public CartsRepository(TeknolojininAdresiContext context) : base(context)
        {

        }

        public async Task<Carts> GetCart(int userId)
        {
            var cart = await Set().Include(x => x.CartLines).FirstOrDefaultAsync(x => x.IsMain == true && x.UsersId == userId);

            if (cart == null)
            {       
                Carts newCart = new Carts()
                {
                    UsersId = userId,
                    IsMain = true
                };
                Add(newCart);

                return newCart;
            }

            return cart; 
        }
    }
}
