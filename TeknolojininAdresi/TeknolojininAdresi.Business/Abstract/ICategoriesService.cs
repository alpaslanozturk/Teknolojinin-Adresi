using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface ICategoriesService
    {
        Task<List<Categories>> GetCategoriesHome();

        Task<List<Categories>> GetCategoriesList();

        Task<List<Categories>> GetCategoriesListHome();

        Task<List<Categories>> GetCategoriesListAdmin();
        void Add(Categories category);
        void Update(Categories category);
        void Delete(Categories category);
        Task<Categories> Find(int categoryId);
    }
}
