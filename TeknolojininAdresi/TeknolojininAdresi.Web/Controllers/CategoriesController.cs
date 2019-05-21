using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using static TeknolojininAdresi.Dto.CategoriesDTO;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesService _serviceCat;
        private IMapper _mapper;

        public CategoriesController(ICategoriesService serviceCat, IMapper mapper)
        {
            _serviceCat = serviceCat;
            _mapper = mapper;
        }

        [HttpGet("categoriesListAdmin")]
        public async Task<IActionResult> GetCategoriesListAdmin()
        {
            List<CategoriesListAdminDTO> dto = _mapper.Map<List<CategoriesListAdminDTO>>(await _serviceCat.GetCategoriesListAdmin());

            return Ok(dto);
        }

        [HttpGet("categoriesList")]
        public async Task<IActionResult> GetCategoriesList()
        {
            List<CategoriesListDTO> dto = _mapper.Map<List<CategoriesListDTO>>(await _serviceCat.GetCategoriesList());

            return Ok(dto);
        }


        [HttpPost("addCategory")]
        public IActionResult AddCategory([FromBody] CategoriesListAdminDTO addCategoryDTO)
        {
            Categories category = _mapper.Map<Categories>(addCategoryDTO);
            _serviceCat.Add(category);
            return Ok(category);
        }

        [HttpPost("updateCategory")]
        public IActionResult UpdateCategory([FromBody] CategoriesListAdminDTO updateCategoryDTO)
        {
            Categories category = _mapper.Map<Categories>(updateCategoryDTO);
            _serviceCat.Update(category);
            return Ok(category);
        }

        [HttpDelete("deleteCategory")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var category = await _serviceCat.Find(categoryId);
            _serviceCat.Delete(category);

            return Ok("Silindi");
        }
    }
}