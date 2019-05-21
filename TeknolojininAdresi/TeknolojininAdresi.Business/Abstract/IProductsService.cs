using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface IProductsService
    {
        Task<List<Products>> GetProductsHome(int? categoryId);
        Task<List<Products>> GetProductsHomeTopSelling(int? categoryId);
        Task<List<Products>> GetProductsList(int page, int? categoryId, string search);
        Task<int> GetPageCount(int? categoryId);
        Task<Products> GetProductDetail(int productId);
        void Add(Products product);
        void Update(Products product);
        void Delete(Products product);
        Task<List<Products>> GetProductsListAdmin();
        Task< Products> Find(int productId);
    }
}
