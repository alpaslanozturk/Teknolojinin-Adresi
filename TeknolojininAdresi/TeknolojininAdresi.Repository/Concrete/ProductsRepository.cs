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
    public class ProductsRepository : BaseRepository<Products> , IProductsRepository
    {
        public ProductsRepository(TeknolojininAdresiContext context) : base(context)
        {
   
        }

        public async Task<int> GetPageCount(int? categoryId)
        {
            if (categoryId != null)
            {
                decimal listCount = Convert.ToDecimal( await Set().Where(x => x.CategoriesId == categoryId).CountAsync());
                return (int)Math.Ceiling((listCount / 9));
            }
            else
            {
                decimal listCount = Convert.ToDecimal(await Set().CountAsync());
                return (int)Math.Ceiling((listCount / 9));
            }
            

        }

        public async Task<List<Products>> GetProductsList(int page, int? categoryId, string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                if (categoryId != null)
                {

                    return await Set().Where(x => x.CategoriesId == categoryId && x.ProductName.Contains(search)).Include(y => y.Categories).Include(x=> x.Comments).OrderBy(x => x.ProductId).Skip((page - 1) * 9).Take(9).ToListAsync();
                }
                else
                {
                    return await Set().Where(x=> x.ProductName.Contains(search)).Include(y => y.Categories).Include(x => x.Comments).OrderBy(x => x.ProductId).Skip((page - 1) * 9).Take(9).ToListAsync();
                }
            }
            else
            {
                if (categoryId != null)
                {

                    return await Set().Where(x => x.CategoriesId == categoryId).Include(y => y.Categories).Include(x => x.Comments).OrderBy(x => x.ProductId).Skip((page - 1) * 9).Take(9).ToListAsync();
                }
                else
                {
                    return await Set().Include(y => y.Categories).Include(x => x.Comments).OrderBy(x => x.ProductId).Skip((page - 1) * 9).Take(9).ToListAsync();
                }
            }
            
        }

        public async Task<List<Products>> GetProductsOrderBy(int? categoryId)
        {
            if (categoryId != null)
            {
                return await Set().Where(x => x.CategoriesId == categoryId).Include(y => y.Categories).Include(x => x.Comments).OrderByDescending(x => x.AddedDate).Take(4).ToListAsync();
            }
            else
            {
                return await Set().Include(y => y.Categories).Include(x => x.Comments).OrderByDescending(x => x.AddedDate).Take(4).ToListAsync();
            }
            
        }

        public async Task<List<Products>> GetProductsTopSelling(int? categoryId)
        {
            if (categoryId != null)
            {
                return await Set().Where(x => x.CategoriesId == categoryId).Include(y => y.Categories).Include(x => x.Comments).OrderByDescending(x => x.SellCount).Take(4).ToListAsync();
            }
            else
            {
                return await Set().Include(y => y.Categories).Include(x => x.Comments).OrderByDescending(x => x.SellCount).Take(4).ToListAsync();
            }
            
        }

        public async Task<Products> GetProductDetail(int productId)
        {
            return await Set().Include(x => x.Categories).Include(x=> x.Comments).FirstOrDefaultAsync(x => x.ProductId == productId);
        }
    }
}
