using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using static TeknolojininAdresi.Dto.CommentsDTO;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentsService _serviceCom;
        private IMapper _mapper;

        public CommentsController(ICommentsService serviceCom, IMapper mapper)
        {
            _serviceCom = serviceCom;
            _mapper = mapper;
        }

        [HttpGet("commentsByProId")]
        public async Task<IActionResult> GetCategoriesList(int productId)
        {
            List<CommentsProductsDTO> dto = _mapper.Map<List<CommentsProductsDTO>>(await _serviceCom.GetCommentsByProId(productId));

            return Ok(dto);
        }

        [HttpPost("addComment")]
        public IActionResult AddComment([FromBody] CommentsAddDTO commentDTO)
        {
            Comments comment = _mapper.Map<Comments>(commentDTO);
            _serviceCom.AddComment(comment);

            return Ok("Basarili");
        }
    }
}