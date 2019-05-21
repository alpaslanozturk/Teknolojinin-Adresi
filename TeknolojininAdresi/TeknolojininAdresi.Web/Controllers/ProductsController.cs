using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Web.Helpers;
using TeknolojininAdresi.Web.Models;
using static TeknolojininAdresi.Dto.ProductsDTO;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMapper _mapper;
        private IProductsService _servicePro;

        public ProductsController(IProductsService servicePro, IMapper mapper,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _servicePro = servicePro;
            _mapper = mapper;
        }

        [HttpGet("productList")]
        public async Task<IActionResult> GetProductsList(int page, int? categoryId, string search)
        {
            ProductsViewModel model = new ProductsViewModel()
            {
                dto = _mapper.Map<List<ProductsHomeDTO>>(await _servicePro.GetProductsList(page, categoryId, search)),
                pageCount = await _servicePro.GetPageCount(categoryId)
            };
 
            return Ok(model);
        }

        [HttpGet("productDetail")]
        public async Task<IActionResult> GetProductDetail(int productId)
        {
            ProductsHomeDTO dto = _mapper.Map<ProductsHomeDTO>(await _servicePro.GetProductDetail(productId));
           
            return Ok(dto);
        }

        [HttpGet("productsListAdmin")]
        public async Task<IActionResult> GetProductsListAdmin()
        {
            List<ProductsListAdminDTO> dto = _mapper.Map<List<ProductsListAdminDTO>>(await _servicePro.GetProductsListAdmin());

            return Ok(dto);
        }


        [HttpPost("addProduct")]
        public IActionResult AddProduct([FromBody] AddProductDTO addProductDTO)
        {
            Products product = _mapper.Map<Products>(addProductDTO);
            product.AddedDate = DateTime.Now;
            _servicePro.Add(product);
            return Ok(product);
        }

        [HttpPost("updateProduct")]
        public IActionResult UpdateProduct([FromBody] AddProductDTO addProductDTO)
        {
            //var currentProduct = _servicePro.Find((int)addProductDTO.ProductId);            
            Products product = _mapper.Map<Products>(addProductDTO);
            //if (addProductDTO.PictureUrl == null)
            //{
            //    product.PictureUrl = currentProduct.PictureUrl;              
            //}
            //product.AddedDate = currentProduct.AddedDate;
            _servicePro.Update(product);
            return Ok(product);
        }

        [HttpDelete("deleteProduct")]
        public async Task< IActionResult> DeleteProduct(int productId)
        {
            var product = await _servicePro.Find(productId);
            _servicePro.Delete(product);
                      
            return Ok("Silindi");
        }

    }
}