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
    public class CategoriesRepository : BaseRepository<Categories> , ICategoriesRepository
    {
        public CategoriesRepository(TeknolojininAdresiContext options) : base (options)
        {

        }

        public async Task<List<Categories>> GetCategoriesHome()
        {
            return await Set().Take(3).ToListAsync();
        }

        public async Task<List<Categories>> GetCategoriesList()
        {
            return await Set().Include(x=> x.Products).ToListAsync();
        }
    }
}
