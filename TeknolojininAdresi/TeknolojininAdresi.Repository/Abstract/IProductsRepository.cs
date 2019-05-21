using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Repository;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Repository.Abstract
{
    public interface IProductsRepository : IBaseRepository<Products>
    {
        Task<List<Products>> GetProductsOrderBy(int? categoryId);
        Task<List<Products>> GetProductsTopSelling(int? categoryId);
        Task<List<Products>> GetProductsList(int page, int? categoryId, string search);
        Task<int> GetPageCount(int? categoryId);
        Task<Products> GetProductDetail(int productId);
    }
}
