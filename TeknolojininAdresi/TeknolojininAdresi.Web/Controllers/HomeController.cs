using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Web.Models;
using static TeknolojininAdresi.Dto.CategoriesDTO;
using static TeknolojininAdresi.Dto.ProductsDTO;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ICategoriesService _serviceCategories;
        private IProductsService _serviceProducts;
        private IMapper _mapper;

        public HomeController(ICategoriesService serviceCategories,
            IMapper mapper, IProductsService serviceProducts)
        {
            _serviceCategories = serviceCategories;
            _mapper = mapper;
            _serviceProducts = serviceProducts;
        }

        [HttpGet("categoryIndex")]
        public async Task< IActionResult> CategoryIndex()
        {
            List<CategoriesHomeDTO> dto = _mapper.Map<List<CategoriesHomeDTO>>(await _serviceCategories.GetCategoriesHome());
            
            return Ok(dto);
        }

        [HttpGet("productIndex")]
        public async Task<IActionResult> ProductIndex(int? categoryId)
        {
            List<ProductsHomeDTO> dto = _mapper.Map<List<ProductsHomeDTO>>(await
                _serviceProducts.GetProductsHome(categoryId));

            return Ok(dto);
        }

        [HttpGet("productTopSelling")]
        public async Task<IActionResult> ProductTopSelling(int? categoryId)
        {
            List<ProductsHomeDTO> dto = _mapper.Map<List<ProductsHomeDTO>>(await
                _serviceProducts.GetProductsHomeTopSelling(categoryId));

            return Ok(dto);
        }

        [HttpGet("categoriesListHome")]
        public async Task<IActionResult> CategoriesListHome()
        {
            List<CategoriesListHomeDTO> dto = _mapper.Map<List<CategoriesListHomeDTO>>(await
                _serviceCategories.GetCategoriesListHome());

            return Ok(dto);
        }
    }
}