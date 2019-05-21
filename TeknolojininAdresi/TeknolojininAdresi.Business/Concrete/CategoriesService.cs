using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _repCategories;

        public CategoriesService(ICategoriesRepository repCategories)
        {
            _repCategories = repCategories;
        }

        public void Add(Categories category)
        {
            _repCategories.Add(category);
        }

        public void Delete(Categories category)
        {
            _repCategories.Delete(category);
        }

        public async Task<Categories> Find(int categoryId)
        {
            return await _repCategories.Get(x=> x.CategoryId == categoryId);
        }

        public async Task<List<Categories>> GetCategoriesHome()
        {
            return await _repCategories.GetCategoriesHome();
        }

        public async Task<List<Categories>> GetCategoriesList()
        {
            return await _repCategories.GetCategoriesList();
        }

        public async Task<List<Categories>> GetCategoriesListAdmin()
        {
            return await _repCategories.GetList();
        }

        public async Task<List<Categories>> GetCategoriesListHome()
        {
            return await _repCategories.GetList();
        }

        public void Update(Categories category)
        {
            _repCategories.Update(category);
        }
    }
}
