using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _repProducts;

        public ProductsService(IProductsRepository repProducts)
        {
            _repProducts = repProducts;
        }

        public void Add(Products product)
        {
            _repProducts.Add(product);
        }

        public void Delete(Products product)
        {
            _repProducts.Delete(product);
        }

        public async Task< Products> Find(int productId)
        {
            //return _repProducts.Find(productId);
            return await _repProducts.Get(x=> x.ProductId == productId);
        }

        public async Task<int> GetPageCount(int? categoryId)
        {
            return await _repProducts.GetPageCount(categoryId);
        }

        public async Task<Products> GetProductDetail(int productId)
        {
            return await _repProducts.GetProductDetail(productId);
        }

        public async Task<List<Products>> GetProductsHome(int? categoryId)
        {
            return await _repProducts.GetProductsOrderBy(categoryId);
        }

        public async Task<List<Products>> GetProductsHomeTopSelling(int? categoryId)
        {
            return await _repProducts.GetProductsTopSelling(categoryId);
        }

        public async Task<List<Products>> GetProductsList(int page, int? categoryId, string search)
        {
            return await _repProducts.GetProductsList(page, categoryId, search);
        }

        public async Task<List<Products>> GetProductsListAdmin()
        {
            return await _repProducts.GetList();
        }

        public void Update(Products product)
        {
            _repProducts.Update(product);
        }
    }
}
